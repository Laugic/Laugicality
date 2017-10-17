using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
	public class MoltenMess : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons Ragnar\n\'Chilled Lava.\' \nGuard of the Caverns.");
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
            return player.ZoneRockLayerHeight;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 25);
            recipe.AddIngredient(207, 2);
            recipe.AddIngredient(null, "ChilledBar", 4);
            recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}