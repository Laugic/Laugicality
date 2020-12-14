using Laugicality.Dusts;
using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Tiles
{
    public class MagmaVeins : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = false;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Magma Shard");
            AddMapEntry(new Color(150, 100, 50));
            mineResist = 1f;
            minPick = 60;
            drop = ModContent.ItemType<DarkShard>();
            dustType = ModContent.DustType<Magma>();
            //soundType = 21;
            //soundStyle = 1;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.4f;
            g = 0.1f;
            b = 0f;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }

        public override void RandomUpdate(int i, int j)
        {
            if (Main.rand.Next(2) == 0)
                LaugicalityWorld.ObsidiumHeartGrowth++;
            if (Main.tile[i, j - 1].type == 0 && Main.tile[i + 1, j - 1].type == 0 && Main.tile[i, j - 2].type == 0 && Main.tile[i + 1, j - 2].type == 0 && Main.tile[i, j].active())
            {
                if (LaugicalityWorld.ObsidiumHeartGrowth > 20 && Main.rand.Next(4) == 0)
                {
                    LaugicalityWorld.ObsidiumHeartGrowth = 0;
                    WorldGen.PlaceObject(i, j - 1, ModContent.TileType<ObsidiumHeart>(), true, 0, -1, -1);
                }
            }
        }
    }
}