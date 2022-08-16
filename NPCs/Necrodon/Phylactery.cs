using Laugicality.Dusts;
using Laugicality.Items.Loot;
using Laugicality.Items.Placeable;
using Laugicality.Projectiles.NPCProj;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Necrodon
{
    [AutoloadBossHead]
    public class Phylactery : ModNPC
    {
        private int counter = 0;
        private static int TEMPO_CHANGE = 5858;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 2;
            LaugicalityVars.etherial.Add(npc.type);
            DisplayName.SetDefault("Phylactery");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.width = 156;
            npc.height = 128;
            npc.damage = 40;
            npc.defense = 9999;
            npc.takenDamageMultiplier = .01f;
            npc.lifeMax = 400000;
            npc.HitSound = SoundID.NPCHit11;
            npc.DeathSound = SoundID.NPCDeath15;
            npc.value = 0;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = -1;
            npc.ai[2] = 0;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Necrodungeon");
            bossBag = ModContent.ItemType<DuneSharkronTreasureBag>();
            counter = -8;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (LaugicalityWorld.downedEtheria && spawnInfo.player.ZoneDungeon && NPC.CountNPCS(ModContent.NPCType<Phylactery>()) == 0)
                return SpawnCondition.Dungeon.Chance;
            else return 0f;
        }

        public override void AI()
        {
            npc.ai[1]++;
            counter++;
            if ((npc.ai[1] >= 66.6666666 && counter < TEMPO_CHANGE) || (npc.ai[1] > 63.158 && counter >= TEMPO_CHANGE))
            {
                NoteSpawn();
                npc.ai[1] = 1;
            }
        }

        private void NoteSpawn()
        {
            npc.ai[0] = 10;
            switch(npc.ai[2] % 4)
            {
                case 0:
                    SpawnRotate((int)npc.ai[2] % 8 == 0);
                    break;
                case 1:
                    SpawnSixteenths();
                    break;
                case 2:
                    SpawnDoubleEighth();
                    break;
                default:
                    SpawnQuarters();
                    break;
            }
            npc.ai[2]++;
        }

        private void SpawnSixteenths()
        {
            float mag = 6;
            var theta = 0;
            for (int i = 0; i < 16; i++)
                Projectile.NewProjectile(npc.Center, new Vector2((float)Math.Cos(theta + i * Math.PI / 8) * mag, (float)Math.Sin(theta + i * Math.PI / 8) * mag), ModContent.ProjectileType<Sixteenth>(), npc.damage, 3f, Main.myPlayer, npc.whoAmI, i);
        }

        private void SpawnDoubleEighth()
        {
            Vector2 targetPos = Main.player[0].Center;
            Vector2 vel = targetPos - npc.Center;
            vel.Normalize();
            vel *= 4;
            Projectile.NewProjectile(npc.Center, vel, ModContent.ProjectileType<DoubleEighth>(), npc.damage, 3f, Main.myPlayer, npc.whoAmI);
        }

        private void SpawnQuarters()
        {
            float mag = 4;
            var theta = Main.rand.NextDouble() * 2 * Math.PI;
            for (int i = 0; i < 4; i++)
                Projectile.NewProjectile(npc.Center, new Vector2((float)Math.Cos(theta + i * Math.PI / 2) * mag, (float)Math.Sin(theta + i * Math.PI / 2) * mag), ModContent.ProjectileType<Quarter>(), npc.damage, 3f, Main.myPlayer, npc.whoAmI, i);
        }

        private void SpawnRotate(bool flipped)
        {
            if (flipped)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (i == 4)
                        i += 4;
                    Projectile.NewProjectile(npc.Center, new Vector2(), ModContent.ProjectileType<PhylacteryRotate>(), npc.damage, 3f, Main.myPlayer, npc.whoAmI, i);
                }
            }
            else
            {
                for (int i = 4; i < 16; i++)
                {
                    if (i == 8)
                        i += 4;
                    Projectile.NewProjectile(npc.Center, new Vector2(), ModContent.ProjectileType<PeriodicalRotateNotes>(), npc.damage, 3f, Main.myPlayer, npc.whoAmI, i);
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.ai[0] > 0)
                npc.ai[0]--;
            npc.frame.Y = frameHeight * (npc.ai[0] > 0 ? 1 : 0);
        }
    }
}
