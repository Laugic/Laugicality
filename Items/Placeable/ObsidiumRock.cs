using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class ObsidiumRock : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Grows Lava Gems over time");
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
            item.createTile = ModContent.TileType<ObsidiumRock>();
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(17);
            recipe.AddIngredient(173);
            recipe.AddIngredient(3);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        
    }
}