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
        public VitalityFocus() : base("VitalityFocus", "Vitality", Color.Gold, new FocusEffect[]
        {
            new FocusEffect(p => NPC.downedSlimeKing, DownedKingSlimeEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedKingSlime", "+2 Life Regen while Jumping") { overrideColor = new Color(0x2B, 0x9D, 0xE9) }), 
            new FocusEffect(p => NPC.downedBoss1, DownedEyeOfCthulhuEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedEyeOfCthulhu", "+25 Max Life during the Night") { overrideColor = new Color(0xB0, 0x3A, 0x2E) }),
            new FocusEffect(p => LaugicalityWorld.downedDuneSharkron, DownedDuneSharkronEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedDuneSHarkron", "+25 Max Life during the Day") { overrideColor = new Color(0xF4, 0xE6, 0x92) }),
            new FocusEffect(p => NPC.downedBoss2, DownedWorldEvilBossEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedWorldEvilBoss", "If you are losing life, lose 2 less life (to a minimum of 1)") { overrideColor = new Color(0x88, 0x4E, 0xA0)}),
            new FocusEffect(p => LaugicalityWorld.downedHypothema, DownedHypothemaEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedHypothema", "Increased defense when affected by a life draining debuff") { overrideColor = new Color(0x98, 0xE1, 0xEA) }),
            new FocusEffect(p => NPC.downedQueenBee, DownedQueenBeeEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedQueenBee", "Honey provides quadruple the normal regeneration") { overrideColor = new Color(0xF3, 0x9C, 0x12)}),
            new FocusEffect(p => LaugicalityWorld.downedRagnar, DownedRagnarEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedRagnar", "Greatly increased Life Regeneration while submerged in Lava") { overrideColor = new Color(0xED, 0x4B, 0x23) }),
            new FocusEffect(p => NPC.downedBoss3, (p, h) => p.player.statLifeMax2 += p.player.statDefense, new TooltipLine(Laugicality.instance, "VitalityFocusDownedSkeletronEffect", "Your defense is added to your Max Life") { overrideColor = new Color(0x83, 0x91, 0x92) }),
            new FocusEffect(p => LaugicalityWorld.downedAnDio, DownedAnDioEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedAnDio", "Greatly increased Life Regeneration while Time is Stopped") { overrideColor = new Color(0xFF, 0xFC, 0xC1) }),
            new FocusEffect(p => Main.hardMode, DownedWallOfFleshEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedWallOfFleshEffect", "Pressing the Ability Key will heal you for 15% of your max life. 30 second cooldown.") { overrideColor = new Color(0xAC, 0x39, 0x5A) }),
            new FocusEffect(p => NPC.downedMechBoss2, DownedTwinsEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedTwinsEffect", "Increased life regen while flying") { overrideColor = new Color(0x2B, 0xD3, 0x4D) }),
            new FocusEffect(p => NPC.downedMechBoss1, DownedDestroyerEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedDestroyerEffect", "Prevent a lethal hit of damage if it does over 60 damage once every 90 seconds") { overrideColor = new Color(0xDF, 0x0A, 0x0A) }),
            new FocusEffect(p => NPC.downedMechBoss3, DownedSkeletronPrimeEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedSkeletronPrimeEffect", "Increased life regen while flying") { overrideColor = new Color(0xAA, 0xAA, 0xAA) }),
            new FocusEffect(p => LaugicalityWorld.downedAnnihilator, Yeet, new TooltipLine(Laugicality.instance, "VitalityFocusDownedAnnihilator", "Pressing the Ability Key heals an additional 1% for every 2 enemies alive") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => LaugicalityWorld.downedSlybertron, DownedSlybertronEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedSlybertron", "Increased life regen when you have Potion Sickness") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => LaugicalityWorld.downedSteamTrain, DownedSteamTrainEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedSteamTrain", "Taking damage when not at full health returns you to full health instead once every 150 seconds.") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => NPC.downedPlantBoss, DownedPlanteraEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedPlantera", "Greatly increased life regen when grappled to a tile") { overrideColor = new Color(0x81, 0xD8, 0x79) }),
            new FocusEffect(p => NPC.downedGolemBoss, DownedGolemEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedGolem", "Greatly increased life regen while standing still") { overrideColor = new Color(0xCC, 0x88, 0x37) }),
            new FocusEffect(p => NPC.downedFishron, DownedDukeFishronEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedDukeFishron", "Being in liquid triples regeneration from Honey (again)") { overrideColor = new Color(0x37, 0xC4, 0xCC) }),
            new FocusEffect(p => LaugicalityWorld.downedEtheria || LaugicalityWorld.downedTrueEtheria, DownedEtheriaEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedEtheria", "+20% Max Life while in the Etherial") { overrideColor = new Color(0x85, 0xCB, 0xF7) }),
            new FocusEffect(p => NPC.downedMoonlord, DownedMoonLordEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedMoonLord", "If you would die from taking damage, your Max Life is reduced by 50%\nand you return to your max life. If your Max Life is under 100, this effect does not trigger.\nThis effect lasts for 90 seconds, after which your Max Life will return to normal.") { overrideColor = new Color(0x37, 0xCC, 0x8B) }),
        }, new FocusEffect[]
        {

        })
        {
        }

        private static void DownedKingSlimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.velocity.Y != 0f)
                laugicalityPlayer.player.lifeRegen += 2;
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
            if (laugicalityPlayer.player.lifeRegen < 0)
                laugicalityPlayer.player.lifeRegen = laugicalityPlayer.player.lifeRegen >= - 3 ? (laugicalityPlayer.player.lifeRegen + 2) : -1;
        }

        private static void DownedHypothemaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.lifeRegen < 0)
                laugicalityPlayer.player.statDefense += 8;
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
                laugicalityPlayer.player.AddBuff(Laugicality.instance.BuffType<LavaRegen>(), 15 * 60);
            }
        }

        private static void DownedAnDioEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (Laugicality.zaWarudo > 0)
                laugicalityPlayer.player.lifeRegen += 12;
        }

        private static void DownedWallOfFleshEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Laugicality.soulStoneAbility.JustPressed || laugicalityPlayer.player.HasBuff(Laugicality.instance.BuffType<SoulStoneAbilityCooldownBuff>())) return;

            laugicalityPlayer.player.statLife += (int)(laugicalityPlayer.player.statLifeMax2 * 0.15f);

            if (LaugicalityWorld.downedAnnihilator)
                DownedAnnihilatorEffect(laugicalityPlayer, hideAccessory);

            laugicalityPlayer.player.AddBuff(Laugicality.instance.BuffType<SoulStoneAbilityCooldownBuff>(), 30 * 60);
        }

        private static void DownedTwinsEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.wingTime > 0)
                laugicalityPlayer.player.lifeRegen += 80; //TODO reduce after testing
        }

        private static void DownedDestroyerEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.DestroyerEffect = true;
        }

        private static void DownedSkeletronPrimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            float globalDmg = laugicalityPlayer.GetGlobalDamage();
            laugicalityPlayer.player.statLifeMax2 = (int)(laugicalityPlayer.player.statLifeMax2 + laugicalityPlayer.player.statLifeMax2 * globalDmg / 2);
        }

        private static void DownedAnnihilatorEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            int count = 0;
            foreach(NPC npc in Main.npc)
            {
                if(npc.damage > 0)
                count++;
            }
            laugicalityPlayer.player.statLife += (int)(laugicalityPlayer.player.statLifeMax2 * 0.01f * count / 2);
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
            if (laugicalityPlayer.player.honey && (laugicalityPlayer.player.wet || laugicalityPlayer.player.lavaWet || laugicalityPlayer.player.lavaWet))
                laugicalityPlayer.HoneyRegenMultiplier *= 4;
        }

        private static void DownedEtheriaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (LaugicalityWorld.downedEtheria)
                laugicalityPlayer.player.statLifeMax2 = (int)(1.2f * laugicalityPlayer.player.statLifeMax2);
        }

        private static void DownedMoonLordEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.MoonLordEffect = true;

            if(laugicalityPlayer.MoonLordLifeMult > 1f)
                laugicalityPlayer.player.statLifeMax2 = (int)(laugicalityPlayer.MoonLordLifeMult * laugicalityPlayer.player.statLifeMax2);
        }

        private static void Yeet(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            //Lol
        }
    }
}