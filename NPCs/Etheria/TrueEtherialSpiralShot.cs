using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;

namespace Laugicality.NPCs.Etheria
{
    public class TrueEtherialSpiralShot : ModNPC
    {
        float theta = -1;
        float dist = 0;
        float distRate = 1;
        Vector2 origin;
        public bool bitherial = true;
        public override void SetStaticDefaults()
        {
            LaugicalityVars.ENPCs.Add(npc.type);
            DisplayName.SetDefault("True Etherial Pulse");
        }
        public override void SetDefaults()
        {
            distRate = 1;
            dist = 20;
            theta = -1;
            npc.width = 44;
            npc.height = 44;
            npc.damage = 70;
            npc.defense = 12;
            npc.lifeMax = 4500;
            npc.value = 0f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[24] = true;
            npc.dontTakeDamage = true;
            npc.scale = 1.5f;
        }
        
        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 300, true);
        }
        
        public override void AI()
        {
            if (theta == -1)
            {
                theta = npc.ai[1] * 6.28f / 12;
                origin = npc.position;
            }
            theta += 3.14f / 70;
            dist += distRate;
            distRate += .075f;
            float divisions = 6.28f / 12;
            Vector2 targetPos;
            targetPos.X = origin.X + dist * (float)Math.Cos(theta) - npc.width / 2;
            targetPos.Y = origin.Y + dist * (float)Math.Sin(theta);
            npc.position = targetPos;
            if(dist > 1600)
            {
                npc.active = false;
                npc.life = 0;
            }
            npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.57f / 2;
        }

        public override Color? GetAlpha(Color drawColor)
        {
            var b = 225;
            var b2 = 125;
            var b3 = 155;
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
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ObsidiumChunk"));
        }
    }
}
