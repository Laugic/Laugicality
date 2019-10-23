using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Tiles
{
    public class HolystoneBrick : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[ModContent.TileType("HolystoneBrick")][ModContent.TileType("Holystone")] = true;
            Main.tileMerge[ModContent.TileType("Holystone")][ModContent.TileType("HolystoneBrick")] = true;
            Main.tileMerge[TileID.Marble][ModContent.TileType("HolystoneBrick")] = true;
            Main.tileMerge[ModContent.TileType("HolystoneBrick")][TileID.Marble] = true;
            Main.tileMerge[TileID.MarbleBlock][ModContent.TileType("HolystoneBrick")] = true;
            Main.tileMerge[ModContent.TileType("HolystoneBrick")][TileID.MarbleBlock] = true;
            //Main.tileSpelunker[Type] = true;
            Main.tileLighted[Type] = true;
            mineResist = .5f;
            minPick = 0;
            dustType = 229;
            drop = ModContent.ItemType("HolystoneBrick");
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}