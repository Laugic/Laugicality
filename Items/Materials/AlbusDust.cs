using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
	public class AlbusDust : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'A whiff of the mystical'");
        }
        public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 99;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 1;
			item.useTime = 15;
			item.useStyle = 1;
		}
        
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Diamond, 1);
            recipe.AddIngredient(null, "ArcaneShard", 1);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this, 2);
            recipe.AddRecipe();

            

        }
	}
}