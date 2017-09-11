using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
	public class TrainWhistle : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Calls a Train for you to ride!");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 36;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = 30000;
			item.rare = 4;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
			item.mountType = mod.MountType("SteamTrain");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SteamBar", 16);
            recipe.AddIngredient(ItemID.Cog, 40);
            recipe.AddIngredient(null, "SoulOfWrought", 8);
            recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}