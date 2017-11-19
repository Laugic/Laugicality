using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Ammo
{
	public class BrassArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Inflicts 'Steamy'");
		}

		public override void SetDefaults()
		{
			item.damage = 16;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 4f;
			item.value = 10;
			item.rare = 6;
			item.shoot = mod.ProjectileType("BrassArrow");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 14f;                  //The speed of the projectile
			item.ammo = 40;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 25);
			recipe.AddIngredient(ItemID.Cog, 1);
			recipe.AddTile(134);
			recipe.SetResult(this, 25);
			recipe.AddRecipe();
		}
	}
}
