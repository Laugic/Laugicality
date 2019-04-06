using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Dusts
{
	public class Bubble : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.2f;
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale = Main.rand.Next(100) * .02f + 1.25f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            if (dust.velocity.Y > -4f)
                dust.velocity.Y -= .05f;
            dust.rotation = 0;
            dust.scale *= 0.99f;
            if (dust.scale < .2f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}