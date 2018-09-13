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
    public class ZaWarudo : ModNPC
    {
        public int id = 0;
        public int life = -1000;
        public bool buffed = false;
        public bool zImmune = true;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.ZNPCs.Add(npc.type);
            DisplayName.SetDefault("");
        }

        public override void SetDefaults()
        {
            zImmune = true;
            life = -1000;
            //npc.frameWidth = 40;
            //npc.frameHeight = 34;
            npc.width = 1;
            npc.height = 1;
            npc.damage = 0;
            npc.defense = 12;
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
            zImmune = true;
            if(!buffed)
            {
                life = LaugicalityWorld.zWarudo;
                buffed = true;
            }
            life -= 1;
            if (life <= 0)
                npc.active = false;
        }

        public override bool CheckActive()
        {
            return false;
        }

    }
}
