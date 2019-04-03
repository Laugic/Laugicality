using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
    public class MagmaSnapper : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Don't get your hand too close.'");
        }

        public override void SetDefaults()
        {
            item.width = 66;
            item.height = 58;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = 0;
            item.rare = 1;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(134);
            recipe.AddIngredient(null, "NullShard", 4);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
        
    }
}