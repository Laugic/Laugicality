using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class ObsidiumPlant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lycoris Radiata");
            Tooltip.SetDefault("'Plants of hell'");
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
            recipe.AddIngredient(null, "LavaGem");
            recipe.AddIngredient(null, "ObsidiumRock", 4);
            recipe.SetResult(null, "Lycoris", 4);
            recipe.AddRecipe();
        }
    }
}