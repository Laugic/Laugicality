using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.TheGreatShadow
{
    [AutoloadBossHead]
    public class TheGreatShadow : ModNPC
    {
        public bool bitherial = true;
        public int damage = 0;
        public int delay = 0;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.ENPCs.Add(npc.type);
            DisplayName.SetDefault("The Great Shadow");
        }

        public override void SetDefaults()
        {
            delay = 0;
            bitherial = true;
            npc.width = 30;
            npc.height = 48;
            npc.damage = 28;
            npc.defense = 10;
            npc.aiStyle = 0;
            npc.lifeMax = 2600;
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
            damage = 24;
            bossBag = mod.ItemType("HypothemaTreasureBag");
            npc.dontTakeDamage = true;
            npc.friendly = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 3000 + numPlayers * 800;
            npc.damage = 36;
            damage = 34;
        }


        public override void AI()
        {
            //if (Main.player[npc.target].statLife <= 0) { npc.position.Y += 20; }
            //if (Main.player[npc.target].ZoneSnow == false) { npc.position.Y += 20; }
            Vector2 delta = Main.player[npc.target].Center - npc.Center;
            float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
            

            Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, mod.DustType("Black"), 0f, 0f);
            Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, mod.DustType("Black"), 0f, 0f);

            //Main.NewText(vaccel.ToString(), 250, 0, 0);
            delay++;
            if(delay == 180)
            {
                delay = 0;
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/zurg"));
                if(Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("ShadowBurst"), 0, 3f, Main.myPlayer);
                for(int k = 0; k< 8; k++)
                {
                    if (Main.player[k].active)
                        {
                            LaugicalityPlayer modPlayer = Main.player[k].GetModPlayer<LaugicalityPlayer>(mod);
                            modPlayer.shakeDur = 60;
                            modPlayer.shakeMag = 1f;
                        }
                }			    
            }

        }



        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {

        }

        public override void NPCLoot()
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
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
