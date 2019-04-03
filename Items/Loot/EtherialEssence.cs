using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class EtherialEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("From the world beyond.");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = 0;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddIngredient(null, "EtherialEssence", 10);
            recipe.SetResult(ItemID.TruffleWorm);
            recipe.AddRecipe();
        }
        
    }
}