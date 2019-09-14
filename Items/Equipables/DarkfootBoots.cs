using Laugicality.Dusts;
using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Equipables
{
    public class DarkfootBoots : LaugicalityItem
    {
        int dashDelay = 0;
        int dashCooldown = 0;
        int dashDir = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ebonfoot Boots");
            Tooltip.SetDefault("Allows the wearer to dash");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = 100;
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            int dashCooldownMax = 90;
            float dashSpeed = 11;

            if (!player.mount.Active && player.grappling[0] == -1 && dashCooldown <= 0)
            {
                if (player.controlRight && player.releaseRight)
                {
                    if (dashDelay > 0 && dashDir == 1)
                    {
                        dashCooldown = dashCooldownMax;
                        player.velocity.X = dashSpeed;
                        player.GetModPlayer<LaugicalityPlayer>().DustBurst(mod.DustType<Black>(), 20);
                    }
                    else
                    {
                        dashDelay = 15;
                        dashDir = 1;
                    }
                }
                if (player.controlLeft && player.releaseLeft)
                {
                    if (dashDelay > 0 && dashDir == 2)
                    {
                        dashCooldown = dashCooldownMax;
                        player.velocity.X = -dashSpeed;
                        player.GetModPlayer<LaugicalityPlayer>().DustBurst(mod.DustType<Black>(), 20);
                    }
                    else
                    {
                        dashDelay = 15;
                        dashDir = 2;
                    }
                }
            }
            if (dashDelay > 0)
                dashDelay--;
            if (dashCooldown > 0)
                dashCooldown--;
        }
    }
}