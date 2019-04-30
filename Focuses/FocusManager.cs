using Laugicality.Managers;

namespace Laugicality.Focuses
{
    public sealed class FocusManager : Manager<Focus>
    {
        private static FocusManager _instance;

        protected override void DefaultInitialize()
        {
            Vitality = Add(new VitalityFocus());

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