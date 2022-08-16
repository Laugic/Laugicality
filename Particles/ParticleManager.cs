using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laugicality.Particles
{
    public static class ParticleManager
    {
        public static void UpdateParticles(ref List<Particle> particles)
        {
            var partToRemove = new List<Particle>();
            foreach (var particle in particles)
            {
                particle.Update();
                if (particle.TimeLeft <= 0)
                    partToRemove.Add(particle);
            }
            foreach (var particle in partToRemove)
            {
                if (particles.Contains(particle))
                    particles.Remove(particle);
            }
        }

        public static void DrawParticles(SpriteBatch spriteBatch, Color lightColor, ref List<Particle> particles)
        {
            foreach (var particle in particles)
                particle.Draw(spriteBatch, lightColor);
        }

    }
}
