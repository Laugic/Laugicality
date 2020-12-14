using Laugicality.Tiles.Furniture;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable.Furniture
{
    public class ObsidiumDresser : LaugicalityItem
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
            item.value = Item.sellPrice(silver: 1);
            item.createTile = ModContent.TileType<ObsidiumDresserTile>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumRock>(), 20);
            recipe.AddIngredient(ModContent.ItemType<LavaGemItem>(), 2);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}