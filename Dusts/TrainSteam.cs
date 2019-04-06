using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Dusts
{
	public class TrainSteam : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity.X *= 0.1f;
            dust.velocity.Y = -1f;
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale = 4.0f;
            dust.alpha = 0;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 1.01f;
            if (dust.scale > 7.0f)
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