using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Slybertron
{
    [AutoloadBossHead]
    public class Slybertron : ModNPC
    {
        public int spawned = 0;
        public Random rnd = new Random();
        public int phase = 0;
        public int numDefeats = 0;
        public int attackDuration = 0;
        public int attackDurationCL = 0;
        public int attackDurationXO = 0;
        public int damage = 0;
        public double attackDelay = 0;      //Current delay between attacks
        public double attackReload = 200;   //What the delay is reset to between attacks
        public double attack2Delay = 0;      //Current delay between attacks
        public double attack2Reload = 400;   //What the delay is reset to between attacks
        public double attackReloadSpeed = 1.0;
        public double reloadSpeed = 1.0;
        public int attack1 = 0;//1: Gearikans, 2: Coginator, 3: SteamStreams, 4:Electroshock
        public int attack2 = 0;//1: Loose Cog, 2: Steamy Shadow, 3: X-Out, 4:Gas Ball
        //Layer 1 stats
        public int steamStreamDmg = 0;
        public int steamStreamHits = 0;
        public int steamStreamShots = 0;
        public int coginatorDmg = 0;
        public int coginatorHits = 0;
        public int coginatorShots = 0;
        public int gearikanDmg = 0;
        public int gearikanHits = 0;
        public int gearikanShots = 0;
        public int electroShockDmg = 0;
        public int electroShockHits = 0;
        public int electroShockShots = 0;
        //Layer 2 Stats
        public int looseCogDmg = 0;
        public int looseCogHits = 0;
        public int looseCogShots = 0;
        public int steamShadowDmg = 0;
        public int steamShadowHits = 0;
        public int steamShadowShots = 0;
        public int xOutDmg = 0;
        public int xOutHits = 0;
        public int xOutShots = 0;
        public int gasBallDmg = 0;
        public int gasBallHits = 0;
        public int gasBallShots = 0;
        public bool stage2 = false;
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slybertron");
            //Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            attackReloadSpeed = 1.0;
            attackDelay = 300;      //Delay before first attack
            attackReload = 200;     //Resetting the reload speed
            attack2Delay = 300;      //Delay before first attack
            attack2Reload = 400;     //Resetting the reload speed
            phase = 1;
            npc.width = 348;
            npc.height = 162;
            npc.damage = 100;
            npc.defense = 32;
            npc.aiStyle = 1;
            npc.lifeMax = 60000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = false;
            npc.noTileCollide = false;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Slybertron");
            damage = 40;

        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 80000 + numPlayers * 8000;
            npc.damage = 140;
            damage = 50;
            attackReloadSpeed += .1;
        }


        public override void AI()
        {
            //Despawn check
            if (Main.player[npc.target].statLife == 0) { npc.position.Y += -100; spawned = 0; }
            Vector2 delta = Main.player[npc.target].Center - npc.Center;
            float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
            //Jump at you if too far away [x]
            if (Math.Abs(delta.X) > 1200 && npc.aiStyle == 1) { npc.aiStyle = 0; }
            if (Math.Abs(delta.X) < 600 && npc.aiStyle == 0) { npc.aiStyle = 1; }
            if (npc.aiStyle == 0)
            {
                if (delta.X > 0) { npc.velocity.X = 8f; npc.velocity.Y = -2f; }
                if (delta.X < 0) { npc.velocity.X = -8f; npc.velocity.Y = -2f; }
            }
            if(npc.aiStyle == 0) { 
            npc.noTileCollide = true;
            }
            else if (npc.aiStyle == 1){
                npc.noTileCollide = false;
            }
            //Jump at you if too far away [y]
            if (delta.Y < -1000 && npc.aiStyle == 1) { npc.aiStyle = 0; }
            if (delta.Y > 40 && npc.aiStyle == 0) { npc.aiStyle = 1; }
            if (npc.aiStyle == 0)
            {
                if (delta.X > 2) { npc.velocity.X = 2f; npc.velocity.Y = -8f; }
                if (delta.X < -2) { npc.velocity.X = -2f; npc.velocity.Y = -8f; }
            }
            npc.rotation = 0f;
            //Attack Durations
            if (attackDuration > 0) attackDuration += 1;
            if (attackDurationCL > 0) attackDurationCL += 1;

            //Phases
            if (npc.life < npc.lifeMax * .67 && phase == 1) { phase = 2; Main.NewText("Phase 2 weapons activated.", 250, 0, 0);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
            }
            if (npc.life < npc.lifeMax * .33 && phase == 2) { phase = 3; attackReloadSpeed += .1; }
            if (npc.life < npc.lifeMax * .20 && phase == 3) { phase = 4; }//Only to apply phase 3 knowledge
            if (npc.life < npc.lifeMax * .10 && phase == 4 && Main.expertMode)
            {
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                attackReloadSpeed += .1;
                phase = 5;
                npc.life = (int)(npc.lifeMax * .25);
                Main.NewText("Slybertron is coming for you.", 250, 0, 0);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color
            }
            //Picking attack 1
            if (attackDelay > 0) attackDelay -= attackReloadSpeed;
            else {//Pick attack 

                //Picking an attack
                if (Main.rand.NextDouble() <= .25) attack1 = 1;//25% chance to do attack 1
                else
                {
                    if (Main.rand.NextDouble() <= .33) attack1 = 2; //33% of 75% is 25%
                    else
                    {
                        if (Main.rand.NextDouble() <= .5) { attack1 = 3; }
                        else attack1 = 4;
                    }
                }
            }//end Pick attack
            if (phase > 1)
            {
                //Picking attack 2
                if (attack2Delay > 0) attack2Delay -= attackReloadSpeed;
                else
                {//Pick attack 

                    //Picking an attack
                    if (Main.rand.NextDouble() <= .25) attack2 = 1;//25% chance to do attack 1
                    else
                    {
                        if (Main.rand.NextDouble() <= .33) attack2 = 2; //33% of 75% is 25%
                        else
                        {
                            if (Main.rand.NextDouble() <= .5) { attack2 = 3; }
                            else attack2 = 4;
                        }
                    }
                }//end Pick attack
            }

            //Attacks
            if (attack1 == 1)//Gearikans
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4 + Main.rand.Next(4), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -1 * (4 + Main.rand.Next(4)), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4 + Main.rand.Next(4), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -1 * (4 + Main.rand.Next(4)), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4 + Main.rand.Next(4), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -1 * (4 + Main.rand.Next(4)), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4 + Main.rand.Next(4), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -1 * (4 + Main.rand.Next(4)), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4 + Main.rand.Next(4), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -1 * (4 + Main.rand.Next(4)), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4 + Main.rand.Next(4), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -1 * (4 + Main.rand.Next(4)), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4 + Main.rand.Next(4), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -1 * (4 + Main.rand.Next(4)), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4 + Main.rand.Next(4), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -1 * (4 + Main.rand.Next(4)), 1 - Main.rand.Next(8), mod.ProjectileType("Gearikan"), damage / 2, 3f, Main.myPlayer);
                attack1 = 0;
                gearikanShots += 1;
                attackDelay = attackReload;
                
            }
            if (attack1 == 2)//Coginator
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("Coginator"), damage, 3f, Main.myPlayer);
                attack1 = 0;
                coginatorShots += 1;
                attackDelay = attackReload;
            }
            if (attack1 == 3)//Steam Stream
            {
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 3, -10, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -3, -10, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, -3, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, -3, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                    attackDuration = 1;
                    attack1 = 0;
                    steamStreamShots += 1;
                    attackDelay = attackReload;
                Main.PlaySound(SoundID.Item34, (int)npc.position.X, (int)npc.position.Y);
            }
                if(attackDuration == 30)
                {
                    Main.PlaySound(SoundID.Item34, (int)npc.position.X, (int)npc.position.Y);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 3, -10, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -3, -10, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, -3, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, -3, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                }
                if (attackDuration == 60)
                {
                    Main.PlaySound(SoundID.Item34, (int)npc.position.X, (int)npc.position.Y);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 3, -10, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -3, -10, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, -3, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, -3, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                }
                if (attackDuration == 90)
                {
                    Main.PlaySound(SoundID.Item34, (int)npc.position.X, (int)npc.position.Y);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 3, -10, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -3, -10, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, -3, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, -3, mod.ProjectileType("SteamStream"), damage, 3f, Main.myPlayer);
                }
                if (attackDuration > 90)
                {
                    attackDuration = 0;
                }
            
            if (attack1 == 4)//Electroshock
            {
                Main.PlaySound(SoundID.Item33, (int)npc.position.X, (int)npc.position.Y);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 12, 0, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, 2, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 4, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 6, 6, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, 8, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 2, 10, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 12, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -2, 10, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, 8, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 6, 6, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 4, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, 2, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -12, 0, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, -2, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, -4, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 6, -6, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, -8, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 2, -10, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -12, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -2, -10, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, -8, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 6, -6, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, -4, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, -2, mod.ProjectileType("Electroshock"), damage, 3f, Main.myPlayer);
                attack1 = 0;
                electroShockShots += 1;
                attackDelay = attackReload;
            }

            //Attack Layer 2
            if(attack2 == 1)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("CogLoose"), damage, 3f, Main.myPlayer);
                attack2 = 0;
                attackDurationCL = 1;
                attack2Delay = attack2Reload;
            }

            if (attackDurationCL == 30)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("CogLoose"), damage, 3f, Main.myPlayer);
            }
            if (attackDurationCL == 60)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("CogLoose"), damage, 3f, Main.myPlayer);
            }
            if (attackDurationCL == 90)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("CogLoose"), damage, 3f, Main.myPlayer);
            }
            if (attackDurationCL > 90)
            {
                attackDurationCL = 0;
            }
            if (attack2 == 2)
            {
                Projectile.NewProjectile(npc.Center.X+120, npc.Center.Y, 0, 0, mod.ProjectileType("SteamyShadow"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X-120, npc.Center.Y, 0, 0, mod.ProjectileType("SteamyShadow"), damage, 3f, Main.myPlayer);
                attack2 = 0;
                attack2Delay = attack2Reload;
            }
            if (attack2 == 3)
            {
                Main.PlaySound(SoundID.Item33, (int)npc.position.X, (int)npc.position.Y);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, 4, mod.ProjectileType("XOut"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, -4, mod.ProjectileType("XOut"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, -4, mod.ProjectileType("XOut"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, 4, mod.ProjectileType("XOut"), damage, 3f, Main.myPlayer);
                attack2 = 0;
                attack2Delay = attack2Reload;
            }
            if (attack2 == 4)
            {
                Main.PlaySound(SoundID.Item34, (int)npc.position.X, (int)npc.position.Y);
                Projectile.NewProjectile(npc.Center.X + 120, npc.Center.Y, 8, 0, mod.ProjectileType("GasBall"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X - 120, npc.Center.Y, -8, 0, mod.ProjectileType("GasBall"), damage, 3f, Main.myPlayer);
                attack2 = 0;
                attack2Delay = attack2Reload;
            }

        }


        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            if (Main.expertMode)
            {
                int debuff = mod.BuffType("Electrified");
                if (debuff >= 0)
                {
                    player.AddBuff(debuff, 90, true);
                }
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            spawned = 0;
            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SteamBar"), Main.rand.Next(15, 30));
                potionType = 499;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulOfFraught"), Main.rand.Next(20, 40));
            }

            if (Main.expertMode)
            {
                potionType = 499;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SlybertronTreasureBag"), 1);
            }

            LaugicalityWorld.downedSlybertron = true;
        }
        /*
        public override void FindFrame(int frameHeight)
        {
            if (npc.life < npc.lifeMax * .5)
            {
                npc.frame.Y = frameHeight;
            }
            else
            {
                npc.frame.Y = 0;
            }
        }*/

        
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
