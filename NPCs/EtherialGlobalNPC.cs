using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs
{
    class EtherialGlobalNPC : GlobalNPC
    {
        private bool grew = false;
        private int counter = 0;
        private int counter2 = 0;
        private int phase = 0;
        private int despawn = 0;
        private bool jumping = false;
        private int movementCounter = 0;
        private int movementCounter2 = 0;
        private int movementType = 0;
        private float theta = 0;
        int tempDamage = 0;

        public bool etherial = false;
        public bool bitherial = false;

        Vector2 targetPos;
        public float tVel = 0f;
        public float vMax = 10f;
        public float vAccel = .2f;
        public float vMag = 0f;

        private int dmg = 0;
        public bool friend = false;
        private bool invin = false;
        bool friendlyInvin = false;

        public float armTheta = 0;
        public float armDist = 0;
        bool hasSpawnedArms = false;
        bool spawnCheck = false;
        float bonusHSpeed = 0f;

        int direction = 0;

        //Boss Fights V
        public override void ScaleExpertStats(NPC npc, int numPlayers, float bossLifeScale)
        {
            tempDamage = 0;
            direction = 0;
            counter2 = 0;
            spawnCheck = false;
            hasSpawnedArms = false;
            armDist = 0;
            armTheta = 0;
            grew = false;
            counter = 0;
            phase = 0;
            despawn = 0;
            jumping = false;
            movementCounter = 0;
            movementCounter2 = 0;
            movementType = 0;
            vMag = 0f;
            theta = 0;
            targetPos = Main.player[npc.target].position;

            if (LaugicalityWorld.downedEtheria)
            {
                npc.damage = (int)(npc.damage * 1.33 + 40);
                npc.defense = (int)(npc.defense / 2);
                if (npc.boss)
                    npc.lifeMax += 15000;
                else
                    npc.lifeMax += 5000;
                npc.lifeMax = (int)(npc.lifeMax * 1.5);
                npc.life = npc.lifeMax;
                ScaleSpecificEtherialStats(npc);
            }
        }

        private void ScaleSpecificEtherialStats(NPC npc)
        {
            if (npc.type == NPCID.KingSlime)
            {
                npc.aiStyle = 0;
                npc.damage = 200;
                npc.defense = 20;
                npc.lifeMax = 70000;
                npc.life = npc.lifeMax;
            }
            if(npc.type == NPCID.EyeofCthulhu)
            {
                npc.damage = 225;
                npc.lifeMax = 70000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == mod.NPCType("DuneSharkron"))
            {
                npc.damage = 200;
                npc.lifeMax = 60000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == NPCID.EaterofWorldsHead)
            {
                npc.damage = 250;
                npc.lifeMax = 8000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == NPCID.EaterofWorldsBody)
            {
                npc.damage = 150;
                npc.lifeMax = 10000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == NPCID.EaterofWorldsTail)
            {
                npc.damage = 100;
                npc.lifeMax = 14000;
                npc.defense = 45;
                npc.life = npc.lifeMax;
            }
            if(npc.type == NPCID.BrainofCthulhu)
            {
                npc.damage = 200;
                npc.lifeMax = 60000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == mod.NPCType("Hypothema"))
            {
                npc.damage = 200;
                npc.lifeMax = 60000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == NPCID.QueenBee)
            {
                npc.damage = 230;
                npc.lifeMax = 80000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == mod.NPCType("Ragnar"))
            {
                npc.damage = 250;
                npc.lifeMax = 100000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == NPCID.SkeletronHead)
            {
                npc.damage = 280;
                npc.lifeMax = 80000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == NPCID.SkeletronHand)
            {
                npc.damage = 200;
                npc.lifeMax = 18000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == mod.NPCType("Dioritus"))
            {
                npc.damage = 250;
                npc.lifeMax = 50000;
                npc.life = npc.lifeMax;
                npc.defense = 40;
                npc.GetGlobalNPC<LaugicalGlobalNPCs>(mod).zImmune = true;
            }
            if (npc.type == mod.NPCType("Andesia"))
            {
                npc.damage = 250;
                npc.lifeMax = 50000;
                npc.life = npc.lifeMax;
                npc.defense = 40;
                npc.GetGlobalNPC<LaugicalGlobalNPCs>(mod).zImmune = true;
            }
            if (npc.type == mod.NPCType("AnDio3"))
            {
                npc.damage = 250;
                npc.lifeMax = 120000;
                npc.life = npc.lifeMax;
                npc.defense = 60;
                npc.GetGlobalNPC<LaugicalGlobalNPCs>(mod).zImmune = true;
            }
            if (npc.type == NPCID.WallofFlesh)
            {
                npc.damage = 250;
                npc.lifeMax = 150000;
                npc.life = npc.lifeMax;
            }
            if(npc.type == NPCID.Spazmatism || npc.type == NPCID.Retinazer || npc.type == mod.NPCType("Terratome"))
            {
                npc.damage = 275;
                npc.lifeMax = 150000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == NPCID.SkeletronPrime)
            {
                npc.damage = 250;
                npc.lifeMax = 125000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == NPCID.PrimeCannon || npc.type == NPCID.PrimeLaser || npc.type == NPCID.PrimeSaw || npc.type == NPCID.PrimeVice)
            {
                npc.damage = 200;
                npc.lifeMax = 150000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == NPCID.TheDestroyer || npc.type == NPCID.TheDestroyerBody || npc.type == NPCID.TheDestroyerTail)
            {
                npc.damage = 250;
                npc.lifeMax = 500000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == NPCID.Probe)
            {
                npc.damage = 175;
                npc.lifeMax = 10000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == mod.NPCType("TheAnnihilator"))
            {
                npc.damage = 300;
                npc.lifeMax = 225000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == mod.NPCType("SuperMechanicalMinion") || npc.type == mod.NPCType("SuperMechanicalCrawler") || npc.type == mod.NPCType("MechanicalCrawler") || npc.type == mod.NPCType("MechanicalMimic") || npc.type == mod.NPCType("MechanicalShelly") || npc.type == mod.NPCType("MechanicalSlimer") || npc.type == mod.NPCType("MechanicalCreeper"))
            {
                npc.damage = 200;
                npc.lifeMax = 20000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == mod.NPCType("Slybertron"))
            {
                npc.damage = 250;
                npc.lifeMax = 250000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == mod.NPCType("GearSlime") || npc.type == mod.NPCType("SparkSlime") || npc.type == mod.NPCType("PipeSlime"))
            {
                npc.damage = 250;
                npc.lifeMax = 20000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == mod.NPCType("SteamTrain"))
            {
                npc.damage = 275;
                npc.lifeMax = 200000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == NPCID.Plantera)
            {
                npc.damage = 300;
                npc.lifeMax = 250000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == NPCID.GolemFistLeft || npc.type == NPCID.GolemFistRight || npc.type == mod.NPCType("SuperGolemFist"))
            {
                npc.damage = 300;
                npc.lifeMax = 175000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == NPCID.GolemHead || npc.type == NPCID.Golem || npc.type == NPCID.GolemHeadFree)
            {
                npc.damage = 300;
                npc.lifeMax = 175000;
                npc.life = npc.lifeMax;
            }
            if (npc.type == NPCID.DukeFishron)
            {
                npc.damage = 320;
                npc.lifeMax = 275000;
                npc.life = npc.lifeMax;
            }
        }

        public void EtherialPostAI(NPC npc)
        {
            if(LaugicalityWorld.downedEtheria)
            {
                if (npc.type == NPCID.KingSlime)
                {
                    KingSlimeAI(npc);
                }
                if(npc.type == NPCID.EyeofCthulhu)
                {
                    EyeofCthulhuAI(npc);
                }
                if(npc.type == mod.NPCType("DuneSharkron"))
                {
                    DuneSharkronAI(npc);
                }
                if (npc.type == NPCID.BrainofCthulhu)
                {
                    BrainOfCthulhuAI(npc);
                }
                if (npc.type == mod.NPCType("Hypothema"))
                {
                    HypothemaAI(npc);
                }
                if (npc.type == NPCID.QueenBee)
                {
                    QueenBeeAI(npc);
                }
                if (npc.type == mod.NPCType("Ragnar"))
                {
                    RagnarAI(npc);
                }
                if (npc.type == NPCID.SkeletronHead)
                {
                    SkeletronAI(npc);
                }
                if (npc.type == NPCID.DungeonGuardian)
                {
                    DungeonGuardianAI(npc);
                }
                if (npc.type == mod.NPCType("AnDio3"))
                {
                    AnDioAI(npc);
                }
                if (npc.type == NPCID.WallofFlesh)
                {
                    WallofFleshAI(npc);
                }
                if (npc.type == NPCID.Retinazer)
                {
                    RetinazerAI(npc);
                }
                if (npc.type == NPCID.Spazmatism)
                {
                    SpazmatismAI(npc);
                }
                if (npc.type == NPCID.SkeletronPrime)
                {
                    SkeletronPrimeAI(npc);
                }
                if (npc.type == NPCID.TheDestroyer)
                {
                    DestroyerAI(npc);
                }
                if (npc.type == mod.NPCType("TheAnnihilator"))
                {
                    AnnihilatorAI(npc);
                }
                if (npc.type == mod.NPCType("SuperMechanicalCrawler"))
                {
                    AnnihilatorCrawlerAI(npc);
                }
                if (npc.type == mod.NPCType("Slybertron"))
                {
                    SlybertronAI(npc);
                }
                if (npc.type == NPCID.Plantera)
                {
                    PlanteraAI(npc);
                }
                if (npc.type == NPCID.Golem)
                {
                    GolemAI(npc);
                }
                if (npc.type == NPCID.DukeFishron)
                {
                    DukeFishronAI(npc);
                }
            }
        }

        private void Retarget(NPC npc)
        {
            if (!(npc.target != null && Main.player.GetLength(0) > 0))
                return;
            Player P = Main.player[npc.target];
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            npc.netUpdate = true;
            if(targetPos.X == 0 && targetPos.Y == 0)
                targetPos = Main.player[npc.target].position;
        }

        private void DespawnCheck(NPC npc)
        {
            if (!Main.player[npc.target].active || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
                if (!Main.player[npc.target].active || Main.player[npc.target].dead)
                {
                    if (despawn == 0)
                        despawn++;
                }
            }
            if (despawn >= 1)
            {
                despawn++;
                npc.noTileCollide = true;
                npc.velocity.Y = 8f;
                if (despawn >= 300)
                    npc.active = false;
            }
        }

        private void KingSlimeAI(NPC npc)
        {
            if (Main.expertMode)
            {
                Grow(npc, 1.75f, 1.5f);
                if (Teleport(npc, 1250, Main.player[npc.target].position.X - npc.width / 2, Main.player[npc.target].position.Y - 350 - npc.height / 2))
                    targetPos = Main.player[npc.target].position;
                KingSlimeHealthEffect(npc);
                KingSlimeMovement(npc);
            }
        }

        private void KingSlimeHealthEffect(NPC npc)
        {
            if (npc.life < (int)(npc.lifeMax - (npc.lifeMax / 10 * (phase + 1))))
            {
                phase++;
                if(Main.netMode != 1)
                {
                    int N = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SuperSlime"));
                    Main.npc[N].ai[0] = npc.whoAmI;
                    Main.npc[N].ai[1] = NPC.CountNPCS(mod.NPCType("SuperSlime"));
                }
            }
        }

        private void KingSlimeMovement(NPC npc)
        {
            movementCounter++;
            theta += 3.14f / 30;
            if(movementType == 0)
            {
                vMax = 25f;
                if (movementCounter > 120)
                {
                    jumping = !jumping;
                    movementCounter = 0;
                    movementCounter2++;
                    if (movementCounter2 > 3)
                    {
                        movementType = 1;
                        movementCounter2 = 0;
                        jumping = false;
                    }
                    if(!jumping)
                        targetPos.Y += 800;
                }
                if (jumping)
                {
                    targetPos = Main.player[npc.target].Center;
                    targetPos.Y -= 400;
                }
            }
            if(movementType == 1)
            {
                vMax = 12f;
                targetPos = Main.player[npc.target].Center;
                if (movementCounter > 180)
                {
                    movementCounter = 0;
                    movementType = 0;
                    jumping = true;
                }
            }
            MoveToTarget(npc);
        }

        private void EyeofCthulhuAI(NPC npc)
        {
            EyeofCthulhuHealthEffect(npc);
        }

        private void EyeofCthulhuHealthEffect(NPC npc)
        {
            if (npc.life < (int)(npc.lifeMax - (npc.lifeMax / 20 * (phase + 1))) && npc.life > npc.lifeMax / 2)
            {
                phase++;
                if (Main.netMode != 1)
                {
                    int N = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SuperServant"));
                    Main.npc[N].ai[0] = npc.whoAmI;
                    Main.npc[N].ai[1] = NPC.CountNPCS(mod.NPCType("SuperServant"));
                }
            }
            if(npc.life < 30000)
            {
                npc.damage = 250;
            }
        }

        private void DuneSharkronAI(NPC npc)
        {
            DuneSharkronHealthEffect(npc);
        }

        private void DuneSharkronHealthEffect(NPC npc)
        {
            if (npc.life < npc.lifeMax / 3 && NPC.CountNPCS(NPCID.SandElemental) < 1)
            {
                phase++;
                if (Main.netMode != 1)
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.SandElemental);
            }
        }

        private void BrainOfCthulhuAI(NPC npc)
        {
            BrainOfCthulhuHealthEffect(npc);
        }

        private void BrainOfCthulhuHealthEffect(NPC npc)
        {
            if (npc.life < (int)(npc.lifeMax - (npc.lifeMax / 10 * (phase + 1))))
            {
                phase++;
                if (Main.netMode != 1)
                {
                    int N = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SuperIchorSpitter"));
                    Main.npc[N].ai[0] = npc.whoAmI;
                    Main.npc[N].ai[1] = NPC.CountNPCS(mod.NPCType("SuperIchorSpitter"));
                }
            }
        }

        private void HypothemaAI(NPC npc)
        {
            HypothemaHealthEffect(npc);
        }

        private void HypothemaHealthEffect(NPC npc)
        {
            if (npc.life < (int)(npc.lifeMax - (npc.lifeMax / 4 * (phase + 1))) )
            {
                phase++;
            }
            if(NPC.CountNPCS(NPCID.IceGolem) < phase && Vector2.Distance(npc.Center, Main.player[npc.target].Center) < 320)
            { 
                if (Main.netMode != 1)
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.IceGolem);
            }
        }

        private void QueenBeeAI(NPC npc)
        {
            counter++;
            counter2++;
            if(counter > 1 * 60 + (int)(60 * (npc.life / npc.lifeMax)))
            {
                counter = 0;
                if (Main.netMode != 1)
                {
                    if(Main.rand.Next(2) == 0)
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("EtherialStinger"), (int)(npc.damage * .7), 3, Main.myPlayer);
                    else
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SuperBee"));
                }
            }
            if(counter2 > 4 * 60 + (int)(2 * 60 * (npc.life / npc.lifeMax)))
            {
                counter2 = 0;
                if (Main.netMode != 1 && NPC.CountNPCS(mod.NPCType("SuperHornet")) < 8)
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SuperHornet"));
            }
        }

        private void RagnarAI(NPC npc)
        {
            armTheta += (float)Math.PI / 90;
            if (armTheta > (float)Math.PI * 2)
                armTheta -= (float)Math.PI * 2;
            armDist = 320;
            if (!hasSpawnedArms)
            {
                SpawnArms(npc);
                hasSpawnedArms = true;
            }
            RagnarHealthEffects(npc);
        }

        private void SpawnArms(NPC npc)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Main.netMode != 1)
                {
                    int N = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("RagnarHand"));
                    Main.npc[N].ai[0] = i;
                    Main.npc[N].ai[1] = npc.whoAmI;
                }
            }
        }

        private void RagnarHealthEffects(NPC npc)
        {
            if (npc.life < (int)(npc.lifeMax * (3 - (phase + 1)) / 3))
            {
                phase++;
                if (Main.netMode != 1)
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("LavaTitan"));
            }
        }

        private void SkeletronAI(NPC npc)
        {
            if(NPC.CountNPCS(NPCID.DungeonGuardian) < 1 || (NPC.CountNPCS(NPCID.DungeonGuardian) < 2 && npc.life < npc.lifeMax / 2))
            {
                if (Main.netMode != 1)
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.DungeonGuardian);
            }
        }

        private void DungeonGuardianAI(NPC npc)
        {
            float dist = Vector2.Distance(Main.player[npc.target].Center, npc.Center);
            if (counter > 0)
                counter--;
            if(counter > 1 * 60 + 30)
            {
                npc.velocity.X = 0;
                npc.velocity.Y = 0;
            }
            if ((dist > 1200  || Main.rand.Next(5 * 60) == 0 ) && Main.player[npc.target].statLife > 1 && counter == 0)
            {
                counter = 2 * 60;
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
                npc.position.X = Main.player[npc.target].position.X - (npc.position.X - Main.player[npc.target].position.X) * 3 / 4;
                npc.position.Y = Main.player[npc.target].position.Y - (npc.position.Y - Main.player[npc.target].position.Y) * 3 / 4;
            }
        }

        private void AnDioAI(NPC npc)
        {
            counter++;
            if(counter > 16 * 60)
            {
                counter = 0;
                if(Laugicality.zawarudo < 10 * 60)
                {
                    Laugicality.zawarudo = 10 * 60;
                    LaugicalGlobalNPCs.zTime = 10 * 60;
                }
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/zawarudo"));
            }
        }
        
        private void WallofFleshAI(NPC npc)
        {
            WallofFleshHealthEffects(npc);
            WallofFleshMovement(npc);
            WallofFleshCheckPlayer(npc);
            WallofFleshEnemySpawn(npc);
        }

        private void WallofFleshHealthEffects(NPC npc)
        {
            bonusHSpeed = (npc.life / npc.lifeMax) * 6 + 4;
        }

        private void WallofFleshMovement(NPC npc)
        {
            if (direction == 0)
            {
                if (npc.position.X < Main.maxTilesX / 2)
                    direction = 1;
                else
                    direction = -1;
            }
            npc.position.X += direction * bonusHSpeed;
        }

        private void WallofFleshCheckPlayer(NPC npc)
        {
            foreach(Player player in Main.player)
            {
                if (npc.position.X > player.position.X && direction == 1)
                {
                    player.position.X += bonusHSpeed * 1.5f;
                }
                if (npc.position.X < player.position.X && direction == -1)
                {
                    player.position.X -= bonusHSpeed * 1.5f;
                }
            }
        }

        private void WallofFleshEnemySpawn(NPC npc)
        {
            counter2++;
            if (counter2 > (NPC.CountNPCS(mod.NPCType("SuperLeechHead")) + 2) * 60)
            {
                counter2 = 0;
                if (NPC.CountNPCS(mod.NPCType("SuperLeechHead")) < 10 && Main.netMode != 1)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SuperLeechHead"));
                }
            }
        }

        private void RetinazerAI(NPC npc)
        {
            if (!spawnCheck)
            {
                if (Main.netMode != 1)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Terratome"));
                }
                spawnCheck = true;
            }

            counter++;
            if(counter >= 8 * 60)
            {
                counter = 0;
                MirrorTeleport(npc, true);
            }
        }

        private void SpazmatismAI(NPC npc)
        {
            if(Main.rand.Next(8 * 60) == 0)
            {
                MirrorTeleport(npc, true);
            }
        }


        private void SkeletronPrimeAI(NPC npc)
        {
            if (!spawnCheck)
            {
                if (Main.netMode != 1)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("MechanicalDungeonGuardian"));
                }
                spawnCheck = true;
            }
        }

        private void DestroyerAI(NPC npc)
        {
            counter++;
            if(counter >= 5)
            {
                counter = 0;
                //Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 33);
                Vector2 newVel = npc.velocity;
                newVel.Normalize();
                newVel *= 12;
                Projectile.NewProjectile(npc.Center, newVel, ProjectileID.DeathLaser, npc.damage / 3, 5);
            }
        }

        private void AnnihilatorAI(NPC npc)
        {
            targetPos = Main.player[npc.target].Center;
            if (npc.life < npc.lifeMax / 2)
                vMax = 20;
            else
                vMax = 14;
            MoveToTarget(npc);
            DespawnCheck(npc);
            counter++;
            if(counter > (NPC.CountNPCS(mod.NPCType("SuperMechanicalMinion")) + 2) * 60)
            {
                counter = 0;
                int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SuperMechanicalMinion"));
                Main.npc[n].ai[0] = npc.whoAmI;
                int m = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SuperMechanicalCrawler"));
                Main.npc[m].ai[0] = npc.whoAmI;
            }
        }

        private void AnnihilatorCrawlerAI(NPC npc)
        {
            vMax = 20;
            targetPos = Main.player[npc.target].Center;
            MoveToTarget(npc);
            if (Main.rand.Next(4 * 60) == 0)
                MirrorTeleport(npc, false);
            if (Main.npc[(int)npc.ai[0]].life < 1 || Main.npc[(int)npc.ai[0]].active == false)
            {
                npc.active = false;
            }
        }

        private void SlybertronAI(NPC npc)
        {
            if(!spawnCheck)
            {
                Main.NewText("Steampunk Slimes are falling from the sky!", 230, 200, 40);
                spawnCheck = true;
            }
            if(Main.rand.Next(2 * 60) == 0)
            {
                int rand = Main.rand.Next(3);
                if(rand == 0)
                {
                    int n = NPC.NewNPC((int)Main.player[npc.target].Center.X - 200 + Main.rand.Next(400), (int)Main.player[npc.target].Center.Y - 500, mod.NPCType("GearSlime"));
                }
                if (rand == 1)
                {
                    int n = NPC.NewNPC((int)Main.player[npc.target].Center.X - 200 + Main.rand.Next(400), (int)Main.player[npc.target].Center.Y - 500, mod.NPCType("PipeSlime"));
                }
                if (rand == 2)
                {
                    int n = NPC.NewNPC((int)Main.player[npc.target].Center.X - 200 + Main.rand.Next(400), (int)Main.player[npc.target].Center.Y - 500, mod.NPCType("SparkSlime"));
                }
            }
            if(npc.life < npc.lifeMax / 2)
            {
                Main.player[npc.target].AddBuff(mod.BuffType("WingClip"), 2, true);
            }
        }

        private void PlanteraAI(NPC npc)
        {
            counter++;
            if ((counter > 30 && npc.life > npc.lifeMax / 2) || (counter > 15 && npc.life <= npc.lifeMax / 2))
            {
                counter = 0;
                if (Main.netMode != 1)
                {
                    float mag = 32;
                    theta = (float)Math.PI * 2 * Main.rand.NextFloat();
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, mod.ProjectileType("EtherialSpore"), (int)(npc.damage * .5), 3, Main.myPlayer);
                    theta = (float)Math.PI * 2 * Main.rand.NextFloat();
                    if (npc.life <= npc.lifeMax / 2)
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, mod.ProjectileType("EtherialSpore"), (int)(npc.damage * .5), 3, Main.myPlayer);
                }
            }
            if(npc.life <= npc.lifeMax / 2)
            {
                Main.player[npc.target].AddBuff(mod.BuffType("WingClip"), 2, true);
            }
        }

        private void GolemAI(NPC npc)
        {
            if(!spawnCheck)
            {
                spawnCheck = true;
                if(Main.netMode != 1)
                {
                    int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SuperGolemFist"));
                    Main.npc[n].ai[0] = npc.whoAmI;
                    Main.npc[n].ai[1] = -1;
                    int m = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SuperGolemFist"));
                    Main.npc[m].ai[0] = npc.whoAmI;
                    Main.npc[m].ai[1] = 1;
                }
            }
        }

        private void DukeFishronAI(NPC npc)
        {
            DukeFishronDamageEffects(npc);
            DukeFishronHealthEffects(npc);
        }

        private void DukeFishronDamageEffects(NPC npc)
        {
            if (tempDamage == 0)
            {
                tempDamage = npc.damage;
            }
            if (!Main.player[npc.target].wet)
            {
                if (npc.life < npc.lifeMax / 3)
                    npc.damage = tempDamage * 2;
                else
                    npc.damage = tempDamage;
                npc.dontTakeDamage = true;
            }
            else
            {
                if (npc.life < npc.lifeMax / 3)
                    npc.damage = tempDamage * 2;
                else
                    npc.damage = tempDamage;
                npc.dontTakeDamage = false;
            }
        }

        private void DukeFishronHealthEffects(NPC npc)
        {
            counter2++;
            if (counter2 > (NPC.CountNPCS(mod.NPCType("SuperShark")) + 2) * 60)
            {
                counter2 = 0;
                if (NPC.CountNPCS(mod.NPCType("SuperShark")) < 15 && Main.netMode != 1)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SuperShark"));
                }
            }
        }

        private void MoveToTarget(NPC npc)
        {
            float dist = Vector2.Distance(targetPos, npc.Center);
            tVel = dist / 15;
            if (vMag < vMax && vMag < tVel)
            {
                vMag += vAccel;
                vMag = tVel;
            }
            if (vMag > tVel)
            {
                vMag = tVel;
            }
            if (vMag > vMax)
            {
                vMag = vMax;
            }
            if (dist != 0)
            {
                npc.velocity = npc.DirectionTo(targetPos) * vMag;
            }
        }

        private void Grow(NPC npc, float hitboxScale, float displayScale)
        {
            if (!grew)
            {
                grew = true;
                npc.width = (int)(npc.width * hitboxScale);
                npc.height = (int)(npc.height * hitboxScale);
            }
            if (grew)
            {
                npc.scale = displayScale;
            }
        }

        private bool Teleport(NPC npc, float threshold, float goalX, float goalY)
        {
            float dist = Vector2.Distance(Main.player[npc.target].Center, npc.Center);
            if(dist > threshold && Main.player[npc.target].statLife > 1)
            {
                npc.position.X = goalX;
                npc.position.Y = goalY;
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
                return true;
            }
            return false;
        }

        private void MirrorTeleport(NPC npc, bool burst)
        {
            Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
            if(burst && Main.player[npc.target].statLife > 1)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (Main.netMode != 1)
                    {
                        int N = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("EtherialSpiralShot"));
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

        public override void OnHitPlayer(NPC npc, Player player, int damage, bool crit)
        {
            if (LaugicalityWorld.downedEtheria)
            {
                if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
                    player.AddBuff(BuffID.ShadowFlame, 8 * 60, true);
                if (npc.type == NPCID.BrainofCthulhu || npc.type == NPCID.Creeper)
                    player.AddBuff(BuffID.Obstructed, 8 * 60, true);
                if (npc.type == mod.NPCType("TheAnnihilator") || npc.type == mod.NPCType("MechanicalCrawler") || npc.type == mod.NPCType("MechanicalMimic") || npc.type == mod.NPCType("MechanicalShelly") || npc.type == mod.NPCType("MechanicalSlimer") || npc.type == mod.NPCType("MehcanicalCreeper"))
                    player.AddBuff(mod.BuffType("Frostbite"), 8 * 60, true);
            }
        }

        public override void NPCLoot(NPC npc)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityWorld.downedEtheria)
            {
                if (npc.boss && npc.type != NPCID.EaterofWorldsBody && npc.type != NPCID.EaterofWorldsTail && npc.type != NPCID.EaterofWorldsHead) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialEssence"), Main.rand.Next(5, 11));
                if (npc.type == 4)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EyeOfEtheria"), 1);
                }
                if (npc.type == 113)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialEnergy"), 1);
                }
                if (npc.type == 50)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialGel"), 1);
                }
                if (npc.type == 35)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialSkull"), 1);
                    foreach(NPC dungeonGuardian in Main.npc)
                    {
                        if (dungeonGuardian.type == NPCID.DungeonGuardian)
                            dungeonGuardian.active = false;
                    }
                }
                if (npc.type == 13)
                {
                    if (NPC.CountNPCS(13) < 2 && NPC.CountNPCS(14) < 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialScarf"), 1);
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialEssence"), Main.rand.Next(5, 11));
                        if (modPlayer.fullBysmal > 0)
                            modPlayer.CycleBysmalPowers(13);
                    }
                }
                if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
                {
                    if (Main.rand.Next(6) == 0 && Main.netMode != 1)
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SuperCorruptor"));
                }
                if (npc.type == 266)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrainOfEtheria"), 1);
                }
                if (npc.type == 222)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialPack"), 1);
                }
                if (npc.type == 245)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StoneOfEtheria"), 1);
                }
                if (npc.type == 262)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialSac"), 1);
                }
                if (npc.type == 398)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialGlobe"), 1);
                }
                if (npc.type == 134)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialDestructionCore"), 1);
                }
                if (npc.type == 125 && NPC.CountNPCS(126) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialConjurationCore"), 1);
                    if (modPlayer.fullBysmal > 0)
                        modPlayer.CycleBysmalPowers(125);
                }
                if (npc.type == 126 && NPC.CountNPCS(125) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialConjurationCore"), 1);
                    if (modPlayer.fullBysmal > 0)
                        modPlayer.CycleBysmalPowers(125);
                }
                if (npc.type == 127)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialIllusionCore"), 1);
                }
                if (npc.type == 370)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialTruffle"), 1);
                }

                if(Main.netMode == 2)
                {
                    foreach (Player player in Main.player)
                    {
                        var modPlayer2 = player.GetModPlayer<LaugicalityPlayer>(mod);
                        if (LaugicalityVars.EBosses.Contains(npc.type) && !modPlayer2.BysmalPowers.Contains(npc.type))
                        {
                            if (modPlayer2.fullBysmal > 0)
                                modPlayer2.CycleBysmalPowers(npc.type);
                        }
                    }
                }
                else if(Main.netMode == 0)
                {
                    if (LaugicalityVars.EBosses.Contains(npc.type) && !modPlayer.BysmalPowers.Contains(npc.type) && npc.type != mod.NPCType("Etheria"))
                    {
                        if (modPlayer.fullBysmal > 0)
                            modPlayer.CycleBysmalPowers(npc.type);
                    }
                }
            }
        }

        //Global Stuff V
        public override bool? DrawHealthBar(NPC npc, byte hbPosition, ref float scale, ref Vector2 position)
        {
            if (!npc.friendly)
            {
                if (etherial)
                {
                    if (LaugicalityWorld.downedEtheria)
                    {
                        scale = 1f;
                    }
                    else
                    {
                        scale = 0f;
                    }
                }
                else
                {
                    if (LaugicalityWorld.downedEtheria)
                    {
                        scale = 0f;
                    }
                    else
                    {
                        scale = 1f;
                    }
                }
            }
            else scale = 1f;
            return null;
        }

        public override bool InstancePerEntity { get { return true; } }

        public override void SetDefaults(NPC npc)
        {
            dmg = 0;
            invin = npc.dontTakeDamage;
            friendlyInvin = npc.dontTakeDamageFromHostiles;
            if (npc.boss)
            {
                bitherial = true;
            }
            if (bitherial)
            {
                LaugicalityVars.ENPCs.Add(npc.type);
            }
            if (LaugicalityVars.ENPCs.Contains(npc.type))
            {
                bitherial = true;
            }
            if (LaugicalityVars.Etherial.Contains(npc.type))
            {
                etherial = true;
            }
            if (LaugicalityVars.EBad.Contains(npc.type))
            {
                npc.life = 0;
            }
        }

        public override bool? CanChat(NPC npc)
        {
            if (LaugicalityWorld.downedEtheria)
            {
                if (npc.type == NPCID.ScorpionBlack && Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod).EtherVision)
                    return true;
                if (Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod).EtherVision)
                    return base.CanChat(npc);
                return false;
            }
            return base.CanChat(npc);
        }


        public override Color? GetAlpha(NPC npc, Color drawColor)
        {
            if (LaugicalityWorld.downedEtheria)
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
            else
            {
                return null;
            }
        }

        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (!bitherial)
            {
                if (!friend || !invin)
                {
                    if (etherial)
                    {
                        if (LaugicalityWorld.downedEtheria)
                        {
                            npc.dontTakeDamage = invin;
                            return true;
                        }
                        else
                        {
                            npc.dontTakeDamage = true;
                            return modPlayer.EtherVision;
                        }
                    }
                    else
                    {

                        if (LaugicalityWorld.downedEtheria)
                        {
                            npc.dontTakeDamage = true;
                            return modPlayer.EtherVision;
                        }
                        else
                        {
                            npc.dontTakeDamage = invin;
                            return true;
                        }
                    }
                }
                else if (npc.townNPC)
                {
                    if (LaugicalityWorld.downedEtheria)
                        npc.dontTakeDamageFromHostiles = true;
                    else
                        npc.dontTakeDamageFromHostiles = invin;
                    if (modPlayer.EtherVision == false)
                        return !LaugicalityWorld.downedEtheria;
                    else
                        return true;
                }
                else return true;
            }
            else return true;
        }

        public override bool PreAI(NPC npc)
        {
            if (CheckSpecialEtherialAI(npc))
                return false;
            if (!bitherial)
            {
                if (dmg == 0)
                {
                    dmg = npc.damage;
                    friend = npc.friendly;
                }
                if (!friend)
                {
                    if (etherial)
                    {
                        if (LaugicalityWorld.downedEtheria)
                        {
                            if (npc.damage == 0)
                            {
                                npc.damage = dmg;
                            }
                            return true;
                        }
                        else
                        {
                            if (npc.damage == dmg)
                            {
                                npc.damage = 0;
                            }
                            return false;
                        }
                    }
                    else
                    {

                        if (LaugicalityWorld.downedEtheria)
                        {
                            if (npc.damage == dmg)
                            {
                                npc.damage = 0;
                            }
                            return false;
                        }
                        else
                        {
                            if (npc.damage == 0)
                            {
                                npc.damage = dmg;
                            }
                            return true;
                        }
                    }
                }
                else
                {
                    if (LaugicalityWorld.downedEtheria)
                        return false;
                    return true;
                }
            }
            else return true;
        }

        private bool CheckSpecialEtherialAI(NPC npc)
        {
            return false;
        }

        public override void PostAI(NPC npc)
        {
            if (LaugicalityWorld.downedEtheria && (npc.type >= 430 && npc.type <= 436))
            {
                npc.life = 0;
            }
            if (npc.townNPC)
            {
                if (LaugicalityWorld.downedEtheria)
                    npc.dontTakeDamage = true;
                else
                    npc.dontTakeDamage = false;
            }
            EtherialPostAI(npc);
        }
    }
}
