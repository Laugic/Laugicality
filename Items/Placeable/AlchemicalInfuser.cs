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
            Warrecipe.AddIngredient(ItemID.SoulofNight, 4);
            Warrecipe.AddIngredient(null, "SoulOfHaught", 4);
            Warrecipe.AddTile(134);
            Warrecipe.SetResult(ItemID.WarriorEmblem);
            Warrecipe.AddRecipe();

            ModRecipe Ranrecipe = new ModRecipe(mod);
            Ranrecipe.AddRecipeGroup("Emblems");
            Ranrecipe.AddIngredient(ItemID.SoulofLight, 4);
            Ranrecipe.AddIngredient(null, "SoulOfHaught", 4);
            Ranrecipe.AddTile(134);
            Ranrecipe.SetResult(ItemID.RangerEmblem);
            Ranrecipe.AddRecipe();

            ModRecipe Sorrecipe = new ModRecipe(mod);
            Sorrecipe.AddRecipeGroup("Emblems");
            Sorrecipe.AddIngredient(ItemID.SoulofNight, 4);
            Sorrecipe.AddIngredient(ItemID.SoulofLight, 4);
            Sorrecipe.AddTile(134);
            Sorrecipe.SetResult(ItemID.SorcererEmblem);
            Sorrecipe.AddRecipe();

            ModRecipe Sumrecipe = new ModRecipe(mod);
            Sumrecipe.AddRecipeGroup("Emblems");
            Sumrecipe.AddIngredient(ItemID.SoulofLight, 4);
            Sumrecipe.AddIngredient(null, "SoulOfSought", 4);
            Sumrecipe.AddTile(134);
            Sumrecipe.SetResult(ItemID.SummonerEmblem);
            Sumrecipe.AddRecipe();

            ModRecipe Ninrecipe = new ModRecipe(mod);
            Ninrecipe.AddRecipeGroup("Emblems");
            Ninrecipe.AddIngredient(ItemID.SoulofNight, 4);
            Ninrecipe.AddIngredient(null, "SoulOfSought", 4);
            Ninrecipe.AddTile(134);
            Ninrecipe.SetResult(null, "NinjaEmblem");
            Ninrecipe.AddRecipe();

            ModRecipe Mysrecipe = new ModRecipe(mod);
            Mysrecipe.AddRecipeGroup("Emblems");
            Mysrecipe.AddIngredient(null, "SoulOfHaught", 4);
            Mysrecipe.AddIngredient(null, "SoulOfSought", 4);
            Mysrecipe.AddTile(134);
            Mysrecipe.SetResult(null, "MysticEmblem");
            Mysrecipe.AddRecipe();

            ModRecipe Enchrecipe1 = new ModRecipe(mod);
            Enchrecipe1.AddIngredient(ItemID.SilverBroadsword);
            Enchrecipe1.AddIngredient(null, "ArcaneShard", 12);
            Enchrecipe1.AddIngredient(null, "AquosDust", 6);
            Enchrecipe1.AddIngredient(null, "RubrumDust", 4);
            Enchrecipe1.AddTile(mod.TileType("AlchemicalInfuser"));
            Enchrecipe1.SetResult(ItemID.EnchantedSword);
            Enchrecipe1.AddRecipe();

            ModRecipe Enchrecipe2 = new ModRecipe(mod);
            Enchrecipe2.AddIngredient(ItemID.TungstenBroadsword);
            Enchrecipe2.AddIngredient(null, "ArcaneShard", 12);
            Enchrecipe2.AddIngredient(null, "AquosDust", 6);
            Enchrecipe2.AddIngredient(null, "RubrumDust", 4);
            Enchrecipe2.AddTile(mod.TileType("AlchemicalInfuser"));
            Enchrecipe2.SetResult(ItemID.EnchantedSword);
            Enchrecipe2.AddRecipe();

            ModRecipe Starfuryrecipe = new ModRecipe(mod);
            Starfuryrecipe.AddRecipeGroup("GldBars", 12);
            Starfuryrecipe.AddIngredient(ItemID.SunplateBlock, 24);
            Starfuryrecipe.AddIngredient(null, "ArcaneShard", 8);
            Starfuryrecipe.AddIngredient(null, "RegisDust", 6);
            Starfuryrecipe.AddIngredient(null, "AuraDust", 4);
            Starfuryrecipe.AddTile(mod.TileType("AlchemicalInfuser"));
            Starfuryrecipe.SetResult(ItemID.Starfury);
            Starfuryrecipe.AddRecipe();

            ModRecipe golemcellrecipe = new ModRecipe(mod);
            golemcellrecipe.AddIngredient(2766, 4); //Solar Tablet Fragment
            golemcellrecipe.AddIngredient(ItemID.HallowedBar, 1);
            golemcellrecipe.AddTile(mod.TileType("AncientEnchanter"));
            golemcellrecipe.SetResult(ItemID.LihzahrdPowerCell);
            golemcellrecipe.AddRecipe();
        }
    }
}