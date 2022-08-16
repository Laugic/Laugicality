using System;
using Laugicality.Buffs;
using Laugicality.Items.Loot;
using Laugicality.Items.Placeable;
using Laugicality.NPCs.Slybertron;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.SteamTrain
{
    [AutoloadBossHead]
    public class SteamTrain : ModNPC
    {
        private int _despawn;
        public float MaxVelocity = 20;
        public float Acceleration = .2f;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(npc.type);
            DisplayName.SetDefault("Steam Train");
        }

        public override void SetDefaults()
        {
            MaxVelocity = 20;
            Acceleration = .2f;
            npc.width = 252;
            npc.height = 138;
            npc.damage = 90;
            npc.defense = 30;
            npc.aiStyle = -1;
            npc.lifeMax = 42000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.netAlways = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/SteamTrain");
            bossBag = ModContent.ItemType<SteamTrainTreasureBag>();
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 50000 + numPlayers * 6000;
            npc.damage = 100;
        }

        public override bool CheckActive()
        {
            if (_despawn < 300)
                return false;
            return true;
        }

        private void Retarget()
        {
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            npc.netUpdate = true;
        }

        private void DespawnCheck()
        {
            if (!Main.player[npc.target].active || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
                if (!Main.player[npc.target].active || Main.player[npc.target].dead)
                {
                    if (_despawn == 0)
                        _despawn++;
                }
                else
                    _despawn = 0;
            }
            if (_despawn >= 1)
            {
                _despawn++;
                npc.noTileCollide = true;
                npc.velocity.Y = 8f;
                if (_despawn >= 300)
                    npc.active = false;
            }
        }

        public override void AI()
        {
            Retarget();
            DespawnCheck();
            if(_despawn == 0)
                Move();
        }

        private void Move()
        {
            if(npc.Center.X + npc.width / 2 < Main.player[npc.target].Center.X)
            {
                if (npc.velocity.X < 0)
                    npc.velocity *= .9f;
                npc.velocity.X = Math.Min(npc.velocity.X + Acceleration, MaxVelocity);
                npc.spriteDirection = -1;
            }
            if (npc.Center.X - npc.width / 2 > Main.player[npc.target].Center.X)
            {
                if (npc.velocity.X > 0)
                    npc.velocity *= .9f;
                npc.velocity.X = Math.Max(npc.velocity.X - Acceleration, -MaxVelocity);
                npc.spriteDirection = 1;
            }
            
            if (npc.Center.Y + npc.height / 2 < Main.player[npc.target].Center.Y)
            {
                if (npc.velocity.Y < 0)
                    npc.velocity *= .9f;
                npc.velocity.Y = Math.Min(npc.velocity.Y + Acceleration / 5f, MaxVelocity / 5f);
            }
            if (npc.Center.Y - npc.height / 2 > Main.player[npc.target].Center.Y)
            {
                if (npc.velocity.Y > 0)
                    npc.velocity *= .9f;
                npc.velocity.Y = Math.Max(npc.velocity.Y - Acceleration / 5f, -MaxVelocity / 5f);
            }
        }

        /*
        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            if (Main.expertMode)
                player.AddBuff(ModContent.BuffType<Steamy>(), 90, true);
        }*/

        public override void NPCLoot()
        {
            if (LaugicalityWorld.downedEtheria)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EtherialTank>(), 1);

            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SteamBar>(), Main.rand.Next(15, 30));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SoulOfWrought>(), Main.rand.Next(20, 40));
            }

            if (Main.expertMode)
                npc.DropBossBags();

            if (Main.rand.Next(10) == 0)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SteamTrainTrophy>(), 1);

            LaugicalityWorld.downedSteamTrain = true;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 499;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 0f;
            return null;
        }
    }
}
