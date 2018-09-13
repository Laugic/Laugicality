using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Laugicality;

namespace Laugicality.Structures
{
    public class ObsidiumHouse1 : ModWorld
    {
        
        public static void StructureGen(int xPosO, int yPosO, bool mirrored)
        {
            //Obsidium Heart
            /**
             * 0 = Do Nothing
             * 1 = obsidium chest
             * 2 = Obsidium Brick
             * 3 = Platforms
             * 4 = Lycoris
             * 5 = Radiata
             * 6 = Lava
             * 7 = lavafall
             * 8 = wooden crate
             * 9 = Kill tile
             * */
            int[,] StructureGen = new int[,]
            {
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3,2,2,2,2},
                {2,5,4,4,9,9,9,9,9,9,7,9,9,9,9,9,9,9,9,9,9,9,7,9,2},
                {2,4,4,9,9,9,9,9,9,9,7,9,9,9,9,9,9,9,9,9,9,9,7,9,2},
                {2,5,9,9,9,9,9,9,9,9,5,9,9,9,9,9,9,9,9,9,9,9,7,9,2},
                {2,5,9,9,9,9,9,9,9,9,5,9,9,9,9,9,9,9,9,9,9,9,7,9,2},
                {2,4,9,9,9,9,9,9,5,4,5,5,9,9,9,9,9,9,9,9,9,9,7,9,2},
                {2,6,6,6,6,6,6,5,4,5,4,4,9,9,9,9,9,9,9,1,9,9,7,9,2},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3,2,2,2,2,2,2,2},
                {0,0,0,0,0,0,0,0,2,9,7,9,9,9,9,9,9,9,9,9,9,5,4,5,2},
                {0,0,0,0,0,0,0,0,2,9,7,9,9,9,9,9,9,9,9,9,9,9,5,4,2},
                {0,0,0,0,0,0,0,0,2,9,7,9,9,9,9,9,9,9,9,9,9,9,7,4,2},
                {0,0,0,0,0,0,0,0,2,9,7,9,9,9,9,9,9,9,9,9,9,4,5,5,2},
                {0,0,0,0,0,0,0,0,2,8,7,9,8,9,9,9,9,9,9,9,4,5,4,4,2},
                {0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,3,3,3,2,2,2,2,2},

            };

            for (int i = 0; i < StructureGen.GetLength(1); i++)
            {
                for (int j = 0; j < StructureGen.GetLength(0); j++)
                {
                    if(mirrored)
                    {
                        if (TileCheckSafe((int)(xPosO + StructureGen.GetLength(1) - i), (int)(yPosO + j)))
                        {
                            if (StructureGen[j, i] == 1)
                            {
                                LaugicalityWorld.PlaceObsidiumChest(xPosO + StructureGen.GetLength(1) - i, yPosO + j, (ushort)ModLoader.GetMod("Laugicality").TileType("ObsidiumBrick"));
                            }
                            if (StructureGen[j, i] == 2)
                            {
                                WorldGen.KillTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j, ModLoader.GetMod("Laugicality").TileType("ObsidiumBrick"), true, true);
                            }
                            if (StructureGen[j, i] == 3)
                            {
                                WorldGen.KillTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j, 19, true, true, -1, 13);
                            }
                            if (StructureGen[j, i] == 4)
                            {
                                WorldGen.KillTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j, ModLoader.GetMod("Laugicality").TileType("Lycoris"), true, true);
                            }
                            if (StructureGen[j, i] == 5)
                            {
                                WorldGen.KillTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j, ModLoader.GetMod("Laugicality").TileType("Radiata"), true, true);
                            }
                            if (StructureGen[j, i] == 6)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                Main.tile[xPosO + StructureGen.GetLength(1) - i, yPosO + j].lava(true);
                                Main.tile[xPosO + StructureGen.GetLength(1) - i, yPosO + j].liquid = 255;
                            }
                            if (StructureGen[j, i] == 7)
                            {
                                WorldGen.KillTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j);
                                WorldGen.KillWall(xPosO + StructureGen.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceWall(xPosO + StructureGen.GetLength(1) - i, yPosO + j, 137, true); //Lavafall Wall
                            }
                            if (StructureGen[j, i] == 8)
                            {
                                WorldGen.KillTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j);
                                WorldGen.KillTile(xPosO + StructureGen.GetLength(1) - i + 1, yPosO + j);
                                WorldGen.KillTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j - 1);
                                WorldGen.KillTile(xPosO + StructureGen.GetLength(1) - i + 1, yPosO + j - 1);
                                Terraria.WorldGen.PlaceObject(xPosO + StructureGen.GetLength(1) - i, yPosO + j, 376, true, 0, -1, -1);
                            }
                            if (StructureGen[j, i] == 9)
                            {
                                Main.tile[xPosO + StructureGen.GetLength(1) - i, yPosO + j].liquid = 0;
                                WorldGen.KillTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j);
                            }
                        }
                    }
                    else
                    {
                        if (TileCheckSafe((int)(xPosO + i), (int)(yPosO + j)))
                        {
                            if (StructureGen[j, i] == 1)
                            {
                                LaugicalityWorld.PlaceObsidiumChest(xPosO + i, yPosO + j, (ushort)ModLoader.GetMod("Laugicality").TileType("ObsidiumBrick"));
                            }
                            if (StructureGen[j, i] == 2)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, ModLoader.GetMod("Laugicality").TileType("ObsidiumBrick"), true, true);
                            }
                            if (StructureGen[j, i] == 3)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, 19, true, true, -1, 13);
                            }
                            if (StructureGen[j, i] == 4)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, ModLoader.GetMod("Laugicality").TileType("Lycoris"), true, true);
                            }
                            if (StructureGen[j, i] == 5)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, ModLoader.GetMod("Laugicality").TileType("Radiata"), true, true);
                            }
                            if (StructureGen[j, i] == 6)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                Main.tile[xPosO + i, yPosO + j].lava(true);
                                Main.tile[xPosO + i, yPosO + j].liquid = 255;
                            }
                            if (StructureGen[j, i] == 7)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.KillWall(xPosO + i, yPosO + j);
                                WorldGen.PlaceWall(xPosO + i, yPosO + j, 137, true); //Lavafall Wall
                            }
                            if (StructureGen[j, i] == 8)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.KillTile(xPosO + i + 1, yPosO + j);
                                WorldGen.KillTile(xPosO + i, yPosO + j - 1);
                                WorldGen.KillTile(xPosO + i + 1, yPosO + j - 1);
                                Terraria.WorldGen.PlaceObject(xPosO + i, yPosO + j, 376, true, 0, -1, -1);
                            }
                            if (StructureGen[j, i] == 9)
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
            if (i > 0 && i < Main.maxTilesX && j > 0 && j < Main.maxTilesY)
                return true;
            return false;
        }
    }
}