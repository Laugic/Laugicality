using Laugicality.Buffs;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Time;

namespace Laugicality.Focuses
{
    public sealed class FerocityFocus : Focus
    {
        public FerocityFocus() : base(LaugicalityPlayer.FOCUS_NAME_FEROCITY, "Ferocity", Color.Red, new FocusEffect[]
        {
            new FocusEffect(p => NPC.downedSlimeKing, DownedKingSlimeEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedKingSlime", "Attacks inflict 'Slimed'") { overrideColor = new Color(0x2B, 0x9D, 0xE9) }),
            new FocusEffect(p => NPC.downedBoss1, DownedEyeOfCthulhuEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedEyeOfCthulhu", "+5% Damage at Night") { overrideColor = new Color(0xB0, 0x3A, 0x2E) }),
            new FocusEffect(p => LaugicalityWorld.downedDuneSharkron, DownedDuneSharkronEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedDuneSharkron", "Increased damage the lower your life is") { overrideColor = new Color(0xF4, 0xE6, 0x92) }),
            new FocusEffect(p => NPC.downedBoss2, DownedWorldEvilBossEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedWorldEvilBoss", "Gain 'Blood Rage' when struck, increasing damage for a time") { overrideColor = new Color(0x88, 0x4E, 0xA0)}),
            new FocusEffect(p => LaugicalityWorld.downedHypothema, DownedHypothemaEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedHypothema", "Attacks inflict 'Frostburn'") { overrideColor = new Color(0x98, 0xE1, 0xEA) }),
            new FocusEffect(p => NPC.downedQueenBee, DownedQueenBeeEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedQueenBee", "Attacks inflict 'Poison', Thorns effect") { overrideColor = new Color(0xF3, 0x9C, 0x12)}),
            new FocusEffect(p => LaugicalityWorld.downedRagnar, DownedRagnarEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedRagnar", "Increased damage for a time after submerging in Lava") { overrideColor = new Color(0xED, 0x4B, 0x23) }),
            new FocusEffect(p => NPC.downedBoss3, DownedSkeletronEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedSkeletron", "+8% Crit Chance") { overrideColor = new Color(0x83, 0x91, 0x92) }),
            new FocusEffect(p => LaugicalityWorld.downedAnDio, DownedAnDioEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedAnDio", "Increased damage while Time is stopped") { overrideColor = new Color(0x42, 0x86, 0xF4) }),
            new FocusEffect(p => Main.hardMode, DownedWallOfFleshEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedWallOfFleshEffect", "+8% Damage. Attacks inflict 'On Fire'") { overrideColor = new Color(0xAC, 0x39, 0x5A) }),
            new FocusEffect(p => NPC.downedMechBoss2, DownedTwinsEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedTwinsEffect", "Attacks inflict 'Cursed Flame'") { overrideColor = new Color(0x2B, 0xD3, 0x4D) }),
            new FocusEffect(p => NPC.downedMechBoss1, DownedDestroyerEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedDestroyerEffect", "Enemies that collide with you take 200% of the damage dealt to you") { overrideColor = new Color(0xDF, 0x0A, 0x0A) }),
            new FocusEffect(p => NPC.downedMechBoss3, DownedSkeletronPrimeEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedSkeletronPrimeEffect", "Half of your global damage modifier is applied twice") { overrideColor = new Color(0xAA, 0xAA, 0xAA) }),
            new FocusEffect(p => LaugicalityWorld.downedAnnihilator, DownedAnnihilatorEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedAnnihilator", "Pressing the Ability Key makes you deal 25% more damage and take 80% more damage. Can be stacked up to 2 times, then resets to 0.") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => LaugicalityWorld.downedSlybertron, DownedSlybertronEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedSlybertron", "+10% Damage when you have Potion Sickness") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => LaugicalityWorld.downedSteamTrain, DownedSteamTrainEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedSteamTrain", "The faster you move, the higher your damage") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => NPC.downedPlantBoss, DownedPlanteraEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedPlantera", "Attacks inflict 'Jungle Plague'") { overrideColor = new Color(0x81, 0xD8, 0x79) }),
            new FocusEffect(p => NPC.downedGolemBoss, DownedGolemEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedGolem", "The longer you stand still without moving while a boss is alive, the higher your damage.") { overrideColor = new Color(0xCC, 0x88, 0x37) }),
            new FocusEffect(p => NPC.downedFishron, DownedDukeFishronEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedDukeFishron", "+10% Damage when in liquid") { overrideColor = new Color(0x37, 0xC4, 0xCC) }),
            new FocusEffect(p => LaugicalityWorld.downedEtheria || LaugicalityWorld.downedTrueEtheria, DownedEtheriaEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedEtheria", "+20% Damage in the Etherial") { overrideColor = new Color(0x85, 0xCB, 0xF7) }),
            new FocusEffect(p => NPC.downedMoonlord, DownedMoonLordEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedMoonLord", "Pressing the Ability key now makes you deal 100% more damage and makes you take 200% more damage per stack") { overrideColor = new Color(0x37, 0xCC, 0x8B) }),
        }, new FocusEffect[]
        {
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect1, new TooltipLine(Laugicality.Instance, "FerocityFocusCurse1", "-5% Damage") { overrideColor = Color.Red }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect2, new TooltipLine(Laugicality.Instance, "FerocityFocusCurse2", "Your critical strike chance is halved") { overrideColor = Color.Red }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect3, new TooltipLine(Laugicality.Instance, "FerocityFocusCurse3", "-20% Damage when above 50% Life") { overrideColor = Color.Red }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect4, new TooltipLine(Laugicality.Instance, "FerocityFocusCurse4", "You cannot buff your damage") { overrideColor = Color.Red }),
        })
        {

        }

        private static void DownedKingSlimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Slimey = true;
        }

        private static void DownedEyeOfCthulhuEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Main.dayTime)
                laugicalityPlayer.DamageBoost(.05f);
        }

        private static void DownedDuneSharkronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.DamageBoost(.2f * (1 - ((float)laugicalityPlayer.player.statLife / (float)laugicalityPlayer.player.statLifeMax2)));
        }

        private static void DownedWorldEvilBossEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.BloodRage = true;
        }

        private static void DownedHypothemaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Frost = true;
        }

        private static void DownedQueenBeeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Poison = true;
            laugicalityPlayer.player.thorns += .33f;
        }

        private static void DownedRagnarEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.lavaWet)
                laugicalityPlayer.player.AddBuff(ModContent.BuffType<LavaDamageBuff>(), 15 * 60);
        }

        private static void DownedSkeletronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            CritBoost(laugicalityPlayer, 8);
        }

        private static void DownedAnDioEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if(Laugicality.zaWarudo > 0 || TimeManagement.TimeAltered)
                laugicalityPlayer.DamageBoost(.15f);
        }

        private static void DownedWallOfFleshEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.allDamage += .08f;
            laugicalityPlayer.Obsidium = true;
        }

        private static void DownedTwinsEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.CursedFlame = true;
        }

        private static void DownedDestroyerEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.thorns += 2f;
        }

