using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables
{
	public class AncientAwakener : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons Dioritus\n\'The rulers of the caverns are fearsome foes\'");
        }
        public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 20;
			item.rare = 1;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
			item.shoot = mod.ProjectileType("DioritusSpawn");
		}

        public override bool CanUseItem(Player player)
        {
            return player.ZoneRockLayerHeight;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3081, 40);
            recipe.AddIngredient(327, 1);
            recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();

            ModRecipe Grecipe = new ModRecipe(mod);
            Grecipe.AddRecipeGroup("GldBars", 4);
            Grecipe.AddIngredient(154, 1);
            Grecipe.AddTile(77);
            Grecipe.SetResult(327);
            Grecipe.AddRecipe();
        }
	}
}