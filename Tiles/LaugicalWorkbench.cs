using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework.Graphics;

namespace Laugicality.Tiles
{
    public class LaugicalWorkbench : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.Width = 7;
            //TileObjectData.newTile.Height = 3;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Laugical Workbench");
            AddMapEntry(new Color(200, 200, 200), name);
            disableSmartCursor = true;
            //adjTiles = new int[] { TileID.WorkBenches };
            animationFrameHeight = 74;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            /*
            if (closer)
            {
                Player player = Main.LocalPlayer;
                player.AddBuff(mod.BuffType("Connected"), 60, true);
            }*/
        }

        /*public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            //LaugicalityWorld.power += 1;
            return true;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }*/

        //int animationFrameWidth = 126;
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            //Main.NewText(frame.ToString(), 250, 250, 0);
            frameCounter++;
			if (frameCounter > 5)
			{
				frameCounter = 0;
				frame++;
				if (frame > 26)
				{
					frame = 0;
				}
			}
            
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 112, 64, mod.ItemType("LaugicalWorkbench"));
        }
    }
}