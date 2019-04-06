using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class ForHonor : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("For Honor");
			Description.SetDefault("+15% Damage \nDefense Halved");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			//player.GetModPlayer<LaugicalityPlayer>(mod).mysticDamage += 0.15f;
            player.GetModPlayer<LaugicalityPlayer>(mod).halfDef = true;
            player.thrownDamage += 0.15f;
            player.rangedDamage += 0.15f;
            player.magicDamage += 0.15f;
            player.minionDamage += 0.15f;
            player.meleeDamage += 0.15f;
        }
        
    }
}
