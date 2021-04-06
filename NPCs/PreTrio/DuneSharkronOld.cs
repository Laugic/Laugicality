/*using System;
using Laugicality.Dusts;
using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Laugicality.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    [AutoloadBossHead]
    public class DuneSharkron : ModNPC
    {
        public bool Enraged { get; set; }
        public int MovementPhaseCounter { get; set; } = 0;
        public int MovementPhaseSteps { get; set; } = 0;
        public int MovementPhase { get; set; } = 0;
        public Vector2 targetPos;
        public int AttackCounter { get; set; } = 0;
        public int AttackDelay { get; set; } = 0;
        private int DespawnCounter { get; set; } = 0;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(npc.type);
            DisplayName.SetDefault("Dune Sharkron");
        }

        public override void SetDefaults()
        {
            npc.width = 150;
            npc.height = 60;
            npc.damage = 35;
            npc.defense = 12;
            npc.aiStyle = 103;
            npc.lifeMax = 2000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/DuneSharkron");
            bossBag = ModContent.ItemType<DuneSharkronTreasureBag>();
            npc.scale = 1.25f;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 3500 + numPlayers * 1500;
            npc.damage = 70;
        }

        private void CheckEnrage()
        {
            Player player = Main.player[npc.target];
            Enraged = !player.ZoneDesert;
            if (Enraged)
            {
                npc.defense = 32;
                CrystalRain();
            }
            else
                npc.defense = 12;
        }

        private bool CheckDespawn()
        {
            if (Main.player[npc.target].statLife < 1 || Vector2.Distance(Main.player[npc.target].Center, npc.Center) > 3500 || !Main.player[npc.target].active)
            {
                DespawnCounter++;
                if (DespawnCounter > 300)
                    npc.active = false;
                return true;
            }
            DespawnCounter = 0;
            return false;
        }

        public override void AI()
        {
            if(CheckDespawn())
                return;
            CheckEnrage();
            if(AttackCounter == 0)
                PickMovement();
            MakeDust();
            npc.netUpdate = true;
        }

        private void PickMovement()
        {
            switch (MovementPhase)
            {
                case 1:
                    DashAI();
                    break;
                case 2:
                    SuperJumpAI();
                    break;
                case 3:
                    LeapAboveAI();
                    break;
                default:
                    FollowAI();
                    break;
            }
            SpriteDirection();
        }

        private void SpriteDirection()
        {
            Player player = Main.player[npc.target];
            if (npc.Center.X < player.Center.X)
                npc.spriteDirection = -1;
            else
                npc.spriteDirection = 1;
        }

        private void FollowAI()
        {
            Player player = Main.player[npc.target];
            npc.aiStyle = 103;
            MovementPhaseCounter++;
            if (MovementPhaseCounter == 5 * 60 && npc.life < npc.lifeMax * 2 / 3)
            {
                SandnadoSpawn();
                CrystalBurst(12);
            }
            if (MovementPhaseCounter > 5 * 60)
            {
                npc.velocity.Y = -12;
            }
            if (MovementPhaseCounter > 5 * 60 + 30)
            {
                MovementPhaseCounter = 0;
                MovementPhase = ChangeMovementPhase(MovementPhase);
            }
            if (npc.Center.X < player.Center.X - 800)
                npc.velocity.X = 8;
            if (npc.Center.X > player.Center.X + 800)
                npc.velocity.X = -8;
            if (npc.Center.Y > player.Center.Y + 300)
                npc.velocity.Y = -8;
            if (npc.Center.Y < player.Center.Y)
                CrystalRain();
            if (npc.Center.Y > player.Center.Y + 300)
                npc.velocity.Y -= .5f;
        }

        private void DashAI()
        {
            Player player = Main.player[npc.target];
            npc.aiStyle = -1;

            if (AttackDelay > 0)
            {
                AttackDelay--;
                npc.velocity.X *= .99f;
            }
            else if (MovementPhaseSteps % 2 == 0)
            {
                if(npc.Center.X > player.Center.X - 600)
                {
                    if (npc.velocity.X > -12)
                        npc.velocity.X -= .4f;
                    else
                        npc.velocity.X *= .98f;
                }
                else
                {
                    AttackDelay = 2 * 60;
                    CrystalBurst(20);
                    if(MovementPhaseSteps == 0 && npc.life < npc.lifeMax / 2)
                        SandnadoSpawn();
                    MovementPhaseSteps++;
                    npc.velocity = npc.DirectionTo(player.Center) * 25;
                    if (MovementPhaseSteps > 4)
                        MovementPhase = ChangeMovementPhase(MovementPhase);
                    if (npc.velocity.Y > 16)
                        npc.velocity.Y = 16;
                    else if (npc.velocity.Y < -16)
                        npc.velocity.Y = -16;
                }
            }
            else
            {
                if (npc.Center.X < player.Center.X + 600)
                {
                    if (npc.velocity.X < 12)
                        npc.velocity.X += .4f;
                    else
                        npc.velocity.X *= .98f;
                }
                else
                {
                    AttackDelay = 2 * 60;
                    CrystalBurst(20);
                    if (MovementPhaseSteps == 3 && npc.life < npc.lifeMax / 2)
                        SandnadoSpawn();
                    MovementPhaseSteps++;
                    npc.velocity = npc.DirectionTo(player.Center) * 25;
                    if (MovementPhaseSteps > 4)
                        MovementPhase = ChangeMovementPhase(MovementPhase);
                    if (npc.velocity.Y > 16)
                        npc.velocity.Y = 16;
                    else if(npc.velocity.Y < -16)
                        npc.velocity.Y = -16;
                }
            }

            if (npc.Center.Y > player.Center.Y + 300)
                npc.velocity.Y -= .5f;
            else
                npc.velocity.Y += .4f;

            if (npc.velocity.Y > 16)
                npc.velocity.Y = 16;
            else if (npc.velocity.Y < -16)
                npc.velocity.Y = -16;

            if (npc.Center.Y < player.Center.Y)
                CrystalRain();
        }

        private void SuperJumpAI()
        {
            Player player = Main.player[npc.target];
            npc.aiStyle = -1;

            if (AttackDelay > 0)
                AttackDelay--;

            if (npc.Center.X < player.Center.X - 80)
                npc.velocity.X += .1f;
            else if (npc.Center.X > player.Center.X + 80)
                npc.velocity.X -= .1f;
            else if (npc.Center.Y > player.Center.Y + 180 && AttackDelay == 0)
            {
                npc.velocity.Y = -20;
                AttackDelay = 2 * 60;
                if (MovementPhaseCounter == 0)
                {
                    npc.velocity.X *= .5f;
                    MovementPhaseCounter++;
                    MovementPhaseSteps++;

                    SandnadoSpawn();
                    CrystalBurst(12);
                    if (MovementPhaseSteps > 2)
                        MovementPhase = ChangeMovementPhase(MovementPhase);
                }
            }
            else if (MovementPhaseCounter > 0)
                MovementPhaseCounter = 0;
            else
                npc.velocity.X *= .9f;

            if (npc.Center.Y < player.Center.Y)
                CrystalRain();
            if (npc.Center.Y > player.Center.Y + 300)
                npc.velocity.Y -= .5f;
            if(npc.velocity.Y < 8)
                npc.velocity.Y += .4f;
        }

        private void LeapAboveAI()
        {
            Player player = Main.player[npc.target];
            npc.aiStyle = -1;
            if (MovementPhaseSteps % 2 == 0)
            {
                if (npc.Center.X > player.Center.X - 800)
                {
                    if (npc.velocity.X > -12)
                        npc.velocity.X -= .4f;
                    else
                        npc.velocity.X *= .98f;
                }
                else if(npc.Center.Y > player.Center.Y + 150)
                {
                    MovementPhaseSteps++;
                    npc.velocity.X = 28;
                    npc.velocity.Y = -24;
                    if (MovementPhaseSteps > 4)
                        MovementPhase = ChangeMovementPhase(MovementPhase);
                }
                else
                {
                    npc.velocity.X *= .98f;
                    if (npc.Center.Y > player.Center.Y + 200)
                        npc.velocity.Y -= .8f;
                    else
                        npc.velocity.Y += .4f;
                }
            }
            else
            {
                if (npc.Center.X < player.Center.X + 800)
                {
                    if (npc.velocity.X < 12)
                        npc.velocity.X += .4f;
                    else
                        npc.velocity.X *= .98f;
                }
                else if (npc.Center.Y > player.Center.Y + 150)
                {
                    MovementPhaseSteps++;
                    npc.velocity.X = -28;
                    npc.velocity.Y = -24;
                    if (MovementPhaseSteps > 4)
                        MovementPhase = ChangeMovementPhase(MovementPhase);
                }
                else
                {
                    npc.velocity.X *= .98f;
                    if (npc.Center.Y > player.Center.Y + 200)
                        npc.velocity.Y -= .8f;
                    else
                        npc.velocity.Y += .4f;
                }
            }
            if (npc.Center.Y > player.Center.Y + 300)
                npc.velocity.Y -= .5f;
            npc.velocity.Y += .4f;
            if (npc.Center.Y < player.Center.Y)
                CrystalRain();
            CrystalRain();
        }

        private int ChangeMovementPhase(int prevPhase)
        {
            MovementPhaseSteps = 0;
            MovementPhaseCounter = 0;
            AttackDelay = 0;
            if (prevPhase == 0)
                return Main.rand.Next(1, 4);
            return 0;
        }

        private void SandnadoSpawn()
        {
            Projectile.NewProjectile(npc.Center, new Vector2(0, -4), ModContent.ProjectileType<Sandnado>(), npc.damage / 4, 3f, npc.target, 0, 1);
        }

        private void CrystalRain()
        {
            AttackCounter++;
            if (AttackCounter > 15)
            {
                float theta = Main.rand.NextFloat() * (float)Math.PI;
                float mag = Main.rand.NextFloat() * 3 + 3;
                if (Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * -mag), ModContent.ProjectileType<SharkronCrystalShard>(), npc.damage / 4, 3f);
                if (npc.life < npc.lifeMax / 2)
                {
                    theta = Main.rand.NextFloat() * (float)Math.PI;
                    mag = Main.rand.NextFloat() * 3 + 3;
                    if (Main.netMode != 1)
                        Projectile.NewProjectile(npc.Center, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * -mag), ModContent.ProjectileType<SharkronCrystalShard>(), npc.damage / 4, 3f);
                }
                AttackCounter = 0;
            }
        }

        private void CrystalBurst(int amount)
        {
            if (amount < 1)
                amount = 1;
            for (int i = 0; i < amount; i++)
            {
                float theta = Main.rand.NextFloat() * (float)Math.PI;
                float mag = Main.rand.NextFloat() * 3 + 3;
                Projectile.NewProjectile(npc.Center, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * -mag), ModContent.ProjectileType<SharkronCrystalShard>(), npc.damage / 4, 3f);
            }
        }

        private void CheckBounce()
        {
            Player player = Main.player[npc.target];
            if (npc.position.Y > player.position.Y + 800)
                npc.velocity.Y = -16;
        }

        private float MoveToTarget(float mag)
        {
            float dist = Vector2.Distance(targetPos, npc.Center);

            if (dist != 0)
            {
                npc.velocity = npc.DirectionTo(targetPos) * mag;
            }
            return dist;
        }

        private void MakeDust()
        {
            if(Main.tile[(int)npc.Center.X / 16, (int)npc.Center.Y / 16].type != 0)
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<White>(), 0f, 0f);
        }

        public override void NPCLoot()
        {
            if (LaugicalityWorld.downedEtheria)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Etheramind>(), 1);

            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AncientShard>(), Main.rand.Next(1, 3));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Crystilla>(), Main.rand.Next(4, 11));

                int ran = Main.rand.Next(1, 8);
                if (ran == 1) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SandstorminaBottle, 1);
                if (ran == 2) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FlyingCarpet, 1);
                if (ran == 3) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BandofRegeneration, 1);
                if (ran == 4) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicMirror, 1);
                if (ran == 5) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CloudinaBottle, 1);
                if (ran == 6) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HermesBoots, 1);
                if (ran == 7) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EnchantedBoomerang, 1);
            }

            if (Main.expertMode)
                npc.DropBossBags();
            if(Main.rand.Next(10) == 0)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DuneSharkronTrophy>(), 1);

            LaugicalityWorld.downedDuneSharkron = true;
        }


        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
        }
    }
}
*/