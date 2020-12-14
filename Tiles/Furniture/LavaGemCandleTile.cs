using Laugicality.Items.Placeable.Furniture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Laugicality.Tiles.Furniture
{
    public class LavaGemCandleTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileTable[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileWaterDeath[Type] = true;
            Main.tileLavaDeath[Type] = false;

            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.WaterDeath = true;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.LavaPlacement = LiquidPlacement.Allowed;
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Lava Gem Candle");
            AddMapEntry(new Color(170, 200, 120), name);

            drop = ModContent.ItemType<LavaGemCandle>();
            adjTiles = new int[] { TileID.Candles };
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        }

        public override void HitWire(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            short frameAdjustment = (short)(tile.frameX > 0 ? -18 : 18);
            Main.tile[i, j].frameX += frameAdjustment;
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
                spriteEffects = SpriteEffects.FlipHorizontally;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.frameX == 0)
            {
                r = 1f;
                g = 0.65f;
                b = .25f;
            }
        }
    }
}
