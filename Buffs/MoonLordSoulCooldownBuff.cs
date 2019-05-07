using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
    public class MoonLordSoulCooldownBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Moon Lord Soul Cooldown");
            Description.SetDefault("Your Moon Lord effect is on Cooldown.");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
        }
    }
}
