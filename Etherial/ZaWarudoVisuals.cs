using Microsoft.Xna.Framework;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using WebmilioCommons.Time;

namespace Laugicality.Etherial
{
    public class ZaShader : ScreenShaderData
    {
        private int _yIndex;
        
        public ZaShader(string passName)
			: base(passName)
		{
        }
        
        public override void Apply()
        {
            base.Apply();
        }
    }

    public class ZaWarudoVisual : CustomSky
    {
        private bool _isActive = false;
        private float _intensity = 0f;

        public override void Update(GameTime gameTime)
        {
            if (_isActive && _intensity < 1f)
            {
                _intensity += 0.01f;
            }
            else if (!_isActive && _intensity > 0f)
            {
                _intensity -= 0.01f;
            }
        }

        private float GetIntensity()
        {
            if (Laugicality.zaWarudo > 0 || TimeManagement.TimeAltered)
            {
                return (1f - Utils.SmoothStep(3000f, 6000f, 1)) * 0.66f;
            }
            return 0.66f;
        }

        public override Color OnTileColor(Color inColor)
        {
            float intensity = this.GetIntensity();
            return new Color(Vector4.Lerp(new Vector4(0.5f, 0.5f, .5f, 1f), inColor.ToVector4(), 1f - intensity));
        }


        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            if (maxDepth >= 0 && minDepth < 0)
            {
                float intensity = this.GetIntensity();
                spriteBatch.Draw(Main.blackTileTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), new Color(100, 100, 100) * intensity);
            }
        }

        public override float GetCloudAlpha()
        {
            return 0f;
        }

        public override void Activate(Vector2 position, params object[] args)
        {
            _isActive = true;
        }

        public override void Deactivate(params object[] args)
        {
            _isActive = false;
        }

        public override void Reset()
        {
            _isActive = false;
        }

        public override bool IsActive()
        {
            return _isActive || _intensity > 0f;
        }
    }
}