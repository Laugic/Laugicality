using SubworldLibrary;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.World.Generation;
using System;
using Laugicality.Tiles;
using Microsoft.Xna.Framework;
using Laugicality.Walls;

namespace Laugicality.Pitdrop
{
    public class PitdropWorld : Subworld
    {
        public override int width => 800;
        public override int height => 2400;
        public Random rand = new Random();

        private static int segment = 80;

        public float DIFFICULTY = 32f;

        public override List<GenPass> tasks => new List<GenPass>()
        {
            new SubworldGenPass(progress =>
            {
                Fill(progress);
            }),
            new SubworldGenPass(progress =>
            {
                GenPits(progress);
            })
        };

        private void Fill(GenerationProgress progress)
        {
            progress.Message = "Fill";
            Main.worldSurface = Main.maxTilesY - segment;
            Main.rockLayer = Main.maxTilesY;
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    progress.Set((j + i * Main.maxTilesY) / (float)(Main.maxTilesX * Main.maxTilesY));
                    Main.tile[i, j].active(true);
                    Main.tile[i, j].type = (ushort)ModContent.TileType<ObsidiumRock>();
                }
            }
        }

        private void GenPits(GenerationProgress progress)
        {
            progress.Message = "Building Rooms";
            rand = new Random();
            Main.spawnTileX = Main.maxTilesX / 2 - segment / 2 + 7;
            Main.spawnTileY = segment * 4 + 12;
            GenPit(Main.maxTilesX / 2 - segment / 2, segment * 4, rand.Next(12, 16));
        }

        private void GenPit(float startX, int startY, float startWidth)
        {
            #region var inits
            float width = startWidth;
            float x = startX;
            int y = startY;
            int slantDir = 0;
            if (x < segment * 2)
                slantDir = 1;
            else if (x > Main.maxTilesX - segment * 2)
                slantDir = -1;
            else
                slantDir = -1 + rand.Next(3) * 2;
            int height = rand.Next(segment, segment * 2);
            float slope = (float)(rand.NextDouble() / 2 + rand.NextDouble() / 2) * DIFFICULTY;
            float grow = .98f + (float)rand.NextDouble() * .04f;
            #endregion

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < (int)width; j++)
                {
                    if (TileCheckSafe((int)x + j, y + i))
                        YeetTile((int)x + j, y + i);
                }

                x += slantDir * slope / height;
                x += width / 2;
                width *= grow;
                width = Math.Max(Math.Min(width, segment / 4), segment / 8); //restricting size of tunnel
                x -= width / 2;
            }
            if (y + height < Main.maxTilesY - segment * 3)
                GenPit(x, y + height, width);
        }

        public void YeetTile(int x, int y)
        {
            WorldGen.KillTile(x, y);
            if((x % 3 == 0 && x % 5 == 0) || x % 4 == 0)
                WorldGen.PlaceWall(x, y, WallID.Lavafall);
            WorldGen.PlaceWall(x, y, ModContent.WallType<ObsidiumRockWall>());
        }

        ///Making sure tiles arent out of bounds
        private static bool TileCheckSafe(int i, int j)
        {
            if (i > 1 && i < Main.maxTilesX - 1 && j > 1 && j < Main.maxTilesY - 1)
                return true;
            return false;
        }
    }
}