using System;
using Laugicality.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Bosses
{
    public class SteampunkDefender : ModNPC
    {
        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(npc.type);
            DisplayName.SetDefault("Steampunk Defender");
        }

        public override void SetDefaults()
        {
            npc.width = 34;
            npc.height = 34;
            npc.damage = 50;
            npc.defense = 10;
            npc.lifeMax = 2000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[ModContent.BuffType<Steamy>()] = true;
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override void AI()
        {
            Move();
            CheckDespawn();
            Visuals();
        }

        private void Visuals()
        {
            Lighting.AddLight(npc.position, .5f, .6f, .8f);
        }

        private void Move()
        {
            npc.position = Main.npc[(int)npc.ai[0]].Center;
            npc.position.X += (float)Math.Cos(Main.npc[(int)npc.ai[0]].ai[0] + 2 * Math.PI / (double)NPC.CountNPCS(ModContent.NPCType<SteampunkDefender>()) * npc.ai[1]) * Main.npc[(int)npc.ai[0]].width * 1.25f;
            npc.position.Y += (float)Math.Sin(Main.npc[(int)npc.ai[0]].ai[1] + 2 * Math.PI / (double)NPC.CountNPCS(ModContent.NPCType<SteampunkDefender>()) * npc.ai[1]) * Main.npc[(int)npc.ai[0]].height * 1.25f;
        }

        private void CheckDespawn()
        {
            if (!Main.npc[(int)npc.ai[0]].active || Main.npc[(int)npc.ai[0]].life < 1 || Main.npc[(int)npc.ai[0]].type != ModContent.NPCType<TheAnnihilator>())
                npc.active = false;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 0f;
            return null;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Microsoft.Xna.Framework.Color color9 = Lighting.GetColor((int)((double)npc.position.X + (double)npc.width * 0.5) / 16, (int)(((double)npc.position.Y + (double)npc.height * 0.5) / 16.0));
            float num66 = 0f;
            Vector2 vector11 = new Vector2((float)(Main.npcTexture[npc.type].Width / 2), (float)(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2));
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (npc.spriteDirection == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            Microsoft.Xna.Framework.Rectangle frame6 = npc.frame;
            Microsoft.Xna.Framework.Color alpha15 = npc.GetAlpha(color9);
            float alpha = 1.25f * ( 1f - (float)Main.npc[(int)npc.ai[0]].life / (float)Main.npc[(int)npc.ai[0]].lifeMax);
            alpha *= alpha;
            alpha = Math.Min(alpha, 1);
            alpha15.R = (byte)((float)alpha15.R * alpha);
            alpha15.G = (byte)((float)alpha15.G * alpha);
            alpha15.B = (byte)((float)alpha15.B * alpha);
            alpha15.A = (byte)((float)alpha15.A * alpha);
            for (int num213 = 0; num213 < 4; num213++)
            {
                Vector2 position9 = npc.position;
                float num214 = Math.Abs(npc.Center.X - Main.player[Main.myPlayer].Center.X);
                float num215 = Math.Abs(npc.Center.Y - Main.player[Main.myPlayer].Center.Y);
                if (num213 == 0 || num213 == 2)
                {
                    position9.X = Main.player[Main.myPlayer].Center.X + num214;
                }
                else
                {
                    position9.X = Main.player[Main.myPlayer].Center.X - num214;
                }
                position9.X -= (float)(npc.width / 2);
                if (num213 == 0 || num213 == 1)
                {
                    position9.Y = Main.player[Main.myPlayer].Center.Y + num215;
                }
                else
                {
                    position9.Y = Main.player[Main.myPlayer].Center.Y - num215;
                }
                position9.Y -= (float)(npc.height / 2);
                Main.spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(position9.X - Main.screenPosition.X + (float)(npc.width / 2) - (float)Main.npcTexture[npc.type].Width * npc.scale / 2f + vector11.X * npc.scale, position9.Y - Main.screenPosition.Y + (float)npc.height - (float)Main.npcTexture[npc.type].Height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + vector11.Y * npc.scale + num66 + npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(frame6), alpha15, npc.rotation, vector11, npc.scale, spriteEffects, 0f);
            }
            Main.spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(npc.position.X - Main.screenPosition.X + (float)(npc.width / 2) - (float)Main.npcTexture[npc.type].Width * npc.scale / 2f + vector11.X * npc.scale, npc.position.Y - Main.screenPosition.Y + (float)npc.height - (float)Main.npcTexture[npc.type].Height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + vector11.Y * npc.scale + num66 + npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(frame6), npc.GetAlpha(color9), npc.rotation, vector11, npc.scale, spriteEffects, 0f);
            return false;
        }

        public override void NPCLoot()
        {
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].type == ModContent.NPCType<SteampunkDefender>() && Main.npc[i].ai[1] > npc.ai[1])
                    Main.npc[i].ai[1]--;
            }
        }
    }
}
