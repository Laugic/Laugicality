using Terraria;
using Terraria.ID;
using System;

namespace Laugicality.Projectiles.Summon
{

    public class UltimateLeader3 : HoverShooter
    {
        public int vMax = 0;
        public float vAccel = 0;
        public float tVel = 0;
        public float vMag = 0;
        public int index = 0;
        public float theta = 0f;
        public int reload = 0;
        public int reloadMax = 60;
        public override void SetStaticDefaults()
        {
            reload = 0;
            reloadMax = 60;
            Main.projFrames[projectile.type] = 3;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            theta = 0f;
            index = 0;
            vMax = 14;
            vAccel = .1f;
            projectile.netImportant = true;
            projectile.width = 24;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 0f;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            inertia = 12f;
            shoot = mod.ProjectileType("UltimateLeader4");
            shootCool = 30f;
            shootSpeed = 18f;
        }

        public override void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (player.dead)
            {
                modPlayer.UltraBoisSummon = false;
            }
            if (modPlayer.UltraBoisSummon)
            {
                projectile.timeLeft = 2;
            }
        }

        public override void CreateDust()
        {
            projectile.rotation = 1f/2f*3.14f;
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
        }

        public override void Behavior()
        {
            Player player = Main.player[projectile.owner];
            index = player.ownedProjectileCounts[mod.ProjectileType("UltimateLeader2")];

            theta += 3.14f / 60f;
            float mag = index / 2f + 2;
            //Movement
            projectile.position.X = player.Center.X - projectile.width * 2 - 4;
            projectile.position.Y = player.position.Y - 32 - mag - mag * (float)Math.Sin(theta);

            //Attacks
            if (reload > 0)
                reload--;
            if (index < 6)
            {
                reloadMax = 70 - 2 * index;
                if(reload <= 0)
                {
                    reload = reloadMax;
                    Projectile.NewProjectile(projectile.Center.X + projectile.width * 2 - 5 + Main.rand.Next(10), projectile.Center.Y, 0, 0, mod.ProjectileType("UltimateLeader4"), (int)(projectile.damage * index / 2), 3, Main.myPlayer);

                }
            }
            else if (index < 12)
            {
                reloadMax = 50 - index;
                if (reload <= 0)
                {
                    reload = reloadMax;
                    Projectile.NewProjectile(projectile.Center.X + projectile.width * 2 - 5 + Main.rand.Next(10), projectile.Center.Y, 0, 0, mod.ProjectileType("UltimateLeader5"), (int)(projectile.damage * index / 3), 3, Main.myPlayer);

                }
            }
            else
            {
                reloadMax = 30;
                if (reload <= 0)
                {
                    reload = reloadMax;
                    Projectile.NewProjectile(projectile.Center.X + projectile.width * 2 - 5 + Main.rand.Next(10), projectile.Center.Y - 5 + Main.rand.Next(10), 0, 0, mod.ProjectileType("UltimateLeader6"), (int)(projectile.damage * index / 4), 3, Main.myPlayer);

                }
            }


            //Frame
            if (index < 6)
            {
                projectile.frame = 0;
            }
            else if (index < 12)
            {
                projectile.frame = 1;
            }
            else
            {
                projectile.frame = 2;
            }
            projectile.netUpdate = true;
        }
    }
}