using Laugicality.Dusts;
using Laugicality.Items.Placeable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace Laugicality.Tiles
{
    public class Radiata : AmelderaTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = false;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(160, 15, 0));
            mineResist = .5f;
            minPick = 10;
            drop = ModContent.ItemType<Items.Placeable.Radiata>();
            dustType = ModContent.DustType<Magma>();

            amelderaTexture = mod.GetTexture(this.GetType().GetRootPath() + "/ElderootTile");
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void RandomUpdate(int i, int j)
        {
            int randm = Main.rand.Next(18);
            if (randm < 9)
            {
                if (CheckTile(i, j + 1))
                {
                    Terraria.WorldGen.PlaceTile(i, j + 1, ModContent.TileType<ObsidiumVine>(), true);
                }
                else if (Main.tile[i, j + 1].type == ModContent.TileType<ObsidiumVine>())
                {
                    for(int k = 1; k < 12; k++)
                    {
                        if (Main.tile[i, j + k].type != ModContent.TileType<ObsidiumVine>())
                        {
                            if(Main.tile[i, j + k].type == 0)
                                Terraria.WorldGen.PlaceTile(i, j + k, ModContent.TileType<ObsidiumVine>(), true);
                            break;
                        }
                    }
                }
            }
        }
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (j < Main.maxTilesY - 4)
            {
                if (Main.tile[i, j + 1].type == ModContent.TileType<ObsidiumVine>())
                    Terraria.WorldGen.KillTile(i, j + 1);
            }
        }
        private bool CheckTile(int i, int j)
        {
            if (Main.tile[i, j].type != 0)
                return false;
            return true;
        }

        public override bool Drop(int i, int j)
        {
            if (LaugicalityWorld.Ameldera)
            {
                Item.NewItem(i * 16, j * 16, 8, 8, ModContent.ItemType<ElderootItem>(), 1);
                return false;
            }
            return base.Drop(i, j);
        }
    }
}