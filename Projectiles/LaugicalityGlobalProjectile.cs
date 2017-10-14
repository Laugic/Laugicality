using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles
{
    public class LaugicalityGlobalProjectile : GlobalProjectile
    {
        
        public virtual bool PreAI(Projectile projectile)
        {
            return true;

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