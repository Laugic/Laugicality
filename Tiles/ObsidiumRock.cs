using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Laugicality.Tiles
{
    public class ObsidiumRock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMerge[56][mod.TileType("ObsidiumRock")] = true;
            Main.tileMerge[mod.TileType("ObsidiumRock")][56] = true;
            Main.tileMerge[mod.TileType("ObsidiumRock")][mod.TileType("ObsidiumOreBlock")] = true;
            Main.tileMerge[mod.TileType("ObsidiumOreBlock")][mod.TileType("ObsidiumRock")] = true;
            Main.tileMerge[mod.TileType("ObsidiumRock")][mod.TileType("ObsidiumBrick")] = true;
            Main.tileMerge[mod.TileType("ObsidiumBrick")][mod.TileType("ObsidiumRock")] = true;
            Main.tileMerge[mod.TileType("ObsidiumOreBlock")][mod.TileType("ObsidiumBrick")] = true;
            Main.tileMerge[mod.TileType("ObsidiumBrick")][mod.TileType("ObsidiumOreBlock")] = true;
            Main.tileMerge[56][mod.TileType("ObsidiumBrick")] = true;
            Main.tileMerge[mod.TileType("ObsidiumBrick")][56] = true;
            Main.tileMerge[mod.TileType("ObsidiumBrick")][58] = true;
            Main.tileMerge[mod.TileType("ObsidiumOreBlock")][58] = true;
            Main.tileMerge[mod.TileType("ObsidiumRock")][58] = true;
            Main.tileMerge[58][mod.TileType("ObsidiumBrick")] = true;
            Main.tileMerge[58][mod.TileType("ObsidiumOreBlock")] = true;
            Main.tileMerge[58][mod.TileType("ObsidiumRock")] = true;
            Main.tileMerge[mod.TileType("ObsidiumBrick")][mod.TileType("Radiata")] = true;
            Main.tileMerge[mod.TileType("ObsidiumOreBlock")][mod.TileType("Radiata")] = true;
            Main.tileMerge[mod.TileType("ObsidiumRock")][mod.TileType("Radiata")] = true;
            Main.tileMerge[58][mod.TileType("Radiata")] = true;
            Main.tileMerge[56][mod.TileType("Radiata")] = true;
            Main.tileMerge[mod.TileType("Radiata")][mod.TileType("ObsidiumBrick")] = true;
            Main.tileMerge[mod.TileType("Radiata")][mod.TileType("ObsidiumOreBlock")] = true;
            Main.tileMerge[mod.TileType("Radiata")][mod.TileType("ObsidiumRock")] = true;
            Main.tileMerge[mod.TileType("Radiata")][58] = true;
            Main.tileMerge[mod.TileType("Radiata")][56] = true;
            Main.tileLighted[Type] = false;
            AddMapEntry(new Color(50, 50, 50));
            mineResist = 1f;
            minPick = 20;
            drop = mod.ItemType("ObsidiumRock");
            soundType = 21;
            dustType = 1;
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
                for (int k = -50; k < 51; k++)
                {
                    for(int l = -50; l < 51; l++)
                    {
                        if(i + k > 0 && i + k < Main.maxTilesX && j + l > 0 && j + l < Main.maxTilesY)
                        {
                            if (Main.tile[i + k, j + l].type == (ushort)mod.TileType("LavaGem"))
                                count++;
                        }
                    }
                }
                if(count < 12)
                    Terraria.WorldGen.PlaceTile(i, j - 1, mod.TileType("LavaGem"), true);
            }
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