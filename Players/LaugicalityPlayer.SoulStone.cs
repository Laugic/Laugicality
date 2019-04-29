using Laugicality.Buffs;
using Terraria.DataStructures;

namespace Laugicality
{
    public sealed partial class LaugicalityPlayer
    {
        private const int HONEY_BASE_LIFE_REGEN = 1;
        public bool destroyerEffect = false;
        public bool destroyerCooldown = false;

        internal void ResetSoulStoneEffects()
        {
            HoneyRegenMultiplier = 1;
            destroyerEffect = false;
            destroyerCooldown = false;
        }

        internal void UpdateSoulStoneLifeRegen()
        {
            if (player.honey)
                player.lifeRegen += HONEY_BASE_LIFE_REGEN * HoneyRegenMultiplier - HONEY_BASE_LIFE_REGEN;
        }

        public bool SoulStonePreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if(destroyerEffect && !destroyerCooldown && damage >= 60)
            {
                player.AddBuff(mod.BuffType<DestroyerSoulCooldown>(), 90 * 60);
                return false;
            }
            return true;
        }

        public int HoneyRegenMultiplier { get; set; }
    }
}
