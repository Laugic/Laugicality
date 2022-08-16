using Laugicality.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables.Potions
{
    public class GreaterMysticaPotion : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Greater Potentia Potion");
            Tooltip.SetDefault("Restores all Potentias to full capacity\nDoes not remove Overflow\nOverflow is increased by 10% while the Mysticality debuff is active");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 30;
            item.rare = ItemRarityID.Orange;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 2;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            item.value = Item.sellPrice(silver: 10);
        }

        public override bool CanUseItem(Player player)
        {
            return player.GetModPlayer<LaugicalityPlayer>().Mysticality == 0;
        }

        public override bool UseItem(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>();
            if (modPlayer.Lux < modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost)
                modPlayer.Lux = modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost;
            if (modPlayer.Vis < modPlayer.VisMax + modPlayer.VisMaxPermaBoost)
                modPlayer.Vis = modPlayer.VisMax + modPlayer.VisMaxPermaBoost;
            if (modPlayer.Mundus < modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost)
                modPlayer.Mundus = modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost;
            player.AddBuff(ModContent.BuffType<Mysticality2>(), 60 * 60, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MysticaPotion", 2);
            recipe.AddIngredient(null, "MagmaSnapper", 1);
            recipe.AddIngredient(null, "Crystilla", 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, 3);
            recipe.AddRecipe();
        }
    }
}