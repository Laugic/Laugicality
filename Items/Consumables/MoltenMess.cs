using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables
{
	public class MoltenMess : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons Ragnar\n\'Chilled Lava.\' \nGuardian of the Obsidium.");
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
			item.shoot = mod.ProjectileType("RagnarSpawn");
		}

        public override bool CanUseItem(Player player)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            return modPlayer.ZoneObsidium;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ObsidiumBar", 5);
            recipe.AddIngredient(173, 8);
            recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}