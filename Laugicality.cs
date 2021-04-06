using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Laugicality.Etherial;
using System.IO;
using Terraria.UI;
using System.Collections.Generic;
using Laugicality.Items.Consumables;
using Laugicality.Items.Equipables;
using Laugicality.Items.Materials;
using Laugicality.Items.Placeable.MusicBoxes;
using Laugicality.UI;
using Terraria.Graphics.Shaders;
using WebmilioCommons.Networking;
using Laugicality.Items.Loot;
using Laugicality.Items.Placeable;
using Laugicality.Items.Weapons.Range;
using Laugicality.Items.Useables;
using Microsoft.Xna.Framework.Graphics;
using Laugicality.Items;
using Laugicality.NPCs;

namespace Laugicality
{
    public class Laugicality : Mod
    {
        public const string GOLD_BARS_GROUP = "GldBars";
        public const string EVIL_BARS_GROUP = "EnigmaEvilBars";
        public const string DOUBLE_JUMP_GROUP = "EnigmaDoubleJump";
        public const string COLORED_BALLOON_GROUP = "EnigmaColoredBalloon";
        public static Texture2D MysticWeaponIcon;

        internal static ModHotKey toggleMystic, toggleSoulStoneV, toggleSoulStoneM, quickMystica, soulStoneAbility, restockNearby;

        public static int zaWarudo = 0;

        public Laugicality()
        {
            Instance = this;

            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
                AutoloadBackgrounds = true
            };

        }

        #region Recipe Groups
        public override void AddRecipeGroups()
        {
            //Emblems
            RecipeGroup.RegisterGroup("Emblems", new RecipeGroup(() => Lang.misc[37] + " Emblem", new int[]
            {
                ItemID.RangerEmblem,
                ItemID.WarriorEmblem,
                ItemID.SorcererEmblem,
                ItemID.SummonerEmblem,
                ModContent.ItemType<NullEmblem>(),
                ModContent.ItemType<MysticEmblem>(),
                ModContent.ItemType<NinjaEmblem>()
            }));


            //Gems
            RecipeGroup.RegisterGroup("Gems", new RecipeGroup(() => Lang.misc[37] + " Gem", new int[]
            {
                ItemID.Amethyst,
                ItemID.Topaz,
                ItemID.Ruby,
                ItemID.Sapphire,
                ItemID.Emerald,
                ItemID.Ruby,
                ItemID.Diamond,
                ItemID.Amber
            }));

            //Gold Bars
            RecipeGroup.RegisterGroup(GOLD_BARS_GROUP, new RecipeGroup(() => Lang.misc[37] + " Gold Bar", new int[]
            {
                ItemID.GoldBar,
                ItemID.PlatinumBar
            }));

            //Silver Bars
            RecipeGroup.RegisterGroup("SilverBars", new RecipeGroup(() => Lang.misc[37] + " Silver Bar", new int[]
            {
                ItemID.SilverBar,
                ItemID.TungstenBar
            }));

            //Titanium Bars
            RecipeGroup.RegisterGroup("TitaniumBars", new RecipeGroup(() => Lang.misc[37] + " Titanium Bar", new int[]
            {
                ItemID.TitaniumBar,
                ItemID.AdamantiteBar
            }));

            //Large Gems
            RecipeGroup.RegisterGroup("LargeGems", new RecipeGroup(() => Lang.misc[37] + " Large Gem", new int[]
            {
                ItemID.LargeAmethyst,
                ItemID.LargeTopaz,
                ItemID.LargeSapphire,
                ItemID.LargeEmerald,
                ItemID.LargeRuby,
                ItemID.LargeDiamond,
                ItemID.LargeAmber
            }));

            //Dungeon Tables
            RecipeGroup.RegisterGroup("DungeonTables", new RecipeGroup(() => Lang.misc[37] + " Dungeon Table", new int[]
            {
                ItemID.GothicTable, //Gothic
                ItemID.BlueDungeonTable, //Blue
                ItemID.GreenDungeonTable, //Green
                ItemID.PinkDungeonTable  //Pink
            }));

            //Evil Bars
            RecipeGroup.RegisterGroup(EVIL_BARS_GROUP, new RecipeGroup(() => Lang.misc[37] + " Evil Bar", new int[]
            {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
            }));

            //DoubleJump
            RecipeGroup.RegisterGroup(DOUBLE_JUMP_GROUP, new RecipeGroup(() => Lang.misc[37] + " Double Jump Bottle", new int[]
            {
                ItemID.CloudinaBottle,
                ItemID.SandstorminaBottle,
                ItemID.BlizzardinaBottle,
                ItemID.TsunamiInABottle
            }));

            //ColoredBalloon
            RecipeGroup.RegisterGroup(COLORED_BALLOON_GROUP, new RecipeGroup(() => Lang.misc[37] + " Colored Balloon", new int[]
            {
                ItemID.BlueHorseshoeBalloon,
                ItemID.WhiteHorseshoeBalloon,
                ItemID.YellowHorseshoeBalloon,
                ItemID.BalloonHorseshoeFart,
                ItemID.BalloonHorseshoeHoney,
                ItemID.BalloonHorseshoeSharkron,
            }));
        }
        #endregion

