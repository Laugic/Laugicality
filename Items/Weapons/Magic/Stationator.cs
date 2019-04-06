using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Magic
{
	public class Stationator : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Here they come'");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 150;
			item.magic = true;
			item.mana = 12;
			item.width = 28;
			item.height = 30;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item34;
            item.autoReuse = true;
			item.shoot = mod.ProjectileType("TrainScythe");
			item.shootSpeed = 14f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SteamBar", 16);
            recipe.AddIngredient(null, "SoulOfWrought", 8);
            recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}