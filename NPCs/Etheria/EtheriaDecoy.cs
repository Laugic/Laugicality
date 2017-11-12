using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etheria
{
    [AutoloadBossHead]
    public class EtheriaDecoy : ModNPC
    {
        public int phase = 0;
        public int delay = 0;
        public bool bitherial = true;
        public int plays = 0;
        public int attack = 0;
        public int attackRel = -1;
        public int attackRelMax = 0;
        public int attackDel = 0;
        public int attackDelMax = 0;
        public int moveType = 1;
        public int hovDir = 1;
        public int moveDelay = 600;
        public int vDir = 2;
        public int dir = 0;
        public int vdir = 0;
        public float accel = 0f;
        public float maxAccel = 20f;
        public float vaccel = 0f;
        public float maxVaccel = 20f;
        public int damage = 0;
        public int Eattack = 0;
        public int EattackDel = 0;
        public int EattackDelMax = 0;
        public static bool despawn = false;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.ENPCs.Add(npc.type);
            delay = 0;
            DisplayName.SetDefault("Etheria");
            Main.npcFrameCount[npc.type] = 7;
        }

        public override void SetDefaults()
        {
            despawn = false;
            phase = 0;
            Eattack = 0;
            EattackDelMax = 280;
            EattackDel = EattackDelMax;
            damage = 40;
            moveDelay = 600;
            maxAccel = 22f;
            maxVaccel = 20f;
            accel = 0f;
            vaccel = 0f;
            hovDir = 1;
            vDir = 1;
            moveType = 1;
            attackDelMax = 260;
            attackDel = attackDelMax;
            attackRel = -1;
            attackRelMax = 0;
            attack = 0;
            bitherial = true;
            npc.width = 128;
            npc.height = 128;
            npc.damage = 80;
            npc.defense = 48;
            npc.aiStyle = 0;
            npc.lifeMax = 8000;
            npc.HitSound = SoundID.NPCHit21;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Etheria");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            plays = numPlayers;
            npc.lifeMax = 10000 + numPlayers * 1950;
            npc.damage = 80;
            attackDelMax = 220;
            attackDel = attackDelMax;
            damage = 30;
            Eattack = 0;
            EattackDelMax = 200;
            EattackDel = EattackDelMax;
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.etherial)
            {
                maxAccel = 30f;
            }
        }
        

        public override void AI()
        {
            //Despawning
            if (Main.player[npc.target].statLife == 0) { npc.position.Y += 100; }
            if (Main.dayTime) { npc.position.Y += 300; }
            if (despawn) { npc.position.Y += 300; }

            npc.spriteDirection = 0;
            bitherial = true;
            npc.rotation = 0;
            npc.scale = 1.5f +  (float)(phase / 2)/4f;
            npc.height = (int)(npc.scale * 128);
            npc.width = (int)(npc.scale * 128);
            phase = Etheria.phase;

            //Movement
            Vector2 delta = Main.player[npc.target].Center - npc.Center;
            float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);

            //Hovering
            if (moveType == 1)
            {
                moveDelay -= 1;
                if (moveDelay <= 0)
                {
                    moveDelay = 900;
                    moveType = 2;
                }
                //Horizontal Movement
                npc.velocity.X = accel;
                if (delta.X > 0) { hovDir = 1; }
                if (delta.X < 0) { hovDir = -1; }
                if (Math.Abs(accel) < maxAccel / 2) { accel += (float)hovDir / 5f; }
                else { accel *= .98f; }

                //Vertical Movement
                npc.velocity.Y = vaccel;
                if (npc.position.Y - Main.player[npc.target].position.Y + 70 > 0) { vDir = -1; }
                if (npc.position.Y - Main.player[npc.target].position.Y + 70 < 0) { vDir = 1; }
                if (Math.Abs(vaccel) < maxVaccel / 4) { vaccel += (float)vDir / 3f; }
                else { vaccel *= .98f; }
            }

            //Floating
            if (moveType == 2)
            {
                moveDelay -= 1;
                if (moveDelay <= 0)
                {
                    moveDelay = 750;
                    moveType = 1;
                }
                //Horizontal Movement
                npc.velocity.X = accel;
                if (npc.position.X < Main.player[npc.target].position.X - 200 && hovDir == -1) { hovDir = 1; }
                if (npc.position.X > Main.player[npc.target].position.X + 200 && hovDir == 1) { hovDir = -1; }
                if (Math.Abs(accel) < maxAccel) { accel += (float)hovDir / 3f; }
                else { accel *= .98f; }

                //Vertical Movement
                npc.velocity.Y = vaccel;
                if (npc.position.Y - Main.player[npc.target].position.Y + 70 > 0) { vDir = -1; }
                if (npc.position.Y - Main.player[npc.target].position.Y + 70 < 0) { vDir = 1; }
                if (Math.Abs(vaccel) < maxVaccel / 6) { vaccel += (float)vDir / 6f; }
                else { vaccel *= .98f; }
            }
            

            //Attack Delay
            attackDel--;
            if(attackDel <= 0)
            {
                attackDel = attackDelMax;
                attack = Main.rand.Next(1,4);
            }

            //Attacks
            if(attack == 1)
            {
                if (attackRel == -1)
                    attackRel = 1;
                attackRelMax = 4;
                if(attackRel > 0)
                {
                    attackRel--;
                    if(attackRel == 0)
                    {
                        attackRelMax--;
                        if (attackRelMax > 0)
                        {
                            attackRel = 45;
                            NPC.NewNPC((int)npc.position.X + Main.rand.Next(0, npc.width), (int)npc.position.Y + Main.rand.Next(0, npc.height), mod.NPCType("HomingEtherial"));
                        }
                        else
                        {
                            attackRel = -1;
                            attack = 0;
                        }
                    }
                }
            }
            if(attack == 2)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, 5, mod.ProjectileType("EtherialPulsar"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, -5, mod.ProjectileType("EtherialPulsar"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, -5, mod.ProjectileType("EtherialPulsar"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, 5, mod.ProjectileType("EtherialPulsar"), damage, 3f, Main.myPlayer);
                attack = 0;
            }
            if (attack == 3)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 7, 0, mod.ProjectileType("EtherialWave"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -7, 0, mod.ProjectileType("EtherialWave"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -7, mod.ProjectileType("EtherialWave"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 7, mod.ProjectileType("EtherialWave"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, 5, mod.ProjectileType("EtherialWave"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, -5, mod.ProjectileType("EtherialWave"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, -5, mod.ProjectileType("EtherialWave"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, 5, mod.ProjectileType("EtherialWave"), damage, 3f, Main.myPlayer);
                attack = 0;
            }

        }


        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {

        }
        
        public override void FindFrame(int frameHeight)
        {
            npc.frame.Y = frameHeight * phase;
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
            float num212 = 1f - (float)npc.life / (float)npc.lifeMax;
            num212 *= num212;
            alpha15.R = (byte)((float)alpha15.R * num212);
            alpha15.G = (byte)((float)alpha15.G * num212);
            alpha15.B = (byte)((float)alpha15.B * num212);
            alpha15.A = (byte)((float)alpha15.A * num212);
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

        /*
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = Main.rand.Next(139, 143);
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}*/
    }
}
