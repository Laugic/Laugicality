using Terraria;
using Terraria.UI;

namespace Laugicality.UI.FocusUI
{
    public class FocusLayer : GameInterfaceLayer
    {
        public FocusLayer(FocusUIState state) : base("Enigma: Focus UI", InterfaceScaleType.UI)
        {
            FocusUIState = state;
            FocusUIState.Activate();

            FocusUserInterface = new UserInterface();
            FocusUserInterface.SetState(FocusUIState);
        }

        protected override bool DrawSelf()
        {
            FocusUIState?.Draw(Main.spriteBatch);

            return true;
        }

        /// Needed for UI to be clickable. Otherwise, you cannot interact with it, like clicking on it
        public UserInterface FocusUserInterface { get; }

        public FocusUIState FocusUIState { get; }
    }
}
