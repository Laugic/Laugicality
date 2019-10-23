using Terraria;

namespace Laugicality.Buffs
{
	public class ConjurationBoost : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Conjuration Power");
			Description.SetDefault("'Otherworldly energy strengthens you.'\n+50% Overflow");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer.Get(player).GlobalOverflow += .5f;
        }
        
	}
}
