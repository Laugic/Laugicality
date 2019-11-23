using Laugicality.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using WebmilioCommons.Extensions;

namespace Laugicality.Tiles
{
    public class ObsidiumPlantGrass2 : AmelderaTile
    {
        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Lycoris Radiata");
            //AddMapEntry(new Color(200, 30, 0), name);
            disableSmartCursor = true;
            Main.tileCut[Type] = true;
            dustType = ModContent.DustType<Magma>();
            soundType = 6;
            //adjTiles = new int[] { TileID.WorkBenches };

            obsidiumTexture = this.GetType().GetTexture();
            amelderaTexture = mod.GetTexture(this.GetType().GetRootPath() + "/EldergrassPlant2");
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            offsetY = 2;
        }
    }
}