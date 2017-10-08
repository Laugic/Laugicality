using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
	public class MechanicalMonitor : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons The Annihilator");
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
			item.shoot = mod.ProjectileType("TheAnnihilatorSpawn");
		}

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1225, 5);
            recipe.AddIngredient(ItemID.Lens, 3);
			recipe.AddIngredient(ItemID.Vertebrae, 3);
            recipe.AddIngredient(null, "SoulOfHaught", 3);
            recipe.AddIngredient(null, "SoulOfSought", 3);
            recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
            
            ModRecipe Arecipe = new ModRecipe(mod);
            Arecipe.AddIngredient(1225, 5);
            Arecipe.AddIngredient(ItemID.Lens, 3);
            Arecipe.AddIngredient(ItemID.RottenChunk, 3);
            Arecipe.AddIngredient(null, "SoulOfHaught", 3);
            Arecipe.AddIngredient(null, "SoulOfSought", 3);
            Arecipe.AddTile(134);
            Arecipe.SetResult(this);
            Arecipe.AddRecipe();
        }
	}
}