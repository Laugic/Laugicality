using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etheria
{
    public class EtherialTear : ModNPC
    {
        public static Random rnd = new Random();
        public static int ai = rnd.Next(1, 6);
        public static bool despawn = false;
        public bool bitherial = false;
        int index = 0;
        Vector2 targetPos;
        int delay = 0;
        public float tVel = 0f;
        public float vel = 0f;
        public float vMax = 14f;
        public float vAccel = .2f;
        public float vMag = 0f;
        public override void SetStaticDefaults()
        {
            LaugicalityVars.ENPCs.Add(npc.type);
            DisplayName.SetDefault("Etherial Tear");
        }

        public override void SetDefaults()
        {
            vMag = 0f;
            vMax = 14f;
            tVel = 0f;
            delay = 0;
            index = 0;
            bitherial = true;
            despawn = false;
            npc.width = 22;
            npc.height = 22;
            npc.damage = 70;
            npc.defense = 50;
            npc.lifeMax = 5000;
            npc.HitSound = SoundID.NPCHit54;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.knockBackResist = 0f;
            npc.aiStyle = -1;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.scale = 2;
        }

        public override void AI()
        {
            bitherial = true;
            if (index == 0)
            {
                if (NPC.CountNPCS(mod.NPCType("Etheria")) > 0)
                    index = Etheria.tearIndex;
            }
            if (NPC.CountNPCS(mod.NPCType("Etheria")) > 0)
            {
                float mag = 96 * Etheria.scale;
                Vector2 rot;
                rot.X = (float)Math.Cos(Etheria.thetaSlow + 3.14f * index / 4) * mag;
                rot.Y = (float)Math.Sin(Etheria.thetaSlow + 3.14f * index / 4) * mag;
                targetPos = Etheria.Center + rot;
            }
            else
            {
                npc.active = false;
                npc.life = 0;
            }
            delay++;
            if(delay > 360)
            {
                delay = 0;
                if (Main.netMode != 1)
                {
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("EtherialYeet"), (int)(npc.damage / 4), 3, Main.myPlayer);
                }
            }

            float dist = Vector2.Distance(targetPos, npc.Center);
            tVel = dist / 15;
            if (vMag < vMax && vMag < tVel)
            {
                vMag += vAccel;
                vMag = tVel;
            }

            if (vMag > tVel)
            {
                vMag = tVel;
            }

            if (vMag > vMax)
            {
                vMag = vMax;
            }

            if (dist != 0)
            {
                npc.velocity = npc.DirectionTo(targetPos) * vMag;
            }
            npc.rotation += 3.14f / 20f;
        }

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(44, 300, true);
        }

        public override Color? GetAlpha(Color drawColor)
        {
            var b = 125;
            var b2 = 225;
            var b3 = 255;
            if (drawColor.R != (byte)b)
            {
                drawColor.R = (byte)b;
            }
            if (drawColor.G < (byte)b2)
            {
                drawColor.G = (byte)b2;
            }
            if (drawColor.B < (byte)b3)
            {
                drawColor.B = (byte)b3;
            }
            return drawColor;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 0f;
            return null;
        }
    }
}
