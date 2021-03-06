using Laugicality.Items.Loot;
using Laugicality.Projectiles.Ranged;
using Terraria.ID;
using Terraria.ModLoader;

using Terraria;

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
            item.value = Item.sellPrice(copper: 16);
            item.rare = ItemRarityID.LightPurple;
			item.shoot = ModContent.ProjectileType<BrassArrowProjectile>();
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
