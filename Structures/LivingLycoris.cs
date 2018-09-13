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
    public class LivingLycoris : ModWorld
    {
        
        public static void StructureGen(int xPosO, int yPosO, bool mirrored)
        {
            //Obsidium Heart
            /**
             * 0 = Do Nothing
             * 1 = Lycoris
             * 2 = Radiata
             * 3 = Obsidium Chest
             * 9 = Kill tile
             * */
            int[,] StructureGen = new int[,]
            {
                 {0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0}
,                {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0}
,                {0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1}
,                {0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,1,1,1,1,1,0,0,0,1,1,1,1,1,1,0,0,0}
,                {0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,0,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,0,0}
,                {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,0}
,                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
,                {0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,1,1,1,1}
,                {0,0,0,0,0,0,2,2,2,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1}
,                {0,0,0,0,0,0,0,2,2,2,0,0,0,1,1,1,1,2,2,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,2,2,2,2,0,1,2,2,2,9,9,2,1,1,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,9,9,9,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,2,2,2,2,9,9,9,9,9,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,2,2,2,9,9,9,9,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0}
,                {0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,2,2,0,2,2,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0}
,                {0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,2,2,0,0,2,2,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0}
,                {0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,2,2,0,0,2,2,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,9,2,2,0,0,2,2,2,0,0,1,1,2,2,2,1,1,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,9,9,2,2,2,0,0,2,2,2,2,2,2,2,1,1,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,9,9,2,2,2,2,2,2,2,2,2,1,1,1,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,9,9,9,9,9,2,2,2,2,0,0,2,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,9,9,9,9,9,9,9,2,2,0,2,2,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,9,9,9,9,9,2,2,2,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,9,9,9,9,9,2,2,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,9,9,9,9,2,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,9,9,9,9,2,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,9,9,9,9,2,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,2,2,2,9,9,9,9,2,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,2,2,9,9,9,9,2,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,1,1,1,1,2,2,2,2,2,0,0,0,2,2,9,9,9,2,2,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,2,2,2,2,2,2,2,9,9,9,9,2,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,2,2,2,2,9,9,9,9,9,2,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,3,9,2,2,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,9,9,9,2,2,2,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0}

            };

            for (int i = 0; i < StructureGen.GetLength(1); i++)
            {
                for (int j = 0; j < StructureGen.GetLength(0); j++)
                {
                    if (mirrored)
                    {
                        if (TileCheckSafe((int)(xPosO + StructureGen.GetLength(1) - i), (int)(yPosO + j)))
                        {
                            if (StructureGen[j, i] == 1)
                            {
                                WorldGen.KillTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j, ModLoader.GetMod("Laugicality").TileType("Lycoris"), true, true);
                            }
                            if (StructureGen[j, i] == 2)
                            {
                                WorldGen.KillTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureGen.GetLength(1) - i, yPosO + j, ModLoader.GetMod("Laugicality").TileType("Radiata"), true, true);
                            }
                            if (StructureGen[j, i] == 3)
                            {
                                LaugicalityWorld.PlaceObsidiumChest(xPosO + StructureGen.GetLength(1) - i, yPosO + j, (ushort)ModLoader.GetMod("Laugicality").TileType("Radiata"));
                            }
                            if (StructureGen[j, i] == 9)
                            {
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
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, ModLoader.GetMod("Laugicality").TileType("Lycoris"), true, true);
                            }
                            if (StructureGen[j, i] == 2)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, ModLoader.GetMod("Laugicality").TileType("Radiata"), true, true);
                            }
                            if (StructureGen[j, i] == 3)
                            {
                                LaugicalityWorld.PlaceObsidiumChest(xPosO + i, yPosO + j, (ushort)ModLoader.GetMod("Laugicality").TileType("Radiata"));
                            }
                            if (StructureGen[j, i] == 9)
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
            if (i > 1 && i < Main.maxTilesX - 1 && j > 1 && j < Main.maxTilesY - 1)
                return true;
            return false;
        }
    }
}