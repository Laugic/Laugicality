using Laugicality.Focuses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace Laugicality.UI.FocusUI
{
    public class FocusUIState : UIState
    {
        private const float
            PANEL_WIDTH = 2400,
            PANEL_HEIGHT = 2400;

        public FocusUIState()
        {
            MainPanel = new UIPanel();
            MainPanel.Width.Set(600, 0);
            MainPanel.Height.Set(600, 0);
            MainPanel.HAlign = 0.5f;
            MainPanel.VAlign = 0.5f;
            MainPanel.BackgroundColor = Color.Black * 0.5f;

            MainPanel.OverflowHidden = true;

            Visible = true;

            FocusPanel = new FocusPanel(PANEL_WIDTH, PANEL_HEIGHT)
            {
                BackgroundColor = Color.Black * 0.5f,
                BorderColor = Color.Black * 0.5f,
                VAlign = 0.5f,
                HAlign = 0.5f
            };

            FocusPanel.MinWidth.Set(PANEL_WIDTH, 0);
            FocusPanel.MinHeight.Set(PANEL_HEIGHT, 0);

            UIImage image = new UIImage(Laugicality.Instance.GetTexture("SoulStones/SoulStone"));
            image.HAlign = 0.5f;
            image.VAlign = 0.5f;

            // Change this to use player's focus (DrawSelf)
            FocusBonusButton button = new FocusBonusButton(Laugicality.Instance.GetTexture("SoulStones/CapacityFocusStone"), FocusManager.Instance.Utility.Effects[0]);

            button.HAlign = 0.6f;
            button.VAlign = 0.5f;

            FocusPanel.Append(button);
            FocusPanel.Append(image);
            MainPanel.Append(FocusPanel);

            base.Append(MainPanel);
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            if (MainPanel.IsMouseHovering)
                Main.LocalPlayer.mouseInterface = true;

            Recalculate();
        }


        public UIPanel MainPanel { get; private set; }

        public FocusPanel FocusPanel { get; private set; }

        public bool Visible { get; set; }
    }
}
