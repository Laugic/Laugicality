using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Tiles
{
    public class RepulsionCore : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Repulsion Core");
            AddMapEntry(new Color(0, 50, 150), name);
            mineResist = .5f;
            minPick = 100;
            dustType = mod.DustType("Etherial");
            drop = mod.ItemType("RepulsionCore");
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = .1f;
            b = .2f;
        }
    }
}