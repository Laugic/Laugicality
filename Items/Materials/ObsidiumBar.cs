using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Laugicality.Items.Placeable;

namespace Laugicality.Items.Materials
{
    public class ObsidiumBar : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = Item.sellPrice(silver: 36);
            item.rare = ItemRarityID.Green;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumOre>(), 3);
            recipe.AddIngredient(ModContent.ItemType<LavaGemItem>(), 1);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Hellforge);
            recipe.AddRecipe();
        }
        
    }
}