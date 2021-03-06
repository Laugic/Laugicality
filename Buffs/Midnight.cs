using Terraria;

namespace Laugicality.Buffs
{
	public class Midnight : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Midnight");
			Description.SetDefault("'Midnight's Moon glows bright on you.'\nUnleash a Midnight Burst when changing Mysticism");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			LaugicalityPlayer.Get(player).Midnight =true;
        }
        
	}
}
