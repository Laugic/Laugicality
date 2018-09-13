using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
    public class Daggoritus : ModProjectile
    {
        public int delay = 20;
        public override void SetDefaults()
        {
            delay = 10;
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.thrown = true;
            projectile.penetrate = -1;      
            projectile.extraUpdates = 1;
            aiType = 48;
        }

        public override void AI()
        {
            delay--;
            if(delay == 0)
            {
                delay = 15;
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 7, mod.ProjectileType("DaggorShard"), (int)(projectile.damage), 3, Main.myPlayer);
            }
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 150f)       //how much time the projectile can travel before landing
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.15f;    // projectile fall velocity
                projectile.velocity.X = projectile.velocity.X * 0.99f;    // projectile velocity
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           
            {
                projectile.Kill();

                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            return false;
        }
        /*
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 80);     
        }*/
    }
}