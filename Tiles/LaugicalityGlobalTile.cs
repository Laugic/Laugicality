using Laugicality.Items.Equipables;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Tiles
{
    public class LaugicalityGlobalTile : GlobalTile
    {
        public int miscVar = 0;

        public override bool Drop(int i, int j, int type)
        {
            Tile tile = Main.tile[i, j];

            if (tile == null)
                return base.Drop(i, j, type);

            if (tile.type == TileID.ShadowOrbs && Main.rand.Next(6) == 0)
            {
                if(i % 2 == 0 && j % 2 == 0)
                {
                    if(WorldGen.shadowOrbSmashed)
                        Item.NewItem(i * 16, j * 16, 8, 8, mod.ItemType<DarkfootBoots>(), 1);
                    else
                        Item.NewItem(i * 16, j * 16, 8, 8, mod.ItemType<BloodfootBoots>(), 1);
                }
                return false;
            }

            return base.Drop(i, j, type);
        }
    }
}