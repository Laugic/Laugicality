using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Laugicality.Projectiles
{
    public class LaugicalityGlobalProjectile : GlobalProjectile
    {
        public bool etherial = false;
        public bool bitherial = false;
        public bool friend = false;
        private int dmg = 0;
        public int eDmg = 0;
        public float oldVX = 0f;
        public float oldVY = 0f;
        public int ai = 0;
        public float xTemp = 0;
        public float yTemp = 0;
        public bool zImmune = false;
        public bool frozen = false;

        public override void SetDefaults(Projectile projectile)
        {
            frozen = false;
            zImmune = false;
            ai = projectile.aiStyle;
            oldVX = 0f;
            oldVY = 0f;
            eDmg = 0;
            dmg = 0;
            etherial = false;
            bitherial = false;
            if (LaugicalityVars.EProjectiles.Contains(projectile.type))
            {
                bitherial = true;
            }
            if (LaugicalityVars.ZProjectiles.Contains(projectile.type))
            {
                zImmune = true;
            }
        }

        public override bool PreDraw(Projectile projectile, SpriteBatch spriteBatch, Color lightColor)
        {
            if (eDmg == 0)
                eDmg = projectile.damage;
            var modPlayer = Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>(mod);

            if (bitherial)
            {
                if (modPlayer.etherial)
                    projectile.damage = eDmg  + 25;
                else
                    projectile.damage = eDmg;
                return true;
            }
            else
            {
                if (dmg == 0)
                {
                    dmg = projectile.damage;
                    friend = !projectile.hostile;
                }
                if (!friend)
                {
                    if (etherial)
                    {
                        if (LaugicalityWorld.downedEtheria)
                        {
                            projectile.damage = dmg;
                            return true;
                        }
                        else
                        {
                            projectile.damage = 0;
                            return false;
                        }
                    }
                    else
                    {

                        if (LaugicalityWorld.downedEtheria)
                        {
                            projectile.damage = 0;
                            return false;
                        }
                        else
                        {
                            projectile.damage = dmg;
                            return true;
                        }
                    }
                }
                else return true;
            }

        }

        public override bool PreAI(Projectile projectile)
        {
            if (eDmg == 0)
                eDmg = projectile.damage;

            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);

            if (bitherial)
            {
                if (modPlayer.etherial)
                    projectile.damage = eDmg + 25;
                else
                    projectile.damage = eDmg;
            }
            else
            {
                if (dmg == 0)
                {
                    dmg = projectile.damage;
                    friend = !projectile.hostile;
                }
                if (!friend)
                {
                    if (etherial)
                    {
                        if (LaugicalityWorld.downedEtheria)
                        {
                            projectile.damage = dmg;
                        }
                        else
                        {
                            projectile.damage = 0;
                            projectile.Kill();
                        }
                    }
                    else
                    {

                        if (LaugicalityWorld.downedEtheria)
                        {
                            projectile.damage = 0;
                            projectile.Kill();
                        }
                        else
                        {
                            projectile.damage = dmg;
                        }
                    }
                }
            }


            int rand = Main.rand.Next(60);
            if (projectile.friendly && projectile.damage > 0)
            {
                if (modPlayer.obsidium && rand == 0 && modPlayer.SoulStoneV)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                if (modPlayer.frost && rand == 0 && modPlayer.SoulStoneV)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                if (modPlayer.skp && rand == 0 && modPlayer.SoulStoneV)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 44, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                if (modPlayer.douche && rand == 0 && modPlayer.SoulStoneV)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 199, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                if (modPlayer.qB && rand == 0 && modPlayer.SoulStoneV)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 46, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                if (modPlayer.meFied && rand == 0 && modPlayer.SoulStoneV)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Steam"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                if (modPlayer.slimey && rand == 0 && modPlayer.SoulStoneV)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 116, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                if (modPlayer.etherialFrost && rand == 0 && modPlayer.SoulStoneV)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Etherial"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
            }

            bool zProjImmune = false;
            Player projOwner = Main.player[projectile.owner];
            zProjImmune = projOwner.GetModPlayer<LaugicalityPlayer>(mod).zProjImmune;
            if (projectile.friendly == false)
                zProjImmune = false;
            if (Laugicality.zawarudo > 0 && zProjImmune == false && zImmune == false)
            {
                projectile.timeLeft++;
                if (!frozen)
                {
                    oldVX = projectile.velocity.X;
                    oldVY = projectile.velocity.Y;
                    frozen = true;
                    xTemp = 0;
                    yTemp = 0;
                }
                if (frozen)
                {
                    projectile.velocity.X *= 0.01f;
                    projectile.velocity.Y *= 0.01f;
                    if (xTemp == 0 || yTemp == 0)
                    {
                        xTemp = projectile.position.X;
                        yTemp = projectile.position.Y;
                    }
                    else
                    {
                        projectile.position.X = xTemp;
                        projectile.position.Y = yTemp;
                    }
                }
                return false;
            }
            else
            {
                if (frozen)
                {
                    projectile.velocity.X = oldVX;
                    projectile.velocity.Y = oldVY;
                    frozen = false;
                }
                if (!frozen)
                {
                    oldVX = 0f;
                    oldVY = 0f;
                }
                return true;
            }
        }
        

        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            var modPlayer = Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>(mod);

            int rand = Main.rand.Next(4);
            if (modPlayer.obsidium)
            {
                target.AddBuff(24, (int)(3 * 60 + 60 * rand), false);
            }
            if (modPlayer.frost)
            {
                target.AddBuff(BuffID.Frostburn, (int)(3 * 60 + 60 * rand), false);
            }
            if (modPlayer.skp)
            {
                target.AddBuff(39, (int)(4 * 60 + 60 * rand), false);
            }
            if (modPlayer.douche)
            {
                target.AddBuff(70, (int)(4 * 60 + 60 * rand), false);
            }
            if (modPlayer.qB)
            {
                target.AddBuff(20, (int)(4 * 60 + 60 * rand), false);
            }
            if (modPlayer.meFied)
            {
                target.AddBuff(mod.BuffType("Steamy"), (int)(3 * 60 + 60 * rand), false);
            }
            if (modPlayer.slimey)
            {
                target.AddBuff(mod.BuffType("Slimed"), (int)(3 * 60 + 60 * rand), false);
            }
            if (modPlayer.etherialFrost)
            {
                target.AddBuff(mod.BuffType("Frostbite"), (int)(12 * 60 + 60 * rand), false);
            }
            if (modPlayer.etherialPipes)
            {
                target.AddBuff(mod.BuffType("Steamified"), (int)((12 * 60 + 60 * rand)), false);
            }
            if (modPlayer.etherCog)
            {
                target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).attacker = projectile.owner;
            }

            if (modPlayer.crysMag && projectile.type != mod.ProjectileType("ObsidiumArrowHead"))
            {
                if (crit)
                {
                    float mag = 6f;
                    float theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    if (Main.myPlayer == projectile.owner)
                        Projectile.NewProjectile(target.Center.X, target.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, mod.ProjectileType("ObsidiumArrowHead"), damage, 3f, Main.myPlayer);
                    theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    if (Main.myPlayer == projectile.owner)
                        Projectile.NewProjectile(target.Center.X, target.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, mod.ProjectileType("ObsidiumArrowHead"), damage, 3f, Main.myPlayer);
                    theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    if (Main.myPlayer == projectile.owner)
                        Projectile.NewProjectile(target.Center.X, target.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, mod.ProjectileType("ObsidiumArrowHead"), damage, 3f, Main.myPlayer);
                }
            }
        }



        public void Explode(Vector2 center, float range, int damage)
        {
            foreach (NPC npc in Main.npc)
            {
                float dist = Vector2.Distance(center, npc.Center);
                if (dist <= range && npc.dontTakeDamage == false)
                {
                    npc.life -= damage;
                }
            }
        }
    }
}