using Laugicality.Managers;

namespace Laugicality.Focuses
{
    public sealed class FocusManager : Manager<Focus>
    {
        private static FocusManager _instance;

        protected override void DefaultInitialize()
        {
            Vitality = Add(new VitalityFocus());
            Tenacity = Add(new TenacityFocus());
            Mobility = Add(new MobilityFocus());
            Utility = Add(new UtilityFocus());
            Ferocity = Add(new FerocityFocus());
            Capacity = Add(new CapacityFocus());

            Focus[] enemies = { Mobility, Ferocity };
            Vitality.RegisterEnemies(enemies);
            Vitality.RegisterNemeses(Utility);
            enemies[0] = Utility;
            enemies[1] = Capacity;
            Tenacity.RegisterEnemies(enemies);
            Tenacity.RegisterNemeses(Ferocity);
            enemies[0] = Ferocity;
            enemies[1] = Vitality;
            Mobility.RegisterEnemies(enemies);
            Mobility.RegisterNemeses(Capacity);
            enemies[0] = Capacity;
            enemies[1] = Tenacity;
            Utility.RegisterEnemies(enemies);
            Utility.RegisterNemeses(Vitality);
            enemies[0] = Vitality;
            enemies[1] = Mobility;
            Ferocity.RegisterEnemies(enemies);
            Ferocity.RegisterNemeses(Tenacity);
            enemies[0] = Tenacity;
            enemies[1] = Utility;
            Capacity.RegisterEnemies(enemies);
            Capacity.RegisterNemeses(Mobility);

            ForAllItems(f => f.ManagerEndInitialization());
            base.DefaultInitialize();
        }

        public override bool Remove(Focus item)
        {
            if (Locked) return false;
            if (!byIndex.Contains(item)) return false;

            byIndex.Remove(item);
            byNames.Remove(item.UnlocalizedName);
            return true;
        }

        public Focus Vitality { get; private set; }

        public Focus Tenacity { get; private set; }

        public Focus Mobility { get; private set; }

        public Focus Utility { get; private set; }

        public Focus Ferocity { get; private set; }

        public Focus Capacity { get; private set; }

        public static FocusManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FocusManager();

                if (!_instance.Initialized)
                    _instance.DefaultInitialize();

                return _instance;
            }
        }
    }
}