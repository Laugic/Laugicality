using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Laugicality.Projectiles
{

    public class UltimateLeader2 : ModProjectile
    {
        public int vMax = 0;
        public float vAccel = 0;
        public float tVel = 0; //Target Velocity
        public float vMag = 0;
        public int index = 0;
        public float theta = 0f;

        public override void SetDefaults()
        {
            theta = 0f;
            index = 0;
            vMax = 14;
            vAccel = .1f;
            projectile.width = 38;
            projectile.height = 38;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            //projectile.aiStyle = 66;
            projectile.minionSlots = .5f;
            projectile.timeLeft = 18000;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            //aiType = 388;
        }
        

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;
            Player player = Main.player[projectile.owner];
            if (index == 0)
                index = player.ownedProjectileCounts[mod.ProjectileType("UltimateLeader2")] + 1;
            projectile.tileCollide = false;
            theta = player.GetModPlayer<LaugicalityPlayer>(mod).theta + 3.14f / 4 * index;
            float mag = 48 + index * 16;
            Vector2 rot = projectile.position;
            rot.X = (float)Math.Cos(theta) * mag;
            rot.Y = (float)Math.Sin(theta) * mag;
            Vector2 targetPos = Main.MouseWorld + rot;
            Vector2 direction = targetPos - projectile.Center;
            float dist = Vector2.Distance(targetPos, projectile.Center);
            tVel = dist / 15;
            if (vMag < vMax && vMag < tVel)
            {
                //vMag += vAccel;
                vMag = tVel;
            }

            if (vMag > tVel)
            {
                vMag = tVel;
            }

            if (dist != 0)
            {
                projectile.velocity = projectile.DirectionTo(targetPos) * vMag;
            }
                
            projectile.netUpdate = true;

            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (player.dead)
            {
                modPlayer.UltraBoisSummon = false;
            }
            if (modPlayer.UltraBoisSummon)
            {
                projectile.timeLeft = 2;
            }

            if (Main.rand.Next(5) == 0)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width / 2, projectile.height / 2, mod.DustType("White"));
                Main.dust[dust].velocity.Y -= 1.2f;
            }
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
        }
    }
}