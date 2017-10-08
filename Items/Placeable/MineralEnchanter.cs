using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class MineralEnchanter : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Combines Crystals into Stones");
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
            item.createTile = mod.TileType("MineralEnchanter");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(null, "LaugicalWorkbench");
            recipe.AddIngredient(1198, 20);
            recipe.AddIngredient(520, 8);
            recipe.AddIngredient(521, 8);
            recipe.AddIngredient(null, "SoulOfHaught", 4);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}