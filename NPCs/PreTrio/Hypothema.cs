using System;
using Laugicality.Buffs;
using Laugicality.Dusts;
using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    [AutoloadBossHead]
    public class Hypothema : ModNPC
    {
        public int despawn = 0;

        public int MovementPhase { get; set; } = 0;
        public int MovementCounter { get; set; } = 0;
        public bool YPassed { get; set; } = false;
        public bool XPassed { get; set; } = false;
        public Vector2 targetPos;
        private float xAccel = 0;

        public int AttackCounter { get; set; } = 0;
        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(npc.type);
            DisplayName.SetDefault("Hypothema");
        }

        public override void SetDefaults()
        {
            npc.width = 64;
            npc.height = 64;
            npc.damage = 40;
            npc.defense = 8;
            npc.aiStyle = 0;
            npc.lifeMax = 3000;
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
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 5000 + numPlayers * 2000;
            npc.damage = 80;
        }


        public override void AI()
        {
            DespawnCheck(npc);
            for(int i = 0; i < 3; i++)
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Frost>(), 0f, 0f);
            npc.dontTakeDamage = !Main.player[npc.target].ZoneSnow;
            Movement();
            Attacks();
        }

        private void Movement()
        {
            switch (MovementPhase)
            {
                case 0:
                    Hover();
                    break;
                case 1:
                    Dash();
                    break;
                case 2:
                    Fall();
                    break;
                default:
                    Follow();
                    break;
            }
            npc.netUpdate = true;
        }

        private void Hover()
        {
            targetPos = Main.player[npc.target].Center + new Vector2(0, -120);
            if (npc.Center.Y > targetPos.Y)
            {
                npc.velocity.Y -= .2f;
                if (npc.velocity.Y > 0)
                    npc.velocity.Y *= .98f;
            }
            if (npc.Center.Y < targetPos.Y)
            {
                npc.velocity.Y += .2f;
                if (npc.velocity.Y < 0)
                    npc.velocity.Y *= .98f;
            }
            if (Math.Abs(npc.velocity.Y) > 16)
                npc.velocity.Y *= .98f;
            if (npc.Center.X > targetPos.X)
                xAccel -= .2f;
            if (npc.Center.X < targetPos.X)
                xAccel += .2f;
            if (Math.Abs(xAccel) > 16)
                xAccel *= .98f;
            npc.velocity.X = xAccel;
            MovementCounter++;
            if(MovementCounter > 12 * 60)
            {
                ResetMovementPhase();
                MovementPhase++;
            }
        }

        private void Dash()
        {
            if(MovementCounter % 2 == 0)
                targetPos = Main.player[npc.target].Center + new Vector2(300, 0);
            else
                targetPos = Main.player[npc.target].Center + new Vector2(-300, 0);
            if (npc.Center.Y > targetPos.Y)
            {
                npc.velocity.Y -= .2f;
                if (npc.velocity.Y > 0)
                    npc.velocity.Y *= .9f;
            }
            if (npc.Center.Y < targetPos.Y)
            {
                npc.velocity.Y += .2f;
                if (npc.velocity.Y < 0)
                    npc.velocity.Y *= .9f;
            }
            if (Math.Abs(npc.velocity.Y) > 16)
                npc.velocity.Y *= .98f;
            if (npc.Center.X > targetPos.X)
            {
                xAccel -= .3f;
                if (MovementCounter % 2 == 0)
                {
                    MovementCounter++;
                    Burst();
                }
            }
            if (npc.Center.X < targetPos.X)
            {
                xAccel += .3f;
                if (MovementCounter % 2 != 0)
                {
                    MovementCounter++;
                    Burst();
                }
            }
            if (Math.Abs(xAccel) > 16)
                xAccel *= .98f;
            npc.velocity.X = xAccel;
            if (MovementCounter > 6)
            {
                ResetMovementPhase();
                MovementPhase++;
            }
        }

        private void Fall()
        {
            if (MovementCounter % 2 == 0)
                targetPos = Main.player[npc.target].Center + new Vector2(0, 150);
            else
                targetPos = Main.player[npc.target].Center + new Vector2(0, -150);
            if (npc.Center.Y > targetPos.Y)
            {
                npc.velocity.Y -= .45f;
                if (MovementCounter % 2 == 0)
                    MovementCounter++;
            }
            if (npc.Center.Y < targetPos.Y)
            {
                npc.velocity.Y += .3f;
                if (MovementCounter % 2 != 0)
                    MovementCounter++;
            }
            if (Math.Abs(npc.velocity.Y) > 16)
                npc.velocity.Y *= .98f;
            if (npc.Center.X > targetPos.X)
            {
                xAccel -= .3f;
                if (npc.velocity.X > 0)
                    npc.velocity.X *= .9f;
            }
            if (npc.Center.X < targetPos.X)
            {
                xAccel += .3f;
                if (npc.velocity.X < 0)
                    npc.velocity.X *= .9f;
            }
            if (Math.Abs(xAccel) > 16)
                xAccel *= .98f;
            npc.velocity.X = xAccel;
            if (MovementCounter > 6)
            {
                ResetMovementPhase();
                MovementPhase++;
            }
            if(Main.rand.NextBool(4) || npc.life < npc.lifeMax / 3)
                Hail();
        }

        private void Follow()
        {
            targetPos = Main.player[npc.target].Center;
            if (npc.Center.Y > targetPos.Y)
            {
                npc.velocity.Y -= .3f;
                if (npc.velocity.Y > 0)
                    npc.velocity.Y *= .9f;
            }
            if (npc.Center.Y < targetPos.Y)
            {
                npc.velocity.Y += .3f;
                if (npc.velocity.Y < 0)
                    npc.velocity.Y *= .9f;
            }
            if (npc.Center.X > targetPos.X)
            {
                xAccel -= .3f;
                if (npc.velocity.X > 0)
                    npc.velocity.X *= .95f;
            }
            if (npc.Center.X < targetPos.X)
            {
                xAccel += .3f;
                if (npc.velocity.X < 0)
                    npc.velocity.X *= .95f;
            }
            if (Math.Abs(xAccel) > 16)
                xAccel *= .98f;
            npc.velocity.X = xAccel;
            MovementCounter++;
            if (MovementCounter > 12 * 60)
            {
                ResetMovementPhase();
                MovementPhase = 0;
            }
        }

        private void ResetMovementPhase()
        {
            MovementCounter = 0;
            YPassed = false;
            XPassed = false;
        }

        private void Attacks()
        {
            if (npc.Center.Y < Main.player[npc.target].Center.Y - 140 && Math.Abs(npc.Center.X - Main.player[npc.target].Center.X) < 250)
                Hail();
        }

        private void Hail()
        {
            if (Main.rand.Next(4) == 0 && Main.netMode != 1)
                Projectile.NewProjectile(new Vector2(npc.Center.X - 12 + Main.rand.Next(24), npc.Center.Y - 12 + Main.rand.Next(24)), new Vector2(0, 9), ModContent.ProjectileType<HailProj>(), npc.damage / 4, 1);
        }

        private void Burst()
        {
            if(Main.netMode != 1)
            {
                for(int i = 0; i < 12; i++)
                {
                    float theta = Main.rand.NextFloat() * 2 * (float)Math.PI;
                    Projectile.NewProjectile(npc.Center, new Vector2((float)Math.Cos(theta) * 8, (float)Math.Sin(theta) * 8), ModContent.ProjectileType<HailProj>(), npc.damage / 4, 1);
                }
                if(npc.life < npc.lifeMax / 2)
                    Projectile.NewProjectile(npc.Center, new Vector2(0, 0), ModContent.ProjectileType<IceShard>(), npc.damage / 4, 1);
            }
        }

        private void DespawnCheck(NPC npc)
        {
            if (Main.player[npc.target].statLife < 1 || Vector2.Distance(Main.player[npc.target].Center, npc.Center) > 2500)
            {
                npc.TargetClosest(true);
                if (Main.player[npc.target].statLife < 1 || Vector2.Distance(Main.player[npc.target].Center, npc.Center) > 2500)
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
            {
                target.AddBuff(ModContent.BuffType<Frostbite>(), 4 * 60, true);
            }
            if (Main.expertMode)
            {
                target.AddBuff(BuffID.Frostburn, 90, true);
                target.AddBuff(BuffID.Chilled, 60, true);
            }
        }

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
                    if (ran == 5) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,987, 1);
                    if (ran == 6) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,ItemID.FlurryBoots, 1);
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnowBlock, Main.rand.Next(30, 60));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IceBlock, Main.rand.Next(30, 60));

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ChilledBar>(), Main.rand.Next(16, 25));
            }

            if (Main.expertMode)
            {
                npc.DropBossBags();
            }

            LaugicalityWorld.downedHypothema = true;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
        }

    }
}
