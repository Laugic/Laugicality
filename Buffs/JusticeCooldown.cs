using Terraria;

namespace Laugicality.Buffs
{
	public class JusticeCooldown : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Blind Justice");
			Description.SetDefault("Justice has gone blind for a while.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
            canBeCleared = false;
        }
        

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<LaugicalityPlayer>(mod).JusticeCooldown = true;
		}
	}
}
