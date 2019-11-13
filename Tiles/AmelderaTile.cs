using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace Laugicality.Tiles
{
    public class AmelderaTile : ModTile
    {
        public Texture2D obsidiumTexture, amelderaTexture;

        public override void SetDefaults()
        {
            obsidiumTexture = this.GetType().GetTexture();
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (LaugicalityWorld.Ameldera)
                Main.tileTexture[Type] = amelderaTexture;
            else
                Main.tileTexture[Type] = obsidiumTexture;
            return base.PreDraw(i, j, spriteBatch);
        }
    }
}
