using Laugicality.Managers;

namespace Laugicality.Focuses
{
    public sealed class FocusManager : Manager<Focus>
    {
        private static FocusManager _instance;

        internal override void DefaultInitialize()
        {
            Vitality = Add(new VitalityFocus());

            Vitality.RegisterAlliedFocus();


            base.DefaultInitialize();
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