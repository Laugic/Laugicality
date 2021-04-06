using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Dusts
{
    public class SteamTrailDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
            dust.alpha = 0;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 1.01f;
            if (dust.scale > 2.0f)
            {
                if (dust.alpha < 255)
                {
                    dust.alpha += 5;
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