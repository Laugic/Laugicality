using Laugicality.Focuses;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using System.Text.RegularExpressions;
using System;
using ReLogic.Graphics;

namespace Laugicality.UI.FocusUI
{
    public class FocusBonusButton : UIImageButton
    {
        public FocusBonusButton(Texture2D texture, FocusEffect effect) : base(texture)
        {
            AssignedEffect = effect;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (!ContainsPoint(Main.MouseScreen))
                return;

            int panelHeight = 64;

            Vector2 position = Main.MouseWorld + new Vector2(Main.cursorTextures[0].Width - 178, Main.cursorTextures[0].Height * 2) - Main.screenPosition;

            string finalizedDesc = SpliceText(AssignedEffect.Tooltip.text, 24);
            panelHeight += finalizedDesc.Split('\n').Length * 26;

            Rectangle descriptionBGSize = new Rectangle(0, 0, 400, panelHeight);

            spriteBatch.Draw(Main.magicPixel, position, descriptionBGSize, Color.DarkSlateGray, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            spriteBatch.DrawString(Main.fontMouseText, "ERROR404:NAME NOT FOUND", position + new Vector2(16), Color.Yellow);
            spriteBatch.Draw(Main.magicPixel, position + new Vector2(20, 40), new Rectangle(0, 0, 360, 2), Color.Yellow, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(Main.fontMouseText, finalizedDesc, position + new Vector2(16, 48), Color.White);
        }


        private string SpliceText(string text, int lineLength)
        {
            return Regex.Replace(text, "(.{" + lineLength + "})" + ' ', "$1" + Environment.NewLine);
        }


        public FocusEffect AssignedEffect { get; }
    }
}
