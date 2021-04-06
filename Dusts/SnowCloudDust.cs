using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Dusts
{
    public class SnowCloudDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= .25f;
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale = 2.5f + Main.rand.NextFloat();
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.velocity *= .9f;
            dust.scale *= 0.95f;
            if (dust.scale < .5f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}