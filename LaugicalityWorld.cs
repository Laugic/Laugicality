using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;

namespace Laugicality
{
    public partial class LaugicalityWorld : ModWorld
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
        public static bool obEnf = false; //obsidiumEnfused
        public static bool bysmal = false;
        public static int obsidiumPosition = 0;

        public static int sizeMult = (int)(Math.Round(Main.maxTilesX / 4200f)); //Small = 2; Medium = ~3; Large = 4;

        public static int zawarudo = 0;
        public static int dungeonSide = 1;

        public override void Initialize()
        {
            sizeMult = (int)(Math.Floor(Main.maxTilesX / 4200f));
            power = 0;
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
            zawarudo = Laugicality.zawarudo;

            if (downedEtheria)
            {
                Main.dayTime = false;
                Main.time = 16200.0;
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
            DryTheObsidium();
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

            //int zTime = Laugicality.zawarudo;
            //writer.Write(zTime);
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
            //int zTime = reader.ReadInt32();
            //zawarudo = (int)zTime;
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
            if (i > 0 && i < Main.maxTilesX - 1 && j > 0 && j < Main.maxTilesY - 1)
            {
                if (TileID.Sets.BasicChest[Main.tile[i, j].type])
                    return false;
                return true;
            }
            return false;
        }

        private float Distance(int x1, int y1, int x2, int y2)
        {
            return (float)(Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
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