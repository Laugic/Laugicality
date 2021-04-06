using Laugicality.UI;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace Laugicality
{
    public class EnigmaConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        [Label("Mystic UI Type [0: Center, 1: Top Circle, 2: Top Stacked]")]
        public int MysticUIType;

        [Label("Mystic UI Animation")]
        public bool MysticUIAnimated;

        public EnigmaConfig()
        {
            MysticUIType = 0;
            MysticUIAnimated = true;
        }

        public override void OnChanged()
        {
            LaugicalityUI.MysticUIType = MysticUIType;
            LaugicalityUI.Animated = MysticUIAnimated;
        }
    }
}
