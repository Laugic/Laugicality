using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class FragmentedMind : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Fragmented Mind");
			Description.SetDefault("Your Etherial Brain has to regenerate before it can save you again.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
            canBeCleared = false;
        }
        
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<LaugicalityPlayer>(mod).EtherialBrainCooldown = true;
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.takenDamageMultiplier = npc.GetGlobalNPC<LaugicalGlobalNPCs>(mod).damageMult * 1.5f;
        }
    }
}
