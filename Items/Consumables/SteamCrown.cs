using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables
{
	public class SteamCrown : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons Slybertron");
        }
        public override void SetDefaults()
		{
			item.width = 24;
			item.height = 22;
			item.maxStack = 20;
			item.rare = 5;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
			item.shoot = mod.ProjectileType("SlybertronSpawn");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1225, 5);
            recipe.AddIngredient(ItemID.Cog, 40);
			recipe.AddIngredient(ItemID.Gel, 40);
			recipe.AddIngredient(null, "SoulOfHaught", 6);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}