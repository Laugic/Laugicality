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

        public override void Initialize()
        {
            downedAnnihilator = false;
            downedSlybertron = false;
            downedSteamTrain = false;
            downedDuneSharkron = false;
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedAnnihilator) downed.Add("annihilator");
            if (downedSlybertron) downed.Add("slybertron");
            if (downedSteamTrain) downed.Add("steamtrain");
            if (downedDuneSharkron) downed.Add("dunesharkron");

            return new TagCompound {
                {"downed", downed}
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedAnnihilator = downed.Contains("annihilator");
            downedSlybertron = downed.Contains("slybertron");
            downedSteamTrain = downed.Contains("steamtrain");
            downedDuneSharkron = downed.Contains("dunesharkron");
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
                progress.Message = "Generating Obsidian Cavern";
                for (int i = 0; i < 1; i++)       //900 is how many biomes. the bigger is the number = less biomes
                {
                    int X = 150;        //WorldGen.genRand.Next(1, Main.maxTilesX - 300);
                    int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer - 100, (int)WorldGen.rockLayer + 100);
                    int TileType = 56;     //this is the tile u want to use for the biome , if u want to use a vanilla tile then its int TileType = 56; 56 is obsidian block

                    WorldGen.TileRunner(X, Y, 350, WorldGen.genRand.Next(100, 200), TileType, false, 0f, 0f, true, true);  //350 is how big is the biome     100, 200 this changes how random it looks.
                    
                    //add this under public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
                    for (int k = 0; k < 750; k++)                     //750 is the ore spawn rate. the bigger is the number = more ore spawns
                    {
                        int Xore = Main.rand.Next(0, 300);
                        int Yore = WorldGen.genRand.Next((int)WorldGen.rockLayer - 100, Main.maxTilesY - 200);
                        if (Main.tile[Xore, Yore].type == TileID.Obsidian)   //this is the tile where the ore will spawn
                        {

                            {
                                WorldGen.TileRunner(Xore, Yore, (double)WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(5, 10), mod.TileType("ObsidiumOreBlock"), false, 0f, 0f, false, true);  //   5, 10 is how big is the ore veins.    mod.TileType("CustomOreTile") is the custom ore tile,  if u want a vanila ore just do this: TileID.Cobalt, for cobalt spawn
                            }
                        }
                    }
                }

            }));

            
        }


    }
}