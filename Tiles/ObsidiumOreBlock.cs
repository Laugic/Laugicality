using Laugicality.Items.Placeable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace Laugicality.Tiles
{
    public class ObsidiumOreBlock : AmelderaTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[56][ModContent.TileType<ObsidiumOreBlock>()] = true;
            Main.tileMerge[ModContent.TileType<ObsidiumOreBlock>()][56] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileLighted[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Obsidium Ore");
            AddMapEntry(new Color(150, 50, 50), name);
            mineResist = 1f;
            minPick = 60;
            drop = ModContent.ItemType<ObsidiumOre>();
            dustType = 1;

            amelderaTexture = mod.GetTexture(this.GetType().GetRootPath() + "/AmelderaOreTile");
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.4f;
            if (LaugicalityWorld.Ameldera)
                r = 0.025f;
            g = 0.2f;
            b = 0f;
            if (LaugicalityWorld.Ameldera)
                b = .4f;
        }
        
        public override bool CanExplode(int i, int j)
        {
            return false;
        }

    }
}