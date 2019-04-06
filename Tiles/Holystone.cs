using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Tiles
{
    public class Holystone : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[TileID.Dirt][mod.TileType("Holystone")] = true;
            Main.tileMerge[mod.TileType("Holystone")][TileID.Dirt] = true;
            Main.tileMerge[TileID.Marble][mod.TileType("Holystone")] = true;
            Main.tileMerge[mod.TileType("Holystone")][TileID.Marble] = true;
            Main.tileMerge[TileID.MarbleBlock][mod.TileType("Holystone")] = true;
            Main.tileMerge[mod.TileType("Holystone")][TileID.MarbleBlock] = true;
            //Main.tileSpelunker[Type] = true;
            Main.tileLighted[Type] = true;
            mineResist = .5f;
            minPick = 0;
            dustType = 229;
            drop = mod.ItemType("Holystone");
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}