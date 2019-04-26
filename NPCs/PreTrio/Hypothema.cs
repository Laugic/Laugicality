using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    [AutoloadBossHead]
    public class Hypothema : ModNPC
    {

        public static Random rnd = new Random();
        public int spawn = 0;
        public bool stage2 = false;
        public int phase = 0;
        public int dir = 0;
        public int vdir = 0;
        public float accel = 0f;
        public float maxAccel = 20f;
        public float vaccel = 0f;
        public float maxVaccel = 20f;
        public bool boosted = false;
        public int delay = 0;
        public int maxDelay = 60;
        public int range = 2000;
        public int damage = 0;
        public int shoot = 0;
        public int reload = 160;
        public int moveType = 1;
        public int hovDir = 1;
        public int moveDelay = 600;
        public int vDir = 2;
        public bool bitherial = true;
        public int plays = 0;
        public int despawn = 0;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.ENPCs.Add(npc.type);
            DisplayName.SetDefault("Hypothema");
        }

        public override void SetDefaults()
        {
            despawn = 0;
            plays = 1;
            bitherial = true;
            moveDelay = 600;
            hovDir = 1;
            vDir = 1;
            moveType = 1;
            shoot = 0;
            reload = 50000;
            phase = 1;
            damage = 0;
            maxDelay = 60;
            range = 200;
            maxAccel = 14f;
            maxVaccel = 20f;
            accel = 0f;
            vaccel = 0f;
            spawn = 0;
            dir = 0;
            vdir = 0;
            delay = reload;
            npc.width = 64;
            npc.height = 64;
            npc.damage = 28;
            npc.defense = 10;
            npc.aiStyle = 0;
            npc.lifeMax = 2600;
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
            damage = 24;
            bossBag = mod.ItemType("HypothemaTreasureBag");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            plays = numPlayers;
            npc.lifeMax = 4000 + numPlayers * 800;
            npc.damage = 36;
            reload = 220;
            damage = 34;
            reload = 40000;
        }


        public override void AI()
        {
            bitherial = true;
            DespawnCheck(npc);
            npc.dontTakeDamage = Main.player[npc.target].ZoneSnow == false;
            Vector2 delta = Main.player[npc.target].Center - npc.Center;
            float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);

            Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, mod.DustType("Frost"), 0f, 0f);
            Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, mod.DustType("Frost"), 0f, 0f);
            Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, mod.DustType("Frost"), 0f, 0f);

            //Main.NewText(vaccel.ToString(), 250, 0, 0);

            //Checking which direction to move when spawned
            if (dir == 0)
            {
                if (delta.X < 0) dir = 1;
                else dir = -1;
            }

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
                if (Math.Abs(accel) < maxAccel / 3) { accel += (float)hovDir / 5f; }
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
                    moveDelay = 4;
                    moveType = 3;
                }
                //Horizontal Movement
                npc.velocity.X = accel;
                if (npc.position.X < Main.player[npc.target].position.X - 200 && hovDir == -1) { hovDir = 1; shoot = 1; }
                if (npc.position.X > Main.player[npc.target].position.X + 200 && hovDir == 1) { hovDir = -1; shoot = 1; }
                if (Math.Abs(accel) < maxAccel) { accel += (float)hovDir / 3f; }
                else { accel *= .98f; }

                //Vertical Movement
                npc.velocity.Y = vaccel;
                if (npc.position.Y - Main.player[npc.target].position.Y + 70 > 0) { vDir = -1; }
                if (npc.position.Y - Main.player[npc.target].position.Y + 70 < 0) { vDir = 1; }
                if (Math.Abs(vaccel) < maxVaccel / 6) { vaccel += (float)vDir / 6f; }
                else { vaccel *= .98f; }
            }

            //Dashing
            if (moveType == 3)
            {

                //Horizontal Movement
                npc.velocity.X = accel;
                if (dir == 1)
                {
                    if (accel < maxAccel / 2)
                    {
                        accel += .2f;
                    }
                    else
                    {
                        if (boosted == false) //Play boosted sound effect
                        {
                            moveDelay -= 1;
                            boosted = true;
                            shoot = 2;
                        }
                        accel = maxAccel;
                    }
                    if (delta.X < -range)
                    {
                        boosted = false;
                        dir = -1;
                    }
                }
                if (dir == -1)
                {
                    if (accel > maxAccel / -2)
                    {
                        accel -= .2f;
                    }
                    else
                    {
                        if (boosted == false) //Play boosted sound effect
                        {
                            moveDelay -= 1;
                            boosted = true;
                            shoot = 2;
                        }
                        accel = -maxAccel;
                    }
                    if (delta.X > range)
                    {
                        boosted = false;
                        dir = 1;
                    }
                }

                //Vertical Movement
                npc.velocity.Y = vaccel;
                if (boosted == false)
                {
                    if (Math.Abs(delta.Y) > 40)
                    {
                        if (delta.Y > 40)
                        {
                            if (vaccel < maxVaccel) vaccel += .4f;
                        }
                        if (delta.Y < -40)
                        {
                            if (vaccel < maxVaccel) vaccel -= .4f;
                        }
                    }
                    else
                    {
                        if (Math.Abs(vaccel) > .01f) vaccel *= .5f;
                        else vaccel = 0f;
                    }
                }
                else vaccel = 0;

                if (moveDelay <= 0)
                {
                    moveDelay = 600;
                    moveType = 1;
                }
            }
            //Phases
            /*
            if (npc.life < npc.lifeMax * .8 && phase == 1)
            {
                phase = 2;
                reload -= 20;
            }
            if (npc.life < npc.lifeMax * .5 && phase == 2)
            {
                npc.damage += 10;
                phase = 3;
                reload -= 20;
            }
            if (npc.life < npc.lifeMax * .2 && phase == 3 && Main.expertMode)
            {
                damage += 4;
                phase = 4;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
            }*/

            //Attacks
            delay -= 1;
            if(delay <= 0)
            {
                delay = reload;
                if (!Main.expertMode)
                    shoot = 1;
                else shoot = 2;
            }
            if (shoot == 1 && Main.netMode != 1)
            {
                shoot = 0;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 0, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, 4, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, -4, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, -4, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, 4, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);
            }
            if (shoot == 2 && Main.netMode != 1)
            {
                shoot = 0;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, mod.ProjectileType("IceShard"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 0, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, 4, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, -4, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, -4, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, 4, mod.ProjectileType("IceSpike"), damage / 3, 3, Main.myPlayer);

            }
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

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            if (LaugicalityWorld.downedEtheria)
            {
                target.AddBuff(mod.BuffType("Frostbite"), 4 * 60, true);
            }
            if (Main.expertMode)
            {
                target.AddBuff(BuffID.Frostburn, 90, true);
                target.AddBuff(BuffID.Chilled, 60, true);
            }
        }

        public override void NPCLoot()
        {
            if (plays == 0)
                plays = 1;
            LaugicalityPlayer modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityWorld.downedEtheria)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialFrost"), 1);
            }
            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostShard"), Main.rand.Next(1, 3));
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

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChilledBar"), Main.rand.Next(16, 25));
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
