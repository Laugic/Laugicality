using Terraria;

namespace Laugicality.Buffs
{
	public class BloodRage : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Blood Rage");
			Description.SetDefault("Increased Damage and Crit chance");
			Main.debuff[Type] = false;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.allDamage += .15f;

            player.thrownCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.meleeCrit += 10;
        }
	}
}
