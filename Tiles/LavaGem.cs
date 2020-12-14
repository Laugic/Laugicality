using Laugicality.Dusts;
using Laugicality.Items.Placeable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using WebmilioCommons.Extensions;

namespace Laugicality.Tiles
{
    public class LavaGem : AmelderaTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileBlockLight[Type] = false;
            Main.tileLighted[Type] = true;

            dustType = ModContent.DustType<Magma>();
            drop = ModContent.ItemType<Items.Placeable.LavaGemItem>();

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Lava Gem");
            AddMapEntry(new Color(180, 50, 0), name);

            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.AnchorValidTiles = new int[]
            {
                56, //TileID.Obsidian
				ModContent.TileType<Tiles.ObsidiumRock>()
            };
            TileObjectData.addTile(Type);

            if (!Main.dedServ)
            {
                obsidiumTexture = this.GetType().GetTexture();
                amelderaTexture = mod.GetTexture(this.GetType().GetRootPath() + "/ArcanaGemTile");
            }
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if ((i % 10) < 5)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
        {
                frameXOffset = i % 5 * 18;
        }
        
        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            offsetY = 4;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = .2f;
            if (LaugicalityWorld.Ameldera)
                r = .05f;
            g = 0.08f;
            b = 0.0f;
            if (LaugicalityWorld.Ameldera)
                b = .2f;
        }

        public override bool Drop(int i, int j)
        {
            if (LaugicalityWorld.Ameldera)
            {
                Item.NewItem(i * 16, j * 16, 8, 8, ModContent.ItemType<ElderockItem>(), 1);
                return false;
            }
            return base.Drop(i, j);
        }
    }
}