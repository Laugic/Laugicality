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
using Laugicality.Structures;

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

        /// <summary>
        /// Refactor This to be short
        /// </summary>
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
            if (downedEtheria)
            {
                for(int k = 0; k < 8; k++)
                {
                    Player player = Main.player[k];
                    NPC.NewNPC((int)player.position.X - 160, (int)player.position.Y - 160, mod.NPCType("EtherialBkg"));
                    bool music = true;
                    foreach (NPC npc in Main.npc)
                        if (npc.boss == true)
                            music = false;
                    if(music)
                        NPC.NewNPC((int)player.position.X - 160, (int)player.position.Y - 160, mod.NPCType("EtherialMusic"));
                }
            }
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
        //public override void PostWorldGen()
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
                GenerateObsidiumStructure(xO, yO);
            }));


        }

        /// <summary>
        /// Refactor This to be short
        /// </summary>
        private void GenerateObsidiumStructure(int xO, int yO)
        {
//progress.Message = "Obsidium Core";
            int numStructs = 7 * sizeMult;
            int structX = xO;
            int structY = yO + 35 * sizeMult;
            //Deco Structs
            numStructs = 7 * sizeMult;
            int q = 0;
            int s = Main.rand.Next(7);
            bool mirrored = false;
            structX = xO - 225 * sizeMult + Main.rand.Next(225 * sizeMult * 2);
            structY = yO - 275 * sizeMult + Main.rand.Next(275 * sizeMult / 2);
            while (q < numStructs)
            {
                //structX = xO - 225 * sizeMult + Main.rand.Next(225 * sizeMult * 2);
                //structY = yO - 275 * sizeMult + Main.rand.Next(275 * sizeMult * 2);
                if (TileCheckSafe(structX, structY))
                {
                    if (Main.tile[structX, structY].wall == (ushort) mod.WallType("ObsidiumRockWall"))
                    {
                        if (Main.rand.Next(2) == 0)
                            mirrored = true;
                        else
                            mirrored = false;
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

                        s++;
                        if (s >= 7)
                            s = 0;
                    }
                }

                q++;
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
            }

            //Loot Structs
            numStructs = 5 * sizeMult;
            q = 0;
            s = Main.rand.Next(3);
            structX = xO - 225 * sizeMult + Main.rand.Next(225 * sizeMult * 2);
            structY = yO - 275 * sizeMult + Main.rand.Next(275 * sizeMult / 2);
            while (q < numStructs)
            {
                if (TileCheckSafe(structX, structY))
                {
                    if (Main.tile[structX, structY].wall == (ushort) mod.WallType("ObsidiumRockWall"))
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

                        s++;
                        if (s >= 3)
                            s = 0;
                    }
                }

                q++;
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
            }

            //Obsidium Heart
            int heartX = xO - 60;
            int heartY = yO - 90;
            HeartWorld.HeartGen(heartX, heartY);
        }

        /// <summary>
        /// Refactor This to be short
        /// </summary>
        private void GenerateObsidium(int xO, int yO)
        {
            for (int i = (int) (-225 * sizeMult); i <= (int) (225 * sizeMult); i++)
            {
                for (int j = (int) (-275 * sizeMult); j <= (int) (275 * sizeMult); j++)
                {
                    if (TileCheckSafe(xO + i, yO + j))
                    {
                        if (Main.tile[xO + i, yO + j].wall != 87 && Main.tile[xO + i, yO + j].type != 226
                        ) //Checking to not override the temple & the thorium blood chamber
                        {
                            if (j < -(int) (150 * sizeMult)) //Top Bumps of the Heart (Semi-Circles)
                            {
                                if (i < 0)
                                {
                                    if (Distance(xO - (int) (100 * sizeMult), yO - (int) (150 * sizeMult), xO + i, yO + j) <
                                        (int) (100 * sizeMult))
                                    {
                                        PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"),
                                            mod.WallType("ObsidiumRockWall"));
                                    }
                                    else if (Distance(xO - (int) (100 * sizeMult), yO - (int) (150 * sizeMult), xO + i,
                                                 yO + j) < (int) (100 * sizeMult) + 6)
                                    {
                                        if (Main.rand.Next(6) < (int) (100 * sizeMult) + 6 -
                                            Distance(xO - (int) (100 * sizeMult), yO - (int) (150 * sizeMult), xO + i, yO + j))
                                        {
                                            PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"));
                                        }
                                    }
                                }
                                else
                                {
                                    if (Distance(xO + (int) (100 * sizeMult), yO - (int) (150 * sizeMult), xO + i, yO + j) <
                                        (int) (100 * sizeMult))
                                    {
                                        PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"),
                                            mod.WallType("ObsidiumRockWall"));
                                    }
                                    else if (Distance(xO + (int) (100 * sizeMult), yO - (int) (150 * sizeMult), xO + i,
                                                 yO + j) < (int) (100 * sizeMult) + 6)
                                    {
                                        if (Main.rand.Next(6) <
                                            -Distance(xO + (int) (100 * sizeMult), yO - (int) (150 * sizeMult), xO + i,
                                                yO + j) + 6 + (int) (100 * sizeMult))
                                        {
                                            PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"));
                                        }
                                    }
                                }
                            }
                            else if (j < 0)
                            {
                                if (Distance(xO + i, yO + j, xO, yO) < (int) (150 * sizeMult - (int) (j * 2 / 3)))
                                {
                                    PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"), mod.WallType("ObsidiumRockWall"));
                                }
                                else if (Distance(xO + i, yO + j, xO, yO) < (int) (150 * sizeMult - (int) (j * 2 / 3)) + 6)
                                {
                                    if (Main.rand.Next(6) < -Distance(xO + i, yO + j, xO, yO) + 6 +
                                        (int) (150 * sizeMult - (int) (j * 2 / 3)))
                                    {
                                        PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"));
                                    }
                                }
                            }
                            else if (j < (int) (100 * sizeMult))
                            {
                                if (Distance(xO + i, yO + j, xO, yO) < (int) (150 * sizeMult - .47 * j))
                                {
                                    PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"), mod.WallType("ObsidiumRockWall"));
                                }
                                else if (Distance(xO + i, yO + j, xO, yO) < (int) (150 * sizeMult - .47 * j) + 6)
                                {
                                    if (Main.rand.Next(6) <
                                        -Distance(xO + i, yO + j, xO, yO) + 6 + (int) (150 * sizeMult - .47 * j))
                                    {
                                        PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"));
                                    }
                                }
                            }
                            else if (yO + j < Main.maxTilesY - 200)
                            {
                                int radius = (Main.maxTilesY - 200) - (yO + (int) (100 * sizeMult));
                                if (i < 0 && i > -radius)
                                {
                                    if (Distance(xO + i, yO + j, xO - (int) (25 * sizeMult) - radius,
                                            yO + (int) (100 * sizeMult)) > radius)
                                    {
                                        PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"),
                                            mod.WallType("ObsidiumRockWall"));
                                    }
                                    else if (Distance(xO + i, yO + j, xO - (int) (25 * sizeMult) - radius,
                                                 yO + (int) (100 * sizeMult)) < radius + 6)
                                    {
                                        if (Main.rand.Next(6) < Distance(xO + i, yO + j, xO - (int) (25 * sizeMult) - radius,
                                                yO + (int) (100 * sizeMult)) - 6 - radius)
                                        {
                                            PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"));
                                        }
                                    }
                                }
                                else if (i >= 0 && i < radius + 1)
                                {
                                    if (Distance(xO + i, yO + j, xO + (int) (25 * sizeMult) + radius,
                                            yO + (int) (100 * sizeMult)) > radius)
                                    {
                                        PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"),
                                            mod.WallType("ObsidiumRockWall"));
                                    }
                                    else if (Distance(xO + i, yO + j, xO + (int) (25 * sizeMult) + radius,
                                                 yO + (int) (100 * sizeMult)) < radius + 6)
                                    {
                                        if (Main.rand.Next(6) < Distance(xO + i, yO + j, xO + (int) (25 * sizeMult) + radius,
                                                yO + (int) (100 * sizeMult)) - 6 - radius)
                                        {
                                            PlaceTile(xO + i, yO + j, mod.TileType("ObsidiumRock"));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            for (int k = 0; k < 100 * sizeMult; k++) //Cave Pockets
            {
                int x = xO + Main.rand.Next(-200 * sizeMult, 200 * sizeMult);
                int y = yO + Main.rand.Next(-250 * sizeMult, 250 * sizeMult);
                if (Main.tile[x, y].type == (ushort) mod.TileType("ObsidiumRock"))
                    WorldGen.TileRunner(x, y, Main.rand.Next(9, 15) * sizeMult, 3 * sizeMult, (ushort) 249, false, 0f, 0f,
                        false, true);
            }

            for (int k = 0; k < 50 * sizeMult; k++) //Cave Tunnels
            {
                int x = xO + Main.rand.Next(-200 * sizeMult, 200 * sizeMult);
                int y = yO + Main.rand.Next(-250 * sizeMult, 250 * sizeMult);
                if (Main.tile[x, y].type == (ushort) mod.TileType("ObsidiumRock"))
                    WorldGen.TileRunner(x, y, Main.rand.Next(16, 25), 140 * sizeMult, (ushort) 249, false, 0f, 0f, false, true);
            }

            for (int k = 0; k < 50 * sizeMult; k++) //Caverns
            {
                int x = xO + Main.rand.Next(-200 * sizeMult, 200 * sizeMult);
                int y = yO + Main.rand.Next(-250 * sizeMult, 250 * sizeMult);
                if (Main.tile[x, y].type == (ushort) mod.TileType("ObsidiumRock"))
                    WorldGen.TileRunner(x, y, Main.rand.Next(25, 30), 25 * sizeMult, (ushort) 249, false, 0f, 0f, false, true);
            }

            for (int i = (int) (-250 * sizeMult); i <= (int) (250 * sizeMult); i++)
            {
                for (int j = (int) (-325 * sizeMult); j <= (int) (325 * sizeMult); j++)
                {
                    if (TileCheckSafe(xO + i, yO + j))
                    {
                        if (Main.tile[xO + i, yO + j].type == (ushort) 249)
                        {
                            WorldGen.KillTile(xO + i, yO + j);
                        }
                    }
                }
            }

            for (int k = 0; k < 25 * sizeMult; k++) //Radiata
            {
                int x = xO + Main.rand.Next(-225 * sizeMult, 225 * sizeMult);
                int y = yO + Main.rand.Next(-275 * sizeMult, 275 * sizeMult);
                if (Main.tile[x, y].type == (ushort) mod.TileType("ObsidiumRock") ||
                    (Main.tile[x, y].active() == false && Main.tile[x, y].wall == mod.WallType("ObsidiumRockWall")))
                    WorldGen.TileRunner(x, y, Main.rand.Next(2, 6), 180 * sizeMult, (ushort) mod.TileType("Radiata"), false, 0f,
                        0f, false, true);
            }

            for (int k = 0; k < 50 * sizeMult; k++) //Lycoris
            {
                int x = xO + Main.rand.Next(-225 * sizeMult, 225 * sizeMult);
                int y = yO + Main.rand.Next(-275 * sizeMult, 275 * sizeMult);
                if (Main.tile[x, y].type == (ushort) mod.TileType("ObsidiumRock") ||
                    (Main.tile[x, y].active() == false && Main.tile[x, y].wall == mod.WallType("ObsidiumRockWall")))
                    WorldGen.TileRunner(x, y, Main.rand.Next(3, 6), 140 * sizeMult, (ushort) mod.TileType("Lycoris"), false, 0f,
                        0f, false, true);
            }

            for (int k = 0; k < 75 * sizeMult; k++) //Smol Radiata
            {
                int x = xO + Main.rand.Next(-225 * sizeMult, 225 * sizeMult);
                int y = yO + Main.rand.Next(-275 * sizeMult, 275 * sizeMult);
                if (Main.tile[x, y].type == (ushort) mod.TileType("ObsidiumRock") ||
                    (Main.tile[x, y].active() == false && Main.tile[x, y].wall == mod.WallType("ObsidiumRockWall")))
                    WorldGen.TileRunner(x, y, Main.rand.Next(3, 5), 180 * sizeMult, (ushort) mod.TileType("Radiata"), false, 0f,
                        0f, false, true);
            }

            for (int k = 0; k < 75 * sizeMult; k++) //Smol Lycoris
            {
                int x = xO + Main.rand.Next(-225 * sizeMult, 225 * sizeMult);
                int y = yO + Main.rand.Next(-275 * sizeMult, 275 * sizeMult);
                if (Main.tile[x, y].type == (ushort) mod.TileType("ObsidiumRock") ||
                    (Main.tile[x, y].active() == false && Main.tile[x, y].wall == mod.WallType("ObsidiumRockWall")))
                    WorldGen.TileRunner(x, y, Main.rand.Next(3, 5), 140 * sizeMult, (ushort) mod.TileType("Lycoris"), false, 0f,
                        0f, false, true);
            }

            for (int k = 0; k < 100 * sizeMult; k++) //Obsidium Brick
            {
                int x = xO + Main.rand.Next(-225 * sizeMult, 225 * sizeMult);
                int y = yO + Main.rand.Next(-275 * sizeMult, 275 * sizeMult);
                if (Main.tile[x, y].type == (ushort) mod.TileType("ObsidiumRock") ||
                    (Main.tile[x, y].active() == false && Main.tile[x, y].wall == mod.WallType("ObsidiumRockWall")) ||
                    Main.tile[x, y].type == (ushort) mod.TileType("Lycoris"))
                    WorldGen.TileRunner(x, y, Main.rand.Next(12, 18), 50 * sizeMult,
                        (ushort) mod.TileType("ObsidiumBrick")); // false, 0f, 0f, false, true);
            }

            for (int k = 0; k < 300 * sizeMult; k++) //Obsidium Ore
            {
                int x = xO + Main.rand.Next(-225 * sizeMult, 225 * sizeMult);
                int y = yO + Main.rand.Next(-275 * sizeMult, 275 * sizeMult);
                if (Main.tile[x, y].type == (ushort) mod.TileType("ObsidiumRock") ||
                    (Main.tile[x, y].active() == false && Main.tile[x, y].wall == mod.WallType("ObsidiumRockWall")) ||
                    Main.tile[x, y].type == (ushort) mod.TileType("Lycoris"))
                    WorldGen.TileRunner(x, y, Main.rand.Next(6, 14), 8, (ushort) mod.TileType("ObsidiumOreBlock"), false, 0f,
                        0f, false, true);
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

        /// <summary>
        /// Refactor This to be short
        /// </summary>
        public static void PlaceObsidiumChest(int x, int y, ushort floorType)
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
            int chestIndex = WorldGen.PlaceChest(x, y, (ushort)ModLoader.GetMod("Laugicality").TileType("ObsidiumChest"), false, 0);
            //int chestIndex = WorldGen.PlaceChest(x, y, 21, false, 44);

            //Put Items in Obsidium Chest
            //Special Loot
            int[] obsidiumLoot = new int[] { ModLoader.GetMod("Laugicality").ItemType("Eruption"), ModLoader.GetMod("Laugicality").ItemType("ObsidiumLily"), ModLoader.GetMod("Laugicality").ItemType("MagmaHeart"), ModLoader.GetMod("Laugicality").ItemType("FireDust"), ModLoader.GetMod("Laugicality").ItemType("CrystalizedMagma"),};
            int specialItem = 0;
            if (obsidiumPosition < obsidiumLoot.GetLength(0))
                specialItem = obsidiumLoot[obsidiumPosition];
            else
            {
                obsidiumPosition = 0;
                specialItem = obsidiumLoot[obsidiumPosition];
            }
            obsidiumPosition++;
            //Ore
            int[] oreLoot = new int[] { ModLoader.GetMod("Laugicality").ItemType("ObsidiumBar"), ModLoader.GetMod("Laugicality").ItemType("ObsidiumChunk"), ModLoader.GetMod("Laugicality").ItemType("ObsidiumBar"), ModLoader.GetMod("Laugicality").ItemType("ObsidiumChunk"), 175 }; //Hellstone Bar
            int orePos = Main.rand.Next(oreLoot.GetLength(0));
            int oreCount = Main.rand.Next(2, 6);
            //Potions
            int[] potLoot = new int[] { ModLoader.GetMod("Laugicality").ItemType("MysticPowerPotion"), ModLoader.GetMod("Laugicality").ItemType("JumpBoostPotion"), 2348, 2345, 2349 }; //Inferno, Lifeforce, Wrath
            int potPos = Main.rand.Next(potLoot.GetLength(0));
            int potCount = Main.rand.Next(2, 4);
            //Moneys
            int monType = 0;
            int monCount = 0;
            if (Main.rand.Next(2) == 0)
            {
                monType = 73; //Gold
                monCount = Main.rand.Next(1, 4);
            }
            else
            {
                monType = 72; //Silver
                monCount = Main.rand.Next(60, 99);
            }
            //Misc
            int mscPos = Main.rand.Next(5);
            int[] mscLoot = new int[] { ModLoader.GetMod("Laugicality").ItemType("LavaGem"), ModLoader.GetMod("Laugicality").ItemType("MagmaSnapper"), ModLoader.GetMod("Laugicality").ItemType("ArcaneShard"), ModLoader.GetMod("Laugicality").ItemType("LavaGem"), ModLoader.GetMod("Laugicality").ItemType("RubrumDust") }; //Inferno, Lifeforce, Wrath
            int mscCount = Main.rand.Next(2, 6);

            int[] itemsToPlaceInChests = new int[] { specialItem, oreLoot[orePos], potLoot[potPos], monType, mscLoot[mscPos] };
            int[] itemCounts = new int[] { 1, oreCount, potCount, monCount, mscCount };
            if(chestIndex < Main.chest.GetLength(0) && chestIndex > 0)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest != null)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == 0)
                        {
                            if (inventoryIndex < itemsToPlaceInChests.GetLength(0))
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
}