using Laugicality.Items.Materials;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class ObsidiumChest : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("Transmutes items of equal value");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = Item.sellPrice(silver: 1);
            item.createTile = ModContent.TileType<Tiles.ObsidiumChest>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(ObsidiumBar), 8);
            recipe.AddIngredient(22, 2);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}