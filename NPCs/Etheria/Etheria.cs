using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Structures;

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
        public int eattack = 0;
        public int eattackDel = 0;
        public int eattackDelMax = 0;
        int _despawn = 0;
        bool _attacking = false;
        float _theta = 0f;
        public static float thetaSlow = 0f;
        int _attackDur = 0;
        public static int tearIndex = 0;
        public static Vector2 center;
        public static float scale = 1;
        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(npc.type);
            delay = 0;
            DisplayName.SetDefault("Etheria");
            Main.npcFrameCount[npc.type] = 5;
        }

        public override void SetDefaults()
        {
            tearIndex = 0;
            thetaSlow = 0f;
            _attackDur = 0;
            _theta = 0f;
            _attacking = false;
            _despawn = 0;
            plays = 1;
            phase = 0;
            eattack = 0;
            eattackDelMax = 280;
            eattackDel = eattackDelMax;
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
            npc.width = 190;
            npc.height = 240;
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
            eattack = 0;
            eattackDelMax = 200;
            eattackDel = eattackDelMax;
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
                    if (_despawn == 0)
                        _despawn++;
                }
            }
            else if(!Main.dayTime || LaugicalityWorld.downedEtheria)
                _despawn = 0;
            if(Main.dayTime && _despawn == 0 && !LaugicalityWorld.downedEtheria)
                _despawn++;
            if (_despawn >= 1)
            {
                _despawn++;
                npc.noTileCollide = true;
                if (_despawn >= 300)
                    npc.active = false;
            }

            npc.spriteDirection = 0;
            bitherial = true;
            npc.rotation = 0;
            if (phase > 2)
                npc.scale = 1f + (float)(phase) / 10f;
            else
                npc.scale = 1f;
            npc.height = (int)(npc.scale * 190);
            npc.width = (int)(npc.scale * 240);
            //Setting Phases
            if (npc.life < npc.lifeMax * .75 && phase == 0 )
            {
                phase += 1;
                if (Main.expertMode)
                    attackDelMax -= 30;
                npc.netUpdate = true;
            }
            if (npc.life < npc.lifeMax * .5 && phase == 1 )
            {
                phase += 1;
                if (Main.expertMode)
                    attackDelMax -= 30;
                if (LaugicalityWorld.downedEtheria && Main.netMode != 1)
                {
                    NPC.NewNPC((int)npc.position.X + Main.rand.Next(0, npc.width), (int)npc.position.Y + Main.rand.Next(0, npc.height), mod.NPCType("EtheriaDecoy"));
                }
                npc.netUpdate = true;
            }
            if (npc.life < npc.lifeMax * .25 && phase == 2 && Main.expertMode && LaugicalityWorld.downedEtheria)
            {
                npc.life = (int)(npc.lifeMax * .5);
                phase += 1;
                if (Main.expertMode)
                    attackDelMax -= 30;
                npc.netUpdate = true;
            }
            if (npc.life < npc.lifeMax * .25 && phase == 3 && Main.expertMode && LaugicalityWorld.downedEtheria)
            {
                phase += 1;
                if (Main.expertMode)
                    attackDelMax -= 30;
                if(Main.netMode != 1)
                    NPC.NewNPC((int)npc.position.X + Main.rand.Next(0, npc.width), (int)npc.position.Y + Main.rand.Next(0, npc.height), mod.NPCType("EtheriaDecoy"));
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
            _theta += 3.14f / 40f;
            if (_theta > 6.28f)
                _theta -= 6.28f;
            thetaSlow += 3.14f / 60f;
            if (thetaSlow > 6.28f)
                thetaSlow -= 6.28f;
            float projMod = 2f;
            center = npc.Center;
            scale = npc.scale;

            //Attack Delay
            if (!_attacking)
                attackDel--;
            if(attackDel <= 0)
            {
                attackDel = attackDelMax;
                attack++;
                _attacking = true;
                if (attack > 5)
                    attack = 1;
                if(LaugicalityWorld.downedEtheria)
                    projMod = 4f;
                if (phase > 4 && LaugicalityWorld.downedEtheria)
                {
                    eattack = attack;
                    attack = 0;
                    projMod = 2.5f;
                }
            }

            //Attacks
            if(attack == 1 && Main.netMode != 1 && _attacking)
            {
                attackRel++;
                if(attackRel > 2)
                {
                    attackRel = 0;
                    Projectile.NewProjectile(npc.Center.X + 48 * (float)Math.Cos(_theta), npc.Center.Y + 48 * (float)Math.Sin(_theta), 8 * (float)Math.Cos(_theta), 8 * (float)Math.Sin(_theta), mod.ProjectileType("EtherialPulse"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                }
                _attackDur++;
                if(_attackDur > 150)
                {
                    _attackDur = 0;
                    _attacking = false;
                }
            }
            if(attack == 2 && Main.netMode != 1 && _attacking)
            {
                attackRel++;
                if (attackRel > 30)
                {
                    _attackDur++;
                    attackRel = 0;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("EtherialYeet"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                }
                if (_attackDur >= 4)
                {
                    _attackDur = 0;
                    _attacking = false;
                }
            }
            if (attack == 3 && Main.netMode != 1 && _attacking)
            {
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
                for (int i = 0; i < 8; i++)
                {
                    int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("EtherialSpiralShot"));
                    Main.npc[n].ai[0] = npc.whoAmI;
                    Main.npc[n].ai[1] = i;
                }
                npc.position.X = Main.player[npc.target].position.X - (npc.position.X - Main.player[npc.target].position.X) / 2;
                npc.position.Y = Main.player[npc.target].position.Y - (npc.position.Y - Main.player[npc.target].position.Y) / 2;
                npc.velocity.X = -npc.velocity.X;
                npc.velocity.Y = -npc.velocity.Y;
                _attacking = false;
            }
            if (attack == 4 && Main.netMode != 1 && _attacking)
            {
                float dir = (float)Math.Atan2(npc.DirectionTo(Main.player[npc.target].Center).Y, npc.DirectionTo(Main.player[npc.target].Center).X);
                //Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8 * (float)Math.Cos(dir), 8 * (float)Math.Sin(dir), mod.ProjectileType("QuadroBurst"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                _attacking = false;
            }
            if (attack == 5 && Main.netMode != 1 && _attacking)
            {
                if (NPC.CountNPCS(mod.NPCType("EtherialTear")) < 4)
                {
                    NPC.NewNPC((int)npc.position.X + Main.rand.Next(0, npc.width), (int)npc.position.Y + Main.rand.Next(0, npc.height), mod.NPCType("EtherialTear"));
                    tearIndex++;
                    _attacking = false;
                }
                else
                    attack = 1;
            }

            //Etherial Attacks
            if (eattack == 1 && Main.netMode != 1 && _attacking)
            {
                attackRel++;
                if (attackRel > 2)
                {
                    attackRel = 0;
                    Projectile.NewProjectile(npc.Center.X + 48 * (float)Math.Cos(_theta), npc.Center.Y + 48 * (float)Math.Cos(_theta), 8 * (float)Math.Cos(_theta), 8 * (float)Math.Sin(_theta), mod.ProjectileType("TrueEtherialPulse"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X + 48 * (float)Math.Cos(_theta + 3.14), npc.Center.Y + 48 * (float)Math.Sin(_theta + 3.14), 8 * (float)Math.Cos(_theta + 3.14), 8 * (float)Math.Sin(_theta + 3.14), mod.ProjectileType("TrueEtherialPulse"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                }
                _attackDur++;
                if (_attackDur > 240)
                {
                    _attackDur = 0;
                    _attacking = false;
                }
            }
            if (eattack == 2 && Main.netMode != 1 && _attacking)
            {
                attackRel++;
                if (attackRel > 30)
                {
                    _attackDur++;
                    attackRel = 0;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("TrueEtherialYeet"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                }
                if (_attackDur >= 4)
                {
                    _attackDur = 0;
                    _attacking = false;
                }
            }
            if (eattack == 3 && Main.netMode != 1 && _attacking)
            {
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
                for (int i = 0; i < 12; i++)
                {
                    int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("TrueEtherialSpiralShot"));
                    Main.npc[n].ai[0] = npc.whoAmI;
                    Main.npc[n].ai[1] = i;
                }
                npc.position.X = Main.player[npc.target].position.X - (npc.position.X - Main.player[npc.target].position.X) / 2;
                npc.position.Y = Main.player[npc.target].position.Y - (npc.position.Y - Main.player[npc.target].position.Y) / 2;
                npc.velocity.X = -npc.velocity.X;
                npc.velocity.Y = -npc.velocity.Y;
                _attacking = false;
            }
            if (eattack == 4 && Main.netMode != 1 && _attacking)
            {
                float dir = (float)Math.Atan2(npc.DirectionTo(Main.player[npc.target].Center).Y, npc.DirectionTo(Main.player[npc.target].Center).X);
                //Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8 * (float)Math.Cos(dir), 8 * (float)Math.Sin(dir), mod.ProjectileType("TrueQuadroBurst"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                //Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8 * (float)Math.Cos(dir + 3.14), 8 * (float)Math.Sin(dir + 3.14), mod.ProjectileType("TrueQuadroBurst"), (int)(npc.damage / projMod), 3, Main.myPlayer);
                _attacking = false;
            }
            if (eattack == 5 && Main.netMode != 1 && _attacking)
            {
                if (NPC.CountNPCS(mod.NPCType("TrueEtherialTear")) < 4)
                {
                    NPC.NewNPC((int)npc.position.X + Main.rand.Next(0, npc.width), (int)npc.position.Y + Main.rand.Next(0, npc.height), mod.NPCType("TrueEtherialTear"));
                    tearIndex++;
                    _attacking = false;
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
            int b = 125;
            int b2 = 225;
            int b3 = 255;
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
                GenerateBysmal();
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

        private void GenerateBysmal()
        {
            int sizeMult = (int)(Math.Floor(Main.maxTilesX / 4200f));
            for(int i = 0; i < 30 * sizeMult; i++)
            {
                BysmalVeins.StructureGenBig(Main.rand.Next(200, Main.maxTilesX - 200), Main.rand.Next(350 * sizeMult, Main.maxTilesY - 400));
            }
            for (int i = 0; i < 100 * sizeMult; i++)
            {
                BysmalVeins.StructureGenMed(Main.rand.Next(200, Main.maxTilesX - 200), Main.rand.Next(350 * sizeMult, Main.maxTilesY - 400));
            }
            for (int i = 0; i < 120 * sizeMult; i++)
            {
                BysmalVeins.StructureGenSmall(Main.rand.Next(200, Main.maxTilesX - 200), Main.rand.Next(350 * sizeMult, Main.maxTilesY - 400));
            }
        }
    }
}
