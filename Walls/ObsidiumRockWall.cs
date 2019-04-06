using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Laugicality.Walls
{
	public class ObsidiumRockWall : ModWall
	{
		public override void SetDefaults()
		{
			//Main.wallHouse[Type] = true;
			dustType = 1;
			AddMapEntry(new Color(20, 20, 32));
            drop = mod.ItemType("ObsidiumRockWall");
        }

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		
	}
}