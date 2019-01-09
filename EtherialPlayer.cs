using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Laugicality
{
    public partial class LaugicalityPlayer
    {
        public List<int> bysmalPowers = new List<int>();

        //Etherial Accessories
        public bool etherialGel = false;
        public bool etherVision = false;
        public bool etherialScarf = false;
        public bool etherialScarfCooldown = false;
        public bool etherialBrain = false;
        public bool etherialBrainCooldown = false;
        public bool etherialFrost = false;
        public bool etherialBees = false;
        public bool etherialMagma = false;
        public bool etherialBones = false;
        public bool etherialAnDio = false;
        public bool etherialTwins = false;
        public bool etherialDestroyer = false;
        public bool etherialPrime = false;
        public bool etherCog = false;
        public bool etherialPipes = false;
        public bool etherialTank = false;
        public bool etherialSpores = false;
        public bool etherialStone = false;
        public bool etherialTruffle = false;
        public int etherable = 0;
        public float etherBonesDamageBoost = 0;
        public bool etherBonesBoost = false;
        public bool grappleReturned = false;
        public bool justiceCooldown = false;
        public bool annihilationBoost = false;
        public float annihilationDamageBoost = 0;


        public void CycleBysmalPowers(int newPower)
        {
            if(bysmalPowers.Count > 2)
            bysmalPowers.RemoveAt(0);
            bysmalPowers.Add(newPower);
        }
        
        private void ResetEtherial()
        {
            annihilationBoost = false;
            justiceCooldown = false;
            etherialGel = false;
            etherVision = false;
            etherialScarf = false;
            etherialScarfCooldown = false;
            etherialBrain = false;
            etherialBrainCooldown = false;
            etherialFrost = false;
            etherialBees = false;
            etherialMagma = false;
            etherialBones = false;
            etherBonesBoost = false;
            etherialAnDio = false;
            etherialTwins = false;
            etherialDestroyer = false;
            etherialPrime = false;
            etherCog = false;
            etherialPipes = false;
            etherialTank = false;
            etherialSpores = false;
            etherialStone = false;
            etherialTruffle = false;
            if(etherable > 0)
                etherable -= 1;
        }

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            CheckBysmalPowers();
            if (etherialBrain && !etherialBrainCooldown && (LaugicalityWorld.downedEtheria || etherable > 0))
            {
                npc.AddBuff(mod.BuffType("FragmentedMind"), 15 * 60, false);
                if (damage >= player.statLife)
                {
                    if (etherialBrain && !etherialBrainCooldown && (LaugicalityWorld.downedEtheria || etherable > 0))
                    {
                        player.AddBuff(mod.BuffType("FragmentedMind"), 60 * 60 * 3, true);
                        player.immune = true;
                        player.immuneTime = 2 * 60;
                        player.statLife += 300;
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
                        for (int i = 0; i < 20; i++)
                            Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
                    }
                }
            }
            if(etherialTank)
            {
                npc.life -= (int)(Math.Abs(player.velocity.X) * 500);
                if (npc.life <= 0)
                {
                    npc.life = 1;
                }
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            CheckBysmalPowers();
            if (etherialBones)
            {
                player.AddBuff(mod.BuffType("EtherBones"), 10 * 60, true);
                etherBonesDamageBoost += ((float)damage / (float)player.statLifeMax2) * 2;
            }
            if(etherialTwins && !justiceCooldown)
            {
                player.AddBuff(mod.BuffType("JusticeCooldown"), 90 * 60, true);
                player.statLife += damage;
                player.immune = true;
                player.immuneTime = 1 * 60;
                return false;
            }
            if (damage >= player.statLife)
            {
                if (etherialScarf && !etherialScarfCooldown && (LaugicalityWorld.downedEtheria || etherable > 0))
                {
                    player.AddBuff(mod.BuffType("EtherialScarfCooldown"), 60 * 60 * 1, true);
                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
                    for (int i = 0; i < 20; i++)
                        Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
                    player.immune = true;
                    player.immuneTime = 2 * 60;
                    return false;
                }
            }
            return true;
        }

        private void CheckBysmalPowers()
        {
            if(fullBysmal > 0)
            {
                if (bysmalPowers.Contains(NPCID.KingSlime))
                    etherialGel = true;
                if (bysmalPowers.Contains(NPCID.EyeofCthulhu))
                    etherVision = true;
                if (bysmalPowers.Contains(NPCID.EaterofWorldsHead))
                    etherialScarf = true;
                if (bysmalPowers.Contains(NPCID.BrainofCthulhu))
                    etherialBrain = true;
                if (bysmalPowers.Contains(mod.NPCType("Hypothema")))
                    etherialFrost = true;
                if (bysmalPowers.Contains(NPCID.QueenBee))
                    etherialBees = true;
                if (bysmalPowers.Contains(mod.NPCType("Ragnar")))
                    etherialMagma = true;
                if (bysmalPowers.Contains(NPCID.SkeletronHead))
                    etherialBones = true;
                if (bysmalPowers.Contains(mod.NPCType("AnDio3")))
                    etherialAnDio = true;
                if (bysmalPowers.Contains(NPCID.Retinazer) || bysmalPowers.Contains(NPCID.Spazmatism))
                    etherialTwins = true;
                if (bysmalPowers.Contains(NPCID.TheDestroyer))
                    etherialDestroyer = true;
                if (bysmalPowers.Contains(NPCID.SkeletronPrime))
                    etherialPrime = true;
                if (bysmalPowers.Contains(mod.NPCType("TheAnnihilator")))
                    etherCog = true;
                if (bysmalPowers.Contains(mod.NPCType("Slybertron")))
                    etherialPipes = true;
                if (bysmalPowers.Contains(mod.NPCType("SteamTrain")))
                    etherialTank = true;
                if (bysmalPowers.Contains(NPCID.Plantera))
                    etherialSpores = true;
                if (bysmalPowers.Contains(NPCID.Golem))
                    etherialStone = true;
                if (bysmalPowers.Contains(NPCID.DukeFishron))
                    etherialTruffle = true;
                if (bysmalPowers.Contains(NPCID.MoonLordCore))
                    etherable = 2;
            }
        }

        private void GetEtherialAccessories()
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if(etherialGel)
            {
                player.jumpSpeedBoost += 5.0f;
                player.moveSpeed += .5f;
                player.maxRunSpeed += 3f;
            }
            if (etherialBees && player.honey)
            {

            }
            if (etherialMagma)
            {
                if (player.lavaWet)
                    player.AddBuff(mod.BuffType("EtherialRagnar"), 15 * 60);
            }
            if (etherialBones)
            {

            }
            if (etherialAnDio)
            {
                modPlayer.zProjImmune = true;
            }
            if (etherialDestroyer)
            {

            }
            if (etherialPrime)
            {

            }
            if (etherCog)
            {
                player.maxMinions += 4;
            }
            if(etherialPipes)
            {
                player.thrownDamage += .30f;
                player.thrownVelocity += .5f;
            }
            if (etherialTank)
            {
                player.jumpSpeedBoost += 3.0f;
                player.maxRunSpeed += 4f;
                player.moveSpeed += 4f;

            }
            if (etherialSpores)
            {

            }
            if (etherialStone)
            {

            }
            if (etherialTruffle)
            {
                player.gills = true;
                player.ignoreWater = true;
                player.accFlipper = true;
                if(player.wet)
                {
                    player.jumpSpeedBoost += 3.0f;
                    player.moveSpeed += .5f;
                    player.maxRunSpeed += 3f;
                }
            }
        }


        private void GetEtherialAccessoriesPost()
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (etherialGel)
            {

            }
            if (etherialBees && player.honey)
            {
                player.lifeRegen += 8;
                player.statDefense += 15;
                float dmgBoost = .15f;
                player.thrownDamage += dmgBoost;
                player.rangedDamage += dmgBoost;
                player.magicDamage += dmgBoost;
                player.minionDamage += dmgBoost;
                player.meleeDamage += dmgBoost;
            }
            if (etherialMagma)
            {
                player.statLifeMax2 = (int)(player.statLifeMax2 * 1.25f);
            }
            if (etherialBones)
            {
                if(etherBonesBoost)
                {
                    if (etherBonesDamageBoost > 5)
                        etherBonesDamageBoost = 5;
                    player.thrownDamage += etherBonesDamageBoost;
                    player.rangedDamage += etherBonesDamageBoost;
                    player.magicDamage += etherBonesDamageBoost;
                    player.minionDamage += etherBonesDamageBoost;
                    player.meleeDamage += etherBonesDamageBoost;
                }
                else
                {
                    etherBonesDamageBoost = 0;
                }
            }
            if (etherialAnDio)
            {

            }
            if (etherialDestroyer)
            {
                int originalDef = player.statDefense;
                float globalDmg = 1;
                globalDmg = player.meleeDamage - 1;
                if (player.rangedDamage - 1 < globalDmg)
                    globalDmg = player.rangedDamage - 1;
                if (player.magicDamage - 1 < globalDmg)
                    globalDmg = player.magicDamage - 1;
                if (player.thrownDamage - 1 < globalDmg)
                    globalDmg = player.thrownDamage - 1;
                if (player.minionDamage - 1 < globalDmg)
                    globalDmg = player.minionDamage - 1;
                if (globalDmg > 0)
                {
                    if (globalDmg > 2)
                        globalDmg = 2;
                    player.statDefense += (int)(originalDef * globalDmg);
                }
            }
            if (etherialPrime)
            {
                float lifePercentage = (float)(player.statLifeMax2 - player.statLife) / (float)player.statLifeMax2;
                player.thrownDamage += lifePercentage;
                player.rangedDamage += lifePercentage;
                player.magicDamage += lifePercentage;
                player.minionDamage += lifePercentage;
                player.meleeDamage += lifePercentage;
            }
            if (etherCog)
            {
                if (annihilationBoost)
                {
                    if (annihilationDamageBoost > 5)
                        annihilationDamageBoost = 5;
                    player.thrownDamage += annihilationDamageBoost;
                    player.rangedDamage += annihilationDamageBoost;
                    player.magicDamage += annihilationDamageBoost;
                    player.minionDamage += annihilationDamageBoost;
                    player.meleeDamage += annihilationDamageBoost;
                }
                else
                {
                    annihilationDamageBoost = 0;
                }
            }
            if (etherialPipes)
            {

            }
            if (etherialTank)
            {
                float moveSpeed = 0;
                moveSpeed = (float)Math.Abs(player.velocity.X) / 25f;
                player.thrownDamage += moveSpeed;
                player.rangedDamage += moveSpeed;
                player.magicDamage += moveSpeed;
                player.minionDamage += moveSpeed;
                player.meleeDamage += moveSpeed;
            }
            if (etherialSpores)
            {
                if (player.grapCount > 0)
                {
                    grappleReturned = false;
                    player.lifeRegen += 15;
                    float dmgBoost = .5f;
                    player.thrownDamage += dmgBoost;
                    player.rangedDamage += dmgBoost;
                    player.magicDamage += dmgBoost;
                    player.minionDamage += dmgBoost;
                    player.meleeDamage += dmgBoost;
                }
            }
            if (etherialStone)
            {
                player.lifeRegen += 18;
                player.statDefense += 20;
                player.statLifeMax2 += player.statDefense;
            }
            if (etherialTruffle)
            {
                if(player.wet)
                {
                    player.lifeRegen += 12;
                    player.statDefense += 35;
                    float dmgBoost = .4f;
                    player.thrownDamage += dmgBoost;
                    player.rangedDamage += dmgBoost;
                    player.magicDamage += dmgBoost;
                    player.minionDamage += dmgBoost;
                    player.meleeDamage += dmgBoost;
                }
            }
        }
    }
}
