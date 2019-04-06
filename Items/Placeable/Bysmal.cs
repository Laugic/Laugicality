using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class Bysmal : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Painful to even touch'");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = mod.TileType("BysmalOre");
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AntitherialBlock");
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe Erecipe = new ModRecipe(mod);
            Erecipe.AddIngredient(null, "EtherialEssence");
            Erecipe.SetResult(this, 20);
            Erecipe.AddRecipe();
        }*/
    }
}