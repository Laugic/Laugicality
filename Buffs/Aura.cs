using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Aura : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Aura");
			Description.SetDefault("+10% Max Life");
			Main.buffNoSave[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.statLifeMax2 = (int)(player.statLifeMax2 * 1.1f);
        }
        
	}
}
