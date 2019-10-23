using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Tiles
{
    public class GodRay : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[TileID.Cloud][ModContent.TileType("GodRay")] = true;
            Main.tileMerge[ModContent.TileType("GodRay")][TileID.Cloud] = true;
            Main.tileMerge[TileID.RainCloud][ModContent.TileType("GodRay")] = true;
            Main.tileMerge[ModContent.TileType("GodRay")][TileID.RainCloud] = true;
            //Main.tileSpelunker[Type] = true;
            Main.tileLighted[Type] = true;
            mineResist = .5f;
            minPick = 0;
            dustType = 19;
            drop = ModContent.ItemType("GodRay");
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}