using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Laugicality.Tiles
{
    public class MagmaVeins : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = false;
            AddMapEntry(new Color(250, 100, 50));
            mineResist = 1f;
            minPick = 60;
            drop = mod.ItemType("DarkShard");
            dustType = mod.DustType("Magma");
            //soundType = 21;
            //soundStyle = 1;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.4f;
            g = 0.1f;
            b = 0f;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }

    }
}