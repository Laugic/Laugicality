using Laugicality.Items.Materials;
using Laugicality.Tiles;
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
            item.createTile = ModContent.TileType<ObsidiumPlantBulbs>();
            item.rare = ItemRarityID.Blue;
        }

        public override void UpdateInventory(Player player)
        {
            if (item.stack % 4 == 0)
                item.createTile = ModContent.TileType<ObsidiumPlantBulbs>();
            if (item.stack % 4 == 1)
                item.createTile = ModContent.TileType<ObsidiumPlantHeart>();
            if (item.stack % 4 == 2)
                item.createTile = ModContent.TileType<ObsidiumPlantLeaves>();
            if (item.stack % 4 == 3)
                item.createTile = ModContent.TileType<ObsidiumPlantMine>();
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Hellforge);
            recipe.AddIngredient(this);
            recipe.AddIngredient(ModContent.ItemType<LavaGemItem>(), 4);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumOre>(), 8);
            recipe.AddIngredient(ItemID.Ruby, 2);
            recipe.SetResult(ItemID.LifeCrystal);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Hellforge);
            recipe.AddIngredient(this);
            recipe.AddIngredient(ModContent.ItemType<LavaGemItem>(), 4);
            recipe.AddIngredient(ItemID.Hellstone, 8);
            recipe.AddIngredient(ItemID.Ruby, 2);
            recipe.SetResult(ItemID.LifeCrystal);
            recipe.AddRecipe();
        }
    }
}