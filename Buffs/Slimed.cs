using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Slimed : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Slimed");
			Description.SetDefault("Slowly losing life");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>(mod).slimed = true;
        }

    }
}
