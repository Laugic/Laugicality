using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Tiles
{
    public class ObsidiumCore : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Obsidium Core");
            AddMapEntry(new Color(200, 150, 50), name);
            mineResist = .5f;
            minPick = 50;
            dustType = mod.DustType("Magma");
            drop = mod.ItemType("ObsidiumCore");
        }
        
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.9f;
            g = 0.6f;
            b = 0f;
        }

        public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i, j - 1].type == 0 && Main.tile[i + 1, j - 1].type == 0 && Main.tile[i, j - 2].type == 0 && Main.tile[i + 1, j - 2].type == 0 && Main.tile[i, j].active() && LaugicalityWorld.downedRagnar)
            {
                if (Main.rand.Next(20) == 0)
                    WorldGen.PlaceObject(i, j - 1, TileID.Heart, true, 0, -1, -1);
            }
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}