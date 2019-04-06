using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Tools
{
	public class FrostburnPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'The best of both worlds'");
		}

		public override void SetDefaults()
		{
			item.damage = 40;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 20;
			item.pick = 160;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FrigidPickaxe", 1);
            recipe.AddIngredient(null, "ObsidiumPickaxe", 1);
            recipe.AddIngredient(null, "MagmaticCrystal", 1);
            recipe.AddIngredient(null, "SoulOfSought", 4);
            recipe.AddIngredient(null, "SoulOfHaught", 4);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}