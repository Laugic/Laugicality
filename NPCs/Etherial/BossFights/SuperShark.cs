using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Laugicality.NPCs.Etherial.BossFights
{
    public class SuperShark : ModNPC
    {
        public bool bitherial = true;
        public bool stopped = false;
        public int power = 0;
        public int damage = 0;
        public int delay = 0;
        public bool spawned = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Shark");
        }

        public override void SetDefaults()
        {
            LaugicalityVars.Etherial.Add(npc.type);
            npc.width = 18;
            npc.height = 18;
            npc.damage = 80;
            npc.defense = 80;
            npc.lifeMax = 4000;
            npc.HitSound = SoundID.NPCHit8;
            npc.DeathSound = SoundID.NPCDeath12;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
        
        public override void AI()
        {
            bitherial = true;
            if(Main.rand.Next(12) == 0)Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, mod.DustType("Bubble"), 0f, 0f);
            if (npc.localAI[0] == 0f)
            {
                AdjustMagnitude(ref npc.velocity);
                npc.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 1400f;
            bool target = false;
            for (int k = 0; k < 8; k++)
            {
                if (Main.player[k].active)
                {
                    Vector2 newMove = Main.player[k].Center - npc.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                npc.velocity = (10 * npc.velocity + move) / 11f;
                AdjustMagnitude(ref npc.velocity);
            }

            npc.velocity *= 2;
            npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.57f;
            if (npc.velocity.X > 0f)
            {
                npc.spriteDirection = -1;
            }
            else
            {
                npc.spriteDirection = 1;
            }
        }


        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }

        public override Color? GetAlpha(Color drawColor)
        {
            var b = 125;
            var b2 = 225;
            var b3 = 255;
            if (drawColor.R != (byte)b)
            {
                drawColor.R = (byte)b;
            }
            if (drawColor.G < (byte)b2)
            {
                drawColor.G = (byte)b2;
            }
            if (drawColor.B < (byte)b3)
            {
                drawColor.B = (byte)b3;
            }
            return drawColor;
        }

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(mod.BuffType("Frostbite"), 300, true);
        }
    }
}