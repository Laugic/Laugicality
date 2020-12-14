using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Dusts
{
    public class DeathMarkDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            if (dust.velocity.Y > -2f)
                dust.velocity.Y -= .05f;
            dust.rotation = 0;
            dust.scale *= 0.96f;
            if (dust.scale < .2f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}
