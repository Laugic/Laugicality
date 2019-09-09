using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class BurningFragrance : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Burning Fragrance");
			Description.SetDefault("Increased attack stats");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage += 0.12f;
        }
        
	}
}
