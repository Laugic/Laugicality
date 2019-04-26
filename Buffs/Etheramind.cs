using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class Etheramind : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Etheramind");
			Description.SetDefault("The Truth, Incarnate");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType("Etheramind"), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
