using System;
using Terraria.ModLoader;

namespace Laugicality.Focuses
{
    public sealed class FocusEffect
    {
        public FocusEffect(Predicate<LaugicalityPlayer> condition, Action<LaugicalityPlayer, bool> effect, TooltipLine tooltip)
        {
            Condition = condition;
            Effect = effect;

            Tooltip = tooltip;
        }

        public Predicate<LaugicalityPlayer> Condition { get; }
        public Action<LaugicalityPlayer, bool> Effect { get; }

        public TooltipLine Tooltip { get; }
    }
}