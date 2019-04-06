using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.NPCs.Etherial.BossFights
{
    public class FrostbiteBreath : ModProjectile
    {
        public bool bitherial = true;

        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 16;
            projectile.height = 16;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.timeLeft = 100;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            int dustID = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, mod.DustType("Etherial"), projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 3f * projectile.scale);
            Main.dust[dustID].noGravity = true;
        }
    }
}