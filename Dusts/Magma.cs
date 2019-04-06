using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Dusts
{
	public class Magma : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.8f;
            dust.velocity.Y *= 0.8f;
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale *= 2.0f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.97f;
            float light = 0.35f * dust.scale;
            Lighting.AddLight(dust.position, light, light, light);
            if (dust.scale < 0.65f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}