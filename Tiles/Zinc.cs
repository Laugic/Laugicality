using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Laugicality.Tiles
{
    public class Zinc : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = false;
            Main.tileMerge[0][mod.TileType("Zinc")] = true;
            Main.tileMerge[mod.TileType("Zinc")][0] = true;
            Main.tileMerge[mod.TileType("ZincBrick")][mod.TileType("Zinc")] = true;
            Main.tileMerge[mod.TileType("Zinc")][mod.TileType("ZincBrick")] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Zinc");
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(40, 100, 80), name);
            Main.tileSpelunker[Type] = true;
            mineResist = 1f;
            minPick = 20;
            drop = mod.ItemType("ZincOre");
            soundType = 21;
            dustType = 1;
            //soundStyle = 1;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
    }
}