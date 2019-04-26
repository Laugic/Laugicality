using Laugicality.Items.Loot;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Ammo
{
	public class BrassArrow : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Redirects itself on collision.");
		}

		public override void SetDefaults()
		{
			item.damage = 16;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 4f;
			item.value = 10;
			item.rare = ItemRarityID.LightPurple;
			item.shoot = mod.ProjectileType("BrassArrow");
			item.shootSpeed = 14f;
			item.ammo = AmmoID.Arrow;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(SteamBar), 1);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 33);
			recipe.AddRecipe();
		}
	}
}
