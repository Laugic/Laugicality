using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public float armTheta = 0;
        public float armDist = 0;
        bool hasSpawnedArms = false;
        bool spawnCheck = false;

        //Boss Fights V
        public override void ScaleExpertStats(NPC npc, int numPlayers, float bossLifeScale)
        {
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
                if (npc.boss)
                {
                    Retarget(npc);
                    DespawnCheck(npc);
                }
            }
        }

        private void Retarget(NPC npc)
        {
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
                int N = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("RagnarHand"));
                Main.npc[N].ai[0] = i;
                Main.npc[N].ai[1] = npc.whoAmI;
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
            if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
                player.AddBuff(BuffID.ShadowFlame, 8 * 60, true);
            if (npc.type == NPCID.BrainofCthulhu || npc.type == NPCID.Creeper)
                player.AddBuff(BuffID.Obstructed, 8 * 60, true);
        }

        public override void NPCLoot(NPC npc)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityWorld.downedEtheria)
            {
                if (npc.boss) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialEssence"), Main.rand.Next(5, 11));
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
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialScarf"), 1);
                    if (modPlayer.fullBysmal > 0)
                        modPlayer.CycleBysmalPowers(npc.type);
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
                        modPlayer.CycleBysmalPowers(npc.type);
                }
                if (npc.type == 126 && NPC.CountNPCS(125) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialConjurationCore"), 1);
                    if (modPlayer.fullBysmal > 0)
                        modPlayer.CycleBysmalPowers(npc.type);
                }
                if (npc.type == 127)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialIllusionCore"), 1);
                }
                if (npc.type == 370)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialTruffle"), 1);
                }


                if(LaugicalityVars.EBosses.Contains(npc.type) && !modPlayer.bysmalPowers.Contains(npc.type))
                {
                    if (modPlayer.fullBysmal > 0)
                        modPlayer.CycleBysmalPowers(npc.type);
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
            if (npc.boss)
            {
                bitherial = true;
            }
            if (bitherial)
            {
                LaugicalityVars.ENPCs.Add(npc.type);
            }
            //bitherial = false;
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
                return false;
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
                            return modPlayer.etherVision;
                        }
                    }
                    else
                    {

                        if (LaugicalityWorld.downedEtheria)
                        {
                            npc.dontTakeDamage = true;
                            return modPlayer.etherVision;
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
                        npc.dontTakeDamage = true;
                    else
                        npc.dontTakeDamage = invin;
                    if (modPlayer.etherVision == false)
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
