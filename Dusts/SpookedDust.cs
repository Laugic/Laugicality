using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Dusts
{
	public class SpookedDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0f;
            dust.noGravity = false;
            dust.noLight = true;
            dust.scale *= 1.5f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += Main.rand.Next(3);
            dust.scale *= 0.95f;
            Lighting.AddLight(dust.position, .4f, .4f, .4f);
            if (dust.scale < 0.25f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}