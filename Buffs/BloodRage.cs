using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class BloodRage : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Blood Rage");
			Description.SetDefault("Increased Damage and Crit chance \n'Samson would be proud'");
			Main.debuff[Type] = false;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<LaugicalityPlayer>(mod).mysticDamage += 0.15f;
            player.thrownDamage += 0.15f;
            player.rangedDamage += 0.15f;
            player.magicDamage += 0.15f;
            player.minionDamage += 0.15f;
            player.meleeDamage += 0.15f;

            player.thrownCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.meleeCrit += 10;
        }
        
	}
}
