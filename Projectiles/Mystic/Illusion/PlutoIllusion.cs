using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class PlutoIllusion : IllusionProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.timeLeft = 100;
            projectile.ignoreWater = true;
            buffID = mod.BuffType("Frigid");
            baseDuration = 2 * 60;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Frost"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if(target.boss == false && !LaugicalityVars.frigImmune.Contains(target.type))
                target.AddBuff(buffID, (int)(baseDuration * duration) + Main.rand.Next(1 * 60));
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
           Main.PlaySound(SoundID.Item30, projectile.position);
           return true;
        }
    }
}