using Laugicality.Items.Loot;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class EtherialBlock : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = mod.TileType("EtherialTile");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AntitherialBlock");
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe erecipe = new ModRecipe(mod);
            erecipe.AddIngredient(mod, nameof(EtherialEssence));
            erecipe.SetResult(this, 20);
            erecipe.AddRecipe();
        }
    }
}