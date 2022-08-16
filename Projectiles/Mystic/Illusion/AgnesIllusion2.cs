using Laugicality.Buffs;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
    public class AgnesIllusion2 : IllusionProjectile
    {
        public float mag = 0;
        Vector2 origin;
        double theta = 0;
        bool spawned = false;
        public override void SetDefaults()
        {
            theta = 0;
            projectile.width = 22;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 4 * 60;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            spawned = false;
            buffID = ModContent.BuffType<InfernalBuff>();
        }
        public override void AI()
        {
            if(!spawned)
            {
                spawned = true;
                theta = Main.rand.NextDouble() * Math.PI * 2;
                origin = projectile.position;
                mag = 20;
            }
            if(Main.rand.Next(8) == 0)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Magma>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

            //projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            theta += Math.PI / 60;
            mag += .4f;
            var targetPos = new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag) + origin;
            projectile.velocity = projectile.DirectionTo(targetPos) * projectile.Distance(targetPos) / 4;
        }
    }
}