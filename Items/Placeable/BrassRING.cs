using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class BrassRING : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brass R.I.N.G.");
            Tooltip.SetDefault("It's a 'Rotation Inertia Negator of Gravity'\nBoosts you upwards."+
                "\nFlying through the R.I.N.G's is not advised, as your wings will override the boost.");
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
            item.createTile = ModContent.TileType<Tiles.BrassRING>();
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