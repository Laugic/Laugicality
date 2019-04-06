using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
	public class Sandnado : ModProjectile
	{
        public int delay = 0;
        public int delMax = 200;
        public bool bitherial = true;
        public float theta = 0f;
        public float tVel = 0f;
        public float vel = 0f;
        public float distance = 0;
        public float vMax = 7f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandnado");
		}

		public override void SetDefaults()
        {
            LaugicalityVars.EProjectiles.Add(projectile.type);
            theta = 0;
            distance = 0;
            tVel = 0f;
            vel = 0f;
            bitherial = true;
            delMax = 4;
            delay = 0;
            projectile.width = 16;
			projectile.height = 16;
			//projectile.alpha = 255;
            projectile.timeLeft = 300;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            //projectile.rotation = (float)(Main.rand.Next(5) * 3.14 / 4);
        }

		public override void AI()
        {
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sandy"), projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.5f);
            
            projectile.rotation += 0.02f;
            if (Main.rand.Next(4) == 0 && Main.netMode != 1)
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4+Main.rand.Next(0,9), -Main.rand.Next(5,8),  mod.ProjectileType("SandnadoUp"), (int)(projectile.damage / 1.27f), 3, Main.myPlayer);

            double targetX = Main.LocalPlayer.position.X;
            double targetY = Main.LocalPlayer.position.Y;
            distance = (float)Math.Sqrt((targetX - projectile.position.X) * (targetX - projectile.position.X) + (targetY - projectile.position.Y) * (targetY - projectile.position.Y));
            /*
            if (Main.LocalPlayer.statLife > 0 && distance > 240)
            {
                vMax = 11f;
            }
            else
                vMax = 3f;*/
            vMax = 4f;
            tVel = distance / 10;

            if (vel < tVel && (float)Math.Abs(vel) < vMax)
            {
                vel += .1f;
                vel *= 1.01f;
            }
            if (vel > tVel)
            {
                vel -= .1f;
                vel *= .99f;
            }

            delay++;
            if(delay >= delMax)
            {
                delay = 0;
                projectile.velocity.X = (float)Math.Abs((projectile.position.X - targetX) / distance * vel);
                if (targetX < projectile.position.X)
                    projectile.velocity.X *= -1;
                projectile.velocity.Y = (float)Math.Abs((projectile.position.Y - targetY) / distance * vel);
                if (targetY < projectile.position.Y)
                    projectile.velocity.Y *= -1;
            }
            
        }
        
    }
}