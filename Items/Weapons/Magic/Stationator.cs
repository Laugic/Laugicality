using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Magic
{
	public class Stationator : LaugicalityItem
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
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item34;
            item.autoReuse = true;
			item.shoot = mod.ProjectileType("TrainScythe");
			item.shootSpeed = 14f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, nameof(SteamBar), 16);
            recipe.AddIngredient(mod, nameof(SoulOfWrought), 8);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}