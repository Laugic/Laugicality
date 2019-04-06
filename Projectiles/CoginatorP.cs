using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
    public class CoginatorP : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.thrown = true;
            projectile.penetrate = 3;      //this is how many enemy this projectile penetrate before desapear
            projectile.extraUpdates = 1;
            aiType = 507;
        }
        /*
        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 150f)       //how much time the projectile can travel before landing
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.15f;    // projectile fall velocity
                projectile.velocity.X = projectile.velocity.X * 0.99f;    // projectile velocity
            }
        }*/
        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hiting the terrain
            {
                projectile.Kill();
                if(Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("Coginator"), 1);
                }
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            return false;
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("Steamy"), 120);       //Add Onfire buff to the NPC for 1 second
        }
    }
}