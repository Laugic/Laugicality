using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.IO;

namespace Laugicality.NPCs
{
    public partial class LaugicalGlobalNPCs : GlobalNPC
    {
        public bool eFied = false;
        public bool mFied = false;//Mystified
        public bool hermes = false;
        public float mysticDamage = 1f;
        public int mysticCrit = 4;
        public bool ethSpawn = false;
        public bool lovestruck = false;
        public bool frigid = false;
        public bool bubbly = false;
        public bool dawn = false;
        public bool trueDawn = false;
        private int dmg = 0;
        public int plays = 0;
        public int dmg2 = 0;
        public static int zTime = 0;
        public int zTimeInstanced = 0;
        public bool zImmune = false;
        public float xTemp = 0;
        public float yTemp = 0;
        public bool invin = false;
        public bool spored = false;
        public bool furious = false;
        public bool slimed = false;
        public bool frostbite = false;
        public bool spooked = false;
        public bool steamified = false;
        public bool incineration = false;
        public float damageMult = 1f;
        public int attacker = -1;
        
        public override void SetDefaults(NPC npc)
        {
            incineration = false;
            steamified = false;
            trueDawn = false;
            dawn = false;
            bubbly = false;
            spooked = false;
            frostbite = false;
            slimed = false;
            furious = false;
            spored = false;
            plays = 0;
            dmg = 0;
            invin = npc.dontTakeDamage;
            dmg2 = npc.damage;
            damageMult = npc.takenDamageMultiplier;

            if (LaugicalityVars.ZNPCs.Contains(npc.type))
            {
                zImmune = true;
            }
        }

        public override void ResetEffects(NPC npc)
        {
            incineration = false;
            steamified = false;
            trueDawn = false;
            dawn = false;
            bubbly = false;
            spooked = false;
            frostbite = false;
            slimed = false;
            furious = false;
            spored = false;
            eFied = false;
            mFied = false;
            hermes = false;
            lovestruck = false;
            frigid = false; 
            mysticCrit = 4;
            npc.takenDamageMultiplier = damageMult;
            if(zTimeInstanced < zTime)
            {
                zTimeInstanced = zTime;
            }
            if (zTime > 0)
            {
                zTime--;
            }
            if (zTimeInstanced > 0)
            {
                zTimeInstanced--;
            }
        }

