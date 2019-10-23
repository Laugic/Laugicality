using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Frigid : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Frigid");
            Description.SetDefault("'Freeze!'");
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}


        public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer.Get(player).Frosty = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<LaugicalGlobalNPCs>().frigid = true;
		}
	}
}
