using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Laugicality.Tiles
{
    public class Radiata : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = false;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(160, 15, 0));
            mineResist = .5f;
            minPick = 10;
            drop = mod.ItemType("Radiata");
            dustType = mod.DustType("Magma");
            //soundType = 21;
            //soundStyle = 1;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void RandomUpdate(int i, int j)
        {
            int randm = Main.rand.Next(18);
            if (randm < 9)
            {
                if (CheckTile(i, j + 1))
                {
                    Terraria.WorldGen.PlaceTile(i, j + 1, mod.TileType("ObsidiumVine"), true);
                }
                else if (Main.tile[i, j + 1].type == mod.TileType("ObsidiumVine"))
                {
                    for(int k = 1; k < 12; k++)
                    {
                        if (Main.tile[i, j + k].type != mod.TileType("ObsidiumVine"))
                        {
                            if(Main.tile[i, j + k].type == 0)
                                Terraria.WorldGen.PlaceTile(i, j + k, mod.TileType("ObsidiumVine"), true);
                            break;
                        }
                    }
                }
            }
        }
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (j < Main.maxTilesY - 4)
            {
                if (Main.tile[i, j + 1].type == mod.TileType("ObsidiumVine"))
                    Terraria.WorldGen.KillTile(i, j + 1);
            }
        }

        private bool CheckTile(int i, int j)
        {
            if (Main.tile[i, j].type != 0)
                return false;
            return true;
        }
    }
}