using Laugicality.Tiles;
using Laugicality.Tiles.Furniture;
using Laugicality.Walls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;

namespace Laugicality.Structures
{
    public class ObsidiumHouses
    {
        private static int numRooms = 0;
        private static int direction = 0;
        private static int roomHeight = 0;
        private static int blockType = Laugicality.instance.TileType<ObsidiumBrick>();
        private static int platformType = TileID.Platforms;
        private static int wallType = Laugicality.instance.WallType<ObsidiumBrickWall>();
        private static int x = 0;
        private static int y = 0;

        private static List<int> nonOverrideBlocks = new List<int> { blockType, platformType, Laugicality.instance.TileType<ObsidiumDoorClosed>(), Laugicality.instance.TileType<LavaGemLanternTile>(), Laugicality.instance.TileType<LavaGemLampTile>() , Laugicality.instance.TileType<LavaGemLanternTile>(),
            Laugicality.instance.TileType<ObsidiumTableTile>(), Laugicality.instance.TileType<ObsidiumDresserTile>(), Laugicality.instance.TileType<ObsidiumBedTile>(), Laugicality.instance.TileType<ObsidiumSinkTile>(), Laugicality.instance.TileType<ObsidiumWorkbenchTile>() };

        public static void GenerateHouse(int i, int j)
        {
            PickVariables(i, j);
            GenRooms(roomHeight);
        }

        private static void PickVariables(int i, int j)
        {
            x = i;
            y = j;
            direction = Main.rand.Next(1, 3);
            numRooms = Main.rand.Next(3, 7);
            roomHeight = Main.rand.Next(6, 8);
        }

        private static void GenRooms(int height)
        {
            while(numRooms > 0)
            {
                GenerateRoom(height);
                numRooms--;
            }
        }

        private static void GenerateRoom(int height)
        {
            int width = Main.rand.Next(13, 20);
            GenerateBorders(height, width);
            GenerateWalls(height, width);
            Furnish(height, width);
            UpdateX(width);
            UpdateY(height);
            UpdateDoorDir();
        }

        private static void Furnish(int height, int width)
        {
            if(numRooms == 1 || Main.rand.Next(20) == 0)
            {
                int chestPos = Main.rand.Next(2, width - 4);
                WorldGen.KillTile(x + chestPos, y + height - 2);
                WorldGen.KillTile(x + chestPos + 1, y + height - 2);
                WorldGen.KillTile(x + chestPos, y + height - 3);
                WorldGen.KillTile(x + chestPos + 1, y + height - 3);
                LaugicalityWorld.PlaceObsidiumChest(x + chestPos, y + height - 2, (ushort)Laugicality.instance.TileType<ObsidiumBrick>());
            }
            for(int i = 2; i < width - 4; i++)
            {
                if(TileCheckSafe(x + i, y + height - 2))
                {
                    if(Main.tile[x + i, y + height - 2].type == 0 && Main.tile[x + i + 1, y + height - 2].type == 0 && Main.tile[x + i + 2, y + height - 2].type == 0 && Main.tile[x + i + 3, y + height - 2].type == 0 && Main.rand.Next(width) == 0)
                    {
                        WorldGen.KillTile(x + i, y + height - 2);
                        WorldGen.KillTile(x + i + 1, y + height - 2);
                        WorldGen.KillTile(x + i + 2, y + height - 2);
                        WorldGen.KillTile(x + i + 3, y + height - 2);
                        WorldGen.KillTile(x + i, y + height - 3);
                        WorldGen.KillTile(x + i + 1, y + height - 3);
                        WorldGen.KillTile(x + i + 2, y + height - 3);
                        WorldGen.KillTile(x + i + 3, y + height - 3);

                        WorldGen.PlaceObject(x + i + 1, y + height - 2, Laugicality.instance.TileType<ObsidiumBedTile>());
                    }
                    else if (Main.tile[x + i, y + height - 2].type == 0 && Main.tile[x + i + 1, y + height - 2].type == 0 && Main.tile[x + i + 2, y + height - 2].type == 0 && Main.rand.Next(width - 2) == 0)
                    {
                        WorldGen.KillTile(x + i, y + height - 2);
                        WorldGen.KillTile(x + i + 1, y + height - 2);
                        WorldGen.KillTile(x + i + 2, y + height - 2);
                        WorldGen.KillTile(x + i, y + height - 3);
                        WorldGen.KillTile(x + i + 1, y + height - 3);
                        WorldGen.KillTile(x + i + 2, y + height - 3);

                        if (Main.rand.Next(4) == 0)
                            WorldGen.PlaceObject(x + i + 1, y + height - 2, Laugicality.instance.TileType<ObsidiumDresserTile>());
                        else
                        {
                            WorldGen.PlaceObject(x + i + 1, y + height - 2, Laugicality.instance.TileType<ObsidiumTableTile>());
                            if(Main.tile[x + i, y + height - 4].type == 0)
                                WorldGen.PlaceObject(x + i, y + height - 4, Laugicality.instance.TileType<LavaGemCandleTile>());
                        }
                    }
                    else if (Main.tile[x + i, y + height - 2].type == 0 && Main.tile[x + i + 1, y + height - 2].type == 0 && Main.rand.Next(width - 4) == 0)
                    {
                        WorldGen.KillTile(x + i, y + height - 2);
                        WorldGen.KillTile(x + i + 1, y + height - 2);
                        WorldGen.KillTile(x + i, y + height - 3);
                        WorldGen.KillTile(x + i + 1, y + height - 3);

                        if (Main.rand.Next(width * 3) == 0)
                            LaugicalityWorld.PlaceObsidiumChest(x + Main.rand.Next(2, width - 4), y + height - 2, (ushort)Laugicality.instance.TileType<ObsidiumBrick>());
                        else if (Main.rand.Next(width * 3) == 0)
                            WorldGen.AddLifeCrystal(x + i, y + height - 2);
                        else if (Main.rand.Next(2) == 0)
                            WorldGen.PlaceObject(x + i, y + height - 2, Laugicality.instance.TileType<ObsidiumSinkTile>());
                        else
                        {
                            WorldGen.PlaceObject(x + i, y + height - 2, Laugicality.instance.TileType<ObsidiumWorkbenchTile>());
                            if (Main.tile[x + i, y + height - 3].type == 0)
                                WorldGen.PlaceObject(x + i, y + height - 3, Laugicality.instance.TileType<LavaGemCandleTile>());
                        }
                    }
                    else if (Main.tile[x + i, y + height - 2].type == 0 && Main.rand.Next(width - 6) == 0)
                    {
                        if (Main.tile[x + i, y + height - 3].type == 0 && Main.tile[x + i, y + height - 4].type == 0 && Main.rand.Next(2) == 0)
                            WorldGen.PlaceObject(x + i, y + height - 2, Laugicality.instance.TileType<LavaGemLampTile>());
                        else if(Main.tile[x + i, y + 1].type == 0 && Main.tile[x + i, y + 2].type == 0)
                            WorldGen.PlaceObject(x + i, y + 1, Laugicality.instance.TileType<LavaGemLanternTile>());
                    }
                }
            }
        }

