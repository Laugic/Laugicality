using Laugicality.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Tiles
{
    public class SootTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Soot");
            AddMapEntry(new Color(60, 50, 60), name);
            mineResist = .5f;
            minPick = 0;
            drop = ModContent.ItemType<Soot>();
            dustType = 1;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}