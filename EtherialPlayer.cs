using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;

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
        public bool etherable = false;


        public void CycleBysmalPowers(int newPower)
        {
            if(bysmalPowers.Count > 2)
            bysmalPowers.RemoveAt(0);
            bysmalPowers.Add(newPower);
        }
        
        private void ResetEtherial()
        {
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
            etherable = false;
        }

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if(etherialBrain && !etherialBrainCooldown && (LaugicalityWorld.downedEtheria || etherable))
            {
                npc.AddBuff(mod.BuffType("FragmentedMind"), 15 * 60, false);
                if (damage >= player.statLife)
                {
                    if (etherialBrain && !etherialBrainCooldown && (LaugicalityWorld.downedEtheria || etherable))
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
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (damage >= player.statLife)
            {
                if (etherialScarf && !etherialScarfCooldown && (LaugicalityWorld.downedEtheria || etherable))
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
                    etherable = true;
            }
        }

        private void GetEtherialAccessories()
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if(etherialGel)
            {
                player.jumpSpeedBoost += 5.0f;
            }
            if (etherialFrost)
            {
                player.meleeCrit += 30;
                player.rangedCrit += 30;
            }
            if (etherialBees)
            {
                player.maxRunSpeed += 3f;
                player.moveSpeed += .3f;
            }
            if (etherialMagma)
            {
                modPlayer.mysticDuration += 0.6f;
                player.statDefense += 8;
                player.thrownVelocity += 0.6f;
            }
            if (etherialBones)
            {
                player.thrownDamage += 0.2f;
                player.rangedDamage += 0.2f;
                player.magicDamage += 0.2f;
                player.minionDamage += 0.2f;
                player.meleeDamage += 0.2f;
            }
            if (etherialAnDio)
            {
                modPlayer.zProjImmune = true;
            }
            if (etherialTwins)
            {
                modPlayer.conjurationDamage += .2f;
                modPlayer.conjurationPower += 2;
            }
            if (etherialDestroyer)
            {
                modPlayer.destructionDamage += .2f;
                modPlayer.destructionPower += 2;
            }
            if (etherialPrime)
            {
                modPlayer.illusionDamage += .2f;
                modPlayer.illusionPower += 2;
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
                modPlayer.mysticDamage += 0.3f;
            }
            if (etherialSpores)
            {
                player.thrownCrit += 30;
                player.rangedCrit += 30;
                player.magicCrit += 30;
                player.meleeCrit += 30;
            }
            if (etherialStone)
            {
                player.lifeRegen += 12;
            }
            if (etherialTruffle)
            {
                player.jumpSpeedBoost += 5.0f;
                player.maxRunSpeed += .5f;
                player.moveSpeed += .25f;
            }
        }
    }
}
