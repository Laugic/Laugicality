using Laugicality.Buffs;
using Laugicality.Focuses;
using Laugicality.SoulStones;
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
            MoonLordEffect = false;
            SteamTrainEffect = false;
            DestroyerCooldown = false;
            if (!player.HasBuff(Laugicality.instance.BuffType<MoonLordSoulCooldownBuff>()))
                MoonLordLifeMult = 1f;
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
                player.AddBuff(mod.BuffType<DestroyerSoulCooldownBuff>(), 90 * Constants.TICKS_PER_SECONDS);
                return false;
            }

            if(SteamTrainEffect && !player.HasBuff(Laugicality.instance.BuffType<SteamTrainSoulCooldownBuff>()) && player.GetModPlayer<LaugicalityPlayer>().Focus == FocusManager.Instance.Vitality)
            {
                if (player.statLife < player.statLifeMax2)
                {
                    player.statLife = player.statLifeMax2;
                    player.AddBuff(mod.BuffType<SteamTrainSoulCooldownBuff>(), 150 * Constants.TICKS_PER_SECONDS);
                    return false;
                }
            }

            if(MoonLordEffect && !player.HasBuff(Laugicality.instance.BuffType<MoonLordSoulCooldownBuff>()) && player.GetModPlayer<LaugicalityPlayer>().Focus == FocusManager.Instance.Vitality && player.statLifeMax2 > 100 && damage >= player.statLife)
            {
                MoonLordLifeMult *= .5f;
                player.statLifeMax2 = (int)(MoonLordLifeMult * player.statLifeMax2);
                player.statLife = player.statLifeMax2;
                player.AddBuff(mod.BuffType<MoonLordSoulCooldownBuff>(), 90 * Constants.TICKS_PER_SECONDS);
                return false;
            }
            return true;
        }

        public int HoneyRegenMultiplier { get; set; }

        public bool DestroyerEffect { get; set; }
        public bool DestroyerCooldown { get; set; }
        public bool SteamTrainEffect { get; set; }
        public float MoonLordLifeMult { get; set; }
        public bool MoonLordEffect { get; set; }
    }
}
