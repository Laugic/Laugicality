using Terraria;

namespace Laugicality.Buffs
{
    public class EvilBossCooldownBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Evil Boss Soul Cooldown");
            Description.SetDefault("Your World Evil Boss effect is on Cooldown.");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            canBeCleared = false;
        }
    }
}
