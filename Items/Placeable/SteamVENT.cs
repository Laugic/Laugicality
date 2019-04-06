using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class SteamVENT : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steam V.E.N.T.");
            Tooltip.SetDefault("It's a 'Velocity Expulsion Nexus Tunnel'\nBoosts you upwards at great speeds.\n'Yeet'");
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
            item.createTile = mod.TileType("SteamVENT");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddIngredient(null, "SteamBar", 4);
            recipe.AddIngredient(null, "Gear", 4);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}