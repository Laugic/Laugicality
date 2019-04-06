using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Magic
{
	public class BookOfKnowledge : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Book of Knowledge");
            Tooltip.SetDefault("'Rain Lightning upon them'");
			Item.staff[item.type] = true; 
		}

		public override void SetDefaults()
		{
			item.damage = 100;
			item.magic = true;
			item.mana = 3;
			item.width = 28;
			item.height = 30;
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item33;
            item.autoReuse = true;
			item.shoot = mod.ProjectileType("LightningBall");
			item.shootSpeed = 14f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SteamBar", 16);
            recipe.AddIngredient(null, "SoulOfThought", 8);
            recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}