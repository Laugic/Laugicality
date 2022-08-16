using System;
using System.Collections.Generic;
using Laugicality.Dusts;
using Laugicality.Items.Equipables;
using Laugicality.Items.Loot;
using Laugicality.Items.Placeable;
using Laugicality.Items.Weapons.Range;
using Laugicality.NPCs.Obsidium;
using Laugicality.Particles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace Laugicality.NPCs.PreTrio
{
    [AutoloadBossHead]
    public class Ragnar : ModNPC
    {
        private int AIPhase { get; set; }
        private int PrevAIPhase { get; set; }
        private int Counter { get; set; }
        private int Frame { get; set; }
        private Vector2 TargetPos;
        double rotSpeed = .1;

        private bool Angry { get; set; }
        public List<Particle> Particles;
        public List<Particle> BkgParticles;
        public static float HEART_HP = .2f;
        Texture2D Heart;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(npc.type);
            DisplayName.SetDefault("Ragnar");
        }
        public override void SetDefaults()
        {
            npc.width = 86;
            npc.height = 132;
            npc.damage = 35;
            npc.defense = 16;
            npc.aiStyle = 0;
            npc.lifeMax = 5000;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[24] = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Ragnar");
            bossBag = ModContent.ItemType<RagnarTreasureBag>();
            PrevAIPhase = AIPhase = 0;
            Counter = 0;
            TargetPos = npc.Center;
            Angry = false;
            npc.ai[0] = -1;
            Frame = 0;
            Particles = new List<Particle>();
            BkgParticles = new List<Particle>();
            npc.velocity = Vector2.Zero;
            if (!Main.dedServ)
            {
                Heart = mod.GetTexture(this.GetType().GetRootPath() + "/RagnarHeart");
            }

        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 10000 + numPlayers * 2000;
            npc.damage = 70;
        }

        public override void AI()
        {
            HealthCheck();
            PickAI();
            Effects();
            Counter++;
        }

        #region behavior AIs
        private void PickAI()
        {
            switch(AIPhase)
            {
                case 1:
                    FireballWave();
                    break;
                case 2:
                    FireballToss();
                    break;
                case 3:
                    FireballSpiral();
                    break;
                default:
                    Chase();
                    break;
            }
        }

        private void FireballSpiral()
        {
            Slow();
            if (Counter > 1 * 60 && Counter <= 5 * 60)
            {
                float mag = 10;
                double theta = Counter / 30.0;
                if (Counter % 10 == 0)
                {
                    int proj = Projectile.NewProjectile(npc.Center, new Vector2(mag * (float)Math.Cos(theta), mag * (float)Math.Sin(theta)), ModContent.ProjectileType<RagnarFireball>(), npc.damage / 2, 4f);
                    Main.projectile[proj].ai[0] = 3;
                    proj = Projectile.NewProjectile(npc.Center, new Vector2(mag * (float)Math.Cos(theta + Math.PI), mag * (float)Math.Sin(theta + Math.PI)), ModContent.ProjectileType<RagnarFireball>(), npc.damage / 2, 4f);
                    Main.projectile[proj].ai[0] = 3;
                }
            }
            if (Counter >= 6 * 60)
                ResetAttack();
        }

        private void FireballToss()
        {
            Slow();
            if (Counter > 1 * 60 && Counter <= 4 * 60)
            {
                int curOff = (Counter - 1 * 60 - (Counter - 1 * 60) % 15) / 15;
                
                if (Counter % 15 == 0)
                {
                    int proj = Projectile.NewProjectile(npc.Center, new Vector2(2 * curOff, -4), ModContent.ProjectileType<RagnarFireball>(), npc.damage / 2, 4f);
                    Main.projectile[proj].ai[0] = 2;
                    Main.projectile[proj].ai[1] = npc.whoAmI;
                    proj = Projectile.NewProjectile(npc.Center, new Vector2(-2 * curOff, -4), ModContent.ProjectileType<RagnarFireball>(), npc.damage / 2, 4f);
                    Main.projectile[proj].ai[0] = 2;
                    Main.projectile[proj].ai[1] = npc.whoAmI;
                }
            }
            if (Counter >= 5 * 60)
                ResetAttack();
        }

        //TODO: Make pick random instead of one attack.
        private void PickRandomAttack()
        {
            Counter = 0;
            AIPhase = 1;
        }

        private void ResetAttack()
        {
            Counter = 0;
            AIPhase = 0;
        }

        private void Chase()
        {
            TargetPos = Main.player[npc.target].Center;
            //MoveTowards(TargetPos, 6 + (Main.expertMode ? 2 : 0));//MoveTowards(TargetPos, 4 + (Main.expertMode?2:0));
            MoveTo(TargetPos, 6 + (Main.expertMode ? 2 : 0), 1.1f);
            if (Counter >= 6 * 60)
                PickRandomAttack();
        }

        private void FireballWave()
        {
            int xOffset = 60;
            int yOffset = 500;
            if(Counter < 2)
            {
                TargetPos = Main.player[npc.target].Center;
                TargetPos.Y -= 180;
            }
            if (Counter < 1 * 60)
                MoveTowards(TargetPos, 8 + (Main.expertMode ? 4 : 0));
            else
                Slow();
            if (Counter > 3 * 60)
            {
                int curOff = (Counter - 3 * 60 - (Counter - 3 * 60) % 15) / 15;
                if(Counter % 3 == 0)
                {
                    BkgParticles.Add(new Particle(mod.GetTexture("Particles/Flame"), new Vector2(npc.Center.X + xOffset * curOff - 20 + Main.rand.Next(40), npc.Center.Y + yOffset - 8 + Main.rand.Next(16)), Vector2.Zero, 7));
                    BkgParticles.Add(new Particle(mod.GetTexture("Particles/Flame"), new Vector2(npc.Center.X - xOffset * curOff - 20 + Main.rand.Next(40), npc.Center.Y + yOffset - 8 + Main.rand.Next(16)), Vector2.Zero, 7));
                }
                //Dust.NewDust(new Vector2(npc.Center.X + xOffset * curOff, npc.Center.Y + yOffset), 40, 10, ModContent.DustType<Magma>(), -2 + Main.rand.Next(5), -2 + Main.rand.Next(5));
                //Dust.NewDust(new Vector2(npc.Center.X - xOffset * curOff, npc.Center.Y + yOffset), 40, 10, ModContent.DustType<Magma>(), -2 + Main.rand.Next(5), -2 + Main.rand.Next(5));
                if (Counter % 15 == 0)
                {
                    int proj = Projectile.NewProjectile(new Vector2(npc.Center.X - xOffset * curOff, npc.Center.Y + yOffset), new Vector2(0, -18), ModContent.ProjectileType<RagnarFireball>(), npc.damage / 2, 4f);
                    Main.projectile[proj].ai[0] = 1;
                    proj = Projectile.NewProjectile(new Vector2(npc.Center.X + xOffset * curOff, npc.Center.Y + yOffset), new Vector2(0, -18), ModContent.ProjectileType<RagnarFireball>(), npc.damage / 2, 4f);
                    Main.projectile[proj].ai[0] = 1;
                }
            }
            if (Counter >= 8 * 60)
                ResetAttack();
        }

        #endregion


        private void Effects()
        {
            //Particles.Add(new Particle(mod.GetTexture("Particles/Spark"), npc.Center, Vector2.Zero, 8));
            AddParticles();
            ParticleManager.UpdateParticles(ref BkgParticles);
            ParticleManager.UpdateParticles(ref Particles);
        }

        private void AddParticles()
        {
            //Background
            if (Counter % 15 == 0)
                BkgParticles.Add(new Particle(mod.GetTexture("Particles/Flame"), npc.Center + new Vector2(-npc.width / 4 + Main.rand.Next(npc.width / 2), 20 - npc.height / 4 + Main.rand.Next(npc.height / 3)), Vector2.Zero, 7));
            if (Counter % 10 == 0)
            {
                BkgParticles.Add(new Particle(mod.GetTexture("Particles/Blaze"), npc.Center + new Vector2(12 + npc.direction * 4 - 8 + Main.rand.Next(16), 20 + Main.rand.Next(16)), new Vector2(0, -1 - (float)Main.rand.NextDouble()), 6, 1, (float)(Main.rand.NextDouble() * 2 * Math.PI), .02f * (Main.rand.NextBool() ? 1 : -1))); BkgParticles.Add(new Particle(mod.GetTexture("Particles/Blaze"), npc.Center + new Vector2(-30 + Main.rand.Next(60) + npc.direction * 4, 20 - npc.height / 4 + Main.rand.Next(npc.height / 3)), new Vector2(0, -1 - (float)Main.rand.NextDouble()), 6, 1, (float)(Main.rand.NextDouble() * 2 * Math.PI), .02f * (Main.rand.NextBool() ? 1 : -1)));
                BkgParticles.Add(new Particle(mod.GetTexture("Particles/Blaze"), npc.Center + new Vector2(12 + npc.direction * 4 - 8 + Main.rand.Next(16), 20 + Main.rand.Next(16)), new Vector2(-1 + 2 * (float)Main.rand.NextDouble(), -1 + 2 * (float)Main.rand.NextDouble()), 6, .95f, (float)(Main.rand.NextDouble() * 2 * Math.PI), .02f * (Main.rand.NextBool() ? 1 : -1)));
            }
            if (Counter % 5 == 0)
                BkgParticles.Add(new Particle(mod.GetTexture("Particles/Spark"), npc.Center + new Vector2(12 + npc.direction * 4 - 8 + Main.rand.Next(16), 20 + Main.rand.Next(16)), new Vector2((float)(-1 + 2 * Main.rand.NextDouble()) / 4f, -1 - (float)Main.rand.NextDouble()), 8));

            //Foreground
            if (Counter % 25 == 0)
                Particles.Add(new Particle(mod.GetTexture("Particles/Flame"), npc.Center + new Vector2(-npc.width / 2 + Main.rand.Next(npc.width), 20 - npc.height / 4 + Main.rand.Next(npc.height / 2)), Vector2.Zero, 7));
        }

        private void HealthCheck()
        {
            if(npc.life <= (int)(HEART_HP * npc.lifeMax) && Main.expertMode)
            {
                if (music != mod.GetSoundSlot(SoundType.Music, "Sounds/Music/RagnarHeart"))
                    HeartChange();
            }
        }

        private void HeartChange()
        {
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/RagnarHeart");
        }

        private void MoveTowards(Vector2 targetPos, float maxVel = 20)
        {
            Vector2 newVel = Vector2.Normalize(targetPos - npc.Center);
            newVel *= Math.Min(Math.Min(Vector2.Distance(npc.Center, targetPos) / 4, npc.velocity.Length() + .6f), maxVel);
            npc.velocity = newVel;
        }

        private void MoveTo(Vector2 targetVector, float maxVel, float accel)
        {
            var tarRot = targetVector.ToRotation();
            var curRot = npc.velocity.ToRotation();
            var rotGoal = tarRot - curRot;

            if (rotGoal > Math.PI)
                rotGoal -= 2 * (float)Math.PI;
            if (rotGoal < -Math.PI)
                rotGoal += 2 * (float)Math.PI;

            if (rotGoal > rotSpeed)
                npc.velocity = npc.velocity.RotatedBy(rotSpeed) / accel;
            if (rotGoal < -rotSpeed)
                npc.velocity = npc.velocity.RotatedBy(-rotSpeed) / accel;

            if (npc.velocity.Length() < maxVel)
            {
                if (npc.velocity.Length() < maxVel / 10)
                    npc.velocity.Y = maxVel / 2;
                npc.velocity *= accel;
            }
        }

        private void Slow()
        {
            npc.velocity *= .98f;
        }


        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            ParticleManager.DrawParticles(spriteBatch, Color.White, ref BkgParticles);

            //Draw Heart
            Rectangle rect = new Rectangle(0, ((int)Math.Floor(Counter / 4.0) % 8) * Heart.Height / 8, Heart.Width, Heart.Height / 8);
            spriteBatch.Draw(Heart, npc.Center - Main.screenPosition + new Vector2( -28 + npc.direction * 4, -10), rect, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);

            return (npc.life > (int)(HEART_HP * npc.lifeMax) && Main.expertMode);
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            base.PostDraw(spriteBatch, drawColor);
            ParticleManager.DrawParticles(spriteBatch, Color.White, ref Particles);
        }



        public override void NPCLoot()
        {
            if (LaugicalityWorld.downedEtheria)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<MoltenEtheria>(), 1);
            }

            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DarkShard>(), Main.rand.Next(1, 3));
                int obsidiumItem = 0;
                int rand = Main.rand.Next(7);
                switch (rand)
                {
                    case 0:
                        obsidiumItem = ItemID.LavaCharm;
                        break;
                    case 1:
                        obsidiumItem = ModContent.ItemType<ObsidiumLily>();
                        break;
                    case 2:
                        obsidiumItem = ModContent.ItemType<FireDust>();
                        break;
                    case 3:
                        obsidiumItem = ModContent.ItemType<Eruption>();
                        break;
                    case 4:
                        obsidiumItem = ModContent.ItemType<CrystalizedMagma>();
                        break;
                    case 5:
                        obsidiumItem = ModContent.ItemType<Ragnashia>();
                        break;
                    default:
                        obsidiumItem = ModContent.ItemType<MagmaHeart>();
                        break;
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, obsidiumItem, 1);
                if(Main.rand.Next(4) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BlackIce>(), 1);
                if (Main.rand.Next(10) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RagnarTrophy>(), 1);
            }
            if (!LaugicalityWorld.downedRagnar)
                Main.NewText("Fury runs through the Obsidium Caverns.", 250, 150, 50);
            LaugicalityWorld.downedRagnar = true;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
        }


        public List<int> Fireballs { get; set; }
    }
}