using Terraria;

namespace Laugicality.Buffs
{
	public class JumpBoost : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Jump Boost");
			Description.SetDefault("'Reach for the sky.'");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.jumpSpeedBoost += 5.0f;
        }
        
	}
}
