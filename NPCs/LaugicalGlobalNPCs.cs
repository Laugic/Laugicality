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
        public bool eFied = false;//Electrified
        public bool mFied = false;//Mystified
        public bool hermes = false;
        public float mysticDamage = 1f;
        public int mysticCrit = 4;
        public bool etherial = false; //if only etherial
        public bool bitherial = false; //if both etherial and non etherial
        public bool ethSpawn = false; //if spawned in etherial
        public bool friend = false;
        public bool lovestruck = false;
        public bool frigid = false;
        private int dmg = 0;
        public int eDmg = 0;
        public int eDef = 0;
        public int eLife = 0;
        public int eLifeMax = 0;
        public int plays = 0;
        public bool lovely = false;
        public int dmg2 = 0;

        public override void ResetEffects(NPC npc)
        {
            etherial = false;
            eFied = false;
            mFied = false;
            hermes = false;
            lovestruck = false;
            frigid = false;
            mysticCrit = 4;
        }

        public override void SetDefaults(NPC npc)
        {
            plays = 0;
            eDmg = 0;
            eDef = 0;
            dmg = 0;
            etherial = false;
            if (npc.boss)
            {
                bitherial = true;
            }
            //bitherial = false;
            if (LaugicalityVars.ENPCs.Contains(npc.type))
            {
                bitherial = true;
            }
            if (LaugicalityVars.EBad.Contains(npc.type))
            {
                npc.life = 0;
            }
            lovely = npc.friendly;
            dmg2 = npc.damage;
        }

        public override void ScaleExpertStats(NPC npc, int numPlayers, float bossLifeScale)
        {
            plays = numPlayers;
            if (bitherial)
            {
                if (LaugicalityWorld.downedEtheria && Main.netMode != 1)
                {
                    npc.damage = (int)(npc.damage * 1.5 + 30);
                    npc.defense = (int)(npc.defense / 2);
                    npc.lifeMax += 60000;
                    npc.lifeMax = (int)(npc.lifeMax * 1.5);
                    npc.life = npc.lifeMax;
                }
            }
        }



        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (npc.boss == false)
            {
                if (eFied)//Electrified
                {
                    if (npc.lifeRegen > 0)
                    {
                        npc.lifeRegen = 0;
                    }
                    npc.lifeRegen -= (int)(8);// * mysticDamage);
                    if (damage < 8)
                    {
                        damage = (8);// * mysticDamage);
                    }
                }
                if (hermes)//Electrified
                {
                    if (npc.lifeRegen > 0)
                    {
                        npc.lifeRegen = 0;
                    }
                    npc.lifeRegen -= 8;// * mysticDamage);
                    if (damage < 8)
                    {
                        damage = (8);// * mysticDamage);
                    }
                }
                if (lovestruck && npc.boss == false)//Mystified
                {
                    if (lovely == false)
                        npc.friendly = true;
                }
                else npc.friendly = lovely;

                if (frigid)
                {
                    npc.velocity.X *= 0;
                    npc.velocity.Y *= 0;
                }
            }
        }

        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityVars.ENPCs.Contains(npc.type) || !npc.boss)
            {
                modPlayer.etherialMusic = false;
            }
            if (eDmg == 0)
                eDmg = npc.damage;
            if (eDef == 0)
                eDef = npc.defense;
            if (eLife == 0)
                eLife = npc.life;
            if (eLifeMax == 0)
                eLifeMax = npc.lifeMax;
            /*if (bitherial)
            {
                if (LaugicalityWorld.downedEtheria && Main.netMode != 1)
                {
                    npc.damage = (int)(eDmg * 1.5 + 30);
                    npc.defense = (int)(eDef / 2);
                    if(npc.lifeMax == eLifeMax)
                    {
                        npc.lifeMax += 60000;
                        npc.lifeMax = (int)( npc.lifeMax * 1.5);
                        npc.life = npc.lifeMax;
                    }
                }
                else
                {
                    npc.damage = eDmg;
                    npc.defense = eDef;
                    if (npc.lifeMax != eLifeMax && Main.netMode != 1)
                    {
                        npc.lifeMax =(int)(npc.lifeMax / 1.5);
                        npc.lifeMax -= 60000;
                        npc.life = npc.lifeMax;
                    }
                }
                return true;
            }*/
            if(!bitherial)
            {
                if (dmg == 0)
                {
                    dmg = npc.damage;
                    friend = npc.friendly;
                }
                if (!friend)
                {
                    if (etherial)
                    {
                        if (LaugicalityWorld.downedEtheria)
                        {
                            npc.dontTakeDamage = false;
                            npc.damage = dmg;
                            return true;
                        }
                        else
                        {
                            npc.dontTakeDamage = true;
                            npc.damage = 0;
                            return modPlayer.etherVision;
                        }
                    }
                    else
                    {

                        if (LaugicalityWorld.downedEtheria)
                        {
                            npc.dontTakeDamage = true;
                            npc.damage = 0;
                            return modPlayer.etherVision;
                        }
                        else
                        {
                            npc.dontTakeDamage = false;
                            npc.damage = dmg;
                            return true;
                        }
                    }
                }
                else return true;
            }else return true;
        }

        public override Color? GetAlpha(NPC npc, Color drawColor)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityWorld.downedEtheria)
            {
                var b = 125;
                var b2 = 225;
                var b3 = 255;
                if (drawColor.R != (byte)b)
                {
                    drawColor.R = (byte)b;
                }
                if (drawColor.G < (byte)b2)
                {
                    drawColor.G = (byte)b2;
                }
                if (drawColor.B < (byte)b3)
                {
                    drawColor.B = (byte)b3;
                }
                return drawColor;
            }
            else
            {
                return null;
            }
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

        }
        public override void AI(NPC npc)
        {

            if (npc.life > npc.lifeMax)
                npc.lifeMax = npc.life;

            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityVars.ENPCs.Contains(npc.type) || !npc.boss)
            {
                modPlayer.etherialMusic = false;
            }
        }

        public override void PostAI(NPC npc)
        {

            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityVars.ENPCs.Contains(npc.type) || !npc.boss)
            {
                modPlayer.etherialMusic = false;
            }
            if (LaugicalityWorld.downedEtheria && (npc.type >= 430 && npc.type <= 436))
            {
                npc.life = 0;
            }
        }

        public override void NPCLoot(NPC npc)
        {
            if (plays == 0)
                plays = 1;
            //Soul Drops
            if (npc.lifeMax > 5 && npc.value > 0f && Main.hardMode)
            {
                if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSkyHeight && Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulOfSought"));
                }
                if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUnderworldHeight && Main.rand.Next(3) == 0)
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
            if (npc.type == 345)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrigidEssence"), Main.rand.Next(1, 3));
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

            //Etherial
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityWorld.downedEtheria)
            {

                if(npc.boss)Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialEssence"), Main.rand.Next(5, 11));
                if (npc.type == 4)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EyeOfEtheria"), 1);
                if (npc.type == 113)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialEnergy"), 1);
                if (npc.type == 50)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialGel"), 1);
                if (npc.type == 35)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialSkull"), 1);
                if (npc.type == 13 && NPC.CountNPCS(13) < 2 && NPC.CountNPCS(14) < 2)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialScarf"), 1);
                if (npc.type == 266)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrainOfEtheria"), 1);
                if (npc.type == 222)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialPack"), 1);
                if (npc.type == 245)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StoneOfEtheria"), 1);
                if (npc.type == 262)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialSac"), 1);
                if (npc.type == 398)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialGlobe"), 1);
                if (npc.type == 127)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialDestructionCore"), 1);
                if (npc.type == 125 && NPC.CountNPCS(126) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialConjurationCore"), 1);
                if (npc.type == 126 && NPC.CountNPCS(125) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialConjurationCore"), 1);
                if (npc.type == 134)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialIllusionCore"), 1);
                if (npc.type == 370)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialTruffle"), 1);
            }
        }

        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override bool? DrawHealthBar(NPC npc, byte hbPosition, ref float scale, ref Vector2 position)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (!npc.friendly)
            {
                if (etherial)
                {
                    if (LaugicalityWorld.downedEtheria)
                    {
                        scale = 1f;
                    }
                    else
                    {
                        scale = 0f;
                    }
                }
                else
                {

                    if (LaugicalityWorld.downedEtheria)
                    {
                        scale = 0f;
                    }
                    else
                    {
                        scale = 1f;
                    }
                }
            }
            else scale = 1f;
            return null;
        }
    }
}