using System;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Obsidium
{
    public class ReaverHeadNPC : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reaver Head");
        }
        int _phase = 0;
        Vector2 targetPos;
        public override void SetDefaults()
        {
            npc.width = 20;
            npc.height = 20;
            npc.damage = 50;
            npc.defense = 12;
            npc.lifeMax = 500;
            npc.value = 0f;
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = 4;
            npc.aiStyle = -1;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[24] = true;
            npc.dontTakeDamage = true;
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 5 * 60, true);
        }

        public override void AI()
        {
            if(Main.rand.Next(4) == 0)
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Magma>(), 0f, 0f);

            SetTarget();
            PhaseCheck();
            Movement();
            DespawnCheck();

        }

        private void SetTarget()
        {
            if (_phase == 0)
                targetPos = Main.player[Main.npc[(int)npc.ai[0]].target].Center;// * 2 - Main.npc[(int)npc.ai[0]].Center;
            else
                targetPos = Main.npc[(int)npc.ai[0]].Center;
        }

        private void PhaseCheck()
        {
            if(Vector2.Distance(npc.Center, targetPos) < 60 + Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y))
            {
                if (_phase == 0)
                    _phase = 1;
                else
                    _phase = 0;
            }
        }

        private void Movement()
        {
            if (npc.position.X < targetPos.X)
            {
                npc.velocity.X += .1f;
                if (npc.velocity.X < 0)
                    npc.velocity.X *= .9f;
            }
            if (npc.position.X > targetPos.X)
            {
                npc.velocity.X -= .1f;
                if (npc.velocity.X > 0)
                    npc.velocity.X *= .9f;
            }
            if (npc.Center.Y < targetPos.Y)
            {
                npc.velocity.Y += .04f;
                if (npc.velocity.Y < 0)
                    npc.velocity.Y *= .9f;
            }
            if (npc.Center.Y > targetPos.Y)
            {
                npc.velocity.Y -= .04f;
                if (npc.velocity.Y > 0)
                    npc.velocity.Y *= .9f;
            }
        }

        private void DespawnCheck()
        {
            if (Vector2.Distance(npc.Center, Main.npc[(int)npc.ai[0]].Center) > 2400 || Main.npc[(int)npc.ai[0]].life < 1 || !Main.npc[(int)npc.ai[0]].active)
            {
                npc.active = false;
                npc.life = 0;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1;
            if (npc.frameCounter > 15)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0;
            }
            if (npc.frame.Y > frameHeight * 3)
            {
                npc.frame.Y = 0;
            }
        }
    }
}
