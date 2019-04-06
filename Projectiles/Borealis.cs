using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;
using System;

namespace Laugicality.Projectiles
{
    public class Borealis : ModProjectile
    {

        public override void SetDefaults()
        {
            //damage = projectile.damage;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 28;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
        }


        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            if (Main.rand.Next(2) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Etherial"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            int power = Main.rand.Next(4, 7);
            if ((LaugicalityWorld.downedEtheria || Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>(mod).etherable > 0) && LaugicalityWorld.downedTrueEtheria)
                    power *= 2;
            while (power > 0)
            {
                power -= 1;
                float theta = (float)Main.rand.Next(440) / 70f;
                float mag = (float)(Main.rand.Next(4, 7));
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, mag * (float)Math.Cos(theta), mag * (float)Math.Sin(theta), mod.ProjectileType("BysmalBlast"), projectile.damage, 3f, Main.myPlayer);
            }

            projectile.Kill();
            Main.PlaySound(SoundID.Item10, projectile.position);

            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int power = Main.rand.Next(4, 7);
            if ((LaugicalityWorld.downedEtheria || Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>(mod).etherable > 0) && LaugicalityWorld.downedTrueEtheria)
                power *= 2;
            while (power > 0)
            {
                power -= 1;
                float theta = (float)Main.rand.Next(440) / 70f;
                float mag = (float)(Main.rand.Next(4, 7));
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, mag * (float)Math.Cos(theta), mag * (float)Math.Sin(theta), mod.ProjectileType("BysmalBlast"), projectile.damage, 3f, Main.myPlayer);
            }

            projectile.Kill();
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
    }
}