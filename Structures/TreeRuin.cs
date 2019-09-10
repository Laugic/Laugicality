using Terraria;

namespace Laugicality.Structures
{
    public class TreeRuin
    {
        private static readonly int[,] _structureArray = new int[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,9,9,9,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,9,9,9,9,9,9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,9,9,9,9,9,9,9,9,9,9,9,7,9,9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,2,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,2,2,9,9,9,9,9,9,9,9,9,9,9,9,9,2,2,2,2,2,2,9,9,2,2,2,9,1,1,1,1,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,2,2,2,2,9,9,9,9,9,9,9,9,9,9,9,2,2,2,2,2,2,6,9,9,2,2,2,9,9,9,1,1,1,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,2,2,2,2,2,9,9,9,9,9,9,9,9,9,2,2,2,2,2,2,9,6,9,9,9,2,2,2,9,9,9,1,1,0,0},
            {0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,9,2,2,2,2,2,2,2,9,9,9,9,9,9,9,9,2,2,2,9,9,9,9,6,9,9,9,9,2,2,9,9,9,1,1,0,0},
            {0,0,0,0,0,0,0,1,1,1,1,1,1,7,9,9,9,9,9,2,2,2,2,2,9,9,9,9,9,9,2,2,2,9,9,9,9,9,6,9,9,9,9,2,2,2,9,7,1,1,0,0},
            {0,0,0,1,1,1,1,1,1,1,1,1,9,9,9,9,9,9,9,9,2,2,2,2,2,9,9,9,9,9,9,9,9,9,9,9,9,9,6,9,9,9,9,9,2,2,9,9,1,1,1,0},
            {0,0,0,1,1,1,1,1,1,2,2,2,9,9,9,9,9,9,9,9,9,9,2,2,2,9,9,9,9,9,9,9,9,9,9,9,9,9,6,9,9,9,9,9,2,2,2,9,9,1,1,0},
            {0,0,0,0,9,9,6,2,2,2,2,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,6,9,9,9,9,9,9,2,2,9,9,1,1,0},
            {0,0,0,0,9,9,6,2,2,2,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,9,9,9,9,9,9,9,9,9,9,6,9,9,9,9,9,9,9,9,9,9,9,9,0},
            {0,0,0,0,9,9,6,2,2,2,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,5,5,5,1,1,9,9,9,9,6,9,9,9,9,9,9,9,9,9,9,9,9,0},
            {0,0,0,0,9,9,2,2,9,9,9,4,4,4,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,5,1,1,1,9,9,9,9,6,9,9,9,9,9,9,9,9,9,9,9,9,0},
            {0,0,0,0,9,9,2,2,9,9,4,4,4,4,4,4,4,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1,1,9,9,9,9,9,6,9,9,9,9,9,9,9,9,9,9,9,9,9},
            {0,0,0,9,9,9,2,9,9,4,4,4,4,4,4,4,4,4,4,9,9,9,9,9,9,9,9,9,9,1,1,1,9,9,9,9,9,9,6,9,9,9,9,9,9,9,9,9,9,9,9,9},
            {0,0,0,9,9,9,6,9,4,4,4,4,4,4,4,4,4,4,4,9,9,9,9,9,9,9,9,9,9,9,7,6,9,9,9,9,9,9,6,9,9,9,9,9,9,9,9,9,9,9,9,9},
            {0,0,0,9,9,9,6,9,4,4,4,4,4,4,4,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,6,9,9,9,9,9,9,6,9,9,9,9,9,9,9,9,9,9,9,9,9},
            {0,0,0,9,9,9,6,4,4,4,4,3,3,3,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,6,9,9,9,9,9,9,6,9,9,9,9,9,9,9,9,9,9,9,9,0},
            {0,0,0,9,9,9,6,4,4,4,9,9,3,3,3,4,4,4,4,4,9,9,9,9,9,9,9,9,9,9,9,6,9,9,9,9,9,9,6,9,9,9,9,9,9,9,9,9,9,9,9,0},
            {0,0,0,9,9,9,6,9,9,9,9,9,9,3,4,4,4,4,4,4,4,4,4,9,9,9,9,9,9,9,9,6,9,9,9,9,9,9,6,9,9,9,9,9,9,9,9,9,9,9,9,0},
            {0,9,9,9,9,9,6,9,9,9,9,9,9,3,3,4,4,4,4,4,4,4,4,4,9,9,9,9,9,9,9,6,9,9,9,9,9,9,6,9,9,9,9,9,9,9,9,9,9,9,0,0},
            {0,9,9,9,9,9,6,9,9,9,9,9,3,3,3,9,9,4,3,3,4,4,9,9,9,9,9,9,9,9,9,6,9,9,9,9,9,9,6,9,9,9,9,9,9,9,9,9,9,9,0,0},
            {0,9,9,9,9,9,6,9,9,9,9,9,3,3,3,9,3,3,3,3,9,9,9,9,9,9,9,9,9,9,9,6,9,9,9,9,9,9,6,9,9,9,9,9,9,9,9,9,9,9,0,0},
            {0,9,9,9,9,9,6,9,9,9,9,9,3,3,3,3,3,3,3,9,9,9,9,9,9,9,9,9,9,9,9,6,9,9,9,9,9,9,6,9,9,9,1,1,1,1,9,9,9,9,0,0},
            {0,9,9,9,9,9,6,9,9,9,9,9,3,3,3,3,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,6,9,9,9,9,9,9,6,9,9,9,9,1,1,1,1,1,9,9,0,0},
            {0,9,9,9,9,9,6,9,9,9,9,9,3,3,3,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,6,9,9,9,9,9,9,6,9,9,9,9,9,9,1,1,1,1,1,1,0},
            {0,9,9,9,9,9,6,9,9,9,9,3,3,3,3,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,6,9,9,9,9,9,9,6,9,9,9,9,9,9,9,1,1,1,1,1,0},
            {9,9,9,9,9,9,6,9,9,9,9,3,3,3,9,9,9,9,9,9,9,9,9,9,9,1,9,9,9,9,9,6,9,9,9,9,9,9,6,9,9,9,9,9,9,7,1,1,0,0,0,0},
            {9,9,9,9,9,9,6,9,9,9,9,3,3,3,9,9,9,9,9,9,9,9,9,9,1,1,9,9,9,9,9,6,9,9,9,9,9,9,6,9,9,9,4,4,4,4,1,1,1,0,0,0},
            {9,9,9,9,9,9,6,9,9,9,3,3,3,3,9,9,9,9,9,9,9,9,9,1,1,1,9,9,9,9,9,6,9,4,4,4,4,4,4,4,4,4,4,4,5,5,4,1,1,0,0,0},
            {9,9,9,9,9,9,6,9,9,9,3,3,3,3,9,9,9,9,9,9,9,9,9,1,1,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1,1,0,0,0},
            {9,9,9,9,9,9,6,9,9,9,3,3,3,3,3,9,9,9,9,9,9,9,9,1,1,1,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1,1,0,0,0},
            {9,9,9,9,9,9,6,9,9,3,3,3,3,3,3,3,9,9,9,9,9,9,9,9,1,1,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1,1,0,0,0},
            {9,9,9,9,9,9,6,9,3,3,8,8,8,8,8,3,9,9,9,9,9,9,2,2,1,1,1,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1,1,0,0,0},
            {9,9,9,9,9,9,6,8,8,8,8,8,8,8,8,8,8,9,9,9,2,2,2,2,2,1,1,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1,1,1,0,0,0},
            {1,1,1,9,9,8,8,8,8,8,8,8,8,8,8,8,8,8,8,2,2,2,2,1,1,1,1,1,1,1,1,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1,1,0,0,0,0},
            {1,1,1,1,1,1,1,1,8,8,8,8,8,8,8,8,8,8,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,5,5,5,5,5,5,5,5,5,1,1,1,0,0,0,0},
            {1,1,1,1,1,1,1,1,1,1,1,1,8,8,8,8,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,5,5,5,5,1,1,1,1,1,1,0,0,0,0},
            {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},

        };

