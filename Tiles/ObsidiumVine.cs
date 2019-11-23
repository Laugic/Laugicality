using Laugicality.Dusts;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace Laugicality.Tiles
{
    public class ObsidiumVine : AmelderaTile
    {
        public override void SetDefaults()
        {
            Main.tileCut[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileNoFail[Type] = true;
            Main.tileLighted[Type] = true;
            ModTranslation name = CreateMapEntryName();
            //AddMapEntry(new Color(150, 0, 0), name);
            soundType = 6;
            dustType = ModContent.DustType<Magma>();

            obsidiumTexture = this.GetType().GetTexture();
            amelderaTexture = mod.GetTexture(this.GetType().GetRootPath() + "/AmelderaVineTile");
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if ((j % 2 == 0 || i % 2 == 0) && !(j % 2 == 0 && i % 2 == 0))
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            offsetY = -2;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = .1f;
            if (LaugicalityWorld.Ameldera)
                r = 0;
            g = 0.05f;
            b = 0.0f;
            if (LaugicalityWorld.Ameldera)
                b = .1f;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if(j < Main.maxTilesY - 4)
            {
                if (Main.tile[i, j + 1].type == ModContent.TileType<ObsidiumVine>())
                    Terraria.WorldGen.KillTile(i, j + 1);
            }
        }
    }
}