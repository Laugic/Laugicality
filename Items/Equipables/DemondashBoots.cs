using Laugicality.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class DemondashBoots : LaugicalityItem
    {
        int dashDelay = 0;
        int dashCooldown = 0;
        int trail = 0;
        int dashDir = 0;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Allows the wearer to dash\nReduced cooldown between dashes\nIncreased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
            item.defense = 2;
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += .15f;
            int dashCooldownMax = 60;
            int trailLength = 45;

            float dashSpeed = 12;

            if (!player.mount.Active && player.grappling[0] == -1 && dashCooldown <= 0)
            {
                if (player.controlRight && player.releaseRight)
                {
                    if (dashDelay > 0 && dashDir == 1)
                    {
                        dashCooldown = dashCooldownMax;
                        trail = trailLength;
                        player.velocity.X = dashSpeed;
                        player.GetModPlayer<LaugicalityPlayer>().DustBurst(ModContent.DustType<Black>(), 20);
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
                        trail = trailLength;
                        player.velocity.X = -dashSpeed;
                        player.GetModPlayer<LaugicalityPlayer>().DustBurst(ModContent.DustType<Black>(), 20);
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
            if(trail > 0)
            {
                trail--;
                player.GetModPlayer<LaugicalityPlayer>().DustTrail(ModContent.DustType<Black>(), 2);
            }
        }
    }
}