using System;
using Terraria;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class PlutoConjuration : ConjurationProjectile
    {
        public bool stopped = false;
        public int damage = 0;
        public bool growing = true;

        public override void SetDefaults()
        {
            growing = true;
            stopped = false;
            damage = projectile.damage;
            projectile.width = 56;
            projectile.height = 56;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 8 * 60;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (growing)
            {
                if (projectile.scale < 1.5f)
                {
                    projectile.scale += 0.02f;
                }
                else growing = false;
            }
            else
            {
                if (projectile.scale > .75f)
                {
                    projectile.scale -= 0.02f;
                }
                else growing = true;
            }
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            projectile.velocity.X *= .92f;
            projectile.velocity.Y *= .92f;
            if(Math.Abs(projectile.velocity.X) <= .2 && Math.Abs(projectile.velocity.Y) <= .2)
            {
                stopped = true;
            }
            if (stopped)
            {
                if (Main.myPlayer == projectile.owner)
                {
                    if(Main.rand.Next(5) == 0)
                        Projectile.NewProjectile(projectile.Center.X - projectile.width / 2 + Main.rand.Next(projectile.width + 1), projectile.Center.Y - projectile.height / 2 + Main.rand.Next(projectile.height + 1), 0, 8, mod.ProjectileType("PlutoConjuration3"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                }
            }
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Frost"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }
    }
}