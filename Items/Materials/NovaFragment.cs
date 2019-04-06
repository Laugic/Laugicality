using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
	public class NovaFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Cosmic entropy bursts from this fragment'");
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public override void SetDefaults()
		{
			item.width = 20;
            item.height = 20;
			item.maxStack = 99;
			item.rare = 9;
			item.useAnimation = 1;
			item.useTime = 15;
			item.useStyle = 1;
		}
        
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3458, 1); //Solar Fragment
            recipe.AddIngredient(3456, 1); //Vortex Fragment
            recipe.AddTile(412);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
	}
}