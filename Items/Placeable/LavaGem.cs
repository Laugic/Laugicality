using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class LavaGem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Grows on Obsidium Rock\n'Molten Candy'");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = mod.TileType("LavaGem");
            item.bait = 20;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(null, "LaugicalWorkbench");
            recipe.AddIngredient(9, 20);
            recipe.AddIngredient(170, 8);
            recipe.AddIngredient(31, 8);
            recipe.AddIngredient(8, 4);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        */
    }
}