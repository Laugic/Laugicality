using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace Laugicality.Particles
{
    public class Particle
    {
        public Particle(Texture2D texture, Vector2 pos, Vector2 velocity, int frames, float acceleration = 1, float rotation = 0, float rotAccel = 0, float scale = 1, float scaleMod = 1, int aniSpeed = 4, int timeLeft = 4 * 60, bool loop = false)
        {
            Texture = texture;
            Position = pos;
            FrameNum = frames;
            Velocity = velocity;
            Acceleration = acceleration;
            Rotation = rotation;
            RotAccel = rotAccel;
            Scale = scale;
            ScaleMod = scaleMod;
            Speed = aniSpeed;
            TimeLeft = timeLeft;
            Loop = loop;
        }


        public virtual void Update()
        {
            Position += Velocity;
            Velocity *= Acceleration;
            Rotation += RotAccel;
            Scale *= ScaleMod;
            TimeLeft--;
            if (Scale < .05f)
                TimeLeft = 0;
            FrameCalc();
        }

        public virtual void Draw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (TimeLeft <= 0)
                return;

            Rectangle rect = new Rectangle(0, CurrentFrame * Texture.Height / FrameNum, Texture.Width, Texture.Height / FrameNum);
            spriteBatch.Draw(Texture, Position - Main.screenPosition/* - new Vector2(Texture.Width / 2, Texture.Height / FrameNum / 2)*/, rect, lightColor, Rotation, new Vector2(Texture.Width / 2, Texture.Height / FrameNum / 2), Scale, SpriteEffects.None, 0f);
        }

        public void FrameCalc()
        {
            FrameCounter++;
            if (FrameCounter > Speed)
            {
                FrameCounter = 0;
                CurrentFrame++;
                if (CurrentFrame >= FrameNum)
                {
                    if (Loop)
                        CurrentFrame = 0;
                    else
                        TimeLeft = 0;
                }
            }
        }

        public virtual Texture2D Texture { get; set; }
        public virtual Vector2 Position { get; set; }
        public virtual Vector2 Velocity { get; set; }
        public virtual int FrameNum { get; set; }
        public virtual float Acceleration { get; set; }
        public virtual float Rotation { get; set; }
        public virtual float RotAccel { get; set; }
        public virtual float Scale { get; set; }
        public virtual float ScaleMod { get; set; }
        public virtual int FrameCounter { get; set; }
        public virtual int CurrentFrame { get; set; }
        public virtual int Speed { get; set; }
        public virtual int TimeLeft { get; set; }
        public virtual bool Loop { get; set; }
    }
}
