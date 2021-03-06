using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Steamified : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Steamified");
			Description.SetDefault("Steamin hot!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}
        
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<LaugicalGlobalNPCs>().steamified = true;
            npc.takenDamageMultiplier = npc.GetGlobalNPC<LaugicalGlobalNPCs>().damageMult * 1.15f;
        }
	}
}
