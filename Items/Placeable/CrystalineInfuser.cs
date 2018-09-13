using Terraria.ID;
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
            ModRecipe Arecipe = new ModRecipe(mod);
            Arecipe.AddTile(null, "LaugicalWorkbench");
            Arecipe.AddIngredient(null, "ObsidiumBar", 8);
            Arecipe.AddIngredient(null, "DarkShard", 1);
            Arecipe.AddIngredient(null, "LavaGem", 4);
            Arecipe.SetResult(this);
            Arecipe.AddRecipe();
        }
    }
}