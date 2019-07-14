using System;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    [AutoloadBossHead]
    public class Hypothema : ModNPC
    {
        public int despawn = 0;
        public int AttackCounter { get; set; } = 0;
        public override void SetStaticDefaults()
        {
            LaugicalityVars.ENPCs.Add(npc.type);
            DisplayName.SetDefault("Hypothema");
        }

        public override void SetDefaults()
        {
            npc.width = 64;
            npc.height = 64;
            npc.damage = 40;
            npc.defense = 10;
            npc.aiStyle = 0;
            npc.lifeMax = 3000;
            npc.HitSound = SoundID.NPCHit5;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Hypothema");
            bossBag = mod.ItemType("HypothemaTreasureBag");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 5000 + numPlayers * 2000;
            npc.damage = 80;
        }


        public override void AI()
        {
            DespawnCheck(npc);
            for(int i = 0; i < 3; i++)
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, mod.DustType<Frost>(), 0f, 0f);
            npc.dontTakeDamage = Main.player[npc.target].ZoneSnow == false;
            Movement();
            Attacks();
        }

        private void Movement()
        {

        }

        private void Attacks()
        {

        }

        private void DespawnCheck(NPC npc)
        {
            if (!Main.player[npc.target].active || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
                if (!Main.player[npc.target].active || Main.player[npc.target].dead)
                {
                    if (despawn == 0)
                        despawn++;
                }
                else
                    despawn = 0;
            }
            if (despawn >= 1)
            {
                despawn++;
                npc.noTileCollide = true;
                npc.velocity.Y = 8f;
                if (despawn >= 300)
                    npc.active = false;
            }
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            if (LaugicalityWorld.downedEtheria)
            {
                target.AddBuff(mod.BuffType("Frostbite"), 4 * 60, true);
            }
            if (Main.expertMode)
            {
                target.AddBuff(BuffID.Frostburn, 90, true);
                target.AddBuff(BuffID.Chilled, 60, true);
            }
        }

        public override void NPCLoot()
        {
            LaugicalityPlayer modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityWorld.downedEtheria)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialFrost"), 1);
            }
            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostShard"), Main.rand.Next(1, 3));
                if (Main.rand.Next(0, 3) != 0)
                {
                    int ran = Main.rand.Next(1, 7);
                    if (ran == 1) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,ItemID.IceBoomerang, 1);
                    if (ran == 2) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,ItemID.IceBlade, 1);
                    if (ran == 3) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,ItemID.IceSkates, 1);
                    if (ran == 4) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,ItemID.SnowballCannon, 1);
                    if (ran == 5) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,987, 1);
                    if (ran == 6) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,ItemID.FlurryBoots, 1);
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnowBlock, Main.rand.Next(30, 60));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IceBlock, Main.rand.Next(30, 60));

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChilledBar"), Main.rand.Next(16, 25));
            }

            if (Main.expertMode)
            {
                npc.DropBossBags();
            }

            LaugicalityWorld.downedHypothema = true;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
        }

    }
}
