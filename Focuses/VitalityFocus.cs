using Laugicality.Buffs;
using Laugicality.SoulStones;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Focuses
{
    public sealed class VitalityFocus : Focus
    {
        public VitalityFocus() : base(LaugicalityPlayer.FOCUS_NAME_VITALITY, "Vitality", Color.Gold, new FocusEffect[]
        {
            new FocusEffect(p => NPC.downedSlimeKing, DownedKingSlimeEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedKingSlime", "+4 Life Regen while Jumping") { overrideColor = new Color(0x2B, 0x9D, 0xE9) }),
            new FocusEffect(p => NPC.downedBoss1, DownedEyeOfCthulhuEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedEyeOfCthulhu", "+25 Max Life during the Night") { overrideColor = new Color(0xB0, 0x3A, 0x2E) }),
            new FocusEffect(p => LaugicalityWorld.downedDuneSharkron, DownedDuneSharkronEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedDuneSharkron", "+25 Max Life during the Day") { overrideColor = new Color(0xF4, 0xE6, 0x92) }),
            new FocusEffect(p => NPC.downedBoss2, DownedWorldEvilBossEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedWorldEvilBoss", "If you are losing life, lose 2 less life (to a minimum of 1)") { overrideColor = new Color(0x88, 0x4E, 0xA0)}),
            new FocusEffect(p => LaugicalityWorld.downedHypothema, DownedHypothemaEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedHypothema", "Increased defense when affected by a life draining debuff") { overrideColor = new Color(0x98, 0xE1, 0xEA) }),
            new FocusEffect(p => NPC.downedQueenBee, DownedQueenBeeEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedQueenBee", "Honey provides quadruple the normal regeneration") { overrideColor = new Color(0xF3, 0x9C, 0x12)}),
            new FocusEffect(p => LaugicalityWorld.downedRagnar, DownedRagnarEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedRagnar", "Greatly increased Life Regeneration while submerged in Lava") { overrideColor = new Color(0xED, 0x4B, 0x23) }),
            new FocusEffect(p => NPC.downedBoss3, (p, h) => p.player.statLifeMax2 += p.player.statDefense, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedSkeletronEffect", "Your defense is added to your Max Life") { overrideColor = new Color(0x83, 0x91, 0x92) }),
            new FocusEffect(p => LaugicalityWorld.downedAnDio, DownedAnDioEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedAnDio", "Greatly increased Life Regeneration while Time is Stopped") { overrideColor = new Color(0x42, 0x86, 0xF4) }),
            new FocusEffect(p => Main.hardMode, DownedWallOfFleshEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedWallOfFleshEffect", "Pressing the Ability Key will heal you for 15% of your max life. 30 second cooldown.") { overrideColor = new Color(0xAC, 0x39, 0x5A) }),
            new FocusEffect(p => NPC.downedMechBoss2, DownedTwinsEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedTwinsEffect", "Increased life regen while flying") { overrideColor = new Color(0x2B, 0xD3, 0x4D) }),
            new FocusEffect(p => NPC.downedMechBoss1, DownedDestroyerEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedDestroyerEffect", "Prevent a lethal hit of damage if it does over 50 damage once every 90 seconds") { overrideColor = new Color(0xDF, 0x0A, 0x0A) }),
            new FocusEffect(p => NPC.downedMechBoss3, DownedSkeletronPrimeEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedSkeletronPrimeEffect", "Half your global damage modifier is applied to your Max Life") { overrideColor = new Color(0xAA, 0xAA, 0xAA) }),
            new FocusEffect(p => LaugicalityWorld.downedAnnihilator, DownedAnnihilatorEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedAnnihilator", "Ability cooldown reduced to 20 seconds. Attacks inflict 'Lovestruck'") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => LaugicalityWorld.downedSlybertron, DownedSlybertronEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedSlybertron", "Increased life regen when you have Potion Sickness") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => LaugicalityWorld.downedSteamTrain, DownedSteamTrainEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedSteamTrain", "Taking damage when not at full health returns you to full health instead once every 150 seconds.") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => NPC.downedPlantBoss, DownedPlanteraEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedPlantera", "Greatly increased life regen when grappled to a tile") { overrideColor = new Color(0x81, 0xD8, 0x79) }),
            new FocusEffect(p => NPC.downedGolemBoss, DownedGolemEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedGolem", "Greatly increased life regen while standing still") { overrideColor = new Color(0xCC, 0x88, 0x37) }),
            new FocusEffect(p => NPC.downedFishron, DownedDukeFishronEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedDukeFishron", "Being in liquid quadruples regeneration from Honey (again)") { overrideColor = new Color(0x37, 0xC4, 0xCC) }),
            new FocusEffect(p => LaugicalityWorld.downedEtheria || LaugicalityWorld.downedTrueEtheria, DownedEtheriaEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedEtheria", "+20% Max Life while in the Etherial") { overrideColor = new Color(0x85, 0xCB, 0xF7) }),
            new FocusEffect(p => NPC.downedMoonlord, DownedMoonLordEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedMoonLord", "If you would die from taking damage, your Max Life is reduced by 50% and you return to your max life. If your Max Life is under 100, this effect does not trigger.") { overrideColor = new Color(0x37, 0xCC, 0x8B) }),
        }, new FocusEffect[]
        {
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect1, new TooltipLine(Laugicality.Instance, "VitalityFocusCurse1", "-5% Max Life") { overrideColor = Color.Gold }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect2, new TooltipLine(Laugicality.Instance, "VitalityFocusCurse2", "If you are losing life, lose an additional 2 life per second") { overrideColor = Color.Gold }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect3, new TooltipLine(Laugicality.Instance, "VitalityFocusCurse3", "You cannot regen above 50% of your Max Life") { overrideColor = Color.Gold }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect4, new TooltipLine(Laugicality.Instance, "VitalityFocusCurse4", "You cannot boost your life total") { overrideColor = Color.Gold }),
        })
        {

        }
        
        private static void DownedKingSlimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.velocity.Y != 0f)
                laugicalityPlayer.player.lifeRegen += 4;
        }

        private static void DownedEyeOfCthulhuEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Main.dayTime)
                laugicalityPlayer.player.statLifeMax2 += 25;
        }

        private static void DownedDuneSharkronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (Main.dayTime)
                laugicalityPlayer.player.statLifeMax2 += 25;
        }

        private static void DownedWorldEvilBossEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.EvilBossEffect = true;
        }

        private static void DownedHypothemaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.HypothemaEffect = true;
        }

        private static void DownedQueenBeeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.honey)
                laugicalityPlayer.HoneyRegenMultiplier *= 4;
        }

        private static void DownedRagnarEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.lavaWet)
            {
                laugicalityPlayer.player.lifeRegen += 4;
                laugicalityPlayer.player.AddBuff(ModContent.BuffType<LavaRegen>(), 15 * 60);
            }
        }

        private static void DownedAnDioEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (Laugicality.zaWarudo > 0)
                laugicalityPlayer.player.lifeRegen += 12;
        }

        private static void DownedWallOfFleshEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Laugicality.soulStoneAbility.JustPressed || laugicalityPlayer.player.HasBuff(ModContent.BuffType<SoulStoneAbilityCooldownBuff>())) return;

            laugicalityPlayer.player.statLife += (int)(laugicalityPlayer.player.statLifeMax2 * 0.15f);

            if (LaugicalityWorld.downedAnnihilator)
                laugicalityPlayer.player.AddBuff(ModContent.BuffType<SoulStoneAbilityCooldownBuff>(), 20 * 60);
            else
                laugicalityPlayer.player.AddBuff(ModContent.BuffType<SoulStoneAbilityCooldownBuff>(), 30 * 60);
        }

        private static void DownedTwinsEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.velocity.Y < 0f)
                laugicalityPlayer.player.lifeRegen += 8;
        }

        private static void DownedDestroyerEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.DestroyerEffect = true;
        }

        private static void DownedSkeletronPrimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            float globalDmg = laugicalityPlayer.player.allDamage - 1;
            laugicalityPlayer.player.statLifeMax2 = (int)(laugicalityPlayer.player.statLifeMax2 + laugicalityPlayer.player.statLifeMax2 * globalDmg / 2);
        }

        private static void DownedAnnihilatorEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Lovestruck = true;
        }

        private static void DownedSlybertronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.potionDelay > 0)
                laugicalityPlayer.player.lifeRegen += 8;
        }

        private static void DownedSteamTrainEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.SteamTrainEffect = true;
        }

        private static void DownedPlanteraEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.grapCount > 0)
                laugicalityPlayer.player.lifeRegen += 10;
        }

        private static void DownedGolemEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (Math.Abs(laugicalityPlayer.player.velocity.X) < .1 && Math.Abs(laugicalityPlayer.player.velocity.Y) < .1)
                laugicalityPlayer.player.lifeRegen += 15;
        }
        
        private static void DownedDukeFishronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.honey && (laugicalityPlayer.player.wet || laugicalityPlayer.player.honeyWet || laugicalityPlayer.player.lavaWet))
                laugicalityPlayer.HoneyRegenMultiplier *= 4;
        }

        private static void DownedEtheriaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (LaugicalityWorld.downedEtheria || laugicalityPlayer.Etherable > 0)
                laugicalityPlayer.player.statLifeMax2 = (int)(1.2f * laugicalityPlayer.player.statLifeMax2);
        }

        private static void DownedMoonLordEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.MoonLordEffect = true;

            if(laugicalityPlayer.MoonLordLifeMult <= 1f)
                laugicalityPlayer.player.statLifeMax2 = (int)(laugicalityPlayer.MoonLordLifeMult * laugicalityPlayer.player.statLifeMax2);
        }

        private static void Yeet(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            //Lol
        }


        //Curses
        private static void CurseEffect1(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.statLifeMax2 = ((int)Math.Round((double)laugicalityPlayer.player.statLifeMax2 * .95 / 10)) * 10;
        }

        private static void CurseEffect2(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.VitalityCurse2 = true;
        }

        private static void CurseEffect3(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.statLife >= laugicalityPlayer.player.statLifeMax2 / 2)
                laugicalityPlayer.player.lifeRegen = 0;
        }

        private static void CurseEffect4(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.VitalityCurse4 = true;
        }
    }
}