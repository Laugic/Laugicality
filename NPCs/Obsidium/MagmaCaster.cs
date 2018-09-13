using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Obsidium
{
    public class MagmaCaster : ModNPC
    {
        int delay = 0;
        int reload = 0;
        public override void SetDefaults()
        {
            reload = 0;
            delay = 0;
            npc.width = 80;
            npc.height = 80;
            npc.damage = 36;
            npc.defense = 12;
            npc.lifeMax = 300;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 8;
            npc.lavaImmune = true;
            npc.buffImmune[24] = true;
            //npc.noGravity = true;
            //npc.noTileCollide = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 450;
            npc.damage = 48;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            var player = Main.LocalPlayer;
            var mPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);

            if (LaugicalityWorld.obsidiumTiles > 250 && spawnInfo.spawnTileY > WorldGen.rockLayer && LaugicalityWorld.downedRagnar)
                return SpawnCondition.Cavern.Chance * 0.75f;
            else return 0f;
        }

        public override void AI()
        {
            if (Main.player[npc.target].Center.X > npc.Center.X)
                npc.spriteDirection = 1;
            else
                npc.spriteDirection = 0;
            Vector2 adj;
            adj.X = -npc.width / 4;
            adj.Y = -npc.height / 2;
            if(Main.rand.Next(3) == 0)
                Dust.NewDust(npc.Center + adj, npc.width / 2, 12, mod.DustType("Magma"), 0f, 0f);
            delay--;
            if (delay <= 0)
            {
                reload++;
                if(reload < 45)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        if (Main.netMode != 1)
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, npc.velocity.X - 4 + Main.rand.Next(9), -Main.rand.Next(6, 9), mod.ProjectileType("EruptionEvil"), (int)(npc.damage / 2), 3, Main.myPlayer);
                    }
                }
                else
                {
                    reload = 0;
                    delay = 240;
                }
            }

        }
        

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            int debuff = BuffID.OnFire;
            if (debuff >= 0)
            {
                target.AddBuff(debuff, 90, true);
            }
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ObsidiumChunk"));
        }
        
    }
}
