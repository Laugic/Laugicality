using Terraria;

namespace Laugicality.Buffs
{
	public class ForGlory : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("For Glory");
			Description.SetDefault("+15% Damage \nNo life Regen");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.bleed = true;
            player.allDamage += 0.15f;
            player.lifeRegen = 0;
        }
        
	}
}