        public override void Load()
        {
            zaWarudo = 0;

            if (!Main.dedServ)
            {                                                                                            //Foreground Filter (RGB)
                Filters.Scene["Laugicality:Etherial"] = new Filter(new EtherialShader("FilterMiniTower").UseColor(0.1f, 0.4f, 1.0f).UseOpacity(0.5f), EffectPriority.VeryHigh);
                SkyManager.Instance["Laugicality:Etherial"] = new EtherialVisual();
                Filters.Scene["Laugicality:Etherial2"] = new Filter(new ScreenShaderData("FilterBloodMoon").UseColor(0f, 2f, 8f).UseOpacity(0.8f), EffectPriority.VeryHigh);
                Filters.Scene["Laugicality:ZaWarudo"] = new Filter(new ZaShader("FilterMiniTower").UseColor(0.5f, .5f, .5f).UseOpacity(0.5f), EffectPriority.VeryHigh);
                SkyManager.Instance["Laugicality:ZaWarudo"] = new ZaWarudoVisual();

                // Register a new music box
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/DuneSharkron"), ModContent.ItemType<DuneSharkronMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.DuneSharkronMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Hypothema"), ModContent.ItemType<HypothemaMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.HypothemaMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Obsidium"), ModContent.ItemType<ObsidiumMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.ObsidiumMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Ragnar"), ModContent.ItemType<RagnarMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.RagnarMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/RockPhase3"), ModContent.ItemType<DioritusMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.DioritusMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/AnDio"), ModContent.ItemType<AnDioMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.AnDioMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Annihilator"), ModContent.ItemType<AnnihilatorMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.AnnihilatorMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Slybertron"), ModContent.ItemType<SlybertronMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.SlybertronMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/SteamTrain"), ModContent.ItemType<SteamTrainMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.SteamTrainMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Etheria"), ModContent.ItemType<EtheriaMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.EtheriaMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/ObsidiumSurface"), ModContent.ItemType<GreatShadowMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.GreatShadowMusicBox>());


                MysticWeaponIcon = Laugicality.Instance.GetTexture("UI/MysticIcon");

                MysticaUI = new LaugicalityUI();
                MysticaUI.Activate();
                MysticaUI.Load();
                MysticaUserInterface = new UserInterface();
                MysticaUserInterface.SetState(MysticaUI);
            }

            toggleMystic = RegisterHotKey("Toggle Mysticism", "Mouse2");
            toggleSoulStoneV = RegisterHotKey("Toggle Visual Effects", "V");
            toggleSoulStoneM = RegisterHotKey("Toggle Mobility Effects", "C");
            quickMystica = RegisterHotKey("Quick Mystica", "G");
            soulStoneAbility = RegisterHotKey("Soul Stone Ability", "Mouse3");
            restockNearby = RegisterHotKey("Restock from Nearby Chests", "N");


            //Boss Info
            ModTranslation text = CreateTranslation("EnigmaStuff");
            text = CreateTranslation("BossSpawnInfo.DuneSharkron");
            text.SetDefault(string.Format("A Tasty Morsel [i:{0}] in the desert will attract this Shark's attention.", ModContent.ItemType<TastyMorsel>()));
            AddTranslation(text);

            text = CreateTranslation("BossSpawnInfo.Hypothema");
            text.SetDefault(string.Format("There's a chill in the air... [i:{0}]", ModContent.ItemType<ChilledMesh>()));
            AddTranslation(text);

            text = CreateTranslation("BossSpawnInfo.Ragnar");
            text.SetDefault(string.Format("This Molten Mess [i:{0}] guards the Obsidium.", ModContent.ItemType<MoltenMess>()));
            AddTranslation(text);

            text = CreateTranslation("BossSpawnInfo.Dioritus");
            text.SetDefault(string.Format("This  [i:{0}] calls the brother of the Guardians of the Underground", ModContent.ItemType<AncientAwakener>()));
            AddTranslation(text);

            text = CreateTranslation("BossSpawnInfo.Andesia");
            text.SetDefault(string.Format("The brother calls for his sister."));
            AddTranslation(text);

            text = CreateTranslation("BossSpawnInfo.Annihilator");
            text.SetDefault(string.Format("The Steam-O-Vision [i:{0}] will summon it at night", ModContent.ItemType<MechanicalMonitor>()));
            AddTranslation(text);

            text = CreateTranslation("BossSpawnInfo.Slybertron");
            text.SetDefault(string.Format("The Steam Crown [i:{0}] calls to its King", ModContent.ItemType<SteamCrown>()));
            AddTranslation(text);

            text = CreateTranslation("BossSpawnInfo.SteamTrain");
            text.SetDefault(string.Format("A Suspicious Train Whistle [i:{0}] might get its attention.", ModContent.ItemType<SuspiciousTrainWhistle>()));
            AddTranslation(text);

            text = CreateTranslation("BossSpawnInfo.Etheria");
            text.SetDefault(string.Format("The gate to the Etherial will consume her prey. Can only be called at night.[i:{0}]", ModContent.ItemType<EmblemOfEtheria>()));
            AddTranslation(text);
        }

	    public override void PostSetupContent()
	    {
	        #region BossChecklist

	        Mod bossChecklist = ModLoader.GetMod("BossChecklist");

            bossChecklist?.Call(
                "AddBoss",
                2.3f,
                new List<int> { ModContent.NPCType<NPCs.PreTrio.DuneSharkron>() },
                this,
                "Dune Sharkron",
                (Func<bool>)(() => LaugicalityWorld.downedDuneSharkron),
                ModContent.ItemType<TastyMorsel>(),
                new List<int> { ModContent.ItemType<DuneSharkronTrophy>(), ModContent.ItemType<DuneSharkronMusicBox>() },
                new List<int> { ModContent.ItemType<Pyramind>(), ModContent.ItemType<AncientShard>(), ModContent.ItemType<Crystilla>(), ItemID.SandstorminaBottle, ItemID.FlyingCarpet, ItemID.BandofRegeneration, ItemID.MagicMirror, ItemID.CloudinaBottle, ItemID.HermesBoots, ItemID.EnchantedBoomerang, },
                "$Mods.Laugicality.BossSpawnInfo.DuneSharkron"
            );
            bossChecklist?.Call(
                "AddBoss",
                3.8f,
                new List<int> { ModContent.NPCType<NPCs.PreTrio.Hypothema>() },
                this,
                "Hypothema",
                (Func<bool>)(() => LaugicalityWorld.downedHypothema),
                ModContent.ItemType<ChilledMesh>(),
                new List<int> { ModContent.ItemType<HypothemaTrophy>(), ModContent.ItemType<HypothemaMusicBox>() },
                new List<int> { ModContent.ItemType<FrostEssence>(), ModContent.ItemType<FrostShard>(), ModContent.ItemType<ChilledBar>(), ItemID.BlizzardinaBottle, ItemID.IceBoomerang, ItemID.IceBlade, ItemID.IceSkates, ItemID.SnowballCannon, ItemID.FlurryBoots, ItemID.SnowBlock, ItemID.IceBlock, },
                "$Mods.Laugicality.BossSpawnInfo.Hypothema"
            );
            bossChecklist?.Call(
                "AddBoss",
                4.5f,
                new List<int> { ModContent.NPCType<NPCs.PreTrio.Ragnar>() },
                this,
                "Ragnar",
                (Func<bool>)(() => LaugicalityWorld.downedRagnar),
                ModContent.ItemType<MoltenMess>(),
                new List<int> { ModContent.ItemType<RagnarTrophy>(), ModContent.ItemType<RagnarMusicBox>() },
                new List<int> { ModContent.ItemType<MoltenCore>(), ModContent.ItemType<DarkShard>(), ModContent.ItemType<ObsidiumChunk>(), ItemID.LavaCharm, ModContent.ItemType<ObsidiumLily>(), ModContent.ItemType<FireDust>(), ModContent.ItemType<Eruption>(), ModContent.ItemType<CrystalizedMagma>(), ModContent.ItemType<Ragnashia>(), ModContent.ItemType<MagmaHeart>(), ModContent.ItemType<BlackIce>(), },
                "$Mods.Laugicality.BossSpawnInfo.Ragnar"
            );
            bossChecklist?.Call(
                "AddBoss",
                5.991f,
                new List<int> { ModContent.NPCType<NPCs.RockTwins.Dioritus>() },
                this,
                "Dioritus",
                (Func<bool>)(() => LaugicalityWorld.downedAnDio),
                ModContent.ItemType<AncientAwakener>(),
                new List<int> { ModContent.ItemType<DioritusMusicBox>() },
                new List<int> { ModContent.ItemType<ZaWarudoWatch>(), ModContent.ItemType<DioritusCore>(), ItemID.Marble, },
                "$Mods.Laugicality.BossSpawnInfo.Dioritus"
            );
            bossChecklist?.Call(
                "AddBoss",
                5.992f,
                new List<int> { ModContent.NPCType<NPCs.RockTwins.Andesia>() },
                this,
                "Andesia",
                (Func<bool>)(() => LaugicalityWorld.downedAnDio),
                ModContent.ItemType<AncientAwakener>(),
                new List<int> { ModContent.ItemType<AnDioTrophy>(), ModContent.ItemType<AnDioMusicBox>() },
                new List<int> { ModContent.ItemType<AndesiaCore>(), ItemID.Granite, },
                "$Mods.Laugicality.BossSpawnInfo.Andesia"
            );
            bossChecklist?.Call(
                "AddBoss",
                9.991f,
                new List<int> { ModContent.NPCType<NPCs.Bosses.TheAnnihilator>() },
                this,
                "The Annihilator",
                (Func<bool>)(() => LaugicalityWorld.downedAnnihilator),
                ModContent.ItemType<MechanicalMonitor>(),
                new List<int> { ModContent.ItemType<AnnihilatorTrophy>(), ModContent.ItemType<AnnihilatorMusicBox>() },
                new List<int> { ModContent.ItemType<CogOfKnowledge>(), ModContent.ItemType<SoulOfThought>(), ModContent.ItemType<SteamBar>() },
                "$Mods.Laugicality.BossSpawnInfo.Annihilator"
            );
            bossChecklist?.Call(
                "AddBoss",
                9.992f,
                new List<int> { ModContent.NPCType<NPCs.Slybertron.Slybertron>() },
                this,
                "Slybertron",
                (Func<bool>)(() => LaugicalityWorld.downedSlybertron),
                ModContent.ItemType<SteamCrown>(),
                new List<int> { ModContent.ItemType<SlybertronTrophy>(), ModContent.ItemType<SlybertronMusicBox>() },
                new List<int> { ModContent.ItemType<Pipeworks>(), ModContent.ItemType<SoulOfFraught>(), ModContent.ItemType<SteamBar>() },
                "$Mods.Laugicality.BossSpawnInfo.Slybertron"
            );
            bossChecklist?.Call(
                "AddBoss",
                9.993f,
                new List<int> { ModContent.NPCType<NPCs.SteamTrain.SteamTrain>() },
                this,
                "Steam Train",
                (Func<bool>)(() => LaugicalityWorld.downedSteamTrain),
                ModContent.ItemType<SuspiciousTrainWhistle>(),
                new List<int> { ModContent.ItemType<SteamTrainTrophy>(), ModContent.ItemType<SteamTrainMusicBox>() },
                new List<int> { ModContent.ItemType<SteamTank>(), ModContent.ItemType<SoulOfWrought>(), ModContent.ItemType<SteamBar>() },
                "$Mods.Laugicality.BossSpawnInfo.SteamTrain"
            );
            bossChecklist?.Call(
                "AddBoss",
                11.51f,
                new List<int> { ModContent.NPCType<NPCs.Etheria.Etheria>() },
                this,
                "Etheria",
                (Func<bool>)(() => LaugicalityWorld.downedTrueEtheria),
                ModContent.ItemType<TastyMorsel>(),
                new List<int> { ModContent.ItemType<EtheriaTrophy>(), ModContent.ItemType<EtheriaMusicBox>() },
                new List<int> { ModContent.ItemType<EssenceOfEtheria>(), ModContent.ItemType<EtherialEssence>(), ModContent.ItemType<BysmalBar>() },
                "$Mods.Laugicality.BossSpawnInfo.Etheria"
            );
            /*
            bossChecklist?.Call("AddBossWithInfo", "The Annihilator", 9.991f, (Func<bool>)(() => LaugicalityWorld.downedAnnihilator), string.Format("The Steam-O-Vision [i:{0}] will summon it at night", ModContent.ItemType<MechanicalMonitor>()));
            bossChecklist?.Call("AddBossWithInfo", "Slybertron", 9.992f, (Func<bool>)(() => LaugicalityWorld.downedSlybertron), string.Format("The Steam Crown [i:{0}] calls to its King", ModContent.ItemType<SteamCrown>()));
            bossChecklist?.Call("AddBossWithInfo", "Steam Train", 9.993f, (Func<bool>)(() => LaugicalityWorld.downedSteamTrain), string.Format("A Suspicious Train Whistle [i:{0}] might get its attention.", ModContent.ItemType<SuspiciousTrainWhistle>()));
            bossChecklist?.Call("AddBossWithInfo", "Dune Sharkron", 2.3f, (Func<bool>)(() => LaugicalityWorld.downedDuneSharkron), string.Format("A Tasty Morsel [i:{0}] in the desert will attract this Shark's attention.", ModContent.ItemType<TastyMorsel>()));
            bossChecklist?.Call("AddBossWithInfo", "Hypothema", 3.8f, (Func<bool>)(() => LaugicalityWorld.downedHypothema), string.Format("There's a chill in the air... [i:{0}]", ModContent.ItemType<ChilledMesh>()));
            bossChecklist?.Call("AddBossWithInfo", "Ragnar", 4.5f, (Func<bool>)(() => LaugicalityWorld.downedRagnar), string.Format("This Molten Mess [i:{0}] guards the Obsidium.", ModContent.ItemType<MoltenMess>()));
            bossChecklist?.Call("AddBossWithInfo", "Etheria", 11.51f, (Func<bool>)(() => LaugicalityWorld.downedTrueEtheria), string.Format("The guardian of the Etherial will consume her prey. Can only be called at night.[i:{0}]", ModContent.ItemType<EmblemOfEtheria>()));
            bossChecklist?.Call("AddBossWithInfo", "Dioritus", 5.91f, (Func<bool>)(() => LaugicalityWorld.downedAnDio), string.Format("This  [i:{0}] calls the brother of the Guardians of the Underground", ModContent.ItemType<AncientAwakener>()));
            bossChecklist?.Call("AddBossWithInfo", "Andesia", 5.92f, (Func<bool>)(() => LaugicalityWorld.downedAnDio), string.Format("The brother calls for his sister."));
            */

            #endregion

            #region AchievementLibs

            Mod achMod = ModLoader.GetMod("AchievementLibs");

	        int[] rewardsBleedingHeart = { ModContent.ItemType<ObsidiumHeart>() };
	        int[] rewardsBleedingHeartCount = { 1 };

	        achMod?.Call("AddAchievementWithoutAction", this, "A Bleeding Heart", string.Format("Defeat Ragnar, Guardian of the Obsidium.  [i:{0}]", ModContent.ItemType<MoltenMess>()), "Achievements/ragChieve2", rewardsBleedingHeart, rewardsBleedingHeartCount, (Func<bool>)(() => LaugicalityWorld.downedRagnar));

                #endregion

            #region RecipeBrowser

            Mod RecipeBrowser = ModLoader.GetMod("RecipeBrowser");
            Predicate<Item> isMystic = item => item.GetGlobalItem<LaugicalityGlobalItem>().Mystic;

            RecipeBrowser?.Call("AddItemCategory", "Mystic", "Weapons", MysticWeaponIcon, isMystic);
            #endregion

	        #region Census

	        Mod censusMod = ModLoader.GetMod("Census");

	        censusMod?.Call("TownNPCCondition", ModContent.NPCType<Conductor>(), "Defeat all Steam Trio bosses.");

	        #endregion
	    }

        public override void Unload()
        {
            Instance = null;

            MysticaUI.Unload();
            MysticaUserInterface = null;
        }

        public override void UpdateMusic(ref int music, ref MusicPriority musicPriority)
        {
            if (Main.myPlayer != -1 && !Main.gameMenu)
            {
                if (Main.player[Main.myPlayer].active && LaugicalityPlayer.Get().zoneObsidium)
                {
                    if (Main.player[Main.myPlayer].ZoneOverworldHeight || Main.player[Main.myPlayer].ZoneSkyHeight)
                        music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/ObsidiumSurface");
                    else
                        music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Obsidium");

                    musicPriority = MusicPriority.BiomeHigh;
                }

                if (LaugicalityWorld.downedEtheria)
                {
                    if(Main.player[Main.myPlayer].ZoneDungeon)
                        music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Necrodungeon");
                    else
                        music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Etherial");
                    musicPriority = MusicPriority.Environment;
                }
            }

            if (zaWarudo > 0)
                zaWarudo--;
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));

            if (mouseTextIndex != -1)
                layers.Insert(mouseTextIndex, new EnigmaMysticaInterface(MysticaUI));
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            NetworkPacketLoader.Instance.HandlePacket(reader, whoAmI);

            /*int zTime = reader.ReadInt32();
            zaWarudo = zTime;
            Main.NewText(zTime.ToString(), 150, 50, 50);

            EnigmaMessageType msgType = (EnigmaMessageType)reader.ReadByte();

            switch (msgType)
            {
                case EnigmaMessageType.ZaWarudoTime:
                    int zTime2 = reader.ReadInt32();
                    zaWarudo = zTime2;
                    Main.NewText(zTime2.ToString(), 150, 50, 50);
                    break;
                default:
                    ErrorLogger.Log("Laugicality: Unknown Message type: " + msgType);
                    break;
            }*/
        }

        enum EnigmaMessageType : byte
        {
            ZaWarudoTime,
        }

        public override void Close()
        {
            base.Close();
        }


        public static Laugicality Instance { get; private set; }

        public UserInterface MysticaUserInterface { get; private set; }
        public LaugicalityUI MysticaUI { get; private set; }
    }

}