        private static void DownedSkeletronPrimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.DamageBoost((laugicalityPlayer.GetGlobalDamage() - 1) / 2);
        }

        private static void DownedAnnihilatorEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (Laugicality.soulStoneAbility.JustPressed)
            {
                laugicalityPlayer.AbilityCount++;
                if (laugicalityPlayer.AbilityCount > 2)
                    laugicalityPlayer.AbilityCount = 0;
                Main.NewText("You have currently stacked the ability " + laugicalityPlayer.AbilityCount.ToString() + " times.", 225, 225, 225);
            }
            if(laugicalityPlayer.AbilityCount > 0)
            {
                if (NPC.downedMoonlord)
                {
                    laugicalityPlayer.DamageBoost(1f * (1 + laugicalityPlayer.AbilityCount));
                    laugicalityPlayer.player.endurance -= 2f * laugicalityPlayer.AbilityCount;
                }
                else
                {
                    laugicalityPlayer.DamageBoost(.25f * (1 + laugicalityPlayer.AbilityCount));
                    laugicalityPlayer.player.endurance -= .8f * laugicalityPlayer.AbilityCount;
                }
            }
        }

        private static void DownedSlybertronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.potionDelay > 0)
                laugicalityPlayer.DamageBoost(.1f);
        }

        private static void DownedSteamTrainEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            float moveSpeed = 0;
            moveSpeed = (float)Math.Abs(laugicalityPlayer.player.velocity.X) / 50f;
            if (moveSpeed > .25f)
                moveSpeed = .25f;
            laugicalityPlayer.player.allDamage += moveSpeed;
        }

        private static void DownedPlanteraEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.JunglePlague = true;
        }

        private static void DownedGolemEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            bool bossActive = false;
            foreach (NPC npc in Main.npc)
            {
                if (npc.boss)
                    bossActive = true;
            }
            if(!bossActive || laugicalityPlayer.player.velocity.X != 0 || laugicalityPlayer.player.velocity.Y != 0)
            {
                laugicalityPlayer.GolemBoost = 0;
            }
            else
            {
                if (laugicalityPlayer.GolemBoost < .5f)
                    laugicalityPlayer.GolemBoost += .002f;
            }
            laugicalityPlayer.player.allDamage += laugicalityPlayer.GolemBoost;
        }

        private static void DownedDukeFishronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.wet || laugicalityPlayer.player.honeyWet || laugicalityPlayer.player.lavaWet)
                laugicalityPlayer.DamageBoost(.1f);
        }

        private static void DownedEtheriaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (LaugicalityWorld.downedEtheria || laugicalityPlayer.Etherable > 0)
                laugicalityPlayer.DamageBoost(.2f);
        }

        private static void DownedMoonLordEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!LaugicalityWorld.downedAnnihilator)
                DownedAnnihilatorEffect(laugicalityPlayer, hideAccessory);
        }



        //Curses
        private static void CurseEffect1(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.DamageBoost(-.05f);
        }

        private static void CurseEffect2(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.meleeCrit /= 2;
            laugicalityPlayer.player.magicCrit /= 2;
            laugicalityPlayer.player.rangedCrit /= 2;
            laugicalityPlayer.player.thrownCrit /= 2;
        }

        private static void CurseEffect3(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if(laugicalityPlayer.player.statLife > laugicalityPlayer.player.statLifeMax2 / 2)
                laugicalityPlayer.DamageBoost(-.2f);
        }

        private static void CurseEffect4(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.NoBuffedDamage = true;
            if (laugicalityPlayer.player.allDamage > 1)
                laugicalityPlayer.player.allDamage = 1;
            if (laugicalityPlayer.player.meleeDamage > 1)
                laugicalityPlayer.player.meleeDamage = 1;
            if (laugicalityPlayer.player.rangedDamage > 1)
                laugicalityPlayer.player.rangedDamage = 1;
            if (laugicalityPlayer.player.minionDamage > 1)
                laugicalityPlayer.player.minionDamage = 1;
            if (laugicalityPlayer.player.magicDamage > 1)
                laugicalityPlayer.player.magicDamage = 1;
            if (laugicalityPlayer.player.thrownDamage > 1)
                laugicalityPlayer.player.thrownDamage = 1;
            if (laugicalityPlayer.MysticDamage > 1)
                laugicalityPlayer.MysticDamage = 1;
            if (laugicalityPlayer.player.allDamageMult > 1)
                laugicalityPlayer.player.allDamageMult = 1;
            if (laugicalityPlayer.player.meleeDamageMult > 1)
                laugicalityPlayer.player.meleeDamageMult = 1;
            if (laugicalityPlayer.player.rangedDamageMult > 1)
                laugicalityPlayer.player.rangedDamageMult = 1;
            if (laugicalityPlayer.player.minionDamageMult > 1)
                laugicalityPlayer.player.minionDamageMult = 1;
            if (laugicalityPlayer.player.magicDamageMult > 1)
                laugicalityPlayer.player.magicDamageMult = 1;
            if (laugicalityPlayer.player.thrownDamageMult > 1)
                laugicalityPlayer.player.thrownDamageMult = 1;
            if (laugicalityPlayer.MysticDamage > 1)
                laugicalityPlayer.MysticDamage = 1;
        }

        private static void CritBoost(LaugicalityPlayer laugicalityPlayer, int Boost)
        {
            laugicalityPlayer.player.meleeCrit += Boost;
            laugicalityPlayer.player.magicCrit += Boost;
            laugicalityPlayer.player.rangedCrit += Boost;
            laugicalityPlayer.player.thrownCrit += Boost;
        }
    }
}
