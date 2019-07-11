using Laugicality.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class ObsidiumPlant : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brimlin");
            Tooltip.SetDefault("'Plants of hell'\nGrows on Lycoris");
        }

        public override void SetDefaults()
        {
            item.width = 62;
            item.height = 62;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = mod.TileType("ObsidiumPlantBulbs");
            item.rare = ItemRarityID.Blue;
        }

        public override void UpdateInventory(Player player)
        {
            if (item.stack % 4 == 0)
                item.createTile = mod.TileType("ObsidiumPlantBulbs");
            if (item.stack % 4 == 1)
                item.createTile = mod.TileType("ObsidiumPlantHeart");
            if (item.stack % 4 == 2)
                item.createTile = mod.TileType("ObsidiumPlantLeaves");
            if (item.stack % 4 == 3)
                item.createTile = mod.TileType("ObsidiumPlantMine");
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Hellforge);
            recipe.AddIngredient(this);
            recipe.AddIngredient(mod.ItemType<LavaGem>(), 4);
            recipe.AddIngredient(mod.ItemType<ObsidiumOre>(), 8);
            recipe.AddIngredient(mod.ItemType<RubrumDust>(), 4);
            recipe.SetResult(ItemID.LifeCrystal);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Hellforge);
            recipe.AddIngredient(this);
            recipe.AddIngredient(mod.ItemType<LavaGem>(), 4);
            recipe.AddIngredient(ItemID.Hellstone, 8);
            recipe.AddIngredient(mod.ItemType<RubrumDust>(), 4);
            recipe.SetResult(ItemID.LifeCrystal);
            recipe.AddRecipe();
        }
    }
}