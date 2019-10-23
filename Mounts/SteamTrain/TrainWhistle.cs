using Laugicality.Items;
using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Mounts.SteamTrain
{
	public class TrainWhistle : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Calls a Train for you to ride! \n'Not so suspicious'");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 36;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = 30000;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
			item.mountType = ModContent.MountType<SteamTrainMount>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(mod, nameof(SteamBar), 16);
            recipe.AddIngredient(mod, nameof(Gear), 20);
            recipe.AddIngredient(mod, nameof(SoulOfWrought), 8);

            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);

			recipe.AddRecipe();
		}
	}
}