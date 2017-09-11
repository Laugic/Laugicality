using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class SandyShark : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Sandy Shark");
            Description.SetDefault("It looks a bit pouty");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("SandyShark")] > 0)
			{
				modPlayer.sShark = true;
			}
			if (!modPlayer.sShark)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}