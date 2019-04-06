using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class EtherialRagnar : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Magmatic");
			Description.SetDefault("Increased stats from being in lava!");
			Main.debuff[Type] = false;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.moveSpeed += 3f;
            player.maxRunSpeed += 3f;
            player.jumpSpeedBoost += 3f;
            player.thrownDamage += 0.15f;
            player.rangedDamage += 0.15f;
            player.magicDamage += 0.15f;
            player.minionDamage += 0.15f;
            player.meleeDamage += 0.15f;
        }
        
	}
}
