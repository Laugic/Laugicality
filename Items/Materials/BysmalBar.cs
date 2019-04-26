using Laugicality.Items.Loot;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
	public class BysmalBar : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Tangibly intangible'");
        }
        public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 1;
			item.useTime = 15;
			item.useStyle = 1;
		}
        
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Bysmal", 3);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 1);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();

            

        }
	}
}