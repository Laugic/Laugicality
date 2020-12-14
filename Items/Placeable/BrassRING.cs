using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Terraria;
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
            item.value = Item.buyPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
            item.createTile = ModContent.TileType<Tiles.BrassRING>();
        }
    }
}