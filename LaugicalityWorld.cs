using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Laugicality.Structures;
using Terraria.DataStructures;

namespace Laugicality
{
    public class LaugicalityWorld : ModWorld
    {
        public static bool downedAnnihilator = false;
        public static bool downedSlybertron = false;
        public static bool downedSteamTrain = false;
        public static bool downedDuneSharkron = false;
        public static bool downedHypothema = false;
        public static bool downedRagnar = false;
        public static bool obsidiumHeart = false;
        public static bool downedRocks = false;
        public static bool downedEtheria = false; 
        public static bool downedTrueEtheria = false;
        public static bool downedDioritus = false;
        public static bool downedAndesia = false;
        public static bool downedAnDio = false;
        public static int obsidiumTiles = 0;
        public static int power = 0;
        public static int zWarudo = 240; //Duration
        public static bool obEnf = false; //obsidiumEnfused
        public static bool bysmal = false;
        public static int obsidiumPosition = 0;

        public static int sizeMult = (int)(Math.Floor(Main.maxTilesX / 4200f)); //Small = 2; Medium = ~3; Large = 4;

        public static int zawarudo = 0;
        public static int dungeonSide = 1;

        public override void Initialize()
        {
            sizeMult = (int)(Math.Floor(Main.maxTilesX / 4200f));
            power = 0;
            zWarudo = 240;
            downedAnnihilator = false;
            downedSlybertron = false;
            downedSteamTrain = false;
            downedDuneSharkron = false;
            downedHypothema = false;
            downedRagnar = false;
            downedRocks = false;
            downedEtheria = false;
            downedTrueEtheria = false;
            downedDioritus = false;
            downedAndesia = false;
            downedAnDio = false;
            zawarudo = 0;
            obEnf = false;
            obsidiumHeart = false;
            bysmal = false;
            obsidiumPosition = 0;
        }
        
