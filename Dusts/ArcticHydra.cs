using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Dusts
{
    public class ArcticHydra : ModDust
    {
        int index = 0;

        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale = 3.0f;
            dust.alpha = 0;
        }

        public override bool Update(Dust dust)
        {
            dust.scale *= .99f;
            if(dust.scale <= .2f)
                dust.active = false;
            if (dust.alpha != 0)
            {
                index = dust.alpha;
                dust.alpha = 0;
            }
            dust.velocity.X = ((Main.player[index].Center.X + Main.player[index].velocity.X * 2) - dust.position.X) / 12;
            dust.velocity.Y = ((Main.player[index].Center.Y + Main.player[index].velocity.Y * 2) - dust.position.Y) / 12;
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale = .8f;
            if (Math.Sqrt((dust.position.X - Main.player[index].Center.X)* (dust.position.X - Main.player[index].Center.X) + (dust.position.Y - Main.player[index].Center.Y) * (dust.position.Y - Main.player[index].Center.Y)) < .1f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}