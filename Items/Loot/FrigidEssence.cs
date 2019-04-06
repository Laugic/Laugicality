using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class FrigidEssence : ModItem
    {

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = 0;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(77);
            recipe.AddIngredient(null, "ObsidiumOre", 3);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
        
    }
}