using Laugicality.Buffs;
using Terraria.DataStructures;

namespace Laugicality
{
    public sealed partial class LaugicalityPlayer
    {
        private const int HONEY_BASE_LIFE_REGEN = 1;

        internal void ResetSoulStoneEffects()
        {
            HoneyRegenMultiplier = 1;
            DestroyerEffect = false;
            DestroyerCooldown = false;
        }

        internal void UpdateSoulStoneLifeRegen()
        {
            if (player.honey)
                player.lifeRegen += HONEY_BASE_LIFE_REGEN * HoneyRegenMultiplier - HONEY_BASE_LIFE_REGEN;
        }

        internal bool SoulStonePreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if(DestroyerEffect && !DestroyerCooldown && damage >= 60)
            {
                player.AddBuff(mod.BuffType<DestroyerSoulCooldown>(), 90 * Constants.TICKS_PER_SECONDS);
                return false;
            }

            return true;
        }

        public int HoneyRegenMultiplier { get; set; }

        public bool DestroyerEffect { get; set; }
        public bool DestroyerCooldown { get; set; }
    }
}
