using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class CrystalineInfuser : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystalline Infuser");
            Tooltip.SetDefault("Combines Gems into Crystals");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = mod.TileType("CrystalineInfuser");
        }

        public override void AddRecipes()
        {
            ModRecipe arecipe = new ModRecipe(mod);
            arecipe.AddTile(null, "LaugicalWorkbench");
            arecipe.AddIngredient(null, "ObsidiumBar", 8);
            arecipe.AddIngredient(null, "DarkShard", 1);
            arecipe.AddIngredient(null, "LavaGem", 4);
            arecipe.SetResult(this);
            arecipe.AddRecipe();
        }
    }
}