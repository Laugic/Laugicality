using Terraria;

namespace Laugicality.Buffs
{
	public class Magmatic : LaugicalityBuff
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
            player.allDamage += 0.1f;
        }
        
	}
}
