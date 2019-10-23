using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Tiles
{
    public class ObsidiumRock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMerge[56][ModContent.TileType<Tiles.ObsidiumRock>()] = true;
            Main.tileMerge[ModContent.TileType<Tiles.ObsidiumRock>()][56] = true;
            Main.tileMerge[ModContent.TileType<Tiles.ObsidiumRock>()][ModContent.TileType<ObsidiumOreBlock>()] = true;
            Main.tileMerge[ModContent.TileType<ObsidiumOreBlock>()][ModContent.TileType<Tiles.ObsidiumRock>()] = true;
            Main.tileMerge[ModContent.TileType<Tiles.ObsidiumRock>()][ModContent.TileType<ObsidiumBrick>()] = true;
            Main.tileMerge[ModContent.TileType<ObsidiumBrick>()][ModContent.TileType<Tiles.ObsidiumRock>()] = true;
            Main.tileMerge[ModContent.TileType<ObsidiumOreBlock>()][ModContent.TileType<ObsidiumBrick>()] = true;
            Main.tileMerge[ModContent.TileType<ObsidiumBrick>()][ModContent.TileType<ObsidiumOreBlock>()] = true;
            Main.tileMerge[56][ModContent.TileType<ObsidiumBrick>()] = true;
            Main.tileMerge[ModContent.TileType<ObsidiumBrick>()][56] = true;
            Main.tileMerge[ModContent.TileType<ObsidiumBrick>()][58] = true;
            Main.tileMerge[ModContent.TileType<ObsidiumOreBlock>()][58] = true;
            Main.tileMerge[ModContent.TileType<Tiles.ObsidiumRock>()][58] = true;
            Main.tileMerge[58][ModContent.TileType<ObsidiumBrick>()] = true;
            Main.tileMerge[58][ModContent.TileType<ObsidiumOreBlock>()] = true;
            Main.tileMerge[58][ModContent.TileType<Tiles.ObsidiumRock>()] = true;
            Main.tileLighted[Type] = false;
            AddMapEntry(new Color(50, 50, 50));
            mineResist = 1f;
            minPick = 20;
            drop = ModContent.ItemType<Items.Placeable.ObsidiumRock>();
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
            if (Main.rand.Next(8) == 0)
            {
                bool spawned = false;
                spawned = LavaGemSpawn(i, j);
                if (!spawned)
                    spawned = SpawnRocks(i, j);
                if (!spawned)
                    spawned = LargeLavaGemSpawn(i, j);
            }
        }

        private bool LavaGemSpawn(int i, int j)
        {
            if (Main.tile[i, j - 1].type == 0 && Main.tile[i, j].active())
            {
                if (Main.rand.Next(4) == 0)
                {
                    WorldGen.PlaceTile(i, j - 1, ModContent.TileType<LavaGem>(), true);
                    return true;
                }
            }
            return false;
        }
        
        private bool SpawnRocks(int i, int j)
        {
            if (Main.tile[i, j - 1].type == 0 && Main.rand.Next(4) == 0)
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<ObsidiumRocks>(), true);
                return true;
            }
            else if(Main.tile[i, j - 1].type == 0 && Main.tile[i, j - 2].type == 0 && Main.rand.Next(3) == 0)
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<ObsidiumStalagmites>(), true);
                return true;
            }
            else if (Main.tile[i, j + 1].type == 0 && Main.tile[i, j + 2].type == 0 && Main.rand.Next(2) == 0)
            {
                WorldGen.PlaceTile(i, j + 1, ModContent.TileType<ObsidiumStalactites>(), true);
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
                    WorldGen.PlaceTile(i, j - 1, ModContent.TileType<LargeLavaGem>(), true);
                    return true;
                }
            }
            return false;
        }
    }
}