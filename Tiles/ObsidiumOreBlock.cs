using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Tiles
{
    public class ObsidiumOreBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[56][mod.TileType("ObsidiumOreBlock")] = true;
            Main.tileMerge[mod.TileType("ObsidiumOreBlock")][56] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileLighted[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Obsidium Ore");
            AddMapEntry(new Color(150, 50, 50), name);
            mineResist = 1f;
            minPick = 60;
            drop = mod.ItemType("ObsidiumOre");
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.2f;
            g = 0.1f;
            b = 0f;
        }
        
        public override bool CanExplode(int i, int j)
        {
            return false;
        }

    }
}