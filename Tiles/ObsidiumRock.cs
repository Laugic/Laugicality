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
            bool spawned = false;
            spawned = LavaGemSpawn(i, j);
            if (!spawned)
                spawned = SpawnRocks(i, j);
            if (!spawned)
                spawned = LargeLavaGemSpawn(i, j);
        }

        private bool LavaGemSpawn(int i, int j)
        {
            if (Main.tile[i, j - 1].type == 0 && Main.tile[i, j].active())
            {
                if (Main.rand.Next(4) == 0)
                {
                    WorldGen.PlaceTile(i, j - 1, mod.TileType("LavaGem"), true);
                    return true;
                }
            }
            return false;
        }
        
        private bool SpawnRocks(int i, int j)
        {
            if (Main.tile[i, j - 1].type == 0 && Main.rand.Next(4) == 0)
            {
                WorldGen.PlaceTile(i, j - 1, mod.TileType("ObsidiumRocks"), true);
                return true;
            }
            else if(Main.tile[i, j - 1].type == 0 && Main.tile[i, j - 2].type == 0 && Main.rand.Next(3) == 0)
            {
                WorldGen.PlaceTile(i, j - 1, mod.TileType("ObsidiumStalagmites"), true);
                return true;
            }
            else if (Main.tile[i, j + 1].type == 0 && Main.tile[i, j + 2].type == 0 && Main.rand.Next(2) == 0)
            {
                WorldGen.PlaceTile(i, j + 1, mod.TileType("ObsidiumStalactites"), true);
                return true;
            }
            return false;
        }

        private bool LargeLavaGemSpawn(int i, int j)
        {
            if (Main.tile[i, j - 1].type == 0 && Main.tile[i + 1, j - 1].type == 0 && Main.tile[i, j - 2].type == 0 && Main.tile[i + 1, j - 2].type == 0)
            {
                if(Main.rand.Next(12) == 0)
                {
                    WorldGen.PlaceTile(i, j - 1, mod.TileType("LargeLavaGem"), true);
                    return true;
                }
            }
            return false;
        }
    }
}