using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
    public class WarlockStaff1 : ModProjectile
    {
        public bool bitherial = true;
        public bool stopped = false;
        public int power = 0;
        public int damage = 0;
        public int delay = 0;
        public bool spawned = false;
        public float theta = 0;
        public float vel = 0;
        public bool zImmune = true;
        public float tVel = 0;
        public float distance = 0;
        public Vector2 origin;
        public Vector2 originV;
        public double mag = 10;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Loki Spiral");
        }
        public override void SetDefaults()
        {
            mag = 10;
            zImmune = true;
            theta = 0;
            vel = 0;
            LaugicalityVars.eProjectiles.Add(projectile.type);
            power = 0;
            stopped = false;
            spawned = false;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 24;
            projectile.height = 24;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.timeLeft = 320;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }


        public override void AI()
        {
            if(origin.X == 0)
            {
                origin.X = projectile.position.X;
                origin.Y = projectile.position.Y;
                originV.X = projectile.velocity.X;
                originV.Y = projectile.velocity.Y;
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("WarlockStaff2"), projectile.damage, 3, Main.myPlayer);
            }
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Blue"), 0f, 0f);
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;
            theta -= 3.14f / 30;
            mag += 1.5;
            origin += originV/5;
            double targetX = origin.X + mag * Math.Cos(theta + 3.14) - projectile.width / 2;
            double targetY = origin.Y + mag * Math.Sin(theta + 3.14);
            //projectile.position.X = (float)targetX;
            //projectile.position.Y = (float)targetY;
            distance = (float)Math.Sqrt((targetX - projectile.position.X) * (targetX - projectile.position.X) + (targetY - projectile.position.Y) * (targetY - projectile.position.Y));
            tVel = distance / 6;
            projectile.netUpdate = true;
            if (vel < tVel)
            {
                vel += .2f;
                vel *= 1.1f;
            }
            if (vel > tVel)
            {
                vel = tVel;
            }
            projectile.velocity.X = (float)Math.Abs((projectile.position.X - targetX) / distance * vel);
            if (targetX < projectile.position.X)
                projectile.velocity.X *= -1;
            projectile.velocity.Y = (float)Math.Abs((projectile.position.Y - targetY) / distance * vel);
            if (targetY < projectile.position.Y)
                projectile.velocity.Y *= -1;
        }
    }
}