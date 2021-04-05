using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Dusts
{
    public class SteamTrailDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.2f;
            dust.velocity.X *= .8f + Main.rand.NextFloat() * .4f;
            dust.velocity.Y *= .8f + Main.rand.NextFloat() * .4f;
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale *= 2.0f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.05f;
            dust.scale *= 1.01f;
            if (dust.scale > 3.0f)
                dust.alpha += 2;
            if (dust.alpha < 255)
                dust.alpha += 5;
            else
                dust.active = false;
            return false;
        }
    }
}