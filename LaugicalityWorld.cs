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
        public static bool downedEtheria = false; 
        public static bool downedTrueEtheria = false;
        public static int obsidiumTiles = 0;
        public static bool obEnf = false; //obsidiumEnfused

        public override void Initialize()
        {
            downedAnnihilator = false;
            downedSlybertron = false;
            downedSteamTrain = false;
            downedDuneSharkron = false;
            downedHypothema = false;
            downedRagnar = false;
            downedEtheria = false;
            downedTrueEtheria = false;
            obEnf = false;
        }

        public override void PostUpdate()
        {
            if(obEnf == false && NPC.downedBoss2)
            {
                obEnf = true;
                Main.NewText("Fury runs through the Obsidium Caverns.", 150, 50, 50);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color
            }
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            bool obs = false;
            if (downedAnnihilator) downed.Add("annihilator");
            if (downedSlybertron) downed.Add("slybertron");
            if (downedSteamTrain) downed.Add("steamtrain");
            if (downedDuneSharkron) downed.Add("dunesharkron");
            if (downedHypothema) downed.Add("hypothema");
            if (downedRagnar) downed.Add("ragnar");
            if (downedEtheria) downed.Add("etheria");
            if (downedTrueEtheria) downed.Add("trueetheria");
            if (obEnf) obs = true; 

            return new TagCompound {
                {"downed", downed},
                {"obsidium", obs }
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
            downedEtheria = downed.Contains("etheria");
            downedTrueEtheria = downed.Contains("trueetheria");
            obEnf = tag.GetBool("obsidium");
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
            writer.Write(flags);

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
        }
        public override void ResetNearbyTileEffects()
        {
            obsidiumTiles = 0;
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            obsidiumTiles = tileCounts[56];
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (genIndex == -1)
            {
                return;
            }
            tasks.Insert(genIndex + 1, new PassLegacy("Generating Obsidian Cavern", delegate (GenerationProgress progress)
            {
                progress.Message = "Obsidification";
                for (int i = 0; i < 1; i++)       
                {
                    int X = 150;       
                    int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer + 100, (int)WorldGen.rockLayer + 150);
                    int TileType = 56;     

                    WorldGen.TileRunner(X, Y, 1000, WorldGen.genRand.Next(300, 600), TileType, false, 0f, 0f, true, true);  
                    
                    for (int k = 0; k < 1000; k++)                
                    {
                        int Xore = Main.rand.Next(0, 600);
                        int Yore = WorldGen.genRand.Next((int)WorldGen.rockLayer - 300, Main.maxTilesY );
                        if (Main.tile[Xore, Yore].type == TileID.Obsidian) 
                        {

                            {
                                WorldGen.TileRunner(Xore, Yore, (double)WorldGen.genRand.Next(6, 12), WorldGen.genRand.Next(6, 12), mod.TileType("ObsidiumOreBlock"), false, 0f, 0f, false, true);  //   5, 10 is how big is the ore veins.    mod.TileType("CustomOreTile") is the custom ore tile,  if u want a vanila ore just do this: TileID.Cobalt, for cobalt spawn
                            }
                        }
                    }
                
                    //progress.Message = "To Ashes";
                
                    for (int k = 0; k < 300; k++)              
                    {
                        int Xore = Main.rand.Next(0, 600);
                        int Yore = WorldGen.genRand.Next((int)WorldGen.rockLayer - 300, Main.maxTilesY);
                        if (Main.tile[Xore, Yore].type == TileID.Obsidian)  
                        {

                            {
                                WorldGen.TileRunner(Xore, Yore, (double)WorldGen.genRand.Next(15, 40), WorldGen.genRand.Next(15, 40), 57, false, 0f, 0f, false, true);  //   5, 10 is how big is the ore veins.    mod.TileType("CustomOreTile") is the custom ore tile,  if u want a vanila ore just do this: TileID.Cobalt, for cobalt spawn
                            }
                        }
                    }
                    for (int k = 0; k < 300; k++)          
                    {
                        int Xore = Main.rand.Next(0, 600);
                        int Yore = WorldGen.genRand.Next((int)WorldGen.rockLayer - 300, Main.maxTilesY);
                        if (Main.tile[Xore, Yore].type == TileID.Obsidian)  
                        {

                            {
                                WorldGen.TileRunner(Xore, Yore, (double)WorldGen.genRand.Next(15, 40), WorldGen.genRand.Next(15, 40), 123, false, 0f, 0f, false, true);  //   5, 10 is how big is the ore veins.    mod.TileType("CustomOreTile") is the custom ore tile,  if u want a vanila ore just do this: TileID.Cobalt, for cobalt spawn
                            }
                        }
                    }
                    for (int k = 0; k < 300; k++)               
                    {
                        int Xore = Main.rand.Next(0, 600);
                        int Yore = WorldGen.genRand.Next((int)WorldGen.rockLayer - 300, Main.maxTilesY);
                        if (Main.tile[Xore, Yore].type == TileID.Obsidian)  
                        {

                            {
                                WorldGen.TileRunner(Xore, Yore, (double)WorldGen.genRand.Next(15, 40), WorldGen.genRand.Next(15, 40), 119, false, 0f, 0f, false, true);  //   5, 10 is how big is the ore veins.    mod.TileType("CustomOreTile") is the custom ore tile,  if u want a vanila ore just do this: TileID.Cobalt, for cobalt spawn
                            }
                        }
                    }
                    for (int k = 0; k < 300; k++)
                    {
                        int Xore = Main.rand.Next(0, 600);
                        int Yore = WorldGen.genRand.Next((int)WorldGen.rockLayer - 300, Main.maxTilesY);
                        if (Main.tile[Xore, Yore].type == TileID.Obsidian)
                        {

                            {
                                WorldGen.TileRunner(Xore, Yore, (double)WorldGen.genRand.Next(15, 40), WorldGen.genRand.Next(15, 40), 369, false, 0f, 0f, false, true);  //   5, 10 is how big is the ore veins.    mod.TileType("CustomOreTile") is the custom ore tile,  if u want a vanila ore just do this: TileID.Cobalt, for cobalt spawn
                            }
                        }
                    }
                    for (int k = 0; k < 100; k++)
                    {
                        int Xore = Main.rand.Next(0, 600);
                        int Yore = WorldGen.genRand.Next((int)WorldGen.rockLayer - 300, Main.maxTilesY);
                        WorldGen.TileRunner(Xore, Yore, (double)WorldGen.genRand.Next(12, 20), WorldGen.genRand.Next(15, 40), 273, false, 0f, 0f, false, true);  //   5, 10 is how big is the ore veins.    mod.TileType("CustomOreTile") is the custom ore tile,  if u want a vanila ore just do this: TileID.Cobalt, for cobalt spawn
                            
                        }
                    }
                for(int k = 0; k < 1500; k++)
                {
                    for(int l = 0; l < Main.maxTilesY; l++)
                    {
                        if (Main.tile[k, l].type == 273)
                            WorldGen.KillTile(k, l);
                    }
                }
                    for (int k = 0; k < 600; k++)
                    {
                        int Xsize = Main.rand.Next(16, 42);
                        int Ysize = Main.rand.Next(16, 42);
                        int Xwal = Main.rand.Next(100, 500);
                        int Ywal = WorldGen.genRand.Next((int)WorldGen.rockLayer - 100, Main.maxTilesY - 300);
                        int type = 79;
                        int radius = 15;
                        for (int x = Xwal - Xsize; x <= Xwal + Xsize; x++)
                            for (int y = Ywal - Ysize; y <= Ywal + Ysize; y++)
                            {
                                if (Vector2.Distance(new Vector2(Xwal, Ywal), new Vector2(x, y)) <= Xsize)
                                {
                                    if (Main.rand.Next(6) != 0) WorldGen.PlaceWall(x, y, type);
                                }
                                if (Vector2.Distance(new Vector2(Xwal, Ywal), new Vector2(x, y)) <= Ysize)
                                {
                                    if (Main.rand.Next(6) != 0) WorldGen.PlaceWall(x, y, type);
                                }
                            }
                    }
                
            }));

            
        }


    }
}