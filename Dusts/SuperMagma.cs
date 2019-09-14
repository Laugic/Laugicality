using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Dusts
{
	public class SuperMagma : ModDust
    {
        int counter = 0;
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale *= 3.0f;
            counter = 0;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            float light = 0.35f * dust.scale;
            Lighting.AddLight(dust.position, light, light, light);
            dust.scale *= 1.01f;
            if (dust.scale > 4.0f)
            {
                if (dust.alpha < 255)
                {
                    dust.alpha += 12;
                }
                else
                {
                    dust.active = false;
                }
            }
            return false;
        }
    }
}