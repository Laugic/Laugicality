using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    [AutoloadBossHead]
    public class Ragnar : ModNPC
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
        public int attacks = 0;
        public bool attacking = false;
        public bool bitherial = true;
        public int plays = 0;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.ENPCs.Add(npc.type);
            DisplayName.SetDefault("Ragnar");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            plays = 1;
            bitherial = true;
            attacks = 0;
            attacking = false;
            moveDelay = 600;
            hovDir = 1;
            vDir = 1;
            moveType = 1;
            shoot = 0;
            reload = 50;
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
            npc.width = 96;
            npc.height = 96;
            npc.damage = 28;
            npc.defense = 10;
            npc.aiStyle = 0;
            npc.lifeMax = 3200;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 99f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/RottenShotgun");
            damage = 32;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            plays = numPlayers;
            npc.lifeMax = 4200 + numPlayers * 800;
            npc.damage = 40;
            reload = 220;
            damage = 36;
        }


        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 127, 0f, 0f);

            if (Main.player[npc.target].statLife <= 0) { npc.position.Y -= 30; }
            if (Main.player[npc.target].ZoneRockLayerHeight == false) { npc.position.Y -= 30; }
            Vector2 delta = Main.player[npc.target].Center - npc.Center;
            float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);

            
            //Main.NewText(vaccel.ToString(), 250, 0, 0);

            //Checking which direction to move when spawned
            if (dir == 0)
            {
                if (delta.X < 0) dir = 1;
                else dir = -1;
            }

            //Moving across top of screen
            if (moveType == 1)
            {
                attacking = false;
                //Horizontal Movement
                npc.velocity.X = accel;
                if (npc.position.X < Main.player[npc.target].position.X - 400 && hovDir == -1)
                {
                    hovDir = 1;
                    if (npc.life > npc.lifeMax / 2)
                        shoot = 1;
                    else
                        shoot = 2;
                    attacks += 1;
                }
                if (npc.position.X > Main.player[npc.target].position.X + 400 && hovDir == 1)
                {
                    hovDir = -1;
                    if (npc.life > npc.lifeMax / 2)
                        shoot = 1;
                    else
                        shoot = 2;
                    attacks += 1;
                }
                if (Math.Abs(accel) < maxAccel) { accel += (float)hovDir / 4f; }
                else { accel *= .5f; }

                //Vertical Movement
                npc.velocity.Y = vaccel;
                if (npc.position.Y - Main.player[npc.target].position.Y + 280 > 0) { vDir = -1; }
                if (npc.position.Y - Main.player[npc.target].position.Y + 280 < 0) { vDir = 1; }
                if (Math.Abs(vaccel) < maxVaccel / 4) { vaccel += (float)vDir / 3f; }
                else { vaccel *= .2f; }
                npc.velocity.Y = vaccel;
                if (boosted == false)
                {
                    if (Math.Abs(npc.position.Y - Main.player[npc.target].position.Y + 280) > 20)
                    {
                        if (npc.position.Y - Main.player[npc.target].position.Y + 280 < 0)
                        {
                            if (vaccel < maxVaccel) vaccel += .4f;
                        }
                        if (npc.position.Y - Main.player[npc.target].position.Y + 280 > 0)
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

                //Attack 2
                if(Math.Abs(delta.X) < 10 && attacks >= 8 && moveType == 1)
                {
                    attacks = 0;
                    moveType = 2;
                    npc.velocity.X = 0;
                    npc.velocity.Y = 0;
                }

            }

            if(moveType == 2)
            {
                attacking = true;
                npc.velocity.Y = 14;
                npc.velocity.X = 0;
                vaccel = 0;
                accel = 0;
                if (npc.position.Y - Main.player[npc.target].position.Y > 280)
                {
                    moveType = 1;
                    delay = reload;
                    shoot = 2;
                }
            }
            /*Attacks
            if (moveType == 1)
            {
                reload = 100;
                delay -= 1;
                if (delay <= 0)
                {
                    delay = reload;
                    if (npc.life > npc.lifeMax / 2)
                        shoot = 1;
                    else
                        shoot = 2;
                    attacks += 1;
                }
            }
            */
            if (shoot == 1 && Main.netMode != 1)
            {
                shoot = 0;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, mod.ProjectileType("RockFalling"), damage, 3, Main.myPlayer);
            }
            if (shoot == 2 && Main.netMode != 1)
            {
                shoot = 0;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("RockLoose"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 5, mod.ProjectileType("RockFalling"), damage, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 7, 0, mod.ProjectileType("MiniRock"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -7, 0, mod.ProjectileType("MiniRock"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 7, mod.ProjectileType("MiniRock"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -7, mod.ProjectileType("MiniRock"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, 5, mod.ProjectileType("MiniRock"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, -5, mod.ProjectileType("MiniRock"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, -5, mod.ProjectileType("MiniRock"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, 5, mod.ProjectileType("MiniRock"), damage / 3, 3, Main.myPlayer);

            }
        }



        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            if (Main.expertMode)
            {
                target.AddBuff(BuffID.Frostburn, 90, true);
                target.AddBuff(BuffID.Chilled, 60, true);
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            if (plays == 0)
                plays = 1;
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityWorld.downedEtheria)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MoltenEtheria"), 1);
            }
                potionType = 188;

            if (Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RagnarTreasureBag"), 1);
            }
            else
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkShard"), Main.rand.Next(1, 3));
                int ran = Main.rand.Next(1, 7);
                if (ran == 1) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 49, 1);
                if (ran == 2) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicMirror, 1);
                if (ran == 3) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 53, 1);
                if (ran == 4) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HermesBoots, 1);
                if (ran == 5) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EnchantedBoomerang, 1);
                if (ran == 6) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LavaCharm, 1);
                
            }

            LaugicalityWorld.downedRagnar = true;
        }


        public override void FindFrame(int frameHeight)
        {
            frameHeight = 96;
            if (attacking)
            {
                npc.frame.Y = frameHeight;
            }
            else
            {
                npc.frame.Y = 0;
            }
        }


    }
}
