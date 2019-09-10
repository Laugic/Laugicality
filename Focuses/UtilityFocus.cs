using Laugicality.Buffs;
using Laugicality.NPCs.Etherial.Enemies;
using Laugicality.SoulStones;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Focuses
{
    public sealed class UtilityFocus : Focus
    {
        public UtilityFocus() : base("UtilityFocus", "Utility", Color.Purple, new FocusEffect[]
        {
            new FocusEffect(p => NPC.downedSlimeKing, DownedKingSlimeEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedKingSlime", "You are immune to slimes") { overrideColor = new Color(0x2B, 0x9D, 0xE9) }),
            new FocusEffect(p => NPC.downedBoss1, DownedEyeOfCthulhuEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedEyeOfCthulhu", "Hunter & Shine potion effects") { overrideColor = new Color(0xB0, 0x3A, 0x2E) }),
            new FocusEffect(p => LaugicalityWorld.downedDuneSharkron, DownedDuneSharkronEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedDuneSharkron", "Immune to fall damage") { overrideColor = new Color(0xF4, 0xE6, 0x92) }),
            new FocusEffect(p => NPC.downedBoss2, DownedWorldEvilBossEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedWorldEvilBoss", "Immune to Confusion, Cursed Flames. Immune to Contact Damage once every 2 minutes") { overrideColor = new Color(0x88, 0x4E, 0xA0)}),
            new FocusEffect(p => LaugicalityWorld.downedHypothema, DownedHypothemaEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedHypothema", "Immune to cold debuffs (including 'Frostburn')") { overrideColor = new Color(0x98, 0xE1, 0xEA) }),
            new FocusEffect(p => NPC.downedQueenBee, DownedQueenBeeEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedQueenBee", "Super Bees, Immune to Poison") { overrideColor = new Color(0xF3, 0x9C, 0x12)}),
            new FocusEffect(p => LaugicalityWorld.downedRagnar, DownedRagnarEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedRagnar", "Immunity to Lava, 'On Fire', and 'Burning'. Wrath potions are 50% more effective") { overrideColor = new Color(0xED, 0x4B, 0x23) }),
            new FocusEffect(p => NPC.downedBoss3, DownedSkeletronEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedSkeletron", "Immune to Cursed & Darkness. Night Owl & Dangersense potion effects") { overrideColor = new Color(0x83, 0x91, 0x92) }),
            new FocusEffect(p => LaugicalityWorld.downedAnDio, DownedAnDioEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedAnDio", "Decreased cooldown of Time Stop. You are Immune to Time Stop") { overrideColor = new Color(0x42, 0x86, 0xF4) }),
            new FocusEffect(p => Main.hardMode, DownedWallOfFleshEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedWallOfFleshEffect", "Spelunker Effect, Ironskin and Regen Potions are 50% stronger, +15% Mining Speed") { overrideColor = new Color(0xAC, 0x39, 0x5A) }),
            new FocusEffect(p => NPC.downedMechBoss2, DownedTwinsEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedTwinsEffect", "Increased Flight Time if worn under wings") { overrideColor = new Color(0x2B, 0xD3, 0x4D) }),
            new FocusEffect(p => NPC.downedMechBoss1, DownedDestroyerEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedDestroyerEffect", "Immunity to Knockback") { overrideColor = new Color(0xDF, 0x0A, 0x0A) }),
            new FocusEffect(p => NPC.downedMechBoss3, DownedSkeletronPrimeEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedSkeletronPrimeEffect", "Innate Ankh Charm") { overrideColor = new Color(0xAA, 0xAA, 0xAA) }),
            new FocusEffect(p => LaugicalityWorld.downedAnnihilator, DownedAnnihilatorEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedAnnihilator", "Pressing the Ability Key destroys hostile projectiles and gives you 4 seconds of immunity. 90 second cooldown") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => LaugicalityWorld.downedSlybertron, DownedSlybertronEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedSlybertron", "Taking a healing potion gives less Potion Sickness") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => LaugicalityWorld.downedSteamTrain, DownedSteamTrainEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedSteamTrain", "You are immune to 'Steamy'. Attacks inflict 'Steamy'") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => NPC.downedPlantBoss, DownedPlanteraEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedPlantera", "You are immune while grappled to a tile, but also True Cursed") { overrideColor = new Color(0x81, 0xD8, 0x79) }),
            new FocusEffect(p => NPC.downedGolemBoss, DownedGolemEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedGolem", "Increase to all stats during the Daytime") { overrideColor = new Color(0xCC, 0x88, 0x37) }),
            new FocusEffect(p => NPC.downedFishron, DownedDukeFishronEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedDukeFishron", "Free movement in liquids. Increased Mobility while in liquids") { overrideColor = new Color(0x37, 0xC4, 0xCC) }),
            new FocusEffect(p => LaugicalityWorld.downedEtheria || LaugicalityWorld.downedTrueEtheria, DownedEtheriaEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedEtheria", "Immune to 'Frostbite' and Etherial Spirits") { overrideColor = new Color(0x85, 0xCB, 0xF7) }),
            new FocusEffect(p => NPC.downedMoonlord, DownedMoonLordEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedMoonLord", "You cannot lose life to life draining debuffs") { overrideColor = new Color(0x37, 0xCC, 0x8B) }),
        }, new FocusEffect[]
        {
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect1, new TooltipLine(Laugicality.Instance, "UtilityFocusCurse1", "+5% Damage Taken") { overrideColor = Color.Purple }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect2, new TooltipLine(Laugicality.Instance, "UtilityFocusCurse2", "You cannot be immune to knockback") { overrideColor = Color.Purple }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect3, new TooltipLine(Laugicality.Instance, "UtilityFocusCurse3", "Debuffs deal double damage when you are above 50% life") { overrideColor = Color.Purple }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect4, new TooltipLine(Laugicality.Instance, "UtilityFocusCurse4", "You are immune to most positive buffs") { overrideColor = Color.Purple }),
        })
        {

        }

        private static void DownedKingSlimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.npcTypeNoAggro[1] = true;
            laugicalityPlayer.player.npcTypeNoAggro[16] = true;
            laugicalityPlayer.player.npcTypeNoAggro[59] = true;
            laugicalityPlayer.player.npcTypeNoAggro[71] = true;
            laugicalityPlayer.player.npcTypeNoAggro[81] = true;
            laugicalityPlayer.player.npcTypeNoAggro[138] = true;
            laugicalityPlayer.player.npcTypeNoAggro[121] = true;
            laugicalityPlayer.player.npcTypeNoAggro[122] = true;
            laugicalityPlayer.player.npcTypeNoAggro[141] = true;
            laugicalityPlayer.player.npcTypeNoAggro[147] = true;
            laugicalityPlayer.player.npcTypeNoAggro[183] = true;
            laugicalityPlayer.player.npcTypeNoAggro[184] = true;
            laugicalityPlayer.player.npcTypeNoAggro[204] = true;
            laugicalityPlayer.player.npcTypeNoAggro[225] = true;
            laugicalityPlayer.player.npcTypeNoAggro[244] = true;
            laugicalityPlayer.player.npcTypeNoAggro[302] = true;
            laugicalityPlayer.player.npcTypeNoAggro[333] = true;
            laugicalityPlayer.player.npcTypeNoAggro[335] = true;
            laugicalityPlayer.player.npcTypeNoAggro[334] = true;
            laugicalityPlayer.player.npcTypeNoAggro[336] = true;
            laugicalityPlayer.player.npcTypeNoAggro[537] = true;
        }

        private static void DownedEyeOfCthulhuEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.detectCreature = true;
            Lighting.AddLight((int)(laugicalityPlayer.player.position.X + (float)(laugicalityPlayer.player.width / 2)) / 16, (int)(laugicalityPlayer.player.position.Y + (float)(laugicalityPlayer.player.height / 2)) / 16, 0.8f, 0.95f, 1f);
        }

        private static void DownedDuneSharkronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.noFallDmg = true;
        }

        private static void DownedWorldEvilBossEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.buffImmune[BuffID.Confused] = true;
            laugicalityPlayer.player.buffImmune[BuffID.CursedInferno] = true;

            laugicalityPlayer.EvilBossEffect = true;
        }

        private static void DownedHypothemaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.buffImmune[BuffID.Frostburn] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Frozen] = true;
            laugicalityPlayer.player.resistCold = true;
        }

        private static void DownedQueenBeeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.strongBees = true;
            laugicalityPlayer.player.buffImmune[BuffID.Poisoned] = true;
        }

        private static void DownedRagnarEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.lavaImmune = true;
            laugicalityPlayer.player.fireWalk = true;
            laugicalityPlayer.player.buffImmune[BuffID.OnFire] = true;

            if (laugicalityPlayer.player.HasBuff(BuffID.Wrath))
                laugicalityPlayer.DamageBoost(.05f);
        }

        private static void DownedSkeletronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.buffImmune[BuffID.Cursed] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Darkness] = true;
            laugicalityPlayer.player.nightVision = true;
            laugicalityPlayer.player.dangerSense = true;
        }

        private static void DownedAnDioEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.zImmune = true;
            laugicalityPlayer.zCoolDown -= 6 * 60;
        }

        private static void DownedWallOfFleshEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.findTreasure = true;
            laugicalityPlayer.player.pickSpeed -= 0.15f;
            if (laugicalityPlayer.player.HasBuff(BuffID.Ironskin))
                laugicalityPlayer.player.statDefense += 4;
            if (laugicalityPlayer.player.HasBuff(BuffID.Regeneration))
                laugicalityPlayer.player.lifeRegen += 2;
        }

        private static void DownedTwinsEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.wingTimeMax += 2 * 60;
        }

        private static void DownedDestroyerEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.noKnockback = true;
        }

        private static void DownedSkeletronPrimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.buffImmune[33] = true;
            laugicalityPlayer.player.buffImmune[36] = true;
            laugicalityPlayer.player.buffImmune[30] = true;
            laugicalityPlayer.player.buffImmune[20] = true;
            laugicalityPlayer.player.buffImmune[32] = true;
            laugicalityPlayer.player.buffImmune[31] = true;
            laugicalityPlayer.player.buffImmune[35] = true;
            laugicalityPlayer.player.buffImmune[23] = true;
            laugicalityPlayer.player.buffImmune[22] = true;
        }

        private static void DownedAnnihilatorEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Laugicality.soulStoneAbility.JustPressed || laugicalityPlayer.player.HasBuff(Laugicality.Instance.BuffType<SoulStoneAbilityCooldownBuff>())) return;

            foreach(Projectile projectile in Main.projectile)
            {
                laugicalityPlayer.player.immune = true;
                laugicalityPlayer.player.immuneTime = 5 * 60;
                if (projectile.hostile && projectile.damage > 0 && projectile.timeLeft > 10)
                    projectile.Kill();
            }

            laugicalityPlayer.player.AddBuff(Laugicality.Instance.BuffType<SoulStoneAbilityCooldownBuff>(), 90 * 60);
        }

        private static void DownedSlybertronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.potionDelayTime -= 15 * 60;
        }

        private static void DownedSteamTrainEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.buffImmune[Laugicality.Instance.BuffType<Steamy>()] = true;
            laugicalityPlayer.Steamified = true;
        }

        private static void DownedPlanteraEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.grapCount > 0)
            {
                laugicalityPlayer.player.immune = true;
                laugicalityPlayer.player.immuneTime = 2;
                laugicalityPlayer.player.AddBuff(Laugicality.Instance.BuffType<TrueCurse>(), 2);
            }
        }

        private static void DownedGolemEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if(Main.dayTime)
            {
                laugicalityPlayer.player.statDefense += 5;
                laugicalityPlayer.DamageBoost(.05f);
                laugicalityPlayer.player.lifeRegen += 5;
                laugicalityPlayer.player.endurance += .05f;
            }
        }

        private static void DownedDukeFishronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.ignoreWater = true;
            if (laugicalityPlayer.player.wet || laugicalityPlayer.player.honeyWet || laugicalityPlayer.player.lavaWet)
            {
                laugicalityPlayer.player.moveSpeed += .25f;
                laugicalityPlayer.player.maxRunSpeed *= 1.25f;
            }
        }

        private static void DownedEtheriaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.buffImmune[Laugicality.Instance.BuffType<Frostbite>()] = true;
            laugicalityPlayer.player.npcTypeNoAggro[Laugicality.Instance.NPCType<EtherialSpirit>()] = true;
        }

        private static void DownedMoonLordEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.MoonLordEffect = true;
        }


        //Curses
        private static void CurseEffect1(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.endurance -= .05f;
        }

        private static void CurseEffect2(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.CancelNoKnockback = true;
        }

        private static void CurseEffect3(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.UtilityCurse3 = true;
        }

        private static void CurseEffect4(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.buffImmune[BuffID.Ironskin] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Regeneration] = true;
            laugicalityPlayer.player.buffImmune[BuffID.ManaRegeneration] = true;
            laugicalityPlayer.player.buffImmune[BuffID.MagicPower] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Wrath] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Rage] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Endurance] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Titan] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Thorns] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Archery] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Calm] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Heartreach] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Lifeforce] = true;
            laugicalityPlayer.player.buffImmune[BuffID.ObsidianSkin] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Summoning] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Swiftness] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Warmth] = true;
            laugicalityPlayer.player.buffImmune[Laugicality.Instance.BuffType<DestructionBoost>()] = true;
            laugicalityPlayer.player.buffImmune[Laugicality.Instance.BuffType<IllusionBoost>()] = true;
            laugicalityPlayer.player.buffImmune[Laugicality.Instance.BuffType<ConjurationBoost>()] = true;
            laugicalityPlayer.player.buffImmune[Laugicality.Instance.BuffType<Albus>()] = true;
            laugicalityPlayer.player.buffImmune[Laugicality.Instance.BuffType<Aquos>()] = true;
            laugicalityPlayer.player.buffImmune[Laugicality.Instance.BuffType<Aura>()] = true;
            laugicalityPlayer.player.buffImmune[Laugicality.Instance.BuffType<Rubrum>()] = true;
            laugicalityPlayer.player.buffImmune[Laugicality.Instance.BuffType<Regis>()] = true;
            laugicalityPlayer.player.buffImmune[Laugicality.Instance.BuffType<Verdi>()] = true;
        }
    }
}
