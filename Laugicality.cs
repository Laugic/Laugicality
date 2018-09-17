using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Laugicality.Etherial;

namespace Laugicality //Laugicality.cs
{

    class Laugicality : Mod
    {
        public static string GithubUserName { get { return "Laugic"; } }
        public static string GithubProjectName { get { return "Laugicality"; } }

        internal static ModHotKey ToggleMystic;
        internal static ModHotKey ToggleSoulStoneV;
        internal static ModHotKey ToggleSoulStoneM;
        private double pressedHotkeyTime;
        private bool musicPlaying = false;

        //Calling Mod References
        Mod calMod = ModLoader.GetMod("Calamity");

        public Laugicality()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
                AutoloadBackgrounds = true
            };

        }
        
        //Recipe Groups
        public override void AddRecipeGroups()
        {
            //Emblems
            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Emblem", new int[]
            {
                ItemID.RangerEmblem,
                ItemID.WarriorEmblem,
                ItemID.SorcererEmblem,
                ItemID.SummonerEmblem,
                ItemType("NullEmblem"),
                ItemType("MysticEmblem"),
                ItemType("NinjaEmblem")
            });
            RecipeGroup.RegisterGroup("Emblems", group);


            //Gems
            RecipeGroup Ggroup = new RecipeGroup(() => Lang.misc[37] + " Gem", new int[]
            {
                ItemID.Amethyst,
                ItemID.Topaz,
                ItemID.Ruby,
                ItemID.Sapphire,
                ItemID.Emerald,
                ItemID.Ruby,
                ItemID.Diamond,
                ItemID.Amber
            });
            RecipeGroup.RegisterGroup("Gems", Ggroup);

            //Gold Bars
            RecipeGroup Gldgroup = new RecipeGroup(() => Lang.misc[37] + " Gold Bar", new int[]
            {
                ItemID.GoldBar,
                ItemID.PlatinumBar
            });
            RecipeGroup.RegisterGroup("GldBars", Gldgroup);

            //Silver Bars
            RecipeGroup Sgroup = new RecipeGroup(() => Lang.misc[37] + " Silver Bar", new int[]
            {
                ItemID.SilverBar,
                ItemID.TungstenBar
            });
            RecipeGroup.RegisterGroup("SilverBars", Sgroup);

            //Titanium Bars
            RecipeGroup Titgroup = new RecipeGroup(() => Lang.misc[37] + " Titanium Bar", new int[]
            {
                ItemID.TitaniumBar,
                ItemID.AdamantiteBar
            });
            RecipeGroup.RegisterGroup("TitaniumBars", Titgroup);

            //Large Gems
            RecipeGroup LGgroup = new RecipeGroup(() => Lang.misc[37] + " Large Gem", new int[]
            {
                ItemID.LargeAmethyst,
                ItemID.LargeTopaz,
                ItemID.LargeSapphire,
                ItemID.LargeEmerald,
                ItemID.LargeRuby,
                ItemID.LargeDiamond
            });
            RecipeGroup.RegisterGroup("LargeGems", LGgroup);

            //Dungeon Tables
            RecipeGroup DTgroup = new RecipeGroup(() => Lang.misc[37] + " Dungeon Table", new int[]
            {
                1510, //Gothic
                1397, //Blue
                1400, //Green
                1403  //Pink
            });
            RecipeGroup.RegisterGroup("DungeonTables", DTgroup);


        }

        //BossChecklist
        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call("AddBossWithInfo", "The Annihilator", 9.991f, (Func<bool>)(() => LaugicalityWorld.downedAnnihilator), string.Format("The Steam-O-Vision [i:{0}] will summon it at night", ItemType("MechanicalMonitor")));
                bossChecklist.Call("AddBossWithInfo", "Slybertron", 9.992f, (Func<bool>)(() => LaugicalityWorld.downedSlybertron), string.Format("The Steam Crown [i:{0}] calls to its King", ItemType("SteamCrown")));
                bossChecklist.Call("AddBossWithInfo", "Steam Train", 9.993f, (Func<bool>)(() => LaugicalityWorld.downedSteamTrain), string.Format("A Suspicious Train Whistle [i:{0}] might get its attention.", ItemType("SuspiciousTrainWhistle")));
                bossChecklist.Call("AddBossWithInfo", "Dune Sharkron", 2.3f, (Func<bool>)(() => LaugicalityWorld.downedDuneSharkron), string.Format("A Tasty Morsel [i:{0}] in the daytime will attract this Shark's attention.", ItemType("TastyMorsel")));
                bossChecklist.Call("AddBossWithInfo", "Hypothema", 3.8f, (Func<bool>)(() => LaugicalityWorld.downedHypothema), string.Format("There's a chill in the air... [i:{0}]", ItemType("ChilledMesh")));
                bossChecklist.Call("AddBossWithInfo", "Ragnar", 4.5f, (Func<bool>)(() => LaugicalityWorld.downedRagnar), string.Format("This Molten Mess [i:{0}] guards the Obsidium.", ItemType("MoltenMess")));
                bossChecklist.Call("AddBossWithInfo", "Etheria", 10.51f, (Func<bool>)(() => LaugicalityWorld.downedTrueEtheria), string.Format("The guardian of the Etherial will consume her prey. Can only be called at night.[i:{0}]", ItemType("EmblemOfEtheria")));
                bossChecklist.Call("AddBossWithInfo", "Dioritus", 5.91f, (Func<bool>)(() => LaugicalityWorld.downedAnDio), string.Format("This  [i:{0}] calls the brother of the Guardians of the Underground", ItemType("AncientAwakener")));
                bossChecklist.Call("AddBossWithInfo", "Andesia", 5.92f, (Func<bool>)(() => LaugicalityWorld.downedAnDio), string.Format("The brother calls for his sister."));
            }
            Mod achMod = ModLoader.GetMod("AchievementLibs");
            int[] rewardsBleedingHeart = { ItemType("ObsidiumHeart") };
            int[] rewardsBleedingHeartCount = { 1 };
            if (achMod != null)
            {
                achMod.Call("AddAchievementWithoutAction", this, "A Bleeding Heart", string.Format("Defeat Ragnar, Guardian of the Obsidium.  [i:{0}]", ItemType("MoltenMess")), "Achievements/ragChieve2", rewardsBleedingHeart, rewardsBleedingHeartCount, (Func<bool>)(() => LaugicalityWorld.downedRagnar));
                //achMod.Call("AddAchievementWithoutReward", this, "The Bleeding Heart Guardian", string.Format("Defeat Ragnar, Guardian of the Obsidium.  [i:{0}]", ItemType("MoltenMess")), "Achievements/ragChieve2", (Func<bool>)(() => LaugicalityWorld.downedRagnar));
            }
        }
        

        //Hotkeys
        public override void Load()
        {
            if (!Main.dedServ)
            {                                                                                            //Foreground Filter (RGB)
                Filters.Scene["Laugicality:Etherial"] = new Filter(new EtherialShader("FilterMiniTower").UseColor(0.1f, 0.4f, 1.0f).UseOpacity(0.5f), EffectPriority.VeryHigh);
                SkyManager.Instance["Laugicality:Etherial"] = new EtherialVisual();
                Filters.Scene["Laugicality:ZaWarudo"] = new Filter(new ZaShader("FilterMiniTower").UseColor(0.5f, .5f, .5f).UseOpacity(0.5f), EffectPriority.VeryHigh);
                SkyManager.Instance["Laugicality:ZaWarudo"] = new ZaWarudoVisual();



                // Register a new music box
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/DuneSharkron"), ItemType("DuneSharkronMusicBox"), TileType("DuneSharkronMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Hypothema"), ItemType("HypothemaMusicBox"), TileType("HypothemaMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Obsidium"), ItemType("ObsidiumMusicBox"), TileType("ObsidiumMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Ragnar"), ItemType("RagnarMusicBox"), TileType("RagnarMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/RockPhase3"), ItemType("DioritusMusicBox"), TileType("DioritusMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/AnDio"), ItemType("AnDioMusicBox"), TileType("AnDioMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Annihilator"), ItemType("AnnihilatorMusicBox"), TileType("AnnihilatorMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Slybertron"), ItemType("SlybertronMusicBox"), TileType("SlybertronMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/SteamTrain"), ItemType("SteamTrainMusicBox"), TileType("SteamTrainMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Etheria"), ItemType("EtheriaMusicBox"), TileType("EtheriaMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/GreatShadow"), ItemType("GreatShadowMusicBox"), TileType("GreatShadowMusicBox"));
            }
            ToggleMystic = RegisterHotKey("Toggle Mysticism", "Mouse2");
            ToggleSoulStoneV = RegisterHotKey("Toggle Accessory Visual FX", "V");
            ToggleSoulStoneM = RegisterHotKey("Toggle Accessory Mobility FX", "C");
        }
        public override void UpdateMusic(ref int music, ref MusicPriority BossHigh)
        {

            /*int[] trackIDs = { 6, 40, 36, 27, 26, 29, 10, 8, 33, 16, 23, 2, 7, 20, 14, 11, 21, 4, 31, 19, 9, 22, 1, 18, 3, 30, 32 };
            if (Main.gameMenu)
            {
                if (!musicPlaying)
                {
                    //musicPlaying = true;
                    Main.musicVolume = 1f;
                    Main.music[6].Pause();
                    Main.musicFade[6] = 0f;
                    Main.music[6].Stop(AudioStopOptions.Immediate);
                    music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Etherial");
                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, GetSoundSlot(SoundType.Custom, "Sounds/Music/DuneSharkron"));
                }
                Main.music[6].Pause();
                Main.musicFade[6] = 0f;
                Main.music[6].Stop(AudioStopOptions.Immediate);
            }*/
            if (Main.myPlayer != -1 && !Main.gameMenu)
            {
                if (Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].GetModPlayer<LaugicalityPlayer>(this).etherial && Main.player[Main.myPlayer].GetModPlayer<LaugicalityPlayer>(this).etherialMusic)
                {
                    bool play = true;
                    foreach (NPC npc in Main.npc)
                    {
                        if (npc.boss == true)
                            play = false;
                    }
                    if (play)
                        music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Etherial");
                }
                if (Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].GetModPlayer<LaugicalityPlayer>(this).ZoneObsidium)
                {
                    music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Obsidium");
                }

            }
        }
        public override void PreSaveAndQuit()
        {
            /*int[] trackIDs = { 6, 40, 36, 27, 26, 29, 10, 8, 33, 16, 23, 2, 7, 20, 14, 11, 21, 4, 31, 19, 9, 22, 1, 18, 3, 30, 32 };

            for (int i = 0; i < trackIDs.Length; i++)
            {
                if (Main.music[trackIDs[i]].IsPlaying)
                {
                    //Main.music[trackIDs[i]].Pause();
                    Main.musicFade[i] = 0f;
                    Main.music[i].Stop(AudioStopOptions.Immediate);
                }
            }*/
        }
    }

}
