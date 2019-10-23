using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Tiles
{
    public class ObsidiumCore : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Obsidium Core");
            AddMapEntry(new Color(200, 150, 50), name);
            mineResist = .5f;
            minPick = 50;
            dustType = ModContent.DustType<Magma>();
            drop = ModContent.ItemType<Items.Placeable.ObsidiumCore>();
        }
        
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.9f;
            g = 0.6f;
            b = 0f;
        }

        public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i, j - 1].type == 0 && Main.tile[i + 1, j - 1].type == 0 && Main.tile[i, j - 2].type == 0 && Main.tile[i + 1, j - 2].type == 0 && Main.tile[i, j].active())
            {
                if (Main.rand.Next(20) == 0)
                {
                    if(CountCrystals(i, j) < 9)
                        WorldGen.AddLifeCrystal(i, j - 1);
                }
            }
        }

        private static int CountCrystals(int i, int j)
        {
            int crystalCount = 0;
            for(int x = -20; x < 20; x++)
            {
                for(int y = -20; y < 20; y++)
                {
                    if(TileCheckSafe(x + i, y + j))
                    {
                        if (Main.tile[x + i, y + j].type == TileID.Heart)
                            crystalCount++;
                    }
                }
            }
            return crystalCount;
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        private static bool TileCheckSafe(int i, int j)
        {
            if (i > 0 && i < Main.maxTilesX - 1 && j > 0 && j < Main.maxTilesY - 1)
                return true;
            return false;
        }
    }
}