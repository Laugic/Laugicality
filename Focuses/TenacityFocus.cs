using Laugicality.Buffs;
using Laugicality.SoulStones;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Focuses
{
    public sealed class TenacityFocus : Focus
    {
        public TenacityFocus() : base(LaugicalityPlayer.FOCUS_NAME_TENACITY, "Tenacity", Color.Silver, new FocusEffect[]
        {
            new FocusEffect(p => NPC.downedSlimeKing, DownedKingSlimeEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedKingSlime", "You are immune to slimes") { overrideColor = new Color(0x2B, 0x9D, 0xE9) }),
            new FocusEffect(p => NPC.downedBoss1, DownedEyeOfCthulhuEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedEyeOfCthulhu", "Movement speed increased for a time after taking damage") { overrideColor = new Color(0xB0, 0x3A, 0x2E) }),
            new FocusEffect(p => LaugicalityWorld.downedDuneSharkron, DownedDuneSharkronEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedDuneSharkron", "You are immune to fall damage") { overrideColor = new Color(0xF4, 0xE6, 0x92) }),
            new FocusEffect(p => NPC.downedBoss2, DownedWorldEvilBossEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedWorldEvilBoss", "+5 Defense when below 50% Life") { overrideColor = new Color(0x88, 0x4E, 0xA0)}),
            new FocusEffect(p => LaugicalityWorld.downedHypothema, DownedHypothemaEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedHypothema", "Increased defense when affected by a life draining debuff") { overrideColor = new Color(0x98, 0xE1, 0xEA) }),
            new FocusEffect(p => NPC.downedQueenBee, DownedQueenBeeEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedQueenBee", "Immune to 'Poison' and 'Venom'") { overrideColor = new Color(0xF3, 0x9C, 0x12)}),
            new FocusEffect(p => LaugicalityWorld.downedRagnar, DownedRagnarEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedRagnar", "Increased Defense for a time after submerging in Lava") { overrideColor = new Color(0xED, 0x4B, 0x23) }),
            new FocusEffect(p => NPC.downedBoss3, DownedSkeletronEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedSkeletron", "+5 Defense at Night") { overrideColor = new Color(0x83, 0x91, 0x92) }),
            new FocusEffect(p => LaugicalityWorld.downedAnDio, DownedAnDioEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedAnDio", "Don't take damage while Time is stopped") { overrideColor = new Color(0x42, 0x86, 0xF4) }),
            new FocusEffect(p => Main.hardMode, DownedWallOfFleshEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedWallOfFleshEffect", "The longer you go without taking damage, the higher your defense") { overrideColor = new Color(0xAC, 0x39, 0x5A) }),
            new FocusEffect(p => NPC.downedMechBoss2, DownedTwinsEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedTwinsEffect", "+6 Defense when flying") { overrideColor = new Color(0x2B, 0xD3, 0x4D) }),
            new FocusEffect(p => NPC.downedMechBoss1, DownedDestroyerEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedDestroyerEffect", "Prevent a lethal hit of damage if it does over 50 damage once every 90 seconds") { overrideColor = new Color(0xDF, 0x0A, 0x0A) }),
            new FocusEffect(p => NPC.downedMechBoss3, DownedSkeletronPrimeEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedSkeletronPrimeEffect", "Half of your global damage modifier is applied to your defense") { overrideColor = new Color(0xAA, 0xAA, 0xAA) }),
            new FocusEffect(p => LaugicalityWorld.downedAnnihilator, DownedAnnihilatorEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedAnnihilator", "Pressing the Ability Key makes you invincible for 4 seconds. 60 Second Cooldown") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => LaugicalityWorld.downedSlybertron, DownedSlybertronEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedSlybertron", "+8 Defense when you have potion sickness") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => LaugicalityWorld.downedSteamTrain, DownedSteamTrainEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedSteamTrain", "Negate contact damage once every 90 seconds") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => NPC.downedPlantBoss, DownedPlanteraEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedPlantera", "+8 Defense when you are grappling") { overrideColor = new Color(0x81, 0xD8, 0x79) }),
            new FocusEffect(p => NPC.downedGolemBoss, DownedGolemEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedGolem", "+15 Defense and immune to Knockback when standing still") { overrideColor = new Color(0xCC, 0x88, 0x37) }),
            new FocusEffect(p => NPC.downedFishron, DownedDukeFishronEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedDukeFishron", "Being in liquid greatly increases defense") { overrideColor = new Color(0x37, 0xC4, 0xCC) }),
            new FocusEffect(p => LaugicalityWorld.downedEtheria || LaugicalityWorld.downedTrueEtheria, DownedEtheriaEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedEtheria", "Take 20% less damage in the Etherial") { overrideColor = new Color(0x85, 0xCB, 0xF7) }),
            new FocusEffect(p => NPC.downedMoonlord, DownedMoonLordEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedMoonLord", "Negate a hit of damage once every 30 seconds") { overrideColor = new Color(0x37, 0xCC, 0x8B) }),
        }, new FocusEffect[]
        {
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect1, new TooltipLine(Laugicality.Instance, "TenacityFocusCurse1", "-5% Defense") { overrideColor = Color.Silver }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect2, new TooltipLine(Laugicality.Instance, "TenacityFocusCurse2", "Taking damage makes you lose 10 defense for a time") { overrideColor = Color.Silver }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect3, new TooltipLine(Laugicality.Instance, "TenacityFocusCurse3", "You take 15% more damage above 50% Life") { overrideColor = Color.Silver }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect4, new TooltipLine(Laugicality.Instance, "TenacityFocusCurse4", "Your defense is halved.") { overrideColor = Color.Silver }),
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
            laugicalityPlayer.player.panic = true;
        }

        private static void DownedDuneSharkronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.noFallDmg = true;
        }

        private static void DownedWorldEvilBossEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if ((float)laugicalityPlayer.player.statLife < (float)laugicalityPlayer.player.statLifeMax2 / 2f)
                laugicalityPlayer.player.statDefense += 5;
        }

        private static void DownedHypothemaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.HypothemaEffect = true;
        }

        private static void DownedQueenBeeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            //laugicalityPlayer.QueenBeeEffect = true;
            laugicalityPlayer.player.buffImmune[BuffID.Poisoned] = true;
            laugicalityPlayer.player.buffImmune[BuffID.Venom] = true;
        }

        private static void DownedRagnarEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.lavaWet)
                laugicalityPlayer.player.AddBuff(Laugicality.Instance.BuffType<LavaDefenseBuff>(), 60 * 15);
        }

        private static void DownedSkeletronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Main.dayTime)
                laugicalityPlayer.player.statDefense += 5;
        }

        private static void DownedAnDioEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (Laugicality.zaWarudo > 0)
            {
                laugicalityPlayer.player.immune = true;
                laugicalityPlayer.player.immuneTime = 60;
            }
        }

        private static void DownedWallOfFleshEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if(laugicalityPlayer.DefenseCounter < 250)
                laugicalityPlayer.DefenseCounter += 1 / 120f;
            laugicalityPlayer.player.statDefense += (int)(laugicalityPlayer.DefenseCounter);
        }

        private static void DownedTwinsEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.velocity.Y < 0)
                laugicalityPlayer.player.statDefense += 6;
        }

        private static void DownedDestroyerEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.DestroyerEffect = true;
        }

        private static void DownedSkeletronPrimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            float globalDmg = laugicalityPlayer.player.allDamage - 1;
            laugicalityPlayer.player.statDefense = (int)(laugicalityPlayer.player.statDefense + laugicalityPlayer.player.statDefense * (globalDmg) / 2);
        }

        private static void DownedAnnihilatorEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Laugicality.soulStoneAbility.JustPressed || laugicalityPlayer.player.HasBuff(Laugicality.Instance.BuffType<SoulStoneAbilityCooldownBuff>())) return;

            laugicalityPlayer.player.immune = true;
            laugicalityPlayer.player.immuneTime += 4 * 60;

            laugicalityPlayer.player.AddBuff(Laugicality.Instance.BuffType<SoulStoneAbilityCooldownBuff>(), 60 * 60);
        }

        private static void DownedSlybertronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if(laugicalityPlayer.player.potionDelay > 0)
                laugicalityPlayer.player.statDefense += 8;

        }

        private static void DownedSteamTrainEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.SteamTrainEffect = true;
        }

        private static void DownedPlanteraEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.grapCount > 0)
                laugicalityPlayer.player.statDefense += 8;
        }

        private static void DownedGolemEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.velocity.X == 0 && laugicalityPlayer.player.velocity.Y == 0)
            {
                laugicalityPlayer.player.statDefense += 15;
                laugicalityPlayer.player.noKnockback = true;
            }
        }

        private static void DownedDukeFishronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.wet || laugicalityPlayer.player.honeyWet || laugicalityPlayer.player.lavaWet)
            {
                laugicalityPlayer.player.statDefense += 20;
            }
        }

        private static void DownedEtheriaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (LaugicalityWorld.downedEtheria || laugicalityPlayer.Etherable > 0)
                laugicalityPlayer.player.endurance += .2f;
        }

        private static void DownedMoonLordEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.MoonLordEffect = true;
        }



        //Curses
        private static void CurseEffect1(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.statDefense = (int)(laugicalityPlayer.player.statDefense * .95f);
        }

        private static void CurseEffect2(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.TenacityCurse2 = true;
        }

        private static void CurseEffect3(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.statLife > laugicalityPlayer.player.statLifeMax2 / 2)
                laugicalityPlayer.player.endurance *= .85f;
        }

        private static void CurseEffect4(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.statDefense /= 2;
        }
    }
}