        public static void StructureGen(int xPosO, int yPosO, bool mirrored)
        {
            //Obsidium Heart
            /**
             * 0 = Do Nothing
             * 1 = Obsidium Rock
             * 2 = Lycoris
             * 3 = Radiata
             * 4 = Obsidian
             * 5 = Lava
             * 6 = Lavafall
             * 7 = Ruby
             * 8 = Hellstone
             * 9 = Kill tile
             * */

            for (int i = 0; i < _structureArray.GetLength(1); i++)
            {
                for (int j = 0; j < _structureArray.GetLength(0); j++)
                {
                    if (mirrored)
                    {
                        if (TileCheckSafe((int)(xPosO + _structureArray.GetLength(1) - i), (int)(yPosO + j)))
                        {
                            if (_structureArray[j, i] == 1)
                            {
                                WorldGen.KillTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j, Laugicality.Instance.TileType("ObsidiumRock"), true, true);
                            }
                            if (_structureArray[j, i] == 2)
                            {
                                WorldGen.KillTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j, Laugicality.Instance.TileType("Lycoris"), true, true);
                            }
                            if (_structureArray[j, i] == 3)
                            {
                                WorldGen.KillTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j, Laugicality.Instance.TileType("Radiata"), true, true);
                            }
                            if (_structureArray[j, i] == 4)
                            {
                                WorldGen.KillTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j, 56, true, true);
                            }
                            if (_structureArray[j, i] == 5)
                            {
                                WorldGen.KillTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j);
                                Main.tile[xPosO + _structureArray.GetLength(1) - i, yPosO + j].lava(true);
                                Main.tile[xPosO + _structureArray.GetLength(1) - i, yPosO + j].liquid = 255;
                            }
                            if (_structureArray[j, i] == 6)
                            {
                                WorldGen.KillTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.KillWall(xPosO + _structureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceWall(xPosO + _structureArray.GetLength(1) - i, yPosO + j, 137, true); //Lavafall Wall
                            }
                            if (_structureArray[j, i] == 7)
                            {
                                WorldGen.KillTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j, 178, true, true, -1, 4);
                            }
                            if (_structureArray[j, i] == 8)
                            {
                                WorldGen.KillTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j, 58, true, true);
                            }
                            if (_structureArray[j, i] == 9)
                            {
                                WorldGen.KillTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j);
                            }
                        }
                    }
                    else
                    {
                        if (TileCheckSafe((int)(xPosO + i), (int)(yPosO + j)))
                        {
                            if (_structureArray[j, i] == 1)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, Laugicality.Instance.TileType("ObsidiumRock"), true, true);
                            }
                            if (_structureArray[j, i] == 2)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, Laugicality.Instance.TileType("Lycoris"), true, true);
                            }
                            if (_structureArray[j, i] == 3)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, Laugicality.Instance.TileType("Radiata"), true, true);
                            }
                            if (_structureArray[j, i] == 4)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, 56, true, true);
                            }
                            if (_structureArray[j, i] == 5)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                Main.tile[xPosO + i, yPosO + j].lava(true);
                                Main.tile[xPosO + i, yPosO + j].liquid = 255;
                            }
                            if (_structureArray[j, i] == 6)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.KillWall(xPosO + i, yPosO + j);
                                WorldGen.PlaceWall(xPosO + i, yPosO + j, 137, true); //Lavafall Wall
                            }
                            if (_structureArray[j, i] == 7)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, 178, true, true, -1, 4);
                            }
                            if (_structureArray[j, i] == 8)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, 58, true, true);
                            }
                            if (_structureArray[j, i] == 9)
                            {
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
            if (i > 0 && i < Main.maxTilesX && j > 0 && j < Main.maxTilesY)
                return true;
            return false;
        }
    }
}