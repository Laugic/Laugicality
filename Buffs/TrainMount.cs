using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class TrainMount : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Train");
			Description.SetDefault("Choo Choo!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType("SteamTrain"), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
