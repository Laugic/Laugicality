using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
    public class NullEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = 0;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(134);
            recipe.AddIngredient(null, "NullShard", 4);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        
    }
}