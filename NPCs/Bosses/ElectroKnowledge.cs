using System;
using Laugicality.Buffs;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Bosses
{
    public class ElectroKnowledge : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electro Knowledge");
        }

        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 32;
            projectile.height = 32;
            projectile.timeLeft = 8 * 60;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            projectile.ai[1]++;
            if(projectile.ai[1] > 45)
            {
                projectile.ai[1] = 0;
                if(Main.netMode != 1)
                {
                    float numBalls = 4;
                    double thetaInit = 0;
                    for (int i = 0; i < numBalls; i++)
                    {
                        float mag = 6 + Main.rand.NextFloat() * 4;
                        if (Main.netMode != 1)
                            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, mag * (float)Math.Cos(thetaInit + (Math.PI * 2) * (i / numBalls)), mag * (float)Math.Sin(thetaInit + (Math.PI * 2) * (i / numBalls)),
                                ModContent.ProjectileType<KnowledgeBolt>(), (int)(projectile.damage), 3, 0, .4f);
                    }
                }
            }
            if (Main.rand.Next(2) == 0)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Blue>(), -projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Steamy>(), 2 * 60 + Main.rand.Next(60), false);
        }
    }
}