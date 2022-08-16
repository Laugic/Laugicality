using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class EerinessBuff : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Eeriness");
			Description.SetDefault("Bubbles!");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.GetGlobalNPC<LaugicalGlobalNPCs>().HitDelay++;
        }

    }
}
