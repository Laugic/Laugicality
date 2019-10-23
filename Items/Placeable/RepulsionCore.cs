using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class RepulsionCore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Bounce like you've never bounced before'");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = ModContent.TileType("RepulsionCore");
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.AddIngredient(ItemID.Gel, 2);
            recipe.AddIngredient(null, "ArcaneShard");
            recipe.AddIngredient(null, "VerdiDust");
            recipe.SetResult(this, 4);
            recipe.AddRecipe();
        }*/
    }
}