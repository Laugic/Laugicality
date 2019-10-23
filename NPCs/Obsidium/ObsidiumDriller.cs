using System;
using Laugicality.Dusts;
using Laugicality.Items.Loot;
using Laugicality.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Obsidium
{
    public class ObsidiumDriller : ModNPC
    {
        public override void SetDefaults()
        {
            npc.width = 72;
            npc.height = 48;
            npc.damage = 22;
            npc.defense = 14;
            npc.lifeMax = 100;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.value = 60f;
            npc.knockBackResist = 0.4f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[24] = true;
        }
        /*
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (LaugicalityWorld.obsidiumTiles > 150 && spawnInfo.spawnTileY > WorldGen.rockLayer)
                return SpawnCondition.Cavern.Chance * 0.15f;
            else return 0f;
        }*/

        public override void AI()
        {
            //Retarget (borrowed from Dan <3)
            Player p = Main.player[npc.target];
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            npc.netUpdate = true;

            if (npc.Center.Y - Main.player[npc.target].Center.Y > 24)
            {
                if (npc.velocity.Y > 0)
                    npc.velocity.Y *= .9f;
                else if (Main.rand.Next(5) == 0)
                    Dust.NewDust(npc.Center, npc.width / 2, 4, ModContent.DustType<Magma>(), 0f, 0f);
                npc.velocity.Y -= .2f;
            }
            else if (npc.Center.Y - Main.player[npc.target].Center.Y < -36)
            {
                if (npc.velocity.Y < 0)
                    npc.velocity.Y *= .9f;
                else if (Main.rand.Next(5) == 0)
                    Dust.NewDust(npc.Center, npc.width / 2, 4, ModContent.DustType<Magma>(), 0f, 0f);
                npc.velocity.Y += .2f;
            }
            else
            {
                if ((float)Math.Abs(npc.velocity.Y) < 2f)
                {
                    npc.velocity.Y = 0;
                    if (Main.player[npc.target].Center.X < npc.Center.X)
                    {
                        if (npc.velocity.X > 0)
                            npc.velocity.X *= .9f;
                        else if (Main.rand.Next(5) == 0)
                            Dust.NewDust(npc.Center, npc.width / 2, 4, ModContent.DustType<Magma>(), 0f, 0f);
                        npc.velocity.X -= .5f;
                    }
                    if (Main.player[npc.target].Center.X > npc.Center.X)
                    {
                        if (npc.velocity.X < 0)
                            npc.velocity.X *= .9f;
                        else if (Main.rand.Next(5) == 0)
                            Dust.NewDust(npc.Center, npc.width / 2, 4, ModContent.DustType<Magma>(), 0f, 0f);
                        npc.velocity.X += .5f;
                    }
                }
                npc.velocity.Y *= .9f;
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
            if (LaugicalityWorld.downedRagnar && Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ObsidiumChunk>());
            }
            else
            {
                if (NPC.downedBoss2)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ObsidiumOre>(), Main.rand.Next(1, 4));
                else
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 173, Main.rand.Next(4));
            }
        }
    }
}
