using Laugicality.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Magic
{
	public class Volcite : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Volcanic Eruption");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 35;
			item.magic = true;
			item.mana = 10;
			item.width = 28;
			item.height = 30;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Volcite");
			item.shootSpeed = 18f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, nameof(ObsidiumBar), 16);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}