using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

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
        
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
			if (frameCounter >= 5)
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
            Item.NewItem(i * 16, j * 16, 112, 64, ModContent.ItemType("LaugicalWorkbench"));
        }
    }
}