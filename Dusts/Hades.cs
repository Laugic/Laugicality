using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Dusts
{
	public class Hades : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0f;
            dust.noGravity = false;
            dust.noLight = true;
            dust.scale *= 2f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += Main.rand.Next(3);
            dust.scale *= 0.95f;
            float light = 0.8f;
            Lighting.AddLight(dust.position, light, light, light);
            if (dust.scale < 0.5f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}