using System;
using System.Collections.Generic;
using Laugicality.Buffs;
using Laugicality.Dusts;
using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Laugicality.Items.Placeable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace Laugicality.NPCs.PreTrio
{
    [AutoloadBossHead]
    public class Hypothema : ModNPC
    {
        #region Initializations
        public int despawn = 0;
        static int NPC_WIDTH = 194, CLOUD_HEIGHT = 66,
            INITIALIZE = 0, TRANSITION = 1, FOLLOW = 2, STEWARD = 3, SLOW = 4, SNOWBOMB = 5, SHOTGUN = 6, SMASH = 7, UPSHOOT = 8, DASH = 9, HATTHROW = 10, GUNTWIRL = 11, CLOUDS = 12;
        private List<int> Attacks;
        private List<int> NextAttacks;
        public int AIPhase { get; set; } = 0;
        public int HealthPhase { get; set; } = 1;
        private int PrevAIPhase { get; set; }
        private int Counter { get; set; }
        private int Counter2 { get; set; }
        private bool AttackBool { get; set; }
        private int CloudFrame { get; set; }
        private float CloudAlpha { get; set; }
        private float Speed { get; set; }
        private Vector2 TargetPos;
        private bool Angry { get; set; }
        private bool FrostLegion { get; set; }
        private bool FrostMoon { get; set; }
        private int Tracker { get; set; }

        public Texture2D AnimFrames;
        public Texture2D CloudFront;
        public Texture2D CloudBack;
        public Texture2D GunSpin;
        int FrameDelay { get; set; } = 0;

        public int AttackCounter { get; set; } = 0;
        #endregion

        #region MainMethods
        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(npc.type);
            DisplayName.SetDefault("Hypothema");
        }

        public override void SetDefaults()
        {
            npc.width = 84;
            npc.height = 140;
            npc.damage = 40;
            npc.defense = 8;
            npc.aiStyle = 0;
            npc.lifeMax = 4000;
            npc.HitSound = SoundID.NPCHit5;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Hypothema");
            bossBag = ModContent.ItemType<HypothemaTreasureBag>();
            PrevAIPhase = AIPhase = 0;
            HealthPhase = 1;
            FrameDelay = 0;
            CloudFrame = 0;
            CloudAlpha = 0;
            Counter = Counter2 = 0;
            Tracker = 0;
            Speed = 2;
            AttackBool = false;
            Attacks = new List<int> { STEWARD, SMASH, DASH, FOLLOW, CLOUDS };
            NextAttacks = new List<int>();
            FrostMoon = Main.snowMoon;
            FrostLegion = Main.invasionType == 2;
            if (FrostLegion)
                npc.lifeMax += 5000;
            if (FrostMoon)
                npc.lifeMax += 8000;
            if (!Main.dedServ)
            {
                AnimFrames = mod.GetTexture(this.GetType().GetRootPath() + "/Hypothema_Frames");
                CloudFront = mod.GetTexture(this.GetType().GetRootPath() + "/HypothemaCloud");
                CloudBack = mod.GetTexture(this.GetType().GetRootPath() + "/HypothemaCloudOutline");
                GunSpin = mod.GetTexture(this.GetType().GetRootPath() + "/GunSpin");
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax += numPlayers * 5000;
        }

        public override void AI()
        {
            HealthEffects();
            Effects();
            SpeedCheck();
            PickAI();
        }

        private void PickAI()
        {
            switch (AIPhase)
            {
                case 0:
                    InitializeAI();
                    break;
                case 1:
                    TransitionAI();
                    break;
                case 2:
                    FollowAI();
                    break;
                case 3:
                    StewardAI();
                    break;
                case 4:
                    Slow();
                    break;
                case 5:
                    SnowbombAI();
                    break;
                case 6:
                    ShotgunAI();
                    break;
                case 7:
                    SmashAI();
                    break;
                case 8:
                    UpshootAI();
                    break;
                case 9:
                    DashAI();
                    break;
                case 10:
                    HatThrowAI();
                    break;
                case 11:
                    GunTwirlAI();
                    break;
                case 12:
                    SpawnClouds();
                    Transition();
                    break;
                default:
                    DespawnAI();
                    break;
            }
        }
        #endregion

        #region AttackAIs
        private void GunTwirlAI()
        {
            Slow();
            Counter++;
            if (Counter > 4 && Counter < 2 * 60)
            {
                AttackBool = true;
                if (Counter % 2 == 0 && Main.netMode != 1)
                {
                    var theta = Main.rand.NextDouble() * 2 * Math.PI;
                    float mag = 9 + Main.rand.NextFloat() * 3;
                    var newPos = npc.Center;
                    newPos.X -= (Counter % 4 == 0 ? -1 : 1) * 66 * npc.spriteDirection - 50 * (float)Math.Cos(theta);
                    newPos.Y -= 36 - 50 * (float)Math.Sin(theta);
                    Projectile.NewProjectile(newPos, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag), ModContent.ProjectileType<Snowball>(), npc.damage / 4, 7);
                }
            }
            else
            {
                Counter2++;
                AttackBool = false;
            }
            if (Counter > 2 * 60 + 12)
                Transition();
        }

        private void HatThrowAI()
        {
            Slow();
            Counter++;
            if(Counter == 3 * 6)
            {
                var newPos = npc.Center;
                newPos.X -= 80 * npc.spriteDirection;
                Counter2 = Projectile.NewProjectile(newPos, new Vector2(0, 0), ModContent.ProjectileType<HatSpin>(), npc.damage / 4, 6f, npc.target, 0, npc.whoAmI);
            }
            if(Counter > 3 * 60 && (Main.projectile[Counter2].type != ModContent.ProjectileType<HatSpin>() || !Main.projectile[Counter2].active))
                Transition();
        }

        private void DashAI()
        {
            Counter++;
            if (Counter == 1)
                AttackBool = Main.rand.NextBool();
            if (Counter < 90)
            {
                MoveTowardsAtSpeed(TargetPos, Speed * 2);
                TargetPos = Main.player[npc.target].Center;
                TargetPos.X += 600 * (AttackBool ? 1 : -1);
            }
            else if (Counter < 105)
                Slow();
            else if (Counter == 105)
            {
                AttackBool = (npc.Center.X < Main.player[npc.target].Center.X);
                npc.velocity.Y = 0;
            }
            if(Counter >= 105)
                npc.velocity.X = (AttackBool ? Speed * 4 : -Speed * 4);
            if (Counter >= 105 && Main.rand.Next(4) == 0 && Main.netMode != 1)
            {
                var theta = Main.rand.NextDouble() * Math.PI + Math.PI;
                float mag = 6 + Main.rand.NextFloat() * 3;
                Projectile.NewProjectile(npc.Center, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag), ModContent.ProjectileType<Snowball>(), npc.damage / 4, 7);
            }
            if (Counter > 3 * 60)
                Transition();
        }

        private void UpshootAI()
        {
            TargetPos = Main.player[npc.target].Center;
            TargetPos.Y -= 200;
            MoveTowardsAtSpeed(TargetPos, Speed);
            Counter++;
            if (Counter % 3 == 0)
            {
                Counter2++;
                switch(Counter2 % 4)
                {
                    case 1:
                        ShootUp(-npc.spriteDirection * 28);
                        break;
                    case 2:
                        break;
                    case 3:
                        ShootUp(npc.spriteDirection * 28);
                        break;
                    default:
                        break;
                }
            }
            if (Counter > 3 * 60)
                Transition();
        }

        private void ShootUp(float xShift)
        {
            var theta = Math.PI * 1.333 + Main.rand.NextDouble() * Math.PI / 3;
            float mag = 6 + Main.rand.NextFloat() * 3;
            var newPos = npc.Center;
            newPos.Y -= 110;
            newPos.X += xShift;
            Main.PlaySound(2, npc.Center, 11);
            Projectile.NewProjectile(newPos, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag), ModContent.ProjectileType<Snowball>(), npc.damage / 4, 7);
        }

        private void SmashAI()
        {
            Counter++;
            if(Counter > 2 * 60)
            {
                CloudAlpha += .04f;
                if (CloudAlpha >= 1)
                {
                    CloudAlpha = 1;
                    bool floored = false;
                    Counter2++;
                    if (Counter2 == 1)
                        npc.velocity.Y = .5f;
                    if (npc.velocity.Y > 0)
                        npc.velocity.Y = Math.Min(npc.velocity.Y + .5f, 16);
                    npc.noTileCollide = false;
                    npc.collideX = false;
                    npc.collideY = true;
                    if (npc.velocity.Y == 0)
                        floored = true;

                    npc.velocity.X = 0;

                    if (floored)
                    {
                        if(!AttackBool)
                        {
                            AttackBool = true;
                            for (int k = 0; k < (Main.expertMode ? 20 : 10); k++)
                            {
                                var theta = Main.rand.NextDouble() * Math.PI;
                                float mag = -5 - Main.rand.NextFloat() * 3;
                                var newPos = npc.Center;
                                newPos.Y += npc.height / 2 - 8;
                                Projectile.NewProjectile(newPos, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag), ModContent.ProjectileType<Snowball>(), npc.damage / 4, 7);
                            }
                        }
                        npc.velocity.Y = 0;
                    }
                }
                else
                    Slow();
            }
            else
            {
                TargetPos = Main.player[npc.target].Center;
                TargetPos.Y -= 400;
                MoveTowardsAtSpeed(TargetPos, Speed * 2);
            }
            if (Counter2 > 2 * 60 || Counter > 5 * 60)
            {
                Transition();
                npc.noTileCollide = true;
                npc.collideX = false;
                npc.collideY = false;
            }
        }

        private void ShotgunAI()
        {
            TargetPos = Main.player[npc.target].Center;
            MoveTowardsAtSpeed(TargetPos, Speed);
            Counter++;
            if(Counter == 45)
            {
                var newPos = npc.Center;
                newPos.X -= 80 * npc.spriteDirection;
                Main.PlaySound(2, npc.Center, 36);
                Projectile.NewProjectile(newPos, new Vector2(6 * npc.spriteDirection, -6), ModContent.ProjectileType<ShotgunYeet>(), npc.damage / 4, 8f, 0, npc.whoAmI);
                for (int i = 0; i < 12; i++)
                {
                    var theta = Math.PI * .67 + (Main.rand.NextDouble() * Math.PI / 2);
                    float mag = 8 + Main.rand.NextFloat() * 6;
                    Projectile.NewProjectile(newPos, new Vector2((float)Math.Cos(theta) * mag * npc.spriteDirection, (float)Math.Sin(theta) * mag / 2), ModContent.ProjectileType<Snowball>(), npc.damage / 4, 8f, 0, npc.whoAmI);
                }
            }
            if (Counter > 60)
                Transition();
        }

        private void SnowbombAI()
        {
            TargetPos = Main.player[npc.target].Center;
            TargetPos.Y -= 200;
            MoveTowardsAtSpeed(TargetPos, Speed);
            Counter++; 
            if (Counter == 45)
            {
                var newPos = npc.Center;
                newPos.Y -= 20;
                newPos.X -= 40;
                Projectile.NewProjectile(newPos, new Vector2(-2+Main.rand.NextFloat() * 4, -1-Main.rand.NextFloat()), ModContent.ProjectileType<Snowbomb>(), npc.damage / 4, 8f, 0, npc.whoAmI);
                newPos.X += 80;
                Projectile.NewProjectile(newPos, new Vector2(-2 + Main.rand.NextFloat() * 4, -1 - Main.rand.NextFloat()), ModContent.ProjectileType<Snowbomb>(), npc.damage / 4, 8f, 0, npc.whoAmI);
            }
            if (Counter > 72)
                Transition();
        }

        private void StewardAI()
        {
            Counter++;
            Slow();
            var dist = 120;
            var newPos = npc.Center;
            newPos.Y -= dist;

            if (Counter == 15)
            {
                Tracker = Projectile.NewProjectile(newPos, new Vector2(), ModContent.ProjectileType<Steward>(), npc.damage / 4, 8f, 0, npc.whoAmI);
                Main.projectile[Tracker].scale = 1f / (2 * 60f);
            }
            if(Counter > 15)
                Main.projectile[Tracker].scale += 1f / (2 * 60f);
            if (Counter < 1 * 60 + 30)
            {
                var theta = Math.PI * 2 * Main.rand.NextDouble();
                var dustShift = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                int dust = Dust.NewDust(newPos + dustShift * dist, 0, 0, ModContent.DustType<SnowAccumulateDust>(), 0, 0, 0, default, 1);
                Main.dust[dust].velocity = new Vector2(dustShift.X * -2, dustShift.Y * -2);
            }
            if (Counter > 2 * 60)
            {
                Main.projectile[Tracker].scale = 1;
                Transition();
            }
        }
        private void Transition()
        {
            PrevAIPhase = AIPhase;
            AIPhase = TRANSITION;
            Counter = Counter2 = 0;
            AttackBool = false;
        }
        #endregion

        #region MovementAIs
        private void SpeedCheck()
        {
            Speed = 2 + (Main.expertMode?1:0) + (Angry?1:0) + (npc.life < npc.lifeMax * 3 / 4?1:0) + (Main.player[npc.target].ZoneSnow?0:2);
        }

        private void FollowAI()
        {
            Counter++;
            TargetPos = Main.player[npc.target].Center;
            MoveTowardsAtSpeed(TargetPos, Speed);
            if (Counter > 2 * 60)
                Transition();
        }

        private void TransitionAI()
        {
            TargetPos = Main.player[npc.target].Center;
            if(Vector2.Distance(npc.Center, Main.player[npc.target].Center) > 300)
                TargetPos.Y -= 200;
            MoveTowardsAtSpeed(TargetPos, Speed);
            Counter++;
            if (CloudAlpha > 0)
                CloudAlpha = Math.Max(0, CloudAlpha - .04f);
            if ((Counter > 2 * 60 && Main.rand.Next(60) == 0) || Counter > 4 * 60)
            {
                Counter = 0;
                CloudAlpha = 0;
                FrameDelay = 0;
                AIPhase = GetNextAI();
            }
        }

        private int GetNextAI()
        {
            int nextAttack;
            if(Vector2.Distance(npc.Center, Main.player[npc.target].Center) > 1200)
                return STEWARD;
            if (NextAttacks.Count == 0)
            {
                for (int i = 0; i < Attacks.Count; i++)
                    NextAttacks.Add(Attacks[i]);
                if(Angry)
                {
                    NextAttacks.Add(UPSHOOT);
                    NextAttacks.Add(GUNTWIRL);
                }
                else
                {
                    NextAttacks.Add(SNOWBOMB);
                    NextAttacks.Add(SHOTGUN);
                    NextAttacks.Add(HATTHROW);
                }
            }
            int pos = Main.rand.Next(NextAttacks.Count);
            if(NextAttacks[pos] == PrevAIPhase && NextAttacks.Count > 1)
            {
                pos++;
                if (pos >= NextAttacks.Count)
                    pos = 0;
            }
            if (NextAttacks.Contains(CLOUDS))
                pos = NextAttacks.IndexOf(CLOUDS);
            if(NextAttacks.Count > 0)
            {
                nextAttack = NextAttacks[pos];
                NextAttacks.RemoveAt(pos);
                return nextAttack;
            }
            return STEWARD;
        }

        private void SpawnClouds()
        {
            if(Main.netMode != 1)
            {
                Projectile.NewProjectile(new Vector2(npc.position.X - 2000, npc.Center.Y + 80), new Vector2(0, -.5f), ModContent.ProjectileType<SnowCloud>(), npc.damage / 4, 8, npc.target, 0, npc.whoAmI);
                Projectile.NewProjectile(new Vector2(npc.position.X + 2000, npc.Center.Y + 80), new Vector2(0, -.5f), ModContent.ProjectileType<SnowCloud>(), npc.damage / 4, 8, npc.target, 0, npc.whoAmI);
                Projectile.NewProjectile(new Vector2(npc.position.X, npc.Center.Y + 80), new Vector2(0, -.5f), ModContent.ProjectileType<SnowCloud>(), npc.damage / 4, 8, npc.target, 0, npc.whoAmI);
            }
        }

        private void MoveTowardsAtSpeed(Vector2 targetPos, float mag)
        {
            Vector2 newVel = Vector2.Normalize(targetPos - npc.Center);
            newVel *= Math.Min(Vector2.Distance(npc.Center, targetPos) / 4, Math.Min(mag, npc.velocity.Length() + .6f));
            npc.velocity = newVel;
        }

        private void Slow()
        {
            npc.velocity *= .95f;
        }
        #endregion

        #region MiscMethods
        private void InitializeAI()
        {
            npc.TargetClosest(false);
            TargetPos = Main.player[npc.target].Center;
            AIPhase = FOLLOW;
            Counter = 0;
        }

        private void HealthEffects()
        {
            if (npc.life < npc.lifeMax / 2 && HealthPhase == 1)
            {
                FrameDelay = 0;
                HealthPhase = 0;
                AIPhase = SLOW;
                Counter = 0;
                Angry = true;
                npc.ai[0] = 1;
                NextAttacks.Clear();
            }
        }

        private void Effects()
        {
            if (npc.velocity.X < 0)
                npc.spriteDirection = 1;
            if (npc.velocity.X > 0)
                npc.spriteDirection = -1;
            if(npc.velocity.X == 0)
                npc.spriteDirection *= -1;
            npc.netUpdate = true;

            DespawnAI();
        }

        private void DespawnAI()
        {
            if (Main.player[npc.target].statLife < 1 || Vector2.Distance(Main.player[npc.target].Center, npc.Center) > 4000)
            {
                npc.TargetClosest(true);
                if (Main.player[npc.target].statLife < 1 || Vector2.Distance(Main.player[npc.target].Center, npc.Center) > 4000)
                {
                    if (despawn == 0)
                        despawn++;
                }
                else
                    despawn = 0;
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

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            if (LaugicalityWorld.downedEtheria)
                target.AddBuff(ModContent.BuffType<Frostbite>(), 4 * 60, true);
            if (Main.expertMode)
            {
                target.AddBuff(BuffID.Frostburn, 2 * 60 + Main.rand.Next(60), true);
                target.AddBuff(BuffID.Chilled, 60, true);
            }
        }
        #endregion

        #region Frames
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            GetFrame();
            var spriteFX = SpriteEffects.None;
            if (npc.spriteDirection == -1)
                spriteFX = SpriteEffects.FlipHorizontally;
            Color color = Lighting.GetColor((int)((double)npc.position.X + (double)npc.width * 0.5) / 16, (int)(((double)npc.position.Y + (double)npc.height * 0.5) / 16.0));
            Vector2 npcDimensions = new Vector2((float)(Main.npcTexture[npc.type].Width / 2), (float)(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2));
            Vector2 drawPos = new Vector2(npc.position.X - Main.screenPosition.X + (float)(npc.width / 2) - (float)NPC_WIDTH * npc.scale / 2f + npcDimensions.X * npc.scale, npc.position.Y - Main.screenPosition.Y + (float)npc.height - (float)NPC_WIDTH * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + npcDimensions.Y * npc.scale + npc.gfxOffY);

            DrawCloud(spriteBatch, color, npcDimensions, drawPos, true);
            spriteBatch.Draw(AnimFrames, drawPos, new Microsoft.Xna.Framework.Rectangle?(npc.frame), npc.GetAlpha(color), npc.rotation, npcDimensions, npc.scale, spriteFX, 0f);
            DrawCloud(spriteBatch, color, npcDimensions, drawPos, false);
            if (AIPhase == GUNTWIRL && AttackBool)
                DrawGunSpin(spriteBatch, color, npcDimensions, drawPos);
            return false;
        }

        private void DrawGunSpin(SpriteBatch spriteBatch, Color color, Vector2 dimensions, Vector2 drawPos)
        {
            int frameCount = 4;
            float animRate = 3;
            Rectangle rect = new Rectangle(0, 112 * (int)Math.Min(Math.Floor(Counter % (frameCount * animRate) / animRate), frameCount - 1), 110, 112);
            var spriteFX = SpriteEffects.None;
            var texture = GunSpin;
            drawPos.Y += 24;
            drawPos.X -= 20;
            spriteBatch.Draw(texture, drawPos, rect, color, npc.rotation, dimensions, npc.scale, spriteFX, 0f);
            drawPos.X += 120;
            spriteFX = SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(texture, drawPos, rect, color, npc.rotation, dimensions, npc.scale, spriteFX, 0f);
        }

        private void DrawCloud(SpriteBatch spriteBatch, Color color, Vector2 dimensions, Vector2 drawPos, bool back)
        {
            int frameCount = 8;
            float animRate = 16;
            CloudFrame++;
            while (CloudFrame >= frameCount * animRate)
                CloudFrame -= (int)(frameCount * animRate);
            Rectangle rect = new Rectangle(0, CLOUD_HEIGHT * (int)Math.Min(Math.Floor(CloudFrame / animRate), frameCount - 1), NPC_WIDTH, CLOUD_HEIGHT);
            var spriteFX = SpriteEffects.None;
            if (npc.spriteDirection == -1)
                spriteFX = SpriteEffects.FlipHorizontally;
            drawPos.X += 0;
            drawPos.Y += 138;
            var texture = CloudFront;
            if (back)
                texture = CloudBack;
            var newColor = new Color(1 - CloudAlpha, 1 - CloudAlpha, 1 - CloudAlpha, 1 - CloudAlpha);
            spriteBatch.Draw(texture, drawPos, rect, newColor, npc.rotation, dimensions, npc.scale, spriteFX, 0f);
        }

        private void GetFrame()
        {
            npc.frame.Width = NPC_WIDTH;
            npc.frame.Height = NPC_WIDTH;
            npc.frame.X = 0;
            npc.frame.Y = 0;

            FrameDelay++;

            if (HealthPhase == 0)
            {
                int frameCount = 20;
                float animRate = 6;

                npc.frame.X = NPC_WIDTH * ((FrameDelay > frameCount * animRate / 2) ? 2 : 1);
                npc.frame.Y = NPC_WIDTH * (int)Math.Min(Math.Floor((FrameDelay > frameCount * animRate / 2) ? (FrameDelay - frameCount * animRate / 2) / animRate : FrameDelay / animRate), 9);

                if (FrameDelay > frameCount * animRate)
                {
                    FrameDelay -= (int)(frameCount * animRate);
                    HealthPhase = 2;
                    Transition();
                }
                return;
            }

            if (AttackFrames())
                return;

            if (HealthPhase == 1)
            {
                int frameCount = 10;
                float animRate = 6;
                while (FrameDelay > frameCount * animRate)
                    FrameDelay -= (int)(frameCount * animRate);

                npc.frame.X = 0;
                npc.frame.Y = NPC_WIDTH * (int)Math.Min(Math.Floor(FrameDelay / animRate), frameCount - 1);
            }

            if (HealthPhase == 2)
            {
                int frameCount = 10;
                float animRate = 6;
                while (FrameDelay > frameCount * animRate)
                    FrameDelay -= (int)(frameCount * animRate);

                npc.frame.X = NPC_WIDTH * 3;
                npc.frame.Y = NPC_WIDTH * (int)Math.Min(Math.Floor(FrameDelay / animRate), frameCount - 1);
            }
        }

        private bool AttackFrames()
        {
            if (AIPhase == GUNTWIRL)
            {
                int frameCount = 5;
                float animRate = 4;

                npc.frame.X = NPC_WIDTH * 6;
                npc.frame.Y = NPC_WIDTH * (5 + (int)Math.Min(Math.Floor(Counter2 / animRate), frameCount - 1));

                return true;
            }
            if (AIPhase == HATTHROW)
            {
                int frameCount = 7;
                float animRate = 6;

                npc.frame.X = NPC_WIDTH * 7;
                npc.frame.Y = NPC_WIDTH * (int)Math.Min(Math.Floor(FrameDelay / animRate), frameCount - 1);

                return true;
            }
            if (AIPhase == UPSHOOT)
            {
                int frameCount = 4;

                npc.frame.X = NPC_WIDTH * 6;
                npc.frame.Y = NPC_WIDTH * (int)Math.Min(Counter2 % 4, frameCount - 1);

                return true;
            }
            if (AIPhase == SHOTGUN)
            {
                int frameCount = 6;
                float animRate = 6;
                
                npc.frame.X = NPC_WIDTH * 4;
                npc.frame.Y = NPC_WIDTH * (int)Math.Min(Math.Floor(FrameDelay / animRate), frameCount - 1);

                if(Counter < 45)
                    return true;
                return false;
            }
            if (AIPhase == SNOWBOMB)
            {
                int frameCount = 10;
                float animRate = 6;

                float frame = FrameDelay;
                if(frame > animRate * 5)
                {
                    frame = animRate * 5;
                    if (FrameDelay > animRate * 7)
                        frame = FrameDelay - animRate * 2;
                }
                npc.frame.X = NPC_WIDTH * 5;
                npc.frame.Y = NPC_WIDTH * (int)Math.Min(Math.Floor(frame / animRate), frameCount - 1);

                if (Counter < 12 * 6)
                    return true;
                return false;
            }
            return false;
        }
        #endregion

        #region Loot
        public override void NPCLoot()
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get();
            if (LaugicalityWorld.downedEtheria)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EtherialFrost>(), 1);
            }
            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<FrostShard>(), Main.rand.Next(1, 3));
                if (Main.rand.Next(0, 3) != 0)
                {
                    int ran = Main.rand.Next(1, 7);
                    if (ran == 1) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,ItemID.IceBoomerang, 1);
                    if (ran == 2) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,ItemID.IceBlade, 1);
                    if (ran == 3) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,ItemID.IceSkates, 1);
                    if (ran == 4) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,ItemID.SnowballCannon, 1);
                    if (ran == 5) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlizzardinaBottle, 1);
                    if (ran == 6) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,ItemID.FlurryBoots, 1);
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnowBlock, Main.rand.Next(30, 60));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IceBlock, Main.rand.Next(30, 60));

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ChilledBar>(), Main.rand.Next(16, 25));
            }

            if (Main.expertMode)
                npc.DropBossBags();

            if(Main.rand.Next(10) == 0)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<HypothemaTrophy>(), 1);

            LaugicalityWorld.downedHypothema = true;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
        }
        #endregion
    }
}
