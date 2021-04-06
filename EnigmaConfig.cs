using Laugicality.UI;
using System.ComponentModel;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace Laugicality
{
    public class EnigmaConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        [Label("Mystic UI Type [0: Center, 1: Top Circle, 2: Top Stacked]")]
        [DefaultValue(0)]
        public int MysticUIType;

        [Label("Mystic UI Animation")]
        [DefaultValue(true)]
        public bool MysticUIAnimated = true;

        [Label("Mystic Change Sound")]
        [DefaultValue(true)]
        public bool MysticSound = true;

        public EnigmaConfig()
        {
            MysticUIType = 0;
            MysticUIAnimated = true;
            MysticSound = true;
        }

        public override void OnChanged()
        {
            LaugicalityUI.MysticUIType = MysticUIType;
            LaugicalityUI.Animated = MysticUIAnimated;
            LaugicalityUI.SoundOn = MysticSound;
        }
    }
}
