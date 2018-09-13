using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Laugicality.Tiles
{
    public class ObsidiumPlantBulbs : ModTile
    {
        bool anim = true;
        public override void SetDefaults()
        {
            anim = true;
            Main.tileSolid[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            dustType = mod.DustType("Magma");
            //drop = mod.ItemType("LavaGem");
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Lycoris Radiata");
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.Width = 4;
            //AddMapEntry(new Color(200, 30, 0), name);
            Main.tileFrameImportant[Type] = true;
            soundType = 6;
            TileObjectData.newTile.AnchorValidTiles = new int[]
            {
				mod.TileType<Lycoris>(),
                mod.TileType<Radiata>()
            };
            TileObjectData.addTile(Type);
        }
        

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        
        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            offsetY = 4;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = .2f;
            g = 0.08f;
            b = 0.0f;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 64, 64, mod.ItemType("ObsidiumPlant"));
        }
    }
}