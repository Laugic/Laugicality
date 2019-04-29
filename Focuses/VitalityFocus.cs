using Laugicality.Buffs;
using Laugicality.SoulStones;
using Microsoft.Xna.Framework;
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
                laugicalityPlayer.HoneyRegenMultiplier += 4; // Base honey regen is 1hp/s.
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
            laugicalityPlayer.player.AddBuff(Laugicality.instance.BuffType<SoulStoneAbilityCooldownBuff>(), 30 * 60);
        }

        private static void DownedTwinsEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.wingTime > 0)
                laugicalityPlayer.player.lifeRegen += 40; //TODO reduce after testing
        }

        private static void DownedDestroyerEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.destroyerEffect = true;
        }

        private static void DownedSkeletronPrimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            float globalDmg = laugicalityPlayer.player.meleeDamage;

            if (laugicalityPlayer.player.rangedDamage < globalDmg)
                globalDmg = laugicalityPlayer.player.rangedDamage;

            if (laugicalityPlayer.player.magicDamage < globalDmg)
                globalDmg = laugicalityPlayer.player.magicDamage;

            if (laugicalityPlayer.player.thrownDamage < globalDmg)
                globalDmg = laugicalityPlayer.player.thrownDamage;

            if (laugicalityPlayer.player.minionDamage < globalDmg)
                globalDmg = laugicalityPlayer.player.minionDamage;

            if (globalDmg > 1)
                laugicalityPlayer.player.statLifeMax2 = (int)(laugicalityPlayer.player.statLifeMax2 + laugicalityPlayer.player.statLifeMax2 * globalDmg / 2);
        }

        private static void DownedAnnihilatorEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {

        }

        private static void DownedSlybertronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.potionDelay > 0)
                laugicalityPlayer.player.lifeRegen += 8;
        }

        private static void DownedSteamTrainEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {

        }
    }
}