using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Laugicality.Tiles
{
    public class ObsidiumRockGrass : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[mod.TileType("ObsidiumRockGrass")][mod.TileType("ObsidiumRock")] = true;
            Main.tileLighted[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("");
            AddMapEntry(new Color(50, 50, 50), name);
            mineResist = 0f;
            minPick = 0;
            drop = mod.ItemType("ObsidiumRock");
            soundType = 21;
            //soundStyle = 1;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        public override void RandomUpdate(int i, int j)
        {
            int count = 0;
            if (Main.tile[i, j - 1].type == 0 && Main.tile[i, j].active())
            {
                for (int k = 0; k < 100; k++)
                {
                    for(int l = 0; l < 100; l++)
                    {
                        if (Main.tile[i, j - 1].type == (ushort)mod.TileType("LavaGem"))
                            count++;
                    }
                }
                if(count < 8)
                    Terraria.WorldGen.PlaceTile(i, j - 1, mod.TileType("LavaGem"), true);
            }
        }

        public override bool Drop(int i, int j)
        {
            Terraria.WorldGen.PlaceTile(i, j, mod.TileType("ObsidiumRock"), true);
            return false;
        }

        /*public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.2f;
            g = 0.1f;
            b = 0.2f;
        }
        
        public override bool CanExplode(int i, int j)
        {
            return false;
        }*/

    }
}