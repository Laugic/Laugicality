using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
	public class ChilledBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Very Cold");
        }
        public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.maxStack = 99;
			item.rare = 1;
			item.useAnimation = 1;
			item.useTime = 15;
			item.useStyle = 1;
		}
        
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SnowBlock, 5);
            recipe.AddIngredient(ItemID.IceBlock, 5);
            recipe.AddIngredient(ItemID.DemoniteBar, 1);
            recipe.AddTile(16);
			recipe.SetResult(this);
            recipe.AddRecipe();


            ModRecipe arecipe = new ModRecipe(mod);
            arecipe.AddIngredient(ItemID.SnowBlock, 5);
            arecipe.AddIngredient(ItemID.IceBlock, 5);
            arecipe.AddIngredient(ItemID.CrimtaneBar, 1);
            arecipe.AddTile(16);
            arecipe.SetResult(this);
            arecipe.AddRecipe();

        }
	}
}