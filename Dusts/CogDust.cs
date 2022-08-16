using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Dusts
{
    public class CogDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.2f;
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale = 1.5f + Main.rand.NextFloat();
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.velocity *= .95f;
            dust.scale *= 0.98f;
            if (dust.scale < .25f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}