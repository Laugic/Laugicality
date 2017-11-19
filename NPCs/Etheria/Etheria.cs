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
    public class Etheria : ModNPC
    {
        public static int phase = 0;
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


        public override void SetStaticDefaults()
        {
            LaugicalityVars.ENPCs.Add(npc.type);
            delay = 0;
            DisplayName.SetDefault("Etheria");
            Main.npcFrameCount[npc.type] = 7;
        }

        public override void SetDefaults()
        {
            plays = 1;
            phase = 0;
            Eattack = 0;
            EattackDelMax = 280;
            EattackDel = EattackDelMax;
            damage = 30;
            moveDelay = 600;
            maxAccel = 22f;
            maxVaccel = 20f;
            accel = 0f;
            vaccel = 0f;
            hovDir = 1;
            vDir = 1;
            moveType = 1;
            attackDelMax = 300;
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
            npc.lifeMax = 80000;
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
            npc.lifeMax = 100000 + numPlayers * 10000;
            npc.damage = 120;
            attackDelMax = 280;
            attackDel = attackDelMax;
            damage = 40;
            Eattack = 0;
            EattackDelMax = 200;
            EattackDel = EattackDelMax;
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityWorld.downedEtheria)
            {
                maxAccel = 26f;
            }
        }
        

        public override void AI()
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            //Despawning

            if (Main.player[npc.target].statLife <= 0) { npc.position.Y -= 10; }
            if (Main.dayTime == true && !LaugicalityWorld.downedEtheria) { npc.position.Y -= 20; }

            npc.spriteDirection = 0;
            bitherial = true;
            npc.rotation = 0;
            npc.scale = 1.5f +  (float)(phase)/10f;
            npc.height = (int)(npc.scale * 128);
            npc.width = (int)(npc.scale * 128);
            //Setting Phases
            if (npc.life < npc.lifeMax * .9 && phase == 0 )
            {
                phase += 1;
                if (Main.expertMode)
                    attackDelMax -= 20;
            }
            if (npc.life < npc.lifeMax * .75 && phase == 1 )
            {
                phase += 1;
                if (Main.expertMode)
                    attackDelMax -= 20;
                if (LaugicalityWorld.downedEtheria && Main.netMode != 1)
                {
                    NPC.NewNPC((int)npc.position.X + Main.rand.Next(0, npc.width), (int)npc.position.Y + Main.rand.Next(0, npc.height), mod.NPCType("EtheriaDecoy"));
                }
            }
            if (npc.life < npc.lifeMax * .5 && phase == 2)
            {
                phase += 1;
                if (Main.expertMode)
                    attackDelMax -= 20;
            }
            if (npc.life < npc.lifeMax * .25 && phase == 3 )
            {
                phase += 1;
                if (Main.expertMode)
                    attackDelMax -= 20;
            }
            if (npc.life < npc.lifeMax * .10 && phase == 4 && Main.expertMode && LaugicalityWorld.downedEtheria)
            {
                npc.life = (int)( npc.lifeMax * .33 );
                phase += 1;
                attackDelMax -= 20;
                if (LaugicalityWorld.downedEtheria )
                {
                    NPC.NewNPC((int)npc.position.X + Main.rand.Next(0, npc.width), (int)npc.position.Y + Main.rand.Next(0, npc.height), mod.NPCType("EtheriaDecoy"));
                }
            }
            if (npc.life < npc.lifeMax * .20 && phase == 5 && Main.expertMode && LaugicalityWorld.downedEtheria)
            {
                phase += 1;
                attackDelMax -= 20;
            }

            //Movement
            Vector2 delta = Main.player[npc.target].Center - npc.Center;
            float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);

            //Hovering
            if (moveType == 1 )
            {
                moveDelay -= 1;
                if (moveDelay <= 0)
                {
                    moveDelay = 900;
                    moveType = 1;
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
                if (phase > 4 && LaugicalityWorld.downedEtheria)
                {
                    Eattack = attack;
                    attack = 0;
                }
            }

            //Attacks
            if(attack == 1 && Main.netMode != 1)
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
            if(attack == 2 && Main.netMode != 1)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, 5, mod.ProjectileType("EtherialPulsar"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, -5, mod.ProjectileType("EtherialPulsar"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, -5, mod.ProjectileType("EtherialPulsar"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, 5, mod.ProjectileType("EtherialPulsar"), damage, 3f, Main.myPlayer);
                attack = 0;
            }
            if (attack == 3 && Main.netMode != 1)
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

            //Etherial Attacks
            if (Eattack == 1 && Main.netMode != 1)
            {
                if (attackRel == -1)
                    attackRel = 1;
                attackRelMax = 6;
                if (attackRel > 0)
                {
                    attackRel--;
                    if (attackRel == 0)
                    {
                        attackRelMax--;
                        if (attackRelMax > 0)
                        {
                            attackRel = 45;
                            NPC.NewNPC((int)npc.position.X + Main.rand.Next(0, npc.width), (int)npc.position.Y + Main.rand.Next(0, npc.height), mod.NPCType("TrueHomingEtherial"));
                        }
                        else
                        {
                            attackRel = -1;
                            Eattack = 0;
                        }
                    }
                }
            }
            if (Eattack == 2 && Main.netMode != 1)
            {
                if (attackRel == -1)
                    attackRel = 1;
                attackRelMax = 4;
                if (attackRel > 0)
                {
                    attackRel--;
                    if (attackRel == 0)
                    {
                        attackRelMax--;
                        if (attackRelMax > 0)
                        {
                            attackRel = 60;
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 7, 0, mod.ProjectileType("TrueEtherialPulsar"), damage, 3f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -7, 0, mod.ProjectileType("TrueEtherialPulsar"), damage, 3f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -7, mod.ProjectileType("TrueEtherialPulsar"), damage, 3f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 7, mod.ProjectileType("TrueEtherialPulsar"), damage, 3f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, 5, mod.ProjectileType("TrueEtherialPulsar"), damage, 3f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, -5, mod.ProjectileType("TrueEtherialPulsar"), damage, 3f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, -5, mod.ProjectileType("TrueEtherialPulsar"), damage, 3f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, 5, mod.ProjectileType("TrueEtherialPulsar"), damage, 3f, Main.myPlayer);
                        }
                        else
                        {
                            attackRel = -1;
                            Eattack = 0;
                        }
                    }
                }
            }
            if (Eattack == 3 && Main.netMode != 1)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 7, 0, mod.ProjectileType("TrueEtherialWave"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -7, 0, mod.ProjectileType("TrueEtherialWave"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -7, mod.ProjectileType("TrueEtherialWave"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 7, mod.ProjectileType("TrueEtherialWave"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, 5, mod.ProjectileType("TrueEtherialWave"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, -5, mod.ProjectileType("TrueEtherialWave"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, -5, mod.ProjectileType("TrueEtherialWave"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, 5, mod.ProjectileType("TrueEtherialWave"), damage, 3f, Main.myPlayer);
                Eattack = 0;
            }
            //Main.NewText(phase.ToString(), 0, 200, 250);
        }


        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {

        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            HomingEtherial.despawn = true;
            TrueHomingEtherial.despawn = true;
            EtheriaDecoy.despawn = true;
            if (plays == 0)
                plays = 1;
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityWorld.downedEtheria)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EssenceOfEtheria"), 1);
                LaugicalityWorld.downedEtheria = false;
                LaugicalityWorld.downedTrueEtheria = true;
            }
            else
            {
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
                Main.NewText("You're trapped in my world now.", 0, 200, 255);
                LaugicalityWorld.downedEtheria = true;
            }
            

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
