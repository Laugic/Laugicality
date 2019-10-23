using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class BrassFAN : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brass F.A.N.");
            Tooltip.SetDefault("It's a 'Fast Acceleration Node'\nBoosts you horizontally");
        }

        public override void SetDefaults()
        {
            item.width = 54;
            item.height = 54;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = ModContent.TileType("BrassFAN");
        }

        public override void UpdateInventory(Player player)
        {
            if (player.direction == 1)
                item.createTile = ModContent.TileType("BrassFANRight");
            else
                item.createTile = ModContent.TileType("BrassFAN");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddIngredient(mod, nameof(SteamBar), 4);
            recipe.AddIngredient(mod, nameof(Gear), 4);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}