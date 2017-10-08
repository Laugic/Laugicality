using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class CrystalineInfuser : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Combines Gems into Crystals");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = mod.TileType("CrystalineInfuser");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(null, "LaugicalWorkbench");
            recipe.AddIngredient(57, 20);
            recipe.AddIngredient(86, 8);
            recipe.AddIngredient(31, 8);
            recipe.AddIngredient(175, 4);
            recipe.SetResult(this);
            recipe.AddRecipe();


            ModRecipe Arecipe = new ModRecipe(mod);
            Arecipe.AddTile(null, "LaugicalWorkbench");
            Arecipe.AddIngredient(1257, 20);
            Arecipe.AddIngredient(1329, 8);
            Arecipe.AddIngredient(31, 8);
            Arecipe.AddIngredient(175, 4);
            Arecipe.SetResult(this);
            Arecipe.AddRecipe();
        }
    }
}