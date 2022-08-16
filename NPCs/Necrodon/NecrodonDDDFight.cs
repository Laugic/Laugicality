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
    public class NecrodonDDDFight : ModNPC
    {
        private int counter = 0;
        private float startTime = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necrodon");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.width = 32;
            npc.height = 28;
            npc.damage = 999;
            npc.lifeMax = 10000000;
            npc.HitSound = SoundID.NPCHit11;
            npc.DeathSound = SoundID.NPCDeath15;
            npc.value = 0;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.dontTakeDamage = true;
            npc.knockBackResist = -1;
            npc.ai[0] = 0;
            npc.ai[1] = 0;
            npc.ai[2] = 0;
            counter = 0;
            startTime = (float)Main.upTimer;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/DDD");
            bossBag = ModContent.ItemType<DuneSharkronTreasureBag>();
        }

        public override void AI()
        {
            counter++;
            if(counter % 60 == 0)
                Step();
        }

        private void Step()
        {
            npc.ai[1]++;
            if((int)npc.ai[1] % 4 == 0)
            {
                switch ((int)npc.ai[1] % 16)
                {
                    case 0:

                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                    default:
                        SpawnRotate((int)npc.ai[1] % 8 == 0);
                        break;
                }

            }
            Main.NewText(npc.ai[1]);
        }

        private void SpawnRotate(bool flipped)
        {
            if(flipped)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (i == 4)
                        i += 4;
                    Projectile.NewProjectile(npc.Center, new Vector2(), ModContent.ProjectileType<PeriodicalRotateNotes>(), npc.damage, 3f, Main.myPlayer, npc.whoAmI, i);
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

        private void NoteSpawn()
        {
            npc.ai[0] = 10;
            if (npc.ai[2] % 2 == 0)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, 0, ModContent.ProjectileType<Eighth>(), (int)(npc.damage / 4), 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, 0, ModContent.ProjectileType<Eighth>(), (int)(npc.damage / 4), 3, Main.myPlayer);
            }
            else
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 4, ModContent.ProjectileType<Eighth>(), (int)(npc.damage / 4), 3, Main.myPlayer);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -4, ModContent.ProjectileType<Eighth>(), (int)(npc.damage / 4), 3, Main.myPlayer);
            }
            npc.ai[2]++;
        }

        private float GetCurTime()
        {
            return (float)Main.upTimer - startTime;
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.ai[0] > 0)
                npc.ai[0]--;
            npc.frame.Y = frameHeight * (npc.ai[0] > 0 ? 1 : 0);
        }
    }
}
