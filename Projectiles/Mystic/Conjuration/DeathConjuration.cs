using System;
using Laugicality.Dusts;
using Laugicality.NPCs.RockTwins;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class DeathConjuration : PrimaryConjurationProjectile
    {
        public Color colorType;
        float rotSpd = .4f;
        Vector2 offset = new Vector2();
        public override void SetDefaults()
        {
            projectile.width = 56;
            projectile.height = 56;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 12 * 60;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            rotSpd = (.3f + Main.rand.NextFloat() * .2f);
        }

        public override void AI()
        {
            Visuals();
            Movement();
            Effects();
        }

        private void Effects()
        {

        }

        private void Movement()
        {
            Player player = Main.player[projectile.owner];
            var dist = (player.Center - projectile.Center);
            if (dist.Length() > 150)
            {
                if (player.velocity.Length() < 1)
                    offset = new Vector2(-40 + Main.rand.Next(80), -40 + Main.rand.Next(80));
                projectile.velocity = (player.Center + offset + player.velocity - projectile.Center) / (20 + rotSpd * 4);
            }
            else if (projectile.velocity.Length() > 2)
                projectile.velocity *= .9f;
        }

        private void Visuals()
        {
            if(projectile.velocity.X > 0)
                projectile.rotation += rotSpd;
            else
                projectile.rotation -= rotSpd;

            if (projectile.timeLeft < 80)
            {
                projectile.alpha += 2;
            }
        }

        public void Burst()
        {
            if (Main.myPlayer == projectile.owner)
            {
                for (int i = 0; i < 20; i++)
                {
                    var theta = (float)(Math.PI * Main.rand.NextDouble() * 2);
                    Vector2 newVel = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                    newVel *= 10;
                    int id = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, newVel.X, newVel.Y, ModContent.ProjectileType<DeathConjurationSkull>(), projectile.damage, 3, Main.myPlayer);
                    Main.projectile[id].ai[1] = 3;
                }
            }
            projectile.timeLeft += 3 * 60;
        }
    }
}
