using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Items;
using Laugicality.Items.Weapons.Mystic;
using Terraria.Utilities;
using System;
using Terraria.World.Generation;
using Terraria.ID;


namespace Laugicality
{
    public abstract class NewTileRunner : ModItem
    {
        public static void OreRunner(int i, int j, double strength, int steps, int type, bool addTile = false, float speedX = 0f, float speedY = 0f, bool noYChange = false, bool overRide = true)
        {
            bool run = true;
            if (TileCheckSafe(i, j))
            {
                if (Main.tile[i, j].wall != 147)
                    run = false;
            }
            if(run)
            {
                double num = strength;
                float num2 = (float)steps;
                Vector2 vector;
                vector.X = (float)i;
                vector.Y = (float)j;
                Vector2 vector2;
                vector2.X = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
                vector2.Y = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
                if (speedX != 0f || speedY != 0f)
                {
                    vector2.X = speedX;
                    vector2.Y = speedY;
                }
                bool flag = type == 368;
                bool flag2 = type == 367;
                while (num > 0.0 && num2 > 0f)
                {
                    if (vector.Y < 0f && num2 > 0f && type == 59)
                    {
                        num2 = 0f;
                    }
                    num = strength * (double)(num2 / (float)steps);
                    num2 -= 1f;
                    int num3 = (int)((double)vector.X - num * 0.5);
                    int num4 = (int)((double)vector.X + num * 0.5);
                    int num5 = (int)((double)vector.Y - num * 0.5);
                    int num6 = (int)((double)vector.Y + num * 0.5);
                    if (num3 < 1)
                    {
                        num3 = 1;
                    }
                    if (num4 > Main.maxTilesX - 1)
                    {
                        num4 = Main.maxTilesX - 1;
                    }
                    if (num5 < 1)
                    {
                        num5 = 1;
                    }
                    if (num6 > Main.maxTilesY - 1)
                    {
                        num6 = Main.maxTilesY - 1;
                    }
                    for (int k = num3; k < num4; k++)
                    {
                        for (int l = num5; l < num6; l++)
                        {
                            if ((double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < strength * 0.5 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.015))
                            {
                                if ((double)l > Main.worldSurface && Main.tile[k, l - 1].wall != 2 && l < Main.maxTilesY - 210 - WorldGen.genRand.Next(3))
                                {
                                    if (l > WorldGen.lavaLine - WorldGen.genRand.Next(0, 4) - 50)
                                    {
                                        if (Main.tile[k, l - 1].wall != 64 && Main.tile[k, l + 1].wall != 64 && Main.tile[k - 1, l].wall != 64 && Main.tile[k, l + 1].wall != 64)
                                        {
                                            WorldGen.PlaceWall(k, l, 15, true);
                                        }
                                    }
                                    else if (Main.tile[k, l - 1].wall != 15 && Main.tile[k, l + 1].wall != 15 && Main.tile[k - 1, l].wall != 15 && Main.tile[k, l + 1].wall != 15)
                                    {
                                        WorldGen.PlaceWall(k, l, 64, true);
                                    }
                                }
                                if (type < 0)
                                {
                                    if (type == -2 && Main.tile[k, l].active() && (l < WorldGen.waterLine || l > WorldGen.lavaLine))
                                    {
                                        Main.tile[k, l].liquid = 255;
                                        if (l > WorldGen.lavaLine)
                                        {
                                            Main.tile[k, l].lava(true);
                                        }
                                    }
                                    Main.tile[k, l].active(false);
                                }
                                else
                                {
                                    if (flag && (double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < strength * 0.3 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.01))
                                    {
                                        WorldGen.PlaceWall(k, l, 180, true);
                                    }
                                    if (flag2 && (double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < strength * 0.3 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.01))
                                    {
                                        WorldGen.PlaceWall(k, l, 178, true);
                                    }
                                    if (overRide || !Main.tile[k, l].active())
                                    {
                                        Tile tile = Main.tile[k, l];
                                        bool flag3 = Main.tileStone[type] && tile.type != 1;
                                        if (!TileID.Sets.CanBeClearedDuringGeneration[(int)tile.type])
                                        {
                                            flag3 = true;
                                        }
                                        ushort type2 = tile.type;
                                        if (type2 <= 147)
                                        {
                                            if (type2 <= 45)
                                            {
                                                if (type2 != 1)
                                                {
                                                    if (type2 == 45)
                                                    {
                                                        goto IL_546;
                                                    }
                                                }
                                                else if (type == 59 && (double)l < Main.worldSurface + (double)WorldGen.genRand.Next(-50, 50))
                                                {
                                                    flag3 = true;
                                                }
                                            }
                                            else if (type2 != 53)
                                            {
                                                if (type2 == 147)
                                                {
                                                    goto IL_546;
                                                }
                                            }
                                            else
                                            {
                                                if (type == 40)
                                                {
                                                    flag3 = true;
                                                }
                                                if ((double)l < Main.worldSurface && type != 59)
                                                {
                                                    flag3 = true;
                                                }
                                            }
                                        }
                                        else if (type2 <= 196)
                                        {
                                            if (type2 - 189 <= 1 || type2 == 196)
                                            {
                                                goto IL_546;
                                            }
                                        }
                                        else if (type2 - 367 > 1)
                                        {
                                            if (type2 - 396 <= 1)
                                            {
                                                flag3 = !TileID.Sets.Ore[type];
                                            }
                                        }
                                        else if (type == 59)
                                        {
                                            flag3 = true;
                                        }
                                        IL_588:
                                        if (!flag3)
                                        {
                                            tile.type = (ushort)type;
                                            goto IL_596;
                                        }
                                        goto IL_596;
                                        IL_546:
                                        flag3 = true;
                                        goto IL_588;
                                    }
                                    IL_596:
                                    if (addTile)
                                    {
                                        Main.tile[k, l].active(true);
                                        Main.tile[k, l].liquid = 0;
                                        Main.tile[k, l].lava(false);
                                    }
                                    if (noYChange && (double)l < Main.worldSurface && type != 59)
                                    {
                                        Main.tile[k, l].wall = 2;
                                    }
                                    if (type == 59 && l > WorldGen.waterLine && Main.tile[k, l].liquid > 0)
                                    {
                                        Main.tile[k, l].lava(false);
                                        Main.tile[k, l].liquid = 0;
                                    }
                                }
                            }
                        }
                    }
                    vector += vector2;
                    if (num > 50.0)
                    {
                        vector += vector2;
                        num2 -= 1f;
                        vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                        vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                        if (num > 100.0)
                        {
                            vector += vector2;
                            num2 -= 1f;
                            vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                            vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                            if (num > 150.0)
                            {
                                vector += vector2;
                                num2 -= 1f;
                                vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                if (num > 200.0)
                                {
                                    vector += vector2;
                                    num2 -= 1f;
                                    vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                    vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                    if (num > 250.0)
                                    {
                                        vector += vector2;
                                        num2 -= 1f;
                                        vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                        vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                        if (num > 300.0)
                                        {
                                            vector += vector2;
                                            num2 -= 1f;
                                            vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                            vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                            if (num > 400.0)
                                            {
                                                vector += vector2;
                                                num2 -= 1f;
                                                vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                if (num > 500.0)
                                                {
                                                    vector += vector2;
                                                    num2 -= 1f;
                                                    vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                    vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                    if (num > 600.0)
                                                    {
                                                        vector += vector2;
                                                        num2 -= 1f;
                                                        vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                        vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                        if (num > 700.0)
                                                        {
                                                            vector += vector2;
                                                            num2 -= 1f;
                                                            vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            if (num > 800.0)
                                                            {
                                                                vector += vector2;
                                                                num2 -= 1f;
                                                                vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                                vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                                if (num > 900.0)
                                                                {
                                                                    vector += vector2;
                                                                    num2 -= 1f;
                                                                    vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                                    vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    if (vector2.X > 1f)
                    {
                        vector2.X = 1f;
                    }
                    if (vector2.X < -1f)
                    {
                        vector2.X = -1f;
                    }
                    if (!noYChange)
                    {
                        vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                        if (vector2.Y > 1f)
                        {
                            vector2.Y = 1f;
                        }
                        if (vector2.Y < -1f)
                        {
                            vector2.Y = -1f;
                        }
                    }
                    else if (type != 59 && num < 3.0)
                    {
                        if (vector2.Y > 1f)
                        {
                            vector2.Y = 1f;
                        }
                        if (vector2.Y < -1f)
                        {
                            vector2.Y = -1f;
                        }
                    }
                    if (type == 59 && !noYChange)
                    {
                        if ((double)vector2.Y > 0.5)
                        {
                            vector2.Y = 0.5f;
                        }
                        if ((double)vector2.Y < -0.5)
                        {
                            vector2.Y = -0.5f;
                        }
                        if ((double)vector.Y < Main.rockLayer + 100.0)
                        {
                            vector2.Y = 1f;
                        }
                        if (vector.Y > (float)(Main.maxTilesY - 300))
                        {
                            vector2.Y = -1f;
                        }
                    }
                }
            }
            
        }


        private static bool TileCheckSafe(int i, int j)
        {
            if (i > 0 && i < Main.maxTilesX && j > 0 && j < Main.maxTilesY)
                return true;
            return false;
        }
    }
}