        public override void ScaleExpertStats(NPC npc, int numPlayers, float bossLifeScale)
        {
            plays = numPlayers;
            dmg2 = npc.damage;
        }

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<LaugicalityPlayer>(mod).ZoneObsidium)
            {
                pool.Clear();
                float spawnMod = .25f;
                if (!Main.hardMode)
                {
                    pool.Add(mod.NPCType("ObsidiumSkull"), 0.10f * spawnMod);
                    //pool.Add(mod.NPCType("ObsidiumDriller"), 0.05f * spawnMod);
                    pool.Add(NPCID.Skeleton, 0.25f * spawnMod);
                    pool.Add(NPCID.BlackSlime, 0.15f * spawnMod);
                    pool.Add(NPCID.MotherSlime, 0.15f * spawnMod);
                    //pool.Add(mod.NPCType("MoltenSlime"), 0.45f);

                    if (LaugicalityWorld.downedRagnar)
                    {
                        pool.Add(mod.NPCType("MagmatipedeHead"), 0.30f * spawnMod);
                        //pool.Add(mod.NPCType("MagmaCaster"), 0.30f * spawnMod);
                    }
                }
                else
                {
                    pool.Add(mod.NPCType("ObsidiumSkull"), 0.15f * spawnMod);
                    //pool.Add(mod.NPCType("MoltenSlime"), 0.2f * spawnMod);
                    pool.Add(mod.NPCType("MoltiochHead"), 0.05f * spawnMod);
                    pool.Add(mod.NPCType("MoltenSoul"), 0.05f * spawnMod);
                    pool.Add(NPCID.SkeletonArcher, 0.25f * spawnMod);
                    pool.Add(NPCID.GiantBat, 0.25f * spawnMod);
                    pool.Add(NPCID.RedDevil, 0.25f * spawnMod);
                    if (LaugicalityWorld.downedRagnar)
                    {
                        pool.Add(mod.NPCType("MagmatipedeHead"), 0.05f * spawnMod);
                        //pool.Add(mod.NPCType("MagmaCaster"), 0.20f * spawnMod);
                        pool.Add(mod.NPCType("LavaTitan"), 0.01f * spawnMod);
                    }
                }
            }
            return;
        }

        public override void GetChat(NPC npc, ref string chat)
        {
            if (npc.type == NPCID.ScorpionBlack && LaugicalityWorld.downedEtheria)
                chat = "Why hello there.";
            base.GetChat(npc, ref chat);
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (spored)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= (int)(2);
                if (damage < 2)
                {
                    damage = (2);
                }
            }
            if (slimed)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= (int)(2);
                if (damage < 2)
                {
                    damage = (2);
                }
            }
            if (furious)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= (int)(8);
                if (damage < 8)
                {
                    damage = (8);
                }
            }
            if (incineration)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= (int)(8);
                if (damage < 8)
                {
                    damage = (8);
                }
            }
            if (hermes)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= (int)(4);
                if (damage < 4)
                {
                    damage = (4);
                }
            }

            if (spooked)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= (int)(24);
                if (damage < 24)
                {
                    damage = (24);
                }
            }

            if (frostbite)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= (int)(320);
                if (damage < 320)
                {
                    damage = (320);
                }
            }
            if (steamified)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= (int)(80);
                if (damage < 80)
                {
                    damage = (80);
                }
            }
            if (npc.boss == false)
            {
                if (frigid)
                {
                    npc.velocity.X *= 0;
                    npc.velocity.Y *= 0;
                }
            }
            if(bubbly)
            {
                if (Main.rand.Next(1 * 60) == 0 && Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (-1 + 2 * Main.rand.Next(2)) * 4, Main.rand.Next(-5, 2), mod.ProjectileType("Bubble"), 20, 3f, Main.myPlayer);
            }
            if (dawn)
            {
                if (Main.rand.Next(1 * 60) == 0 && Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (-1 + 2 * Main.rand.Next(2)) * 4, Main.rand.Next(-5, 2), mod.ProjectileType("DawnSpark"), 20, 3f, Main.myPlayer);
            }
            if (trueDawn)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= (int)(24);
                if (damage < 24)
                {
                    damage = (24);
                }
                if (Main.rand.Next(1 * 60) == 0 && Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (-1 + 2 * Main.rand.Next(2)) * 4, Main.rand.Next(-5, 2), mod.ProjectileType("TrueDawnSpark"), 40, 3f, Main.myPlayer);
            }
        }
        public override bool PreAI(NPC npc)
        {
            if (zTimeInstanced > 0 && zImmune == false)
                return false;
            return true;
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (eFied)
            {
                if (Main.rand.Next(13) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("TrainSteam"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.8f);
            }
            if (spored)
            {
                if (Main.rand.Next(13) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("Shroom"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.8f);
            }
            if (slimed)
            {
                if (Main.rand.Next(13) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 116, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                //Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.8f);
            }
            if (mFied)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("Lightning"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.8f);
            }
            if (incineration)
            {
                if (Main.rand.Next(8) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("Magma"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.8f, 0.4f, 0f);
            }
            if (hermes)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("Hermes"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.8f);
            }
            if (lovestruck)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("Pink"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.8f);
            }
            if (frigid)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("Frost"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.8f);
            }

            if (furious)
            {
                if (Main.rand.Next(4) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("Magma"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.2f);
            }
            if (bubbly)
            {
                if (Main.rand.Next(8) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("Bubble"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 2f;
                    }
                }
            }
            if (dawn || trueDawn)
            {
                if (Main.rand.Next(8) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("Dawn"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 2f;
                    }
                }
            }
            if (frostbite)
            {
                if (Main.rand.Next(4) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("Etherial"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.0f, 0.4f, 0.6f);
            }
            if (steamified)
            {
                if (Main.rand.Next(4) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("Steam"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.4f, 0.4f, 0.4f);
            }
            if (spooked)
            {
                if (Main.rand.Next(4) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("Spooked"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.4f, 0.0f, 0.4f);
            }
        }

        public override void PostAI(NPC npc)
        {
            //Za Warudo
            if ((zTimeInstanced > 0 && zImmune == false) || frigid)
            {
                npc.velocity.X *= 0;
                npc.velocity.Y *= 0;
                if (xTemp == 0 || yTemp == 0)
                {
                    xTemp = npc.position.X;
                    yTemp = npc.position.Y;
                }
                else
                {
                    npc.position.X = xTemp;
                    npc.position.Y = yTemp;
                }
            }
            else
            {
                xTemp = 0;
                yTemp = 0;
            }


            if (npc.life > npc.lifeMax)
                npc.lifeMax = npc.life;

            //Za Warudo
            if (zTimeInstanced > 0 && zImmune == false)
            {
                npc.velocity.X *= 0;
                npc.velocity.Y *= 0;
            }

        }

        public override void NPCLoot(NPC npc)
        {
            //Debuffs
            if(furious)
            {
                if(Main.netMode != 1)
                {
                    float mag = 6f;
                    float theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    int damage = 80;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, mod.ProjectileType("ObsidiumArrowHead"), damage, 3f, Main.myPlayer);
                    theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, mod.ProjectileType("ObsidiumArrowHead"), damage, 3f, Main.myPlayer);
                    theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, mod.ProjectileType("ObsidiumArrowHead"), damage, 3f, Main.myPlayer);
                    theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, mod.ProjectileType("ObsidiumArrowHead"), damage, 3f, Main.myPlayer);
                    theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, mod.ProjectileType("ObsidiumArrowHead"), damage, 3f, Main.myPlayer);
                }
            }
            if (bubbly)
            {
                if (Main.netMode != 1)
                {
                    int rand = Main.rand.Next(3, 7);
                    for(int i = 0; i < rand; i++)
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (-1 + 2 * Main.rand.Next(2)) * 4, Main.rand.Next(-5, 2), mod.ProjectileType("Bubble"), 20, 3f, Main.myPlayer);
                }
            }
            if (dawn)
            {
                if (Main.netMode != 1)
                {
                    int rand = Main.rand.Next(3, 7);
                    for (int i = 0; i < rand; i++)
                    {
                        float mag = 8f;
                        float theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                        int damage = 32;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, mod.ProjectileType("DawnSpark"), damage, 3f, Main.myPlayer);
                    }
                }
            }
            if (trueDawn)
            {
                if (Main.netMode != 1)
                {
                    int rand = Main.rand.Next(4, 9);
                    for (int i = 0; i < rand; i++)
                    {
                        float mag = 8f;
                        float theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                        int damage = 45;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, mod.ProjectileType("TrueDawnSpark"), damage, 3f, Main.myPlayer);
                    }
                }
            }
            if (steamified)
            {
                if (Main.netMode != 1)
                {
                    int rand = Main.rand.Next(4, 7);
                    for (int i = 0; i < rand; i++)
                    {
                        float mag = 8f;
                        float theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                        int damage = 1000;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, mod.ProjectileType("VulcanConjuration"), damage, 3f, Main.myPlayer);
                    }
                }
            }
            if(attacker != -1)
            {
                if(Main.player[attacker].GetModPlayer<LaugicalityPlayer>(mod).etherCog)
                {
                    Main.player[attacker].AddBuff(mod.BuffType("Annihilation"), 10 * 60, false);
                    Main.player[attacker].GetModPlayer<LaugicalityPlayer>(mod).annihilationDamageBoost += .2f;
                }
            }
            if (plays == 0)
                plays = 1;
            //Soul Drops
            if(lovestruck)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 58); //Drop Hearts
                if(Main.rand.Next(1, 3) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 58);
                }
            }
            if (npc.lifeMax > 5 && npc.value > 0f && Main.hardMode)
            {
                if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSkyHeight && Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulOfSought"));
                }
                if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUnderworldHeight && Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulOfHaught"));
                }
                if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<LaugicalityPlayer>(mod).ZoneObsidium && Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulOfHaught"));
                }
            }
            //Misc Materials
            if (npc.type == 113)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NullShard"), Main.rand.Next(1,4));
            }
            if (npc.type == 4)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TastyMorsel"), 1);
            }
            //Soul Fragments
            if (npc.type == NPCID.QueenBee && Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HonifiedSoulCrystal"), 1);
            }
            if (npc.type == 35 && Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NecroticSoulCrystal"), 1);
            }
            if (npc.type == 113 && Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HellishSoulCrystal"), 1);
            }
            if (npc.type == NPCID.Plantera && Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NaturalSoulCrystal"), 1);
            }
            if (npc.type == 439 && Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LunarSoulCrystal"), 1);
            }

        }

        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }


    }
}