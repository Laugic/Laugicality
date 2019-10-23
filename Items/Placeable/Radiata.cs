using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class Radiata : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Roots of hell'");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = ModContent.TileType("Radiata");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(13); //Bottle
            recipe.AddIngredient(null, "Lycoris", 2);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
            
    }
}