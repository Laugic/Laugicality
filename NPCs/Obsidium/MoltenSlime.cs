/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Obsidium
{
    public class MoltenSlime : ModNPC
    {
        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 32;
            npc.damage = 35;
            npc.defense = 12;
            npc.lifeMax = 80;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 1;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[24] = true;
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            //NPCs.Slybertron.Slybertron.coginatorHits += 1;
            int debuff = BuffID.OnFire;
            if (debuff >= 0)
            {
                target.AddBuff(debuff, 90, true);
            }      //Add Onfire buff to the NPC for 1 second
        }

        public override void NPCLoot()
        {
            if (LaugicalityWorld.downedRagnar && Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ObsidiumChunk"));
            }
            else
            {
                if (NPC.downedBoss2)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ObsidiumOre"), Main.rand.Next(1, 4));
                else
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 173, Main.rand.Next(4));
            }
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, Main.rand.Next(1, 4));
        }
    }
}*/
