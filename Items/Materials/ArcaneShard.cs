using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
	public class ArcaneShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Used as a catalyst in many transmutations\n'A sliver of Magic'");
        }
        public override void SetDefaults()
		{
			item.width = 14;
			item.height = 22;
			item.maxStack = 99;
			item.rare = 1;
			item.useAnimation = 1;
			item.useTime = 15;
			item.useStyle = 1;
		}
        
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ManaCrystal, 1);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
            
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.Cloud, 5);
            recipe2.AddIngredient(null, "ArcaneShard");
            recipe2.AddTile(null, "AlchemicalInfuser");
            recipe2.SetResult(ItemID.FallenStar);
            recipe2.AddRecipe();
        }
	}
}