        public override void PostUpdate()
        {
            if(obEnf == false && downedRagnar)
            {
                obEnf = true;
                Main.NewText("Fury runs through the Obsidium Caverns.", 150, 50, 50);
            }
            if (zawarudo > 0)
            {
                zawarudo--;
            }
            zWarudo = 240;

            
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            bool obs = false;
            int pwr = 0;
            if (downedAnnihilator) downed.Add("annihilator");
            if (downedSlybertron) downed.Add("slybertron");
            if (downedSteamTrain) downed.Add("steamtrain");
            if (downedDuneSharkron) downed.Add("dunesharkron");
            if (downedHypothema) downed.Add("hypothema");
            if (downedRagnar) downed.Add("ragnar");
            if (downedRocks) downed.Add("rocks");
            if (downedTrueEtheria) downed.Add("trueetheria");
            if (downedDioritus) downed.Add("dioritus");
            if (downedAndesia) downed.Add("andesia");
            if (downedAnDio) downed.Add("andio");
            if (obEnf) obs = true;
            pwr = power;

            return new TagCompound {
                {"downed", downed},
                {"etherial", downedEtheria},
                {"obsidium", obs },
                {"obsidiumHeart", obsidiumHeart },
                {"bysmal", bysmal },
                {"power", pwr }
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedAnnihilator = downed.Contains("annihilator");
            downedSlybertron = downed.Contains("slybertron");
            downedSteamTrain = downed.Contains("steamtrain");
            downedDuneSharkron = downed.Contains("dunesharkron");
            downedHypothema = downed.Contains("hypothema");
            downedRagnar = downed.Contains("ragnar");
            downedRocks = downed.Contains("rocks");
            downedTrueEtheria = downed.Contains("trueetheria");
            downedDioritus = downed.Contains("dioritus");
            downedAndesia = downed.Contains("andesia");
            downedAnDio = downed.Contains("andio");
            obEnf = tag.GetBool("obsidium");
            downedEtheria = tag.GetBool("etherial");
            obsidiumHeart = tag.GetBool("obsidiumHeart");
            bysmal = tag.GetBool("bysmal");
            power = tag.GetInt("power");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedAnnihilator = flags[0];
                downedSlybertron = flags[1];
                downedSteamTrain = flags[2];
                downedDuneSharkron = flags[3];
                downedHypothema = flags[4];
                downedRagnar = flags[5];
                downedEtheria = flags[6];
                downedTrueEtheria = flags[7];

                BitsByte flags2 = reader.ReadByte();
                downedRocks = flags2[0];
                downedDioritus = flags2[1];
                downedAndesia = flags2[2];
                downedAnDio = flags2[3];
                obEnf = flags2[4];
                obsidiumHeart = flags2[5];
                bysmal = flags2[6];
            }
            else
            {
                ErrorLogger.Log("Enigma: Unknown loadVersion: " + loadVersion);
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedAnnihilator;
            flags[1] = downedSlybertron;
            flags[2] = downedSteamTrain;
            flags[3] = downedDuneSharkron;
            flags[4] = downedHypothema;
            flags[5] = downedRagnar;
            flags[6] = downedEtheria;
            flags[7] = downedTrueEtheria;

            BitsByte flags2 = new BitsByte();
            flags2[0] = downedRocks;
            flags2[1] = downedDioritus;
            flags2[2] = downedAndesia;
            flags2[3] = downedAnDio;
            flags2[4] = obEnf;
            flags2[5] = obsidiumHeart;
            flags2[6] = bysmal;
            writer.Write(flags);
            writer.Write(flags2);

            int zawarudoSync = zawarudo;
            writer.Write(zawarudoSync);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedAnnihilator = flags[0];
            downedSlybertron = flags[1];
            downedSteamTrain = flags[2];
            downedDuneSharkron = flags[3];
            downedHypothema = flags[4];
            downedRagnar = flags[5];
            downedEtheria = flags[6];
            downedTrueEtheria = flags[7];
            
            BitsByte flags2 = reader.ReadByte();
            downedRocks = flags2[0];
            downedDioritus = flags2[1];
            downedAndesia = flags2[2];
            downedAnDio = flags2[3];
            obEnf = flags2[4];
            obsidiumHeart = flags2[5];
            bysmal = flags2[6];
            int zawarudoSync = reader.ReadByte();
            if(zawarudoSync < zawarudo)
                zawarudo = zawarudoSync;
        }

        public override void ResetNearbyTileEffects()
        {
            obsidiumTiles = 0;
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            obsidiumTiles = tileCounts[56] + tileCounts[mod.TileType("ObsidiumRock")] +  tileCounts[mod.TileType("Lycoris")] + tileCounts[mod.TileType("Radiata")];
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Larva"));
            int xO = Main.maxTilesX / 2;
            int yO = (int)(Main.maxTilesY * .7f);
            tasks.Insert(genIndex + 1, new PassLegacy("Generating Obsidian Cavern", delegate (GenerationProgress progress)
            {
                progress.Message = "Obsidification";
                GenerateObsidium(xO, yO);
            }));

            int genIndex2 = tasks.FindIndex(genpass => genpass.Name.Equals("Larva"));
            tasks.Insert(genIndex2 + 2, new PassLegacy("Obsidium Features", delegate (GenerationProgress progress)
            {
                progress.Message = "Obsidium Core";
                GenerateObsidiumStructures(xO, yO);
            }));
        }

        private void GenerateObsidium(int xO, int yO)
        {
            CreateObsidiumRock(xO, yO);

            CreateObsidiumCaverns(xO, yO);

            GenerateObsidiumFeatures(xO, yO);
        }

        private void CreateObsidiumRock(int xO, int yO)
        {
            for (int i = (int)(-225 * sizeMult); i <= (int)(225 * sizeMult); i++)
            {
                for (int j = (int)(-275 * sizeMult); j <= (int)(275 * sizeMult); j++)
                {
                    CreateObsidiumTileCheck(xO, yO, i, j);
                }
            }
        }

        private void CreateObsidiumTileCheck(int xO, int yO, int i, int j)
        {
            if (TileCheckSafe(xO + i, yO + j))
            {
                if (Main.tile[xO + i, yO + j].wall != WallID.LihzahrdBrick && Main.tile[xO + i, yO + j].type != TileID.LihzahrdBrick)
                {
                    if (j < -(int)(150 * sizeMult))
                    {
                        GenerateCavernTop(xO, yO, i, j);
                    }
                    else if (j < 0)
                    {
                        GenerateCavernTopMid(xO, yO, i, j);
                    }
                    else if (j < (int)(100 * sizeMult))
                    {
                        GenerateCavernMid(xO, yO, i, j);
                    }
                    else if (yO + j < Main.maxTilesY - 200)
                    {
                        GenerateCavernBottom(xO, yO, i, j);
                    }
                }
            }
        }

        private void GenerateCavernTop(int xO, int yO, int i, int j)
        {
            int sign = 1;
            if (i != 0)
                sign = (int)(Math.Abs(i) / i);
            if (Distance(xO + sign * 100 * sizeMult, yO - 150 * sizeMult, xO + i, yO + j) < 100 * sizeMult)
            {
                PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"), mod.WallType("ObsidiumRockWall"));
            }
            else if (Distance(xO + sign * 100 * sizeMult, yO - (int)(150 * sizeMult), xO + i, yO + j) < 100 * sizeMult + 6)
            {
                if (Main.rand.Next(6) < 100 * sizeMult + 6 - Distance(xO + sign * 100 * sizeMult, yO - 150 * sizeMult, xO + i, yO + j))
                {
                    PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"));
                }
            }
        }

        private void GenerateCavernTopMid(int xO, int yO, int i, int j)
        {
            if (Distance(xO + i, yO + j, xO, yO) < (int)(150 * sizeMult - (int)(j * 2 / 3)))
            {
                PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"), mod.WallType("ObsidiumRockWall"));
            }
            else if (Distance(xO + i, yO + j, xO, yO) < (int)(150 * sizeMult - (int)(j * 2 / 3)) + 6)
            {
                if (Main.rand.Next(6) < -Distance(xO + i, yO + j, xO, yO) + 6 + (int)(150 * sizeMult - (int)(j * 2 / 3)))
                {
                    PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"));
                }
            }
        }

        private void GenerateCavernMid(int xO, int yO, int i, int j)
        {
            if (Distance(xO + i, yO + j, xO, yO) < (int)(150 * sizeMult - .47 * j))
            {
                PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"), mod.WallType("ObsidiumRockWall"));
            }
            else if (Distance(xO + i, yO + j, xO, yO) < (int)(150 * sizeMult - .47 * j) + 6)
            {
                if (Main.rand.Next(6) < -Distance(xO + i, yO + j, xO, yO) + 6 + (int)(150 * sizeMult - .47 * j))
                {
                    PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"));
                }
            }
        }

        private void GenerateCavernBottom(int xO, int yO, int i, int j)
        {
            int radius = (Main.maxTilesY - 200) - (yO + (int)(100 * sizeMult));
            if (i < 0 && i > -radius)
            {
                if (Distance(xO + i, yO + j, xO - (int)(25 * sizeMult) - radius, yO + (int)(100 * sizeMult)) > radius)
                {
                    PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"), mod.WallType("ObsidiumRockWall"));
                }
                else if (Distance(xO + i, yO + j, xO - (int)(25 * sizeMult) - radius, yO + (int)(100 * sizeMult)) < radius + 6)
                {
                    if (Main.rand.Next(6) < Distance(xO + i, yO + j, xO - (int)(25 * sizeMult) - radius, yO + (int)(100 * sizeMult)) - 6 - radius)
                    {
                        PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"));
                    }
                }
            }
            else if (i >= 0 && i < radius + 1)
            {
                if (Distance(xO + i, yO + j, xO + (int)(25 * sizeMult) + radius, yO + (int)(100 * sizeMult)) > radius)
                {
                    PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"), mod.WallType("ObsidiumRockWall"));
                }
                else if (Distance(xO + i, yO + j, xO + (int)(25 * sizeMult) + radius, yO + (int)(100 * sizeMult)) < radius + 6)
                {
                    if (Main.rand.Next(6) < Distance(xO + i, yO + j, xO + (int)(25 * sizeMult) + radius, yO + (int)(100 * sizeMult)) - 6 - radius)
                    {
                        PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"));
                    }
                }
            }
        }

        private void CreateObsidiumCaverns(int xO, int yO)
        {
            GenerateCave(xO, yO, 100 * sizeMult, (ushort)TileID.BubblegumBlock, 9 * sizeMult, 15 * sizeMult, 3 * sizeMult);
            GenerateCave(xO, yO, 50 * sizeMult, (ushort)TileID.BubblegumBlock, 16, 25, 140 * sizeMult);
            GenerateCave(xO, yO, 50 * sizeMult, (ushort)TileID.BubblegumBlock, 25, 30, 25 * sizeMult);

            for (int i = (int)(-250 * sizeMult); i <= (int)(250 * sizeMult); i++)
            {
                for (int j = (int)(-325 * sizeMult); j <= (int)(325 * sizeMult); j++)
                {
                    if (TileCheckSafe(xO + i, yO + j))
                    {
                        if (Main.tile[xO + i, yO + j].type == (ushort)249)
                        {
                            WorldGen.KillTile(xO + i, yO + j);
                        }
                    }
                }
            }
        }


        private void GenerateObsidiumFeatures(int xO, int yO)
        {
            GenerateFeature(xO, yO, 25, (ushort)mod.TileType("Radiata"), 2, 6, 180 * sizeMult);
            GenerateFeature(xO, yO, 50, (ushort)mod.TileType("Lycoris"), 3, 6, 140 * sizeMult);
            GenerateFeature(xO, yO, 75, (ushort)mod.TileType("Radiata"), 3, 5, 180 * sizeMult);
            GenerateFeature(xO, yO, 75, (ushort)mod.TileType("Lycoris"), 3, 5, 140 * sizeMult);
            GenerateFeature(xO, yO, 100, (ushort)mod.TileType("ObsidiumBrick"), 12, 18, 50 * sizeMult);
            GenerateFeature(xO, yO, 300, (ushort)mod.TileType("ObsidiumBrick"), 6, 14, 8);
        }

        private void GenerateCave(int xO, int yO, int numSteps, ushort tileType, int minSize, int maxSize, int length)
        {
            for (int k = 0; k < numSteps * sizeMult; k++)
            {
                int x = xO + Main.rand.Next(-200 * sizeMult, 200 * sizeMult);
                int y = yO + Main.rand.Next(-250 * sizeMult, 250 * sizeMult);
                if (Main.tile[x, y].type == (ushort)mod.TileType("ObsidiumRock") || (Main.tile[x, y].active() == false && Main.tile[x, y].wall == mod.WallType("ObsidiumRockWall")) || Main.tile[x, y].type == (ushort)mod.TileType("Lycoris") || Main.tile[x, y].type == (ushort)mod.TileType("Radiata"))
                    WorldGen.TileRunner(x, y, Main.rand.Next(minSize, maxSize), length, tileType, false, 0f, 0f, false, true);
            }
        }

        private void GenerateFeature(int xO, int yO, int numSteps, ushort tileType, int minSize, int maxSize, int length)
        {
            for (int k = 0; k < numSteps * sizeMult; k++)
            {
                int x = xO + Main.rand.Next(-225 * sizeMult, 225 * sizeMult);
                int y = yO + Main.rand.Next(-275 * sizeMult, 275 * sizeMult);
                if (Main.tile[x, y].type == (ushort)mod.TileType("ObsidiumRock") || (Main.tile[x, y].active() == false && Main.tile[x, y].wall == mod.WallType("ObsidiumRockWall")) || Main.tile[x, y].type == (ushort)mod.TileType("Lycoris") || Main.tile[x, y].type == (ushort)mod.TileType("Radiata"))
                    WorldGen.TileRunner(x, y, Main.rand.Next(minSize, maxSize), length, tileType, false, 0f, 0f, false, true);
            }
        }

        private void GenerateObsidiumStructures(int xO, int yO)
        {
            DecorationStructures(xO, yO);
            
            LootStructures(xO, yO);
            
            HeartWorld.HeartGen(xO - 60, yO - 90);
        }

        private void DecorationStructures(int xO, int yO)
        {
            int s = Main.rand.Next(7);
            int structX = xO - 225 * sizeMult + Main.rand.Next(225 * sizeMult * 2);
            int structY = yO - 275 * sizeMult + Main.rand.Next(275 * sizeMult / 2);

            for (int q = 0; q < 7 * sizeMult; q++)
            {
                s = GenerateDecorationStructure(s, structX, structY);
                Point16 newStructurePosition = new Point16(structX, structY);
                newStructurePosition = AlterStructureLocation(xO, yO, structX, structY);
                structX = newStructurePosition.X;
                structY = newStructurePosition.Y;
            }
        }

        private int GenerateDecorationStructure(int s, int structX, int structY)
        {
            if (TileCheckSafe(structX, structY))
            {
                if (Main.tile[structX, structY].wall == (ushort)mod.WallType("ObsidiumRockWall"))
                {
                    bool mirrored = false;
                    if (Main.rand.Next(2) == 0)
                        mirrored = true;

                    PickDecorationStructure(s, structX, structY, mirrored);

                    s++;
                    if (s >= 7)
                        s = 0;
                }
            }
            return s;
        }

        private Point16 AlterStructureLocation(int xO, int yO, int structX, int structY)
        {
            structX += Main.rand.Next(225 * sizeMult);
            if (structX > xO + 225 * sizeMult)
            {
                structX -= 225 * sizeMult * 2;
                structY += Main.rand.Next(275 * sizeMult / 4, 275 * sizeMult / 2);
                if (structY > yO + 275 * sizeMult)
                {
                    structY -= 275 * sizeMult * 2;
                }
            }
            Point16 structurePosition = new Point16(structX, structY);
            return structurePosition;
        }

        private void PickDecorationStructure(int s, int structX, int structY, bool mirrored)
        {
            switch (s)
            {
                case 0:
                    TreeRuin.StructureGen(structX, structY, mirrored);
                    break;
                case 1:
                    PetrifiedTitans.StructureGen(structX, structY, mirrored);
                    break;
                case 2:
                    ObsidiumChalice.StructureGen(structX, structY, mirrored);
                    break;
                case 3:
                    LycorisCave.StructureGen(structX, structY, mirrored);
                    break;
                case 4:
                    LavaCave1.StructureGen(structX, structY, mirrored);
                    break;
                case 5:
                    LavaCave2.StructureGen(structX, structY, mirrored);
                    break;
                case 6:
                    LavaCave3.StructureGen(structX, structY, mirrored);
                    break;
                default:
                    LavaCave1.StructureGen(structX, structY, mirrored);
                    break;
            }
        }

        private void LootStructures(int xO, int yO)
        {
            int s = Main.rand.Next(3);
            int structX = xO - 225 * sizeMult + Main.rand.Next(225 * sizeMult * 2);
            int structY = yO - 275 * sizeMult + Main.rand.Next(275 * sizeMult / 2);

            for (int q = 0; q < 5 * sizeMult; q++)
            {
                s = GenerateLootStructure(s, structX, structY);
                Point16 newStructurePosition = new Point16(structX, structY);
                newStructurePosition = AlterStructureLocation(xO, yO, structX, structY);
                structX = newStructurePosition.X;
                structY = newStructurePosition.Y;
            }
        }

        private int GenerateLootStructure(int s, int structX, int structY)
        {
            if (TileCheckSafe(structX, structY))
            {
                if (Main.tile[structX, structY].wall == (ushort)mod.WallType("ObsidiumRockWall"))
                {
                    bool mirrored = false;
                    if (Main.rand.Next(2) == 0)
                        mirrored = true;

                    PickLootStructure(s, structX, structY, mirrored);
                    s++;
                    if (s >= 3)
                        s = 0;
                }
            }
            return s;
        }

        private void PickLootStructure(int s, int structX, int structY, bool mirrored)
        {
            switch (s)
            {
                case 0:
                    LivingLycoris.StructureGen(structX, structY, mirrored);
                    break;
                case 1:
                    ObsidiumHouse1.StructureGen(structX, structY, mirrored);
                    break;
                case 2:
                    ObsidiumHouse2.StructureGen(structX, structY, mirrored);
                    break;
            }
        }
        
        
        private void PlaceTile(int x, int y, int tileType)
        {
            WorldGen.KillTile(x, y);
            WorldGen.KillWall(x, y);
            Main.tile[x, y].liquid = 0;
            WorldGen.PlaceTile(x, y, tileType, true, true);
        }

        private void PlaceTile(int x, int y, int tileType, int wallType)
        {
            WorldGen.KillTile(x, y);
            WorldGen.KillWall(x, y);
            Main.tile[x, y].liquid = 0;
            WorldGen.PlaceTile(x, y, tileType, true, true);
            WorldGen.PlaceWall(x, y, wallType, true);
        }

        private static bool TileCheckSafe(int i, int j)
        {
            if (i > 0 && i < Main.maxTilesX && j > 0 && j < Main.maxTilesY)
                return true;
            return false;
        }

        private float Distance(int x1, int y1, int x2, int y2)
        {
            return (float)(Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
        }
        
        public static void PlaceObsidiumChest(int x, int y, ushort floorType)
        {
            ClearSpaceForChest(x, y, floorType);
            int chestIndex = WorldGen.PlaceChest(x, y, (ushort)Laugicality.instance.TileType("ObsidiumChest"), false, 0);

            int specialItem = GetObsidiumLoot();
            obsidiumPosition++;
            int[] oreLoot = GetOreLoot();
            int[] potionLoot = GetPotionLoot();
            int[] money = GetMoneyLoot();
            int[] miscLoot = GetMiscLoot();

            int[] itemsToPlaceInChests = new int[] { specialItem, oreLoot[0], potionLoot[0], money[0], miscLoot[0] };
            int[] itemCounts = new int[] { 1, oreLoot[1], potionLoot[1], money[1], miscLoot[1] };

            FillChest(chestIndex, itemsToPlaceInChests, itemCounts);
        }

        private static void ClearSpaceForChest(int x, int y, ushort floorType)
        {
            WorldGen.KillTile(x, y);
            WorldGen.KillTile(x, y - 1);
            WorldGen.KillTile(x + 1, y - 1);
            WorldGen.KillTile(x + 1, y);
            WorldGen.PlaceTile(x + 1, y + 1, floorType, true, true);
            WorldGen.PlaceTile(x, y + 1, floorType, true, true);
            Main.tile[x, y].liquid = 0;
            Main.tile[x + 1, y].liquid = 0;
            Main.tile[x, y + 1].liquid = 0;
            Main.tile[x + 1, y + 1].liquid = 0;
        }

        private static int GetObsidiumLoot()
        {
            int[] obsidiumLoot = new int[] { Laugicality.instance.ItemType("Eruption"), Laugicality.instance.ItemType("ObsidiumLily"), Laugicality.instance.ItemType("MagmaHeart"), Laugicality.instance.ItemType("FireDust"), Laugicality.instance.ItemType("CrystalizedMagma"), };
            
            if (obsidiumPosition < obsidiumLoot.GetLength(0))
                return obsidiumLoot[obsidiumPosition];
            else
            {
                obsidiumPosition = 0;
                return obsidiumLoot[obsidiumPosition];
            }
        }

        private static int[] GetOreLoot()
        {
            int[] oreLoot = new int[] { ItemID.GoldBar, ItemID.PlatinumBar, ItemID.TungstenBar, ItemID.SilverBar};
            int orePos = Main.rand.Next(oreLoot.GetLength(0));
            int oreCount = Main.rand.Next(6, 16);
            int[] ore = { 0, 0 };
            ore[0] = oreLoot[orePos];
            ore[1] = oreCount;
            return ore;
        }

        private static int[] GetPotionLoot()
        {
            int[] potLoot = new int[] { Laugicality.instance.ItemType("MysticPowerPotion"), Laugicality.instance.ItemType("JumpBoostPotion"), ItemID.InfernoPotion, ItemID.LifeforcePotion, ItemID.WrathPotion };
            int potPos = Main.rand.Next(potLoot.GetLength(0));
            int potCount = Main.rand.Next(2, 5);
            int[] pot = { 0, 0 };
            pot[0] = potLoot[potPos];
            pot[1] = potCount;
            return pot;
        }

        private static int[] GetMoneyLoot()
        {
            int monType = 0;
            int monCount = 0;
            if (Main.rand.Next(2) == 0)
            {
                monType = ItemID.GoldCoin;
                monCount = Main.rand.Next(1, 4);
            }
            else
            {
                monType = ItemID.SilverCoin;
                monCount = Main.rand.Next(60, 99);
            }
            int[] mon = {0 , 0};
            mon[0] = monType;
            mon[1] = monCount;
            return mon;
        }
        
        private static int[] GetMiscLoot()
        {
            int[] mscLoot = new int[] { Laugicality.instance.ItemType("LavaGem"), Laugicality.instance.ItemType("ArcaneShard"), Laugicality.instance.ItemType("LavaGem"), Laugicality.instance.ItemType("RubrumDust"), Laugicality.instance.ItemType("AlbusDust"), Laugicality.instance.ItemType("VerdiDust") };
            int mscPos = Main.rand.Next(mscLoot.GetLength(0));
            int mscCount = Main.rand.Next(2, 6);
            int[] msc = { 0, 0 };
            msc[0] = mscLoot[mscPos];
            msc[1] = mscCount;
            return msc;
        }

        private static void FillChest(int chestIndex, int[] itemsToPlaceInChests, int[] itemCounts)
        {
            if (chestIndex < Main.chest.GetLength(0) && chestIndex >= 0)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest != null)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == 0 && inventoryIndex < itemsToPlaceInChests.GetLength(0))
                        {
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInChests[inventoryIndex]);
                            chest.item[inventoryIndex].stack = itemCounts[inventoryIndex];
                        }
                    }
                }
            }
        }
    }
}