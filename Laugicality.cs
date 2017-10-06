using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.UI.Chat;
using Terraria.ModLoader;

namespace Laugicality //Laugicality.cs
{
    class Laugicality : Mod
    {
        internal static ModHotKey ToggleMystic;
        private double pressedHotkeyTime;

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
        //Calling Mod References
        Mod calMod = ModLoader.GetMod("Calamity");

        //Recipe Groups
        public override void AddRecipeGroups()
        {
            //Emblem
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


        }

        //BossChecklist
        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call("AddBossWithInfo", "The Annihilator", 9.2f, (Func<bool>)(() => LaugicalityWorld.downedAnnihilator), "The Mechanical Television will summon it at night");
                bossChecklist.Call("AddBossWithInfo", "Slybertron", 9.3f, (Func<bool>)(() => LaugicalityWorld.downedSlybertron), "The Steam Crown calls to its King");
                bossChecklist.Call("AddBossWithInfo", "Steam Train", 9.4f, (Func<bool>)(() => LaugicalityWorld.downedSteamTrain), "A Suspicious Train Whistle might get its attention.");
                bossChecklist.Call("AddBossWithInfo", "Dune Sharkron", 2.3f, (Func<bool>)(() => LaugicalityWorld.downedDuneSharkron), "A tasty morsel in the daytime will attract this Shark's attention.");
            }
        }
        
        //Hotkeys
        public override void Load()
        {
            ToggleMystic = RegisterHotKey("Toggle Mysticism", "Mouse2");
        }

        public override void UpdateMusic(ref int music)
        {
            if(Main.myPlayer != -1 && !Main.gameMenu)
            {
                if(Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].GetModPlayer<LaugicalityPlayer>(this).ZoneObsidium)
                {
                    music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Obsidium");
                }

            }
        }
    }

}
