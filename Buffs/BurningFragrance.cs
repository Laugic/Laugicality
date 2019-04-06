using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class BurningFragrance : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Burning Fragrance");
			Description.SetDefault("Increased attack stats");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.thrownDamage += 0.12f;
            player.rangedDamage += 0.12f;
            player.magicDamage += 0.12f;
            player.minionDamage += 0.12f;
            player.meleeDamage += 0.12f;
        }
        
	}
}
