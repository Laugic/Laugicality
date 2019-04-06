using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Bubbly : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Bubbly");
			Description.SetDefault("Bubbles!");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>(mod).bubbly = true;
        }

    }
}
