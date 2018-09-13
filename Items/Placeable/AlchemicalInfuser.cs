using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class AlchemicalInfuser : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Infuses Potions into Gems");
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
            item.consumable = true;
            item.value = 150;
            item.createTile = mod.TileType("AlchemicalInfuser");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(null, "LaugicalWorkbench");
            recipe.AddIngredient(9, 20);
            recipe.AddIngredient(170, 8);
            recipe.AddIngredient(31, 8);
            recipe.AddIngredient(8, 4);
            recipe.SetResult(this);
            recipe.AddRecipe();

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