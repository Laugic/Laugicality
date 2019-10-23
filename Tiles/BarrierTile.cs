using Laugicality.Items.Placeable;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Tiles
{
    public class BarrierTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            dustType = 0;
            drop = ModContent.ItemType<Barrier>();
            minPick = 225;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 0;
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            return Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>().HoldingBarrier;
        }
    }
}