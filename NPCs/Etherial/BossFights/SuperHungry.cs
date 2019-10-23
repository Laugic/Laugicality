using System;
using Laugicality.NPCs.Etheria;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etherial.BossFights
{
    public class SuperHungry : ModNPC
    {
        int delay = 0;
        public bool etherial = true;
        public override void SetDefaults()
        {
            delay = 0;
            npc.CloneDefaults(NPCID.TheHungryII);
            LaugicalityVars.etherial.Add(npc.type);
            npc.damage = 50;
            npc.defense = 80;
            npc.lifeMax = 6000;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }

        public override void AI()
        {
            MovementType(npc);
            npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + (float)Math.PI;
        }

        private void MovementType(NPC npc)
        {
            delay++;
            if (delay > 480)
            {
                delay = Main.rand.Next(0, 120);
                MirrorTeleport(npc, false);
            }
        }
        private void MirrorTeleport(NPC npc, bool burst)
        {
            Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
            if (burst && Main.player[npc.target].statLife > 1)
            {
                for (int i = 0; i < 8; i++)
                {
                    if(Main.netMode != 1)
                    {
                        int N = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<EtherialSpiralShot>());
                        Main.npc[N].ai[0] = npc.whoAmI;
                        Main.npc[N].ai[1] = i;
                    }
                }
            }
            npc.position.X = Main.player[npc.target].position.X - (npc.position.X - Main.player[npc.target].position.X);
            npc.position.Y = Main.player[npc.target].position.Y - (npc.position.Y - Main.player[npc.target].position.Y);
            npc.velocity.X = -npc.velocity.X;
            npc.velocity.Y = -npc.velocity.Y;
        }
    }
}
