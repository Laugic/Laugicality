using System;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.RockTwins
{
    public class LaserBall : ModNPC
    {
        public int laserBallNum = 0;
        public static int life = 0;
        public bool zImmune = true;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("LaserBall"); 
		}
        public override void SetDefaults()
        {
            zImmune = true;
            life = 0;
            laserBallNum = 0;
            npc.width = 16;
			npc.height = 16;
			npc.aiStyle = -1;
			//aiType = 429;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 2000;
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
            npc.dontTakeDamage = true;
            npc.netAlways = true;
        }
		public override bool CheckActive()
		{
			if(NPC.CountNPCS(ModContent.NPCType<Andesia>()) < 1)
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
            npc.life = life;
            int flameCount = 1;
            if(laserBallNum == 0)
            {
                laserBallNum = (int)Main.npc[(int)npc.ai[3]].ai[1];
                Main.npc[(int)npc.ai[3]].ai[1]++;
            }
            flameCount = NPC.CountNPCS(ModContent.NPCType<LaserBall>());
            float divisions = 6.28f / flameCount;
            float flameTheta = Main.npc[(int)npc.ai[3]].ai[0] + laserBallNum * divisions;
            double targetX = Andesia.posX + Andesia.dist * Math.Cos(flameTheta) - npc.width / 2;
            double targetY = Andesia.posY + Andesia.dist * Math.Sin(flameTheta);
            npc.position.X = (float)targetX;
            npc.position.Y = (float)targetY;
           
            
            for (int k = 0; k < 2; k++)
            {                                                                                               
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Blue>(), 0f, 0f);
            }
		}
		
    }
}