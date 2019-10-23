using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Magic
{
	public class Electrospark : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Zap them to dust'");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 55;
			item.magic = true;
			item.mana = 5;
			item.width = 28;
			item.height = 30;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item33;
            item.autoReuse = true;
			item.shoot = ModContent.ProjectileType("Electrospark");
			item.shootSpeed = 14f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, nameof(SteamBar), 16);
            recipe.AddIngredient(null, "SoulOfFraught", 8);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}