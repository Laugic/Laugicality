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
        int despawn = 0;
        bool attacking = false;
        float theta = 0f;
        public static float thetaSlow = 0f;
        int attackDur = 0;
        public static int tearIndex = 0;
        public static Vector2 Center;
        public static float scale = 1;
        public override void SetStaticDefaults()
        {
            LaugicalityVars.ENPCs.Add(npc.type);
            delay = 0;
            DisplayName.SetDefault("Etheria");
            Main.npcFrameCount[npc.type] = 7;
        }

        public override void SetDefaults()
        {
            tearIndex = 0;
            thetaSlow = 0f;
            attackDur = 0;
            theta = 0f;
            attacking = false;
            despawn = 0;
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
            npc.damage = 70;
            npc.defense = 25;
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
            npc.damage = 100;
            attackDelMax = 280;
            attackDel = attackDelMax;
            damage = 30;
            Eattack = 0;
            EattackDelMax = 200;
            EattackDel = EattackDelMax;
            if (LaugicalityWorld.downedEtheria)
            {
                maxAccel = 24f;
            }
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override void AI()
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);

            //Retarget (borrowed from Dan <3)
            Player player = Main.player[npc.target];
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            npc.netUpdate = true;

            //DESPAWN
            if (!Main.player[npc.target].active || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
                if (!Main.player[npc.target].active || Main.player[npc.target].dead)
                {
                    if (despawn == 0)
                        despawn++;
                }
            }
            else if(!Main.dayTime || LaugicalityWorld.downedEtheria)
                despawn = 0;
            if(Main.dayTime && despawn == 0 && !LaugicalityWorld.downedEtheria)
                despawn++;
            if (despawn >= 1)
            {
                despawn++;
                npc.noTileCollide = true;
                if (despawn >= 300)
                    npc.active = false;
            }

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
                npc.netUpdate = true;
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
                npc.netUpdate = true;
            }
            if (npc.life < npc.lifeMax * .5 && phase == 2)
            {
                phase += 1;
                if (Main.expertMode)
                    attackDelMax -= 20;
                npc.netUpdate = true;
            }
            if (npc.life < npc.lifeMax * .25 && phase == 3 )
            {
                phase += 1;
                if (Main.expertMode)
                    attackDelMax -= 20;
                npc.netUpdate = true;
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
                npc.netUpdate = true;
            }
            if (npc.life < npc.lifeMax * .20 && phase == 5 && Main.expertMode && LaugicalityWorld.downedEtheria)
            {
                phase += 1;
                attackDelMax -= 20;
                npc.netUpdate = true;
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

            //Attack Vars
            theta += 3.14f / 40f;
            if (theta > 6.28f)
                theta -= 6.28f;
            thetaSlow += 3.14f / 60f;
            if (thetaSlow > 6.28f)
                thetaSlow -= 6.28f;
            float projMod = 2f;
            Center = npc.Center;
            scale = npc.scale;

            //Attack Delay
            if (!attacking)
                attackDel--;
            if(attackDel <= 0)
            {
                attackDel = attackDelMax;
                attack++;
                attacking = true;
                if (attack > 5)
                    attack = 1;
                if(LaugicalityWorld.downedEtheria)
                    projMod = 4f;
                if (phase > 4 && LaugicalityWorld.downedEtheria)
                {
                    Eattack = attack;
                    attack = 0;
                    projMod = 2.5f;
                }
            }

            //Attacks
            if(attack == 1 && Main.netMode != 1 && attacking)
            {
                attackRel++;
                if(attackRel > 2)
                {
                    attackRel = 0;
                    Projectile.NewProjectile(npc.Center.X + 48 * (float)Math.Cos(theta), npc.Center.Y + 48 * (float)Math.Sin(theta), 8 * (float)Math.Cos(theta), 8 * (float)Math.Sin(theta), mod.ProjectileType("EtherialPulse"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                }
                attackDur++;
                if(attackDur > 150)
                {
                    attackDur = 0;
                    attacking = false;
                }
            }
            if(attack == 2 && Main.netMode != 1 && attacking)
            {
                attackRel++;
                if (attackRel > 30)
                {
                    attackDur++;
                    attackRel = 0;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("EtherialYeet"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                }
                if (attackDur >= 4)
                {
                    attackDur = 0;
                    attacking = false;
                }
            }
            if (attack == 3 && Main.netMode != 1 && attacking)
            {
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
                for (int i = 0; i < 8; i++)
                {
                    int N = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("EtherialSpiralShot"));
                    Main.npc[N].ai[0] = npc.whoAmI;
                    Main.npc[N].ai[1] = i;
                }
                npc.position.X = Main.player[npc.target].position.X - (npc.position.X - Main.player[npc.target].position.X) / 2;
                npc.position.Y = Main.player[npc.target].position.Y - (npc.position.Y - Main.player[npc.target].position.Y) / 2;
                npc.velocity.X = -npc.velocity.X;
                npc.velocity.Y = -npc.velocity.Y;
                attacking = false;
            }
            if (attack == 4 && Main.netMode != 1 && attacking)
            {
                float dir = (float)Math.Atan2(npc.DirectionTo(Main.player[npc.target].Center).Y, npc.DirectionTo(Main.player[npc.target].Center).X);
                //Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8 * (float)Math.Cos(dir), 8 * (float)Math.Sin(dir), mod.ProjectileType("QuadroBurst"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                attacking = false;
            }
            if (attack == 5 && Main.netMode != 1 && attacking)
            {
                if (NPC.CountNPCS(mod.NPCType("EtherialTear")) < 4)
                {
                    NPC.NewNPC((int)npc.position.X + Main.rand.Next(0, npc.width), (int)npc.position.Y + Main.rand.Next(0, npc.height), mod.NPCType("EtherialTear"));
                    tearIndex++;
                    attacking = false;
                }
                else
                    attack = 1;
            }

            //Etherial Attacks
            if (Eattack == 1 && Main.netMode != 1 && attacking)
            {
                attackRel++;
                if (attackRel > 2)
                {
                    attackRel = 0;
                    Projectile.NewProjectile(npc.Center.X + 48 * (float)Math.Cos(theta), npc.Center.Y + 48 * (float)Math.Cos(theta), 8 * (float)Math.Cos(theta), 8 * (float)Math.Sin(theta), mod.ProjectileType("TrueEtherialPulse"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X + 48 * (float)Math.Cos(theta + 3.14), npc.Center.Y + 48 * (float)Math.Sin(theta + 3.14), 8 * (float)Math.Cos(theta + 3.14), 8 * (float)Math.Sin(theta + 3.14), mod.ProjectileType("TrueEtherialPulse"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                }
                attackDur++;
                if (attackDur > 240)
                {
                    attackDur = 0;
                    attacking = false;
                }
            }
            if (Eattack == 2 && Main.netMode != 1 && attacking)
            {
                attackRel++;
                if (attackRel > 30)
                {
                    attackDur++;
                    attackRel = 0;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("TrueEtherialYeet"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                }
                if (attackDur >= 4)
                {
                    attackDur = 0;
                    attacking = false;
                }
            }
            if (Eattack == 3 && Main.netMode != 1 && attacking)
            {
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
                for (int i = 0; i < 12; i++)
                {
                    int N = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("TrueEtherialSpiralShot"));
                    Main.npc[N].ai[0] = npc.whoAmI;
                    Main.npc[N].ai[1] = i;
                }
                npc.position.X = Main.player[npc.target].position.X - (npc.position.X - Main.player[npc.target].position.X) / 2;
                npc.position.Y = Main.player[npc.target].position.Y - (npc.position.Y - Main.player[npc.target].position.Y) / 2;
                npc.velocity.X = -npc.velocity.X;
                npc.velocity.Y = -npc.velocity.Y;
                attacking = false;
            }
            if (Eattack == 4 && Main.netMode != 1 && attacking)
            {
                float dir = (float)Math.Atan2(npc.DirectionTo(Main.player[npc.target].Center).Y, npc.DirectionTo(Main.player[npc.target].Center).X);
                //Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8 * (float)Math.Cos(dir), 8 * (float)Math.Sin(dir), mod.ProjectileType("TrueQuadroBurst"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                //Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8 * (float)Math.Cos(dir + 3.14), 8 * (float)Math.Sin(dir + 3.14), mod.ProjectileType("TrueQuadroBurst"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                attacking = false;
            }
            if (Eattack == 5 && Main.netMode != 1 && attacking)
            {
                if (NPC.CountNPCS(mod.NPCType("TrueEtherialTear")) < 4)
                {
                    NPC.NewNPC((int)npc.position.X + Main.rand.Next(0, npc.width), (int)npc.position.Y + Main.rand.Next(0, npc.height), mod.NPCType("TrueEtherialTear"));
                    tearIndex++;
                    attacking = false;
                }
                else
                    attack = 1;
            }
            //Main.NewText(phase.ToString(), 0, 200, 250);

            if (Main.dayTime && !LaugicalityWorld.downedEtheria)
            {
                npc.position.Y += 18;
            }
        }

        public override Color? GetAlpha(Color drawColor)
        {
            var b = 125;
            var b2 = 225;
            var b3 = 255;
            if (phase > 4 && LaugicalityWorld.downedEtheria)
            {
                b = 225;
                b2 = 125;
                b3 = 125;
            }
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

            player.AddBuff(44, 300, true);//Frostburn
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
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
                LaugicalityWorld.downedEtheria = true;
            }

            if (LaugicalityWorld.downedEtheria)
            {
                Main.NewText("You're trapped in my world now.", 0, 200, 255);
            }
            if(LaugicalityWorld.bysmal == false)
            {
                LaugicalityWorld.bysmal = true;
                Main.NewText("Bysmal Veins burst through the world", 125, 200, 255);
                float sizeMult = Main.maxTilesX / 2600f;
                for (int k = 0; k < (int)(200 * sizeMult); k++)
                {
                    int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer + 200, Main.maxTilesY - 200);
                    WorldGen.OreRunner(X, Y, WorldGen.genRand.Next(9, 12), WorldGen.genRand.Next(5, 9), (ushort)mod.TileType("BysmalOre"));   
                }
                WorldGen.PlaceTile(0, 42, mod.TileType("BysmalOre"), true, true);
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
