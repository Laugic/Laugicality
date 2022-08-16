using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class AlchemicalInfuserItem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Alchemical Infuser");
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
            item.value = Item.buyPrice(silver: 50) * 5;
            item.createTile = ModContent.TileType<Tiles.AlchemicalInfuser>();
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

            ModRecipe warrecipe = new ModRecipe(mod);
            warrecipe.AddRecipeGroup("Emblems");
            warrecipe.AddIngredient(ItemID.SoulofNight, 4);
            warrecipe.AddIngredient(mod, nameof(SoulOfHaught), 4);
            warrecipe.AddTile(TileID.MythrilAnvil);
            warrecipe.SetResult(ItemID.WarriorEmblem);
            warrecipe.AddRecipe();

            ModRecipe ranrecipe = new ModRecipe(mod);
            ranrecipe.AddRecipeGroup("Emblems");
            ranrecipe.AddIngredient(ItemID.SoulofLight, 4);
            ranrecipe.AddIngredient(mod, nameof(SoulOfHaught), 4);
            ranrecipe.AddTile(TileID.MythrilAnvil);
            ranrecipe.SetResult(ItemID.RangerEmblem);
            ranrecipe.AddRecipe();

            ModRecipe sorrecipe = new ModRecipe(mod);
            sorrecipe.AddRecipeGroup("Emblems");
            sorrecipe.AddIngredient(ItemID.SoulofNight, 4);
            sorrecipe.AddIngredient(ItemID.SoulofLight, 4);
            sorrecipe.AddTile(TileID.MythrilAnvil);
            sorrecipe.SetResult(ItemID.SorcererEmblem);
            sorrecipe.AddRecipe();

            ModRecipe sumrecipe = new ModRecipe(mod);
            sumrecipe.AddRecipeGroup("Emblems");
            sumrecipe.AddIngredient(ItemID.SoulofLight, 4);
            sumrecipe.AddIngredient(mod, nameof(SoulOfSought), 4);
            sumrecipe.AddTile(TileID.MythrilAnvil);
            sumrecipe.SetResult(ItemID.SummonerEmblem);
            sumrecipe.AddRecipe();

            ModRecipe ninrecipe = new ModRecipe(mod);
            ninrecipe.AddRecipeGroup("Emblems");
            ninrecipe.AddIngredient(ItemID.SoulofNight, 4);
            ninrecipe.AddIngredient(mod, nameof(SoulOfSought), 4);
            ninrecipe.AddTile(TileID.MythrilAnvil);
            ninrecipe.SetResult(null, "NinjaEmblem");
            ninrecipe.AddRecipe();

            ModRecipe mysrecipe = new ModRecipe(mod);
            mysrecipe.AddRecipeGroup("Emblems");
            mysrecipe.AddIngredient(mod, nameof(SoulOfHaught), 4);
            mysrecipe.AddIngredient(mod, nameof(SoulOfSought), 4);
            mysrecipe.AddTile(TileID.MythrilAnvil);
            mysrecipe.SetResult(null, "MysticEmblem");
            mysrecipe.AddRecipe();

            ModRecipe enchrecipe1 = new ModRecipe(mod);
            enchrecipe1.AddIngredient(ItemID.SilverBroadsword);
            enchrecipe1.AddIngredient(null, "ArcaneShard", 4);
            enchrecipe1.AddIngredient(ItemID.Sapphire, 2);
            enchrecipe1.AddIngredient(ItemID.Ruby, 2);
            enchrecipe1.AddTile(ModContent.TileType<Tiles.AlchemicalInfuser>());
            enchrecipe1.SetResult(ItemID.EnchantedSword);
            enchrecipe1.AddRecipe();

            ModRecipe enchrecipe2 = new ModRecipe(mod);
            enchrecipe2.AddIngredient(ItemID.TungstenBroadsword);
            enchrecipe2.AddIngredient(null, "ArcaneShard", 4);
            enchrecipe2.AddIngredient(ItemID.Sapphire, 2);
            enchrecipe2.AddIngredient(ItemID.Ruby, 2);
            enchrecipe2.AddTile(ModContent.TileType<Tiles.AlchemicalInfuser>());
            enchrecipe2.SetResult(ItemID.EnchantedSword);
            enchrecipe2.AddRecipe();

            ModRecipe starfuryrecipe = new ModRecipe(mod);
            starfuryrecipe.AddRecipeGroup(Laugicality.GOLD_BARS_GROUP, 12);
            starfuryrecipe.AddIngredient(ItemID.SunplateBlock, 24);
            starfuryrecipe.AddIngredient(null, "ArcaneShard", 4);
            starfuryrecipe.AddIngredient(ItemID.Amethyst, 2);
            starfuryrecipe.AddIngredient(ItemID.Topaz, 2);
            starfuryrecipe.AddTile(ModContent.TileType<Tiles.AlchemicalInfuser>());
            starfuryrecipe.SetResult(ItemID.Starfury);
            starfuryrecipe.AddRecipe();

            ModRecipe golemcellrecipe = new ModRecipe(mod);
            golemcellrecipe.AddIngredient(2766, 4); //Solar Tablet Fragment
            golemcellrecipe.AddIngredient(ItemID.HallowedBar, 1);
            golemcellrecipe.AddTile(ModContent.TileType<Tiles.AncientEnchanter>());
            golemcellrecipe.SetResult(ItemID.LihzahrdPowerCell);
            golemcellrecipe.AddRecipe();
        }
    }
}