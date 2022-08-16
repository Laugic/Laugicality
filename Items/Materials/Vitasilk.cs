using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
    public class Vitasilk : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Cloth of life'");
        }
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 99;
            item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
        }
    }
}