using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Walls
{
	public class ObsidiumRockWall : ModWall
	{
		public override void SetDefaults()
		{
			dustType = 1;
			AddMapEntry(new Color(20, 20, 32));
            drop = mod.ItemType("ObsidiumRockWall");
        }

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

        public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i, j].liquid > 1 && !Main.tile[i, j].lava() && Main.tile[i, j].type < 1)
            {
                Main.tile[i, j].liquid = 0;
                Main.tile[i, j].ClearTile();
            }
            base.RandomUpdate(i, j);
        }
    }
}