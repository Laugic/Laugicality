using Laugicality.Tiles.Furniture;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable.Furniture
{
    public class LavaGemCandle : LaugicalityItem
    {
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = ModContent.TileType<LavaGemCandleTile>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumRock>(), 4);
            recipe.AddIngredient(ModContent.ItemType<LavaGem>(), 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}