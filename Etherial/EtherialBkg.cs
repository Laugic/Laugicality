using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;

namespace Laugicality.Etherial
{
    public class EtherialBkg : ModNPC
    {
        public int id = 0;
        public int life = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("");
        }

        public override void SetDefaults()
        {
            life = 16;
            //npc.frameWidth = 40;
            //npc.frameHeight = 34;
            npc.width = 40;
            npc.height = 34;
            npc.damage = 0;
            npc.defense = 12;
            npc.life = 99999;
            npc.lifeMax = 99999;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.friendly = true;
            npc.dontTakeDamage = true;
        }
        
        public override void AI()
        {
            life -= 1;
            if (life == 0)
                npc.life = 0;
        }
        
    }
}
