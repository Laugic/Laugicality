using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
	public class GalacticFragment : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'The secrets of the universe swirl around this fragment'");
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public override void SetDefaults()
		{
			item.width = 20;
            item.height = 20;
			item.maxStack = 99;
			item.rare = ItemRarityID.Cyan;
			item.useAnimation = 1;
			item.useTime = 15;
			item.useStyle = 1;
		}
        
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3457, 1); //Nebula Fragment
            recipe.AddIngredient(3459, 1); //Stardust Fragment
            recipe.AddTile(412);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
	}
}