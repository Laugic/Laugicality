using System.Collections;
using System.Collections.Generic;
using Laugicality.Managers;
using Microsoft.Xna.Framework;

namespace Laugicality.Focuses
{
    public abstract class Focus : IHasUnlocalizedName
    {
        private readonly List<Focus>
            _alliedFocuses = new List<Focus>(),
            _opposedFocuses = new List<Focus>();

        private readonly List<FocusEffect> _effects;


        protected Focus(string unlocalizedName, string displayName, Color associatedColor, params FocusEffect[] effects)
        {
            UnlocalizedName = unlocalizedName;
            DisplayName = displayName;
            AssociatedColor = associatedColor;

            _effects = new List<FocusEffect>(effects);
        }

        protected Focus(string unlocalizedName, string displayName, Color associatedColor, IEnumerable<Focus> alliedFocuses, IEnumerable<Focus> enemyFocuses, params FocusEffect[] effects) : this(unlocalizedName, displayName, associatedColor)
        {
            _alliedFocuses = new List<Focus>(alliedFocuses);
            _opposedFocuses = new List<Focus>(enemyFocuses);
        }


        public void RegisterAlliedFocus(params Focus[] focus) => HandleAddFocusCategory(_alliedFocuses, focus);

        public void RegisterOpposedFocus(params Focus[] focus) => HandleAddFocusCategory(_opposedFocuses, focus);

        private void HandleAddFocusCategory(List<Focus> focusCategory, Focus[] focus)
        {
            for (int i = 0; i < focus.Length; i++)
                focusCategory.Add(focus[i]);
        }


        public FocusEffect GetEffectAt(int index) => _effects[index];

        public IEnumerator<FocusEffect> GetEnumerator() => _effects.GetEnumerator();


        public string UnlocalizedName { get; }

        public string DisplayName { get; }

        public Color AssociatedColor { get; }

        public int EffectsCount => _effects.Count;
    }
}