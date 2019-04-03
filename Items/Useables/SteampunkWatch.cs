using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Useables
{
    public class SteampunkWatch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steampunk Watch");
            Tooltip.SetDefault("You tell the time.");
        }

        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 42;
            item.value = 100;
            item.rare = 5;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
        }
        
        
        public override bool UseItem(Player player)
        {
            Main.dayTime = !Main.dayTime;
            Main.time = 0.0;
            return true;
        }


        public override void AddRecipes()
        {
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null, "SteamBar", 8);
                recipe.AddIngredient(null, "Gear", 20);
                recipe.AddIngredient(null, "AndesiaCore", 1);
                recipe.AddIngredient(null, "DioritusCore", 1);
                recipe.AddIngredient(null, "CogOfKnowledge", 1);
                recipe.AddIngredient(null, "SteamTank", 1);
                recipe.AddIngredient(null, "Pipeworks", 1);
                recipe.AddTile(134);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}