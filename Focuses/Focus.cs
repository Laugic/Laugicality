using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using WebmilioCommons.Managers;

namespace Laugicality.Focuses
{
    public abstract class Focus : IHasUnlocalizedName
    {
        private readonly List<Focus> _enemies, _nemeses;
        private readonly List<FocusEffect> _effects, _curses;

        private IReadOnlyList<Focus> _finalEnemies, _finalNemeses;
        private IReadOnlyList<FocusEffect> _finalEffects, _finalCurses;

        protected Focus(string unlocalizedName, string displayName, Color associatedColor, FocusEffect[] effects, FocusEffect[] curses) : this(unlocalizedName, displayName, associatedColor, new List<Focus>(), new List<Focus>(), effects, curses)
        {
        }

        protected Focus(string unlocalizedName, string displayName, Color associatedColor, IEnumerable<Focus> enemies, IEnumerable<Focus> nemeses, FocusEffect[] effects, FocusEffect[] curses)
        {
            UnlocalizedName = unlocalizedName;
            DisplayName = displayName;
            AssociatedColor = associatedColor;

            _enemies = new List<Focus>(enemies);
            _nemeses = new List<Focus>(nemeses);

            _effects = new List<FocusEffect>(effects);
            _curses = new List<FocusEffect>(curses);
        }


        internal void ManagerEndInitialization()
        {
            if (EnemiesCount < 2) throw new Exception("All foci must have at least two enemies.");
            if (NemesesCount < 1) throw new Exception("All foci must have at least one nemesis.");

            _finalEnemies = _enemies.AsReadOnly();
            _finalNemeses = _nemeses.AsReadOnly();

            _finalEffects = _effects.AsReadOnly();
            _finalCurses = _curses.AsReadOnly();
        }


        public void RegisterEnemies(params Focus[] focus)
        {
            for (int i = 0; i < focus.Length; i++)
                _enemies.Add(focus[i]);
        }

        public void RegisterNemeses(params Focus[] focus)
        {
            for (int i = 0; i < focus.Length; i++)
                _nemeses.Add(focus[i]);
        }


        /*public virtual bool PlayerPreHurt(LaugicalityPlayer laugicalityPlayer, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            List<FocusEffect> activeFocusEffects = GetActives(laugicalityPlayer);

            for (int i = 0; i < activeFocusEffects.Count; i++)
                if (!activeFocusEffects[i].PlayerPreHurt(laugicalityPlayer, this, pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource))
                    return false;

            return true;
        }

        public virtual void PlayerPostHurt(LaugicalityPlayer laugicalityPlayer, bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            List<FocusEffect> activeFocusEffects = GetActives(laugicalityPlayer);

            for (int i = 0; i < activeFocusEffects.Count; i++)
                activeFocusEffects[i].PlayerPostHurt(laugicalityPlayer, this, pvp, quiet, damage, hitDirection, crit);
        }*/


        #region Accessors

        private List<FocusEffect> GetActives(LaugicalityPlayer laugicalityPlayer, List<FocusEffect> focusEffects)
        {
            List<FocusEffect> activeEffects = new List<FocusEffect>(focusEffects);

            for (int i = 0; i < focusEffects.Count; i++)
                if (activeEffects[i].Condition(laugicalityPlayer))
                    activeEffects.Add(_effects[i]);

            return activeEffects;
        }

        public List<FocusEffect> GetActives(LaugicalityPlayer laugicalityPlayer)
        {
            List<FocusEffect> activeEffects = GetActiveEffects(laugicalityPlayer);
            List<FocusEffect> activeCurses = GetActiveCurses(laugicalityPlayer);

            List<FocusEffect> all = new List<FocusEffect>(activeEffects.Count + activeCurses.Count);
            all.AddRange(activeEffects);
            all.AddRange(activeCurses);

            return all;
        }

        public List<FocusEffect> GetActiveEffects(LaugicalityPlayer laugicalityPlayer) => GetActives(laugicalityPlayer, _effects);
        public List<FocusEffect> GetActiveCurses(LaugicalityPlayer laugicalityPlayer) => GetActives(laugicalityPlayer, _curses);


        public FocusEffect GetEffect(int index) => _effects[index];
        public FocusEffect GetCurse(int index) => _curses[index];

        public Focus GetEnemy(int index) => _enemies[index];
        public Focus GetNemesis(int index) => _nemeses[index];


        public int EffectsCount => _effects.Count;
        public int CursesCount => _curses.Count;

        public int EnemiesCount => _enemies.Count;
        public int NemesesCount => _nemeses.Count;

        #endregion


        public string UnlocalizedName { get; }

        public string DisplayName { get; }

        public Color AssociatedColor { get; }

        public IReadOnlyList<Focus> Enemies => _finalEnemies;
        public IReadOnlyList<Focus> Nemeses => _finalNemeses;

        public IReadOnlyList<FocusEffect> Effects => _finalEffects;
        public IReadOnlyList<FocusEffect> Curses => _finalCurses;
    }
}