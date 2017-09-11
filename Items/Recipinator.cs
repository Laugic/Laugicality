using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items
{
    public class Recipinator : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("How did you get this? You haxxor.");
        }

        public override void SetDefaults()
        {
            item.width = 54;
            item.height = 27;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = 150;
        }
        
        public override void AddRecipes()
        {
            /*
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(null, "LaugicalWorkbench");
            recipe.AddIngredient(9, 10);
            recipe.SetResult(3549);
            recipe.AddRecipe();*/

            ModRecipe Titrecipe = new ModRecipe(mod);
            Titrecipe.AddTile(null, "CrystalineInfuser");
            Titrecipe.AddIngredient(391);
            Titrecipe.SetResult(1198);
            Titrecipe.AddRecipe();

            ModRecipe Adrecipe = new ModRecipe(mod);
            Adrecipe.AddTile(null, "CrystalineInfuser");
            Adrecipe.AddIngredient(1198);
            Adrecipe.SetResult(391);
            Adrecipe.AddRecipe();

            ModRecipe Warrecipe = new ModRecipe(mod);
            Warrecipe.AddRecipeGroup("Emblems");
            Warrecipe.AddIngredient(ItemID.SoulofFright, 5);
            Warrecipe.AddTile(134);
            Warrecipe.SetResult(ItemID.WarriorEmblem);
            Warrecipe.AddRecipe();

            ModRecipe Ranrecipe = new ModRecipe(mod);
            Ranrecipe.AddRecipeGroup("Emblems");
            Ranrecipe.AddIngredient(ItemID.SoulofMight, 5);
            Ranrecipe.AddTile(134);
            Ranrecipe.SetResult(ItemID.RangerEmblem);
            Ranrecipe.AddRecipe();

            ModRecipe Sorrecipe = new ModRecipe(mod);
            Sorrecipe.AddRecipeGroup("Emblems");
            Sorrecipe.AddIngredient(ItemID.SoulofSight, 5);
            Sorrecipe.AddTile(134);
            Sorrecipe.SetResult(ItemID.SorcererEmblem);
            Sorrecipe.AddRecipe();

            ModRecipe Sumrecipe = new ModRecipe(mod);
            Sumrecipe.AddRecipeGroup("Emblems");
            Sumrecipe.AddIngredient(null, "SoulOfThought", 5);
            Sumrecipe.AddTile(134);
            Sumrecipe.SetResult(ItemID.SummonerEmblem);
            Sumrecipe.AddRecipe();

            ModRecipe Ninrecipe = new ModRecipe(mod);
            Ninrecipe.AddRecipeGroup("Emblems");
            Ninrecipe.AddIngredient(null, "SoulOfFraught", 5);
            Ninrecipe.AddTile(134);
            Ninrecipe.SetResult(null, "NinjaEmblem");
            Ninrecipe.AddRecipe();

            ModRecipe Mysrecipe = new ModRecipe(mod);
            Mysrecipe.AddRecipeGroup("Emblems");
            Mysrecipe.AddIngredient(null, "SoulOfWrought", 5);
            Mysrecipe.AddTile(134);
            Mysrecipe.SetResult(null, "MysticEmblem");
            Mysrecipe.AddRecipe();
        }
        
    }
}