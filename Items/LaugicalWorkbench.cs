using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items
{
    public class LaugicalWorkbench : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("For crafting things to craft things.");
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
            item.createTile = mod.TileType("LaugicalWorkbench");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(16);
            recipe.AddIngredient(9, 20);
            recipe.AddIngredient(2340, 40);
            recipe.AddIngredient(363);
            recipe.AddIngredient(997);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}