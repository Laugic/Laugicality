namespace Laugicality
{
    public sealed partial class LaugicalityPlayer
    {
        private const int HONEY_BASE_LIFE_REGEN = 1;

        internal void ResetSoulStoneEffects()
        {
            HoneyRegenMultiplier = 1;
        }

        internal void UpdateSoulStoneLifeRegen()
        {
            if (player.honey)
                player.lifeRegen += HONEY_BASE_LIFE_REGEN * HoneyRegenMultiplier - HONEY_BASE_LIFE_REGEN;
        }

        public int HoneyRegenMultiplier { get; set; }
    }
}
