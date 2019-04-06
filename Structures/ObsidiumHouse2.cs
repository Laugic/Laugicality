using Terraria;

namespace Laugicality.Structures
{
    public class ObsidiumHouse2
    {
        private static readonly int[,] StructureArray = new int[,]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,9,7,9,9,9,9,9,9,9,9,9,9,9,9,7,9,9,9,9,9,4,4,4,3,1},
            {1,9,7,9,9,9,9,9,9,9,9,9,9,9,9,7,9,9,9,9,9,9,3,4,4,1},
            {1,9,7,9,6,9,9,9,9,9,9,9,9,9,9,7,3,9,9,9,9,9,9,3,4,1},
            {1,9,7,9,9,9,9,9,9,9,9,9,9,9,9,3,4,3,9,9,9,9,9,3,4,1},
            {1,9,7,6,9,9,6,9,9,9,9,9,9,9,4,3,4,4,3,9,2,9,4,4,3,1},
            {1,1,1,1,1,1,1,1,1,5,5,5,5,5,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,4,4,4,9,9,9,9,9,9,9,9,9,9,9,7,9,1,0,0,0,0,0,0,0,0},
            {1,3,4,9,9,9,9,9,9,9,9,9,9,9,9,7,9,1,0,0,0,0,0,0,0,0},
            {1,4,7,9,9,9,9,9,9,9,9,9,9,9,9,7,9,9,0,0,0,0,0,0,0,0},
            {1,4,4,9,9,9,9,9,9,9,9,9,9,9,9,7,9,9,0,0,0,0,0,0,0,0},
            {1,3,3,4,4,9,6,9,9,9,8,9,9,9,9,7,9,9,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,5,5,5,1,1,0,0,0,0,0,0,0,0},

        };

        public static void StructureGen(int xPosO, int yPosO, bool mirrored)
        {
            //Obsidium Heart
            /**
             * 0 = Do Nothing
             * 1 = Obsidium Brick
             * 2 = Obsidium Chest
             * 3 = Lycoris
             * 4 = Radiata
             * 5 = Platform
             * 6 = wooden crate
             * 7 = lavafall
             * 8 = ?
             * 9 = Kill tile
             * */
            

            for (int i = 0; i < StructureArray.GetLength(1); i++)
            {
                for (int j = 0; j < StructureArray.GetLength(0); j++)
                {
                    if(mirrored)
                    {
                        if (TileCheckSafe((int)(xPosO + StructureArray.GetLength(1) - i), (int)(yPosO + j)))
                        {
                            if (StructureArray[j, i] == 1)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j, Laugicality.instance.TileType("ObsidiumBrick"), true, true);
                            }
                            if (StructureArray[j, i] == 2)
                            {
                                LaugicalityWorld.PlaceObsidiumChest(xPosO + StructureArray.GetLength(1) - i, yPosO + j, (ushort)Laugicality.instance.TileType("ObsidiumBrick"));
                            }
                            if (StructureArray[j, i] == 3)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j, Laugicality.instance.TileType("Lycoris"), true, true);
                            }
                            if (StructureArray[j, i] == 4)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j, Laugicality.instance.TileType("Radiata"), true, true);
                            }
                            if (StructureArray[j, i] == 5)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j, 19, true, true, -1, 13);
                            }
                            if (StructureArray[j, i] == 6)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i + 1, yPosO + j);
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j - 1);
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i + 1, yPosO + j - 1);
                                Terraria.WorldGen.PlaceObject(xPosO + StructureArray.GetLength(1) - i, yPosO + j, 376, true, 0, -1, -1);
                            }
                            if (StructureArray[j, i] == 7)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.KillWall(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceWall(xPosO + StructureArray.GetLength(1) - i, yPosO + j, 137, true); //Lavafall Wall
                            }
                            if (StructureArray[j, i] == 8)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i + 1, yPosO + j);
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j - 1);
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i + 1, yPosO + j - 1);
                                Terraria.WorldGen.PlaceObject(xPosO + StructureArray.GetLength(1) - i, yPosO + j, 376, true, 0, -1, -1);
                            }
                            if (StructureArray[j, i] == 9)
                            {
                                Main.tile[xPosO + StructureArray.GetLength(1) - i, yPosO + j].liquid = 0;
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                            }
                        }
                    }
                    else
                    {
                        if (TileCheckSafe((int)(xPosO + i), (int)(yPosO + j)))
                        {
                            if (StructureArray[j, i] == 1)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, Laugicality.instance.TileType("ObsidiumBrick"), true, true);
                            }
                            if (StructureArray[j, i] == 2)
                            {
                                LaugicalityWorld.PlaceObsidiumChest(xPosO + i, yPosO + j, (ushort)Laugicality.instance.TileType("ObsidiumBrick"));
                            }
                            if (StructureArray[j, i] == 3)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, Laugicality.instance.TileType("Lycoris"), true, true);
                            }
                            if (StructureArray[j, i] == 4)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, Laugicality.instance.TileType("Radiata"), true, true);
                            }
                            if (StructureArray[j, i] == 5)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, 19, true, true, -1, 13);
                            }
                            if (StructureArray[j, i] == 6)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.KillTile(xPosO + i + 1, yPosO + j);
                                WorldGen.KillTile(xPosO + i, yPosO + j - 1);
                                WorldGen.KillTile(xPosO + i + 1, yPosO + j - 1);
                                Terraria.WorldGen.PlaceObject(xPosO + i, yPosO + j, 376, true, 0, -1, -1);
                            }
                            if (StructureArray[j, i] == 7)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.KillWall(xPosO + i, yPosO + j);
                                WorldGen.PlaceWall(xPosO + i, yPosO + j, 137, true); //Lavafall Wall
                            }
                            if (StructureArray[j, i] == 8)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.KillTile(xPosO + i + 1, yPosO + j);
                                WorldGen.KillTile(xPosO + i, yPosO + j - 1);
                                WorldGen.KillTile(xPosO + i + 1, yPosO + j - 1);
                                Terraria.WorldGen.PlaceObject(xPosO + i, yPosO + j, 376, true, 0, -1, -1);
                            }
                            if (StructureArray[j, i] == 9)
                            {
                                Main.tile[xPosO + i, yPosO + j].liquid = 0;
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                            }
                        }
                    }
                }
            }
        }
        
        //Making sure tiles arent out of bounds
        private static bool TileCheckSafe(int i, int j)
        {
            if (i > 1 && i < Main.maxTilesX - 1 && j > 1 && j < Main.maxTilesY - 1)
            {
                if (LaugicalityVars.ObsidiumTiles.Contains(Main.tile[i, j].type))
                    return true;
            }
            return false;
        }
    }
}