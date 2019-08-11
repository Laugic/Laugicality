using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
    public class Shadowflame : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Acursed Heat");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.maxStack = 99;
            item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 4);
            recipe.AddIngredient(ItemID.MagicDagger);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.ShadowFlameKnife);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 4);
            recipe.AddIngredient(ItemID.HellwingBow);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.ShadowFlameBow);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 4);
            recipe.AddIngredient(ItemID.BookofSkulls);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.ShadowFlameHexDoll);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 1);
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(ItemID.ShadowflameHadesDye);
            recipe.AddRecipe();
        }
    }
}