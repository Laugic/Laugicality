using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Laugicality.Managers;
using Microsoft.Xna.Framework;

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


        #region Accessors

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