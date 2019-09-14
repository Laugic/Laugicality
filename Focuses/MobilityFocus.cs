using Laugicality.SoulStones;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Focuses
{
    public sealed class MobilityFocus : Focus
    {
        public MobilityFocus() : base(LaugicalityPlayer.FOCUS_NAME_MOBILITY, "Mobility", Color.Green, new FocusEffect[]
        {
            new FocusEffect(p => NPC.downedSlimeKing, DownedKingSlimeEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedKingSlime", "Increased Jump Height") { overrideColor = new Color(0x2B, 0x9D, 0xE9) }), 
            new FocusEffect(p => NPC.downedBoss1, DownedEyeOfCthulhuEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedEyeOfCthulhu", "Increased movement speed when below 50% life") { overrideColor = new Color(0xB0, 0x3A, 0x2E) }),
            new FocusEffect(p => LaugicalityWorld.downedDuneSharkron, DownedDuneSharkronEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedDuneSharkron", "Innate magic carpet effect") { overrideColor = new Color(0xF4, 0xE6, 0x92) }),
            new FocusEffect(p => NPC.downedBoss2, DownedWorldEvilBossEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedWorldEvilBoss", "+10% Increased Movement Speed and Run Speed") { overrideColor = new Color(0x88, 0x4E, 0xA0)}),
            new FocusEffect(p => LaugicalityWorld.downedHypothema, DownedHypothemaEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedHypothema", "Immunity to cold debuffs (including Chilled and Frostburn)") { overrideColor = new Color(0x98, 0xE1, 0xEA) }),
            new FocusEffect(p => NPC.downedQueenBee, DownedQueenBeeEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedQueenBee", "When not moving vertically, increased Run Speed") { overrideColor = new Color(0xF3, 0x9C, 0x12)}),
            new FocusEffect(p => LaugicalityWorld.downedRagnar, DownedRagnarEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedRagnar", "Greatly increased Mobility while in the Obsidium, while in the Underworld, or while affected by a debuff") { overrideColor = new Color(0xED, 0x4B, 0x23) }),
            new FocusEffect(p => NPC.downedBoss3, DownedSkeletronEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedSkeletron", "Low chance to dodge an attack when hit") { overrideColor = new Color(0x83, 0x91, 0x92) }),
            new FocusEffect(p => LaugicalityWorld.downedAnDio, DownedAnDioEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedAnDio", "Greatly increased Mobility while Time is stopped. You can move during Time Stop.") { overrideColor = new Color(0x42, 0x86, 0xF4) }),
            new FocusEffect(p => Main.hardMode, DownedWallOfFleshEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedWallOfFleshEffect", "Pressing the Ability Key teleports you to the mouse. 15 second cooldown.") { overrideColor = new Color(0xAC, 0x39, 0x5A) }),
            new FocusEffect(p => NPC.downedMechBoss2, DownedTwinsEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedTwinsEffect", "Increased wing flight time if worn under wings") { overrideColor = new Color(0x2B, 0xD3, 0x4D) }),
            new FocusEffect(p => NPC.downedMechBoss1, DownedDestroyerEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedDestroyerEffect", "You are immune to Knockback") { overrideColor = new Color(0xDF, 0x0A, 0x0A) }),
            new FocusEffect(p => NPC.downedMechBoss3, DownedSkeletronPrimeEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedSkeletronPrimeEffect", "Half of your global damage modifier is applied to your Run Speed") { overrideColor = new Color(0xAA, 0xAA, 0xAA) }),
            new FocusEffect(p => LaugicalityWorld.downedAnnihilator, DownedAnnihilatorEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedAnnihilator", "Cooldown of the teleportation Ability reduced to 8 seconds. Become immune after teleporting") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => LaugicalityWorld.downedSlybertron, DownedSlybertronEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedSlybertron", "Increased Jump Height and Wing acceleration when you have Potion Sickness") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => LaugicalityWorld.downedSteamTrain, DownedSteamTrainEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedSteamTrain", "The faster you move, the higher your damage. +10% Max Run Speed.") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => NPC.downedPlantBoss, DownedPlanteraEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedPlantera", "Large movement boost when under 50% life") { overrideColor = new Color(0x81, 0xD8, 0x79) }),
            new FocusEffect(p => NPC.downedGolemBoss, DownedGolemEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedGolem", "When standing still, charge up energy. Moving releases it in a burst of speed.") { overrideColor = new Color(0xCC, 0x88, 0x37) }),
            new FocusEffect(p => NPC.downedFishron, DownedDukeFishronEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedDukeFishron", "Free movement in liquids. Greatly increased Mobility while in liquids.") { overrideColor = new Color(0x37, 0xC4, 0xCC) }),
            new FocusEffect(p => LaugicalityWorld.downedEtheria || LaugicalityWorld.downedTrueEtheria, DownedEtheriaEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedEtheria", "+20% Max Run Speed and Movement Speed while in the Etherial") { overrideColor = new Color(0x85, 0xCB, 0xF7) }),
            new FocusEffect(p => NPC.downedMoonlord, DownedMoonLordEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedMoonLord", "'+50% Movement speed, +10% Max Run Speed. Chance to dodge attacks based on how fast you are moving") { overrideColor = new Color(0x37, 0xCC, 0x8B) }),
        }, new FocusEffect[]
        {
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect1, new TooltipLine(Laugicality.Instance, "MobilityFocusCurse1", "-5% Movement Speed & Max Run Speed") { overrideColor = Color.Green }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect2, new TooltipLine(Laugicality.Instance, "MobilityFocusCurse2", "Taking damage slows you down for a time.") { overrideColor = Color.Green }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect3, new TooltipLine(Laugicality.Instance, "MobilityFocusCurse3", "Reduced movement speed when above 50% Life") { overrideColor = Color.Green }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect4, new TooltipLine(Laugicality.Instance, "MobilityFocusCurse4", "You cannot fly") { overrideColor = Color.Green }),
        })
        {

        }

        private static void DownedKingSlimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.jumpSpeedBoost += 3;
        }

        private static void DownedEyeOfCthulhuEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.statLife < laugicalityPlayer.player.statLifeMax2 / 2)
                laugicalityPlayer.player.moveSpeed += .25f;
        }

        private static void DownedDuneSharkronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.carpet = true;
        }

        private static void DownedWorldEvilBossEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.moveSpeed += .1f;
            laugicalityPlayer.player.maxRunSpeed *= 1.1f;
        }

        private static void DownedHypothemaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.resistCold = true;
        }

        private static void DownedQueenBeeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.velocity.Y == 0)
                laugicalityPlayer.player.maxRunSpeed *= 1.2f;
        }

        private static void DownedRagnarEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if(laugicalityPlayer.player.ZoneUnderworldHeight || laugicalityPlayer.zoneObsidium || laugicalityPlayer.LosingLife)
            {
                laugicalityPlayer.player.moveSpeed += .15f;
                laugicalityPlayer.player.maxRunSpeed *= 1.15f;
            }
        }

        private static void DownedSkeletronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.SkeletronEffect = true;
        }

        private static void DownedAnDioEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.zMove = true;
            if(Laugicality.zaWarudo > 0)
            {
                laugicalityPlayer.player.moveSpeed += 1;
                laugicalityPlayer.player.maxRunSpeed *= 1.5f;
            }
        }

        private static void DownedWallOfFleshEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Laugicality.soulStoneAbility.JustPressed || laugicalityPlayer.player.HasBuff(Laugicality.Instance.BuffType<SoulStoneAbilityCooldownBuff>())) return;

            laugicalityPlayer.player.Center = Main.MouseWorld;
            if(LaugicalityWorld.downedAnnihilator)
            {
                laugicalityPlayer.player.AddBuff(Laugicality.Instance.BuffType<SoulStoneAbilityCooldownBuff>(), 8 * 60);
                laugicalityPlayer.player.immune = true;
                laugicalityPlayer.player.immuneTime = 2 * 60;
            }
            else
                laugicalityPlayer.player.AddBuff(Laugicality.Instance.BuffType<SoulStoneAbilityCooldownBuff>(), 15 * 60);
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
            laugicalityPlayer.player.maxRunSpeed *= (1 + (laugicalityPlayer.player.allDamage - 1) / 2);
            laugicalityPlayer.player.moveSpeed *= (1 + (laugicalityPlayer.player.allDamage - 1) / 2);
            laugicalityPlayer.player.accRunSpeed *= (1 + (laugicalityPlayer.player.allDamage - 1) / 2);
        }

        private static void DownedAnnihilatorEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            //Yeet
        }

        private static void DownedSlybertronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.potionDelay > 0)
            {
                laugicalityPlayer.player.jumpSpeedBoost += 6f;
            }
        }

        private static void DownedSteamTrainEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.maxRunSpeed *= 1.1f;
            float moveSpeed = 0;
            moveSpeed = (float)Math.Abs(laugicalityPlayer.player.velocity.X) / 50f;
            if (moveSpeed > .25f)
                moveSpeed = .25f;
            laugicalityPlayer.player.allDamage += moveSpeed;
        }

        private static void DownedPlanteraEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.statLife < laugicalityPlayer.player.statLifeMax2 / 2)
            {
                laugicalityPlayer.player.moveSpeed += .25f;
                laugicalityPlayer.player.maxRunSpeed *= 1.25f;
                laugicalityPlayer.player.accRunSpeed *= 1.25f;
            }
        }

        private static void DownedGolemEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.velocity.X == 0 && laugicalityPlayer.player.velocity.Y == 0)
                laugicalityPlayer.GolemBoost += .05f;
            else if(laugicalityPlayer.GolemBoost > 0)
            {
                laugicalityPlayer.player.moveSpeed += laugicalityPlayer.GolemBoost;
                laugicalityPlayer.player.maxRunSpeed += laugicalityPlayer.GolemBoost;
                laugicalityPlayer.player.runAcceleration += laugicalityPlayer.GolemBoost;
                laugicalityPlayer.player.jumpSpeedBoost += laugicalityPlayer.GolemBoost;
                laugicalityPlayer.GolemBoost -= .2f;
            }
            if (laugicalityPlayer.GolemBoost < 0)
                laugicalityPlayer.GolemBoost = 0;
            if (laugicalityPlayer.GolemBoost > 4)
                laugicalityPlayer.GolemBoost = 4;
        }

        private static void DownedDukeFishronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.ignoreWater = true;
            if(laugicalityPlayer.player.wet || laugicalityPlayer.player.honeyWet || laugicalityPlayer.player.lavaWet)
            {
                laugicalityPlayer.player.moveSpeed += .25f;
                laugicalityPlayer.player.maxRunSpeed *= 1.25f;
            }
        }

        private static void DownedEtheriaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (LaugicalityWorld.downedEtheria || laugicalityPlayer.Etherable > 0)
            {
                laugicalityPlayer.player.moveSpeed += .2f;
                laugicalityPlayer.player.maxRunSpeed *= 1.2f;
            }
        }

        private static void DownedMoonLordEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.moveSpeed += .5f;
            laugicalityPlayer.player.maxRunSpeed *= 1.1f;
            laugicalityPlayer.MoonLordEffect = true;
        }

        //Curses
        private static void CurseEffect1(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.moveSpeed *= .95f;
            laugicalityPlayer.player.maxRunSpeed *= .95f;
        }

        private static void CurseEffect2(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.MobilityCurse2 = true;
        }

        private static void CurseEffect3(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.statLife >= laugicalityPlayer.player.statLifeMax2 / 2)
            {
                laugicalityPlayer.player.moveSpeed *= .8f;
                laugicalityPlayer.player.maxRunSpeed *= .8f;
            }
        }

        private static void CurseEffect4(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.wingTimeMax = 1;
        }
    }
}
