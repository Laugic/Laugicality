using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs
{
    public class LaugicalGlobalNPCs : GlobalNPC
    {
        public bool eFied = false;
        public bool mFied = false;//Mystified
        public bool hermes = false;
        public float mysticDamage = 1f;
        public int mysticCrit = 4;
        public bool ethSpawn = false;
        public bool lovestruck = false;
        public bool frigid = false;
        private int dmg = 0;
        public int plays = 0;
        public int dmg2 = 0;
        public bool zImmune = false;
        public float xTemp = 0;
        public float yTemp = 0;
        public bool invin = false;
        public bool spored = false;
        public bool furious = false;
        public bool slimed = false;
        public bool frostbite = false;
        public bool spooked = false;
        public float damageMult = 1f;
        
        public override void SetDefaults(NPC npc)
        {
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
        }

        public override void ScaleExpertStats(NPC npc, int numPlayers, float bossLifeScale)
        {
            plays = numPlayers;
            dmg2 = npc.damage;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (eFied)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= (int)(16);
                if (damage < 16)
                {
                    damage = (16);
                }
            }
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
                npc.lifeRegen -= (int)(24);
                if (damage < 24)
                {
                    damage = (24);
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
        }
        public override bool PreAI(NPC npc)
        {
            if (LaugicalityWorld.zawarudo > 0 && zImmune == false)
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
            if ((LaugicalityWorld.zawarudo > 0 && zImmune == false) || frigid)
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
            if (LaugicalityWorld.zawarudo > 0 && zImmune == false)
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