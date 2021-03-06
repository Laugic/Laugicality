using Terraria;

namespace Laugicality.Buffs
{
	public class Connected : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Connected");
			Description.SetDefault("You are connected to the grid!");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}
        

		public override void Update(Player player, ref int buffIndex)
		{
            if(LaugicalityPlayer.Get(player).Connected <= 1)
			    LaugicalityPlayer.Get(player).Connected = 1;
		}
	}
}
