using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.RockTwins
{
    public class AnDioLaserBall : ModNPC
    {
        public int laserBallNum = 0;
        public static int life = 2;
        public bool zImmune = true;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser Ball"); 
		}
        public override void SetDefaults()
        {
            zImmune = true;
            life = 2;
            laserBallNum = 0;
            npc.width = 16;
			npc.height = 16;
			npc.aiStyle = -1;
			//aiType = 429;
			npc.damage = 1;
			npc.defense = 0;
			npc.lifeMax = 2;
			npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCHit1;
			npc.knockBackResist = 0f;
			npc.value = Item.buyPrice(0, 0, 0, 0);
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Venom] = true;
			npc.buffImmune[BuffID.ShadowFlame] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
			npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            //npc.dontTakeDamage = false;
            npc.netAlways = true;
            npc.scale = 2f;
        }
		public override bool CheckActive()
		{
			if(NPC.CountNPCS(mod.NPCType("AnDio3")) < 1)
				return false;
			return true;
		}
        public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			//player.AddBuff(BuffID.Shadowflame, 300, true);
		}
        
		public override Color? GetAlpha(Color drawColor)
		{
			return Color.White;
		}
		public override void AI()
		{
            if (npc.life > life)
                npc.life = life;
            int flameCount = 1;
            if(laserBallNum == 0)
            {
                laserBallNum = Andesia.laserBallNum;
                Andesia.laserBallNum++;
            }
            flameCount = NPC.CountNPCS(mod.NPCType("AnDioLaserBall"));
            float divisions = 6.28f / flameCount;
            float flameTheta = AnDio3.theta + laserBallNum * divisions;
            double targetX = AnDio3.posX + AnDio3.dist * Math.Cos(flameTheta) - npc.width / 2;
            double targetY = AnDio3.posY + AnDio3.dist * Math.Sin(flameTheta);
            npc.position.X = (float)targetX;
            npc.position.Y = (float)targetY;
           
            
            for (int k = 0; k < 2; k++)
            {                                                                                               
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, mod.DustType("Blue"), 0f, 0f);
            }
		}
		
    }
}