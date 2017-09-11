using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
	public class SuspiciousTrainWhistle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons the Steam Train");
        }
        public override void SetDefaults()
		{
			item.width = 48;
			item.height = 40;
			item.maxStack = 20;
			item.rare = 5;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
			item.shoot = mod.ProjectileType("SteamTrainSpawn");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1225, 5);
            recipe.AddIngredient(null, "SteamBar", 5);
            recipe.AddIngredient(ItemID.Cog, 40);
            recipe.AddIngredient(null, "SoulOfSought", 6);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}