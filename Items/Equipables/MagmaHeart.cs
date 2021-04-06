using Laugicality.Buffs;
using Laugicality.Projectiles.Pets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class MagmaHeart : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Heart");
            Tooltip.SetDefault("Summons a Magma Heart to shine light\nYou are immune to lava");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
            item.useStyle = 1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.noMelee = true;
            item.buffType = ModContent.BuffType<MagmaHeartBuff>();
            item.shoot = ModContent.ProjectileType<MagmaHeartProjectile>();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[BuffID.OnFire] = true;
            base.UpdateAccessory(player, hideVisual);
        }
        public override void UpdateEquip(Player player)
        {
            player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[BuffID.OnFire] = true;
            base.UpdateEquip(player);
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
                player.AddBuff(item.buffType, 60 * 60 * 60, true);
        }
    }
}