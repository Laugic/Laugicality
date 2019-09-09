using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Tiles
{
    public class Lycoris : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileMerge[mod.TileType("Lycoris")][mod.TileType("Radiata")] = true;
            Main.tileMerge[mod.TileType("Radiata")][mod.TileType("Lycoris")] = true;
            AddMapEntry(new Color(225, 50, 0));
            mineResist = .5f;
            minPick = 10;
            drop = mod.ItemType("Lycoris");
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
            r = 0.6f;
            g = 0.5f;
            b = 0f;
        }

        public override void RandomUpdate(int i, int j)
        {
            int randm = Main.rand.Next(30);
            if(randm < 8)
            {
                if(CheckTile(i, j - 1))
                {
                    Terraria.WorldGen.PlaceObject(i, j - 1, mod.TileType("ObsidiumGrass"), true, 0, -1, -1);
                }
            }
            else if(randm < 12)
            {
                if(Check2Tiles(i, j-1) && Main.tile[i,j + 1].type == mod.TileType("Lycoris"))
                {
                    int chance = Main.rand.Next(2);
                    if(chance == 0)
                        Terraria.WorldGen.PlaceObject(i, j - 1, mod.TileType("ObsidiumPlantGrass"), true, 0, -1, -1);
                    else
                        Terraria.WorldGen.PlaceObject(i, j - 1, mod.TileType("ObsidiumPlantGrass2"), true, 0, -1, -1);
                }
                else if(CheckTile(i, j - 1))
                    Terraria.WorldGen.PlaceObject(i, j - 1, mod.TileType("ObsidiumGrass"), true, 0, -1, -1);
            }
            else if(randm < 14)
            {
                if (Check4Tiles(i, j - 1) && Main.tile[i, j].type == mod.TileType("Lycoris") && Main.tile[i + 1, j].type == mod.TileType("Lycoris") && Main.tile[i + 2, j].type == mod.TileType("Lycoris") && Main.tile[i + 3, j].type == mod.TileType("Lycoris"))
                {
                    int chance = Main.rand.Next(4);
                    if (chance == 0)
                        Terraria.WorldGen.PlaceObject(i, j - 1, mod.TileType("ObsidiumPlantBulbs"), true, 0, -1, -1);
                    if (chance == 1)
                        Terraria.WorldGen.PlaceObject(i, j - 1, mod.TileType("ObsidiumPlantHeart"), true, 0, -1, -1);
                    if (chance == 2)
                        Terraria.WorldGen.PlaceObject(i, j - 1, mod.TileType("ObsidiumPlantLeaves"), true, 0, -1, -1);
                    if (chance == 3)
                        Terraria.WorldGen.PlaceObject(i, j - 1, mod.TileType("ObsidiumPlantMine"), true, 0, -1, -1);
                }
                else if (Check2Tiles(i, j - 1) && Main.tile[i, j + 1].type == mod.TileType("Lycoris"))
                {
                    int chance = Main.rand.Next(2);
                    if (chance == 0)
                        Terraria.WorldGen.PlaceObject(i, j - 1, mod.TileType("ObsidiumPlantGrass"), true, 0, -1, -1);
                    else
                        Terraria.WorldGen.PlaceObject(i, j - 1, mod.TileType("ObsidiumPlantGrass2"), true, 0, -1, -1);
                }
                else if (CheckTile(i, j - 1))
                    Terraria.WorldGen.PlaceObject(i, j - 1, mod.TileType("ObsidiumGrass"), true, 0, -1, -1);
            }
            /*randm = Main.rand.Next(60);
            if (randm < 9)
            {
                if (CheckTile(i, j + 1))
                {
                    Terraria.WorldGen.PlaceTile(i, j + 1, mod.TileType("ObsidiumVine"), true);
                }
                else if(Main.tile[i, j + 1].type == mod.TileType("ObsidiumVine"))
                {
                    for (int k = 1; k < 12; k++)
                    {
                        if (Main.tile[i, j + k].type != mod.TileType("ObsidiumVine") && Main.tile[i, j + k].type == 0)
                        {
                            Terraria.WorldGen.PlaceTile(i, j + k, mod.TileType("ObsidiumVine"), true);
                            break;
                        }
                    }
                }
            }*/
        }

        private bool Check4Tiles(int i, int j)
        {
            for (int k = i; k < i + 4; k++)
            {
                for (int l = j; l > j - 4; l--)
                {
                    if (Main.tile[k, l].type != 0)
                        return false;
                }
            }
            return true;
        }

        private bool Check2Tiles(int i, int j)
        {
            for (int k = i; k < i + 2; k++)
            {
                for (int l = j; l > j - 2; l--)
                {
                    if (Main.tile[k, l].type != 0)
                        return false;
                }
            }
            return true;
        }

        private bool CheckTile(int i, int j)
        {
            if (Main.tile[i, j].type != 0)
                return false;
            return true;
        }


        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (j < Main.maxTilesY - 4)
            {
                if (Main.tile[i, j + 1].type == mod.TileType("ObsidiumVine"))
                    Terraria.WorldGen.KillTile(i, j + 1);
            }
        }
    }
}