using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class YuleConjuration1 : PrimaryConjurationProjectile
    {
        public int counter = 0;
        private float rotationGoal;

        public override void SetDefaults()
        {
            projectile.width = 54;
            projectile.height = 54;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 60 * 8;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            counter = 0;
            rotationGoal = 0;
        }

        public override void AI()
        {
            projectile.velocity *= .98f;

            counter++;
            if(counter == 24)
                rotationGoal += (float)Math.PI / 4;
            if(counter > 30)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (Main.myPlayer == projectile.owner)
                        Projectile.NewProjectile(projectile.Center, new Vector2((float)Math.Cos(projectile.rotation + i * Math.PI / 2) * 4, (float)Math.Sin(projectile.rotation + i * Math.PI / 2) * 4), ModContent.ProjectileType<YuleConjuration2>(), projectile.damage, 3f, projectile.owner);
                }
                counter = 0;
            }
            if (projectile.rotation < rotationGoal)
                projectile.rotation += .2f;
        }
    }
}