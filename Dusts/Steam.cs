using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Dusts
{
	public class Steam : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.2f;
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale *= 5.0f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.99f;
            if (dust.scale < 2.0f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}