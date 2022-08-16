using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class OrbitalBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Orbital");
            Description.SetDefault("Into orbit!");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
    }
}
