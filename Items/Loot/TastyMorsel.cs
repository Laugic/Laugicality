using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
	public class TastyMorsel : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons Dune Sharkron in the daylight \n\'Mmm... Looks delicious.\'");
        }
        public override void SetDefaults()
		{
			item.width = 16;
			item.height = 20;
			item.maxStack = 20;
			item.rare = 1;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
			item.shoot = mod.ProjectileType("DuneSharkronSpawn");
		}

        public override bool CanUseItem(Player player)
        {
            return Main.dayTime;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Lens, 2);
			recipe.AddIngredient(ItemID.Vertebrae, 3);
            recipe.AddIngredient(ItemID.SharkFin, 2);
            recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();


            ModRecipe Arecipe = new ModRecipe(mod);
            Arecipe.AddIngredient(ItemID.Lens, 2);
            Arecipe.AddIngredient(ItemID.RottenChunk, 3);
            Arecipe.AddIngredient(ItemID.SharkFin, 2);
            Arecipe.AddTile(26);
            Arecipe.SetResult(this);
            Arecipe.AddRecipe();
        }
	}
}