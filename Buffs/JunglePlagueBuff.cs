using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class JunglePlagueBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Jungle Plague");
            Description.SetDefault("Sporified!");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>(mod).JunglePlague = true;
        }

    }
}
