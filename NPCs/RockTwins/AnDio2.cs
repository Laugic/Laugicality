using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.RockTwins
{
    public class AnDio2 : ModNPC
    {
        public bool spawned = false;
        public bool bitherial = true;
        public override void SetDefaults()
        {
            bitherial = true;
            spawned = false;
            npc.width = 59;
            npc.height = 167;
            npc.damage = 42;
            npc.defense = 10;
            npc.aiStyle = 0;
            npc.lifeMax = 5000;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath1;
            Main.npcFrameCount[npc.type] = 9;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 99f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.scale = 2f;
            npc.dontTakeDamage = true;
            npc.frameCounter = -45.0;
            npc.boss = true;
        }
        public override void AI()
        {
            bitherial = true;
            npc.spriteDirection = 0;
            /*
            if (spawned && Main.netMode != 1)
            {
                NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + npc.height, ModContent.NPCType<AnDio3>());
                spawned = false;
            }
            if (NPC.CountNPCS(ModContent.NPCType<AnDio3>()) >= 1)
            {
                npc.active = false;
            }*/
        }
        public override void FindFrame(int frameHeight)
        {
            int num = 168;
            //drawOffsetY = 56f;
            npc.frameCounter += 1.0;
            if (npc.frameCounter > 1.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y > frameHeight * 8 && !spawned)
            {
                npc.frame.Y = frameHeight * 7;
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/zurg"));
                if (Main.netMode != 1)
                    NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + npc.height, ModContent.NPCType<AnDio3>());
                npc.active = false;
                spawned = true;
            }

        }
    }
}
