using Laugicality.Buffs;
using Terraria;

namespace Laugicality.SoulStones
{
    public sealed class SoulStoneAbilityCooldownBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Soul Stone Ability Cooldown");
            Description.SetDefault("You used your Soul Stone's ability recently!");

            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            canBeCleared = false;
        }
    }
}