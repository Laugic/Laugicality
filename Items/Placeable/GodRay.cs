namespace Laugicality.Items.Placeable
{
    public class GodRay : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Solid divinity'");
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
            item.createTile = mod.TileType("GodRay");
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(17);
            recipe.AddIngredient(null, "ObsidiumRock", 2);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/

    }
}