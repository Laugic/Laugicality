using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Magic
{
	public class SandstormInABook : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandstorm in a Book");
            Tooltip.SetDefault("Don't try to read it");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 24;
			item.magic = true;
			item.mana = 10;
			item.width = 28;
			item.height = 30;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Sandball");
			item.shootSpeed = 12f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Book, 1);
            recipe.AddIngredient(169, 16);
			recipe.AddIngredient(null, "AncientShard", 1);
            recipe.AddTile(101);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}