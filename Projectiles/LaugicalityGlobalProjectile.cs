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

        public override void SetDefaults(Projectile projectile)
        {
            eDmg = 0;
            dmg = 0;
            etherial = false;
            bitherial = false;
            if (LaugicalityVars.EProjectiles.Contains(projectile.type))
            {
                bitherial = true;
            }
        }

        public override bool PreDraw(Projectile projectile, SpriteBatch spriteBatch, Color lightColor)
        {
            if (eDmg == 0)
                eDmg = projectile.damage;

            if (bitherial)
            {
                if (LaugicalityWorld.etherial)
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
                    friend = projectile.friendly;
                }
                if (!friend)
                {
                    if (etherial)
                    {
                        if (LaugicalityWorld.etherial)
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

                        if (LaugicalityWorld.etherial)
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

        public virtual bool PreAI(Projectile projectile)
        {
            /*
            if (LaugicalityWorld.etherial)
            {
                etherial = true;
            }
            */
            var mPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);

            int rand = Main.rand.Next(4);
            if (mPlayer.obsidium)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            if (mPlayer.frost)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            if (mPlayer.skp)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 44, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            if (mPlayer.douche)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 199, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            if (mPlayer.qB)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 46, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            if (mPlayer.meFied)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Lightning"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            return true;
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
            var mPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);

            int rand = Main.rand.Next(4);
            if (mPlayer.obsidium)
            {
                target.AddBuff(24, (int)((120 + 60 * rand) * mPlayer.mysticDuration), false);
            }
            if (mPlayer.frost)
            {
                target.AddBuff(BuffID.Frostburn, (int)((120 + 60 * rand) * mPlayer.mysticDuration), false);
            }
            if (mPlayer.skp)
            {
                target.AddBuff(39, (int)((120 + 60 * rand) * mPlayer.mysticDuration), false);
            }
            if (mPlayer.douche)
            {
                target.AddBuff(70, (int)((120 + 60 * rand) * mPlayer.mysticDuration), false);
            }
            if (mPlayer.qB)
            {
                target.AddBuff(20, (int)((120 + 60 * rand) * mPlayer.mysticDuration), false);
            }
            if (mPlayer.meFied)
            {
                target.AddBuff(mod.BuffType("Electrified"), (int)((120 + 60 * rand) * mPlayer.mysticDuration), false);
            }
        }
    }
}