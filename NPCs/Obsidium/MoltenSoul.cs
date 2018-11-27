using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;

namespace Laugicality.NPCs.Obsidium
{
    public class MoltenSoul : ModNPC
    {
        int shootDel = 0;
        public override void SetDefaults()
        {
            shootDel = 300;
            //npc.frameWidth = 40;
            //npc.frameHeight = 34;
            npc.width = 56;
            npc.height = 56;
            npc.damage = 60;
            npc.defense = 22;
            npc.lifeMax = 2000;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.value = 6000f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 10;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[24] = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (LaugicalityWorld.obsidiumTiles > 150 && Main.hardMode)
                return SpawnCondition.Cavern.Chance * 0.15f;
            else return 0f;
        }

        public override void AI()
        {
            npc.rotation = 0;
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(npc.Center, npc.width / 2, 4, mod.DustType("Magma"), 0f, 0f);
            shootDel--;
            if (shootDel <= 0)
            {
                if (Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("MagmaBallLaunched"), (int)(npc.damage / 4f), 3, Main.myPlayer);
                shootDel = 60 * 5;
            }

        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 300, true);
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MagmaticCrystal"));
        }
    }
}
