using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Dusts
{
    public class SnowAccumulateDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale += .02f;
            if (dust.scale > 2f)
                dust.active = false;
            return false;
        }
    }
}