        private static void GenerateWalls(int height, int width)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (TileCheckSafe(i + x, j + y))
                    {
                        WorldGen.KillWall(i + x, j + y);
                        WorldGen.PlaceWall(i + x, j + y, wallType);
                    }
                }
            }

            for (int i = 2; i < width - 2; i++)
            {
                if (TileCheckSafe(i + x, y - 1))
                {
                    if(Main.tile[i + x, y - 1].wall == WallID.Lavafall || Main.rand.Next(width / 2) == 0)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            if (TileCheckSafe(i + x, j + y))
                            {
                                WorldGen.KillWall(i + x, j + y);
                                WorldGen.PlaceWall(i + x, j + y, WallID.Lavafall);
                            }
                        }
                    }
                }
            }
        }

        private static void UpdateX(int width)
        {
            if (direction == 1)
                x += width - 1;
            else
                x += Main.rand.Next(-width / 4, width / 4);
        }

        private static void UpdateY(int height)
        {
            if (direction == 2)
                y += height - 1;
        }

        private static void UpdateDoorDir()
        {
            direction = Main.rand.Next(1, 3);
        }

        private static void GenerateBorders(int height, int width)
        {
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    if(TileCheckSafe(i + x, j + y))
                    {
                        if (!nonOverrideBlocks.Contains(Main.tile[i + x, j + y].type) && Main.tile[i + x, j + y].wall != wallType)
                        {
                            WorldGen.KillTile(i + x, j + y);
                            if (i == 0 || j == 0 || i == width - 1 || j == height - 1)
                            {
                                WorldGen.PlaceTile(i + x, j + y, blockType);
                            }
                        }
                    }
                }
            }
            if (TileCheckSafe(x - 1, y) && TileCheckSafe(x + width, y + height - 1))
            {
                if(!nonOverrideBlocks.Contains(Main.tile[x - 1, y].type))
                {
                    WorldGen.KillTile(x - 1, y);
                    WorldGen.PlaceTile(x - 1, y, blockType);
                }

                if (!nonOverrideBlocks.Contains(Main.tile[x - 1, y + height - 1].type))
                {
                    WorldGen.KillTile(x - 1, y + height - 1);
                    WorldGen.PlaceTile(x - 1, y + height - 1, blockType);
                }

                if (!nonOverrideBlocks.Contains(Main.tile[x + width, y].type))
                {
                    WorldGen.KillTile(x + width, y);
                    WorldGen.PlaceTile(x + width, y, blockType);
                }

                if (!nonOverrideBlocks.Contains(Main.tile[x + width, y + height - 1].type))
                {
                    WorldGen.KillTile(x + width, y + height - 1);
                    WorldGen.PlaceTile(x + width, y + height - 1, blockType);
                }
            }
            BuildDoor(height, width);
        }

        private static void BuildDoor(int height, int width)
        {
            if(direction == 1)
            {
                if(TileCheckSafe(x + width - 1, y + height - 2))
                {
                    WorldGen.KillTile(x + width - 1, y + height - 2);
                    WorldGen.KillTile(x + width - 1, y + height - 3);
                    WorldGen.KillTile(x + width - 1, y + height - 4);
                    WorldGen.PlaceObject(x + width - 1, y + height - 3, Laugicality.instance.TileType<ObsidiumDoorClosed>());
                }
            }

            if (direction == 2)
            {
                if (TileCheckSafe(x + width / 2, y + height - 1))
                {
                    WorldGen.KillTile(x + width / 2, y + height - 1);
                    WorldGen.PlaceTile(x + width / 2, y + height - 1, platformType);

                    WorldGen.KillTile(x + width / 2 - 1, y + height - 1);
                    WorldGen.PlaceTile(x + width / 2 - 1, y + height - 1, platformType);

                    WorldGen.KillTile(x + width / 2 + 1, y + height - 1);
                    WorldGen.PlaceTile(x + width / 2 + 1, y + height - 1, platformType);
                }
            }
        }

        private static bool TileCheckSafe(int i, int j)
        {
            if (i > 0 && i < Main.maxTilesX - 1 && j > 0 && j < Main.maxTilesY - 1)
                return true;
            return false;
        }
    }
}
