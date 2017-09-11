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
    public class DuneSharkron : ModNPC
    {
        
        public Random rnd = new Random();
        public int phase = 0;
        public int damage = 0;
        public int dash = 0;
        public float dashSp = 6f;
        public int jump = 0;
        public int shoot = 0;
        public int reload = 160;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dune Sharkron");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            shoot = 0;
            reload = 260;
            phase = 1;
            dash = 0;
            dashSp = 6f;
            jump = 0;
            npc.width = 180;
            npc.height = 80;
            npc.damage = 28;
            npc.defense = 10;
            npc.aiStyle = 103;
            npc.lifeMax = 2600;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            //music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Annihilator");
            music = MusicID.Boss2;
            damage = 28;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 3000 + numPlayers * 800;
            npc.damage = 36;
            reload = 220;
            damage = 36;
        }


        public override void AI()
        {
            if (Main.player[npc.target].statLife == 0) { npc.position.Y += 100; }
            if (!Main.dayTime) { npc.position.Y += 300; }

            Vector2 delta = Main.player[npc.target].Center - npc.Center;

            //Main.NewText(delta.Y.ToString(), 250, 0, 0);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color

            //Horizontal Dash
            if (Math.Abs(delta.X) > 300) {  dash = 1; }
            
            if (Math.Abs(delta.X) < 40 ) { dash = 0; }

            //Vertical Jump
            if (delta.Y < -500 ) {jump = 1; }
            if (delta.Y > 0) { jump = 0; }

            if (dash == 1)
            {
                if (delta.X > 2) { npc.velocity.X = dashSp; if (jump == 1) npc.velocity.Y = -8f; }
                if (delta.X < -2) { npc.velocity.X = -dashSp; if (jump == 1) npc.velocity.Y = -8f; }
            }
            else
            {
                if (jump == 1) { 

                if (delta.X > 2) { if(npc.velocity.X < 2f) npc.velocity.X = 2f; npc.velocity.Y = -8f; }
                if (delta.X < -2) { if (npc.velocity.X > -2f) npc.velocity.X = -2f; npc.velocity.Y = -8f; }
                }
            }

            //Phases
            if (npc.life < npc.lifeMax * .8 && phase == 1)
            {
                phase = 2;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                reload -= 20;
            }
            if (npc.life < npc.lifeMax * .5 && phase == 2)
            {
                npc.damage += 10;
                dashSp = 6.5f;
                phase = 3;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                reload -= 20;
            }
            if (npc.life < npc.lifeMax * .2 && phase == 3 && Main.expertMode)
            {
                damage += 4;
                dashSp = 7f;
                phase = 4;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
            }

            //Attacks
            if (shoot > 0) shoot -= 1;
            if(shoot <= 0)
            {
                shoot = reload;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 0, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, 4, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, -4, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, -4, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, 4, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
            }
            if (phase >= 2 && shoot == reload/2)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 0, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, 4, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, -4, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, -4, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, 4, mod.ProjectileType("SharkNeedle"), damage / 3, 3, Main.myPlayer);
            }
            if (phase >= 3 && shoot == reload / 8f )
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 0, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, 4, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, -4, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, -4, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, 4, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
            }/*
            if (phase >= 2 && shoot == reload / 8 * 3)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 0, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, 4, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, -4, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, -4, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, 4, mod.ProjectileType("SharkNeedleHoming"), damage / 3, 3, Main.myPlayer);
            }*/



        }

        /*
        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
        }*/

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkShard"), Main.rand.Next(1, 3));
                
                int ran = Main.rand.Next(1, 5);
                if (ran == 1) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 934, 1);
                if (ran == 2) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 857, 1);
                if (ran == 3) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 848, 1);
                if (ran == 4) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 866, 1);
            }

            if (Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DuneSharkronTreasureBag"), 1);
            }

            LaugicalityWorld.downedDuneSharkron = true;
        }
        
        public override void FindFrame(int frameHeight)
        {
            frameHeight = 92;
            Vector2 delta = Main.player[npc.target].Center - npc.Center;

            if (delta.X > 0)
            {
                npc.frame.Y = frameHeight;
            }
            else
            {
                npc.frame.Y = 0;
            }
        }

        
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
