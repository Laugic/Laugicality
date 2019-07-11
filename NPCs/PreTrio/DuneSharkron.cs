using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    [AutoloadBossHead]
    public class DuneSharkron : ModNPC
    {
        public bool Enraged { get; set; }
        public int MovementPhaseCounter { get; set; } = 0;
        public Vector2 targetPos;
        public int AttackCounter { get; set; } = 0;
        private int DespawnCounter { get; set; } = 0;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.ENPCs.Add(npc.type);
            DisplayName.SetDefault("Dune Sharkron");
        }

        public override void SetDefaults()
        {
            npc.width = 160;
            npc.height = 70;
            npc.damage = 35;
            npc.defense = 12;
            npc.aiStyle = 103;
            npc.lifeMax = 3000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/DuneSharkron");
            bossBag = mod.ItemType("DuneSharkronTreasureBag");
            npc.scale = 1.5f;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 4500 + numPlayers * 1500;
            npc.damage = 80;
        }

        private void Enrage()
        {
            Player player = Main.player[npc.target];
            Enraged = !player.ZoneDesert;
            if (Enraged)
            {
                npc.defense = 32;
                CrystalRain();
            }
            else
                npc.defense = 12;
        }

        private bool CheckDespawn()
        {
            if (Main.player[npc.target].statLife < 1 || Vector2.Distance(Main.player[npc.target].Center, npc.Center) > 2000)
            {
                DespawnCounter++;
                if (DespawnCounter > 300)
                    npc.active = false;
                return true;
            }
            DespawnCounter = 0;
            return false;
        }

        public override void AI()
        {
            if(CheckDespawn())
                return;
            Enrage();
            FollowAI();
        }

        private void FollowAI()
        {
            Player player = Main.player[npc.target];
            MovementPhaseCounter++;
            if (MovementPhaseCounter == 5 * 60 && npc.life < npc.lifeMax * 2 / 3)
            {
                if (Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center, new Vector2(0, -4), mod.ProjectileType<Sandnado>(), npc.damage / 4, 3f, npc.target, 0, 1);

                CrystalBurst(12);
            }
            if (MovementPhaseCounter > 5 * 60)
            {
                npc.velocity.Y = -12;
            }
            if (MovementPhaseCounter > 5 * 60 + 30)
            {
                MovementPhaseCounter = 0;
            }
            if (npc.Center.X < player.Center.X)
                npc.spriteDirection = -1;
            else
                npc.spriteDirection = 1;
            if (npc.Center.X < player.Center.X - 800)
                npc.velocity.X = 8;
            if (npc.Center.X > player.Center.X + 800)
                npc.velocity.X = -8;
            if (npc.Center.Y > player.Center.Y + 300)
                npc.velocity.Y = -8;
            if (npc.Center.Y < player.Center.Y)
                CrystalRain();
        }

        private void CrystalRain()
        {
            AttackCounter++;
            if (AttackCounter > 15)
            {
                float theta = Main.rand.NextFloat() * (float)Math.PI;
                float mag = Main.rand.NextFloat() * 3 + 3;
                if (Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * -mag), mod.ProjectileType<SharkronCrystalShard>(), npc.damage / 4, 3f);
                if (npc.life < npc.lifeMax / 2)
                {
                    theta = Main.rand.NextFloat() * (float)Math.PI;
                    mag = Main.rand.NextFloat() * 3 + 3;
                    if (Main.netMode != 1)
                        Projectile.NewProjectile(npc.Center, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * -mag), mod.ProjectileType<SharkronCrystalShard>(), npc.damage / 4, 3f);
                }
                AttackCounter = 0;
            }
        }

        private void CrystalBurst(int amount)
        {
            if (amount < 1)
                amount = 1;
            for (int i = 0; i < amount; i++)
            {
                float theta = Main.rand.NextFloat() * (float)Math.PI;
                float mag = Main.rand.NextFloat() * 3 + 3;
                if (Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * -mag), mod.ProjectileType<SharkronCrystalShard>(), npc.damage / 4, 3f);
            }
        }

        private float MoveToTarget(float mag)
        {
            float dist = Vector2.Distance(targetPos, npc.Center);

            if (dist != 0)
            {
                npc.velocity = npc.DirectionTo(targetPos) * mag;
            }
            return dist;
        }

        public override void NPCLoot()
        {
            if (LaugicalityWorld.downedEtheria)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Etheramind"), 1);
            }
            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientShard"), Main.rand.Next(1, 3));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Crystilla"), Main.rand.Next(4, 11));

                int ran = Main.rand.Next(1, 8);
                if (ran == 1) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SandstorminaBottle, 1);
                if (ran == 2) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FlyingCarpet, 1);
                if (ran == 3) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BandofRegeneration, 1);
                if (ran == 4) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicMirror, 1);
                if (ran == 5) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CloudinaBottle, 1);
                if (ran == 6) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HermesBoots, 1);
                if (ran == 7) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EnchantedBoomerang, 1);
            }

            if (Main.expertMode)
            {
                npc.DropBossBags();
            }

            LaugicalityWorld.downedDuneSharkron = true;
        }


        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
        }
    }
}
