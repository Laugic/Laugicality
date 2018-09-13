using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
	public class CaerulumDust : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'A shadow\'s soul'");
        }
        public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 99;
			item.rare = 1;
			item.useAnimation = 1;
			item.useTime = 15;
			item.useStyle = 1;
		}
        
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sapphire, 1);
            recipe.AddIngredient(null, "ArcaneShard", 1);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
	}
}