using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class ZincBrick : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("A crucial component of Brass");
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
            item.createTile = ModContent.TileType<Tiles.ZincBrick>();
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(17); //Furnace
            recipe.AddIngredient(null, "ZincOre");
            recipe.AddIngredient(3); //Stone
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}