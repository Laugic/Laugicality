using Terraria;

namespace Laugicality.Buffs
{
	public class Verdi : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Verdi");
			Description.SetDefault("+10% Max Run Speed");
			Main.buffNoSave[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            LaugicalityPlayer.Get(player).Verdi = 2;
        }
        
	}
}
