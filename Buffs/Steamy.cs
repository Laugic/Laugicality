using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Steamy : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Steamy");
			Description.SetDefault("Smokin hot!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			LaugicalityPlayer.Get(player).Electrified = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<LaugicalGlobalNPCs>().eFied = true;
            npc.takenDamageMultiplier = npc.GetGlobalNPC<LaugicalGlobalNPCs>().damageMult * 1.1f;
        }
	}
}
