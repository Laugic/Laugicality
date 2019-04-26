using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Regis : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Regis");
			Description.SetDefault("+10% Life Regen");
			Main.buffNoSave[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen = (int)(player.lifeRegen * 1.1f);
        }
        
	}
}
