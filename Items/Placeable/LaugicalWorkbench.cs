using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class LaugicalWorkbench : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("For crafting things to craft things. \n'It's completely logical!'");
        }

        public override void SetDefaults()
        {
            item.width = 27;
            item.height = 15;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = ModContent.TileType("LaugicalWorkbench");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(16);
            recipe.AddIngredient(9, 20);
            recipe.AddIngredient(2340, 40);
            recipe.AddIngredient(363);
            recipe.AddIngredient(2343);
            recipe.AddIngredient(997);
            recipe.SetResult(this);
            recipe.AddRecipe();


            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddTile(114);
            recipe1.AddIngredient(3202);
            recipe1.AddIngredient(583);
            recipe1.SetResult(3119);
            recipe1.AddRecipe();
        }
    }
}