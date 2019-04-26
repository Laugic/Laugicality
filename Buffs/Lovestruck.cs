using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Lovestruck : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Lovestruck");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}
        

		public override void Update(NPC npc, ref int buffIndex)
		{
            if(npc.boss == false)
			    npc.GetGlobalNPC<LaugicalGlobalNPCs>(mod).lovestruck = true;
		}
	}
}
