using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class MineralEnchanter : LaugicalityItem
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
            item.createTile = ModContent.TileType<Tiles.MineralEnchanterTile>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(null, "LaugicalWorkbench");
            recipe.AddIngredient(1198, 12);
            recipe.AddIngredient(520, 8);
            recipe.AddIngredient(531, 1); //Spell Tome
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}