using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.BossSummons
{
	public class GeneralBossSpawn : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 6;
			projectile.height = 6;
			projectile.aiStyle = 1;
			projectile.scale = 1f;
			projectile.penetrate = 1;
			projectile.timeLeft = 20;
			projectile.tileCollide = false;
			aiType = ProjectileID.Bullet;
            LaugicalityVars.zProjectiles.Add(projectile.type);
        }
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.ai[1]++;
			
			if (projectile.ai[1] >= 0)
			{
				Main.PlaySound(15, (int)player.position.X, (int)player.position.Y-50, 0);
                if(projectile.damage != NPCID.WallofFlesh)
				NPC.SpawnOnPlayer(player.whoAmI, (int)projectile.damage);
                else
                {
                    if(player.position.X > Main.maxTilesX / 2)
                        NPC.NewNPC((int)player.position.X + 160, (int)player.position.Y, NPCID.WallofFlesh);
                    else
                        NPC.NewNPC((int)player.position.X - 160, (int)player.position.Y, NPCID.WallofFlesh);
                }
				projectile.ai[1] = -30;
			}
		}
	}
}