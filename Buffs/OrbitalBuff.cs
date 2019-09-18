using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class OrbitalBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Orbital");
            Description.SetDefault("Into orbit!");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.boss)
                return;
            npc.GetGlobalNPC<LaugicalGlobalNPCs>(mod).Orbital = true;
            npc.takenDamageMultiplier = npc.GetGlobalNPC<LaugicalGlobalNPCs>(mod).damageMult * 1.1f;
        }
    }
}
