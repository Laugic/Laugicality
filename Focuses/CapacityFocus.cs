using Laugicality.Projectiles;
using Laugicality.Projectiles.SoulStone;
using Laugicality.SoulStones;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Focuses
{
    public sealed class CapacityFocus : Focus
    {
        public CapacityFocus() : base("CapacityFocus", "Capacity", Color.Blue, new FocusEffect[]
        {
            new FocusEffect(p => NPC.downedSlimeKing, DownedKingSlimeEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedKingSlime", "If you take contact damage while falling, stomp on the enemy that deals the damage") { overrideColor = new Color(0x2B, 0x9D, 0xE9) }),
            new FocusEffect(p => NPC.downedBoss1, DownedEyeOfCthulhuEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedEyeOfCthulhu", "Release Eyes when damaged") { overrideColor = new Color(0xB0, 0x3A, 0x2E) }),
            new FocusEffect(p => LaugicalityWorld.downedDuneSharkron, DownedDuneSharkronEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedDuneSharkron", "Launch enemies affected by gravity into the air on contact") { overrideColor = new Color(0xF4, 0xE6, 0x92) }),
            new FocusEffect(p => NPC.downedBoss2, DownedWorldEvilBossEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedWorldEvilBoss", "Blood Rage when damaged") { overrideColor = new Color(0x88, 0x4E, 0xA0)}),
            new FocusEffect(p => LaugicalityWorld.downedHypothema, DownedHypothemaEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedHypothema", "Frost Touch- Inflict Frostburn on enemies in a short radius around you") { overrideColor = new Color(0x98, 0xE1, 0xEA) }),
            new FocusEffect(p => NPC.downedQueenBee, DownedQueenBeeEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedQueenBee", "Taking damage creates a ring of Thorns around you that damage and knock back enemies") { overrideColor = new Color(0xF3, 0x9C, 0x12)}),
            new FocusEffect(p => LaugicalityWorld.downedRagnar, DownedRagnarEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedRagnar", "Reduced damage from lava. Increased Damage and Defense while On Fire") { overrideColor = new Color(0xED, 0x4B, 0x23) }),
            new FocusEffect(p => NPC.downedBoss3, DownedSkeletronEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedSkeletron", "Spawn a friendly Dungeon Guardian when you take contact damage") { overrideColor = new Color(0x83, 0x91, 0x92) }),
            new FocusEffect(p => LaugicalityWorld.downedAnDio, DownedAnDioEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedAnDio", "Taking damage below 25% life automatically stops time. You are immune while time is stopped") { overrideColor = new Color(0x42, 0x86, 0xF4) }),
            new FocusEffect(p => Main.hardMode, DownedWallOfFleshEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedWallOfFleshEffect", "Taking more than 1 damage is reduced to 1 damage once every 2 minutes") { overrideColor = new Color(0xAC, 0x39, 0x5A) }),
            new FocusEffect(p => NPC.downedMechBoss2, DownedTwinsEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedTwinsEffect", "Taking damage creates a Shadow Double that follows you and deals damage to enemies") { overrideColor = new Color(0x2B, 0xD3, 0x4D) }),
            new FocusEffect(p => NPC.downedMechBoss1, DownedDestroyerEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedDestroyerEffect", "You are immune to knockback. Burst into lasers when damaged") { overrideColor = new Color(0xDF, 0x0A, 0x0A) }),
            new FocusEffect(p => NPC.downedMechBoss3, DownedSkeletronPrimeEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedSkeletronPrimeEffect", "Call a Dungeon Guardian Prime to fight for you when below 50% life") { overrideColor = new Color(0xAA, 0xAA, 0xAA) }),
            new FocusEffect(p => LaugicalityWorld.downedAnnihilator, DownedAnnihilatorEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedAnnihilator", "Pressing the Ability Key makes you take 1 damage.") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => LaugicalityWorld.downedSlybertron, DownedSlybertronEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedSlybertron", "Have an Electrosphere Aura around you which deals damage to enemies in a short range while you have Potion Sickness") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => LaugicalityWorld.downedSteamTrain, DownedSteamTrainEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedSteamTrain", "Deal more damage when Immune. Immune time increased") { overrideColor = new Color(0xF9, 0xEB, 0x90) }),
            new FocusEffect(p => NPC.downedPlantBoss, DownedPlanteraEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedPlantera", "Innate Spore Sack") { overrideColor = new Color(0x81, 0xD8, 0x79) }),
            new FocusEffect(p => NPC.downedGolemBoss, DownedGolemEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedGolem", "Spawn a Golem Head that shoots lasers at nearby enemies when below 50% life") { overrideColor = new Color(0xCC, 0x88, 0x37) }),
            new FocusEffect(p => NPC.downedFishron, DownedDukeFishronEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedDukeFishron", "Unleash the Sharks upon taking damage") { overrideColor = new Color(0x37, 0xC4, 0xCC) }),
            new FocusEffect(p => LaugicalityWorld.downedEtheria || LaugicalityWorld.downedTrueEtheria, DownedEtheriaEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedEtheria", "'Etherial Rage'- After taking damage, gain +20 Defense and +20% Damage for a time") { overrideColor = new Color(0x85, 0xCB, 0xF7) }),
            new FocusEffect(p => NPC.downedMoonlord, DownedMoonLordEffect, new TooltipLine(Laugicality.instance, "CapacityFocusDownedMoonLord", "Immune time after taking damage doubled. 20% Damage reduction. Spawn a True Eye of Cthulhu when below 50% Life") { overrideColor = new Color(0x37, 0xCC, 0x8B) }),
        }, new FocusEffect[]
        {
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect1, new TooltipLine(Laugicality.instance, "CapacityFocusCurse1", "Take 5 additional damage each time you are damaged") { overrideColor = Color.Blue }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect2, new TooltipLine(Laugicality.instance, "CapacityFocusCurse2", "Taking damage reduces your defense for a time") { overrideColor = Color.Blue }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect3, new TooltipLine(Laugicality.instance, "CapacityFocusCurse3", "Take 50% more collision damage above 50% Life") { overrideColor = Color.Blue }),
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect4, new TooltipLine(Laugicality.instance, "CapacityFocusCurse4", "Your immune time is halved") { overrideColor = Color.Blue }),
        })
        {

        }

        private static void DownedKingSlimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.KingSlimeStomp = true;
        }

        private static void DownedEyeOfCthulhuEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Eyes = true;
        }

        private static void DownedDuneSharkronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.SharkronEffect = true;
        }

        private static void DownedWorldEvilBossEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.BloodRage = true;
        }

        private static void DownedHypothemaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.HypothemaEffect = true;
            foreach(NPC npc in Main.npc)
            {
                float range = 48;
                if (npc.active && !npc.friendly && (npc.damage > 0 || npc.type == NPCID.TargetDummy) && !npc.dontTakeDamage && !npc.buffImmune[BuffID.Frostburn] && Vector2.Distance(laugicalityPlayer.player.Center, npc.Center) <= range)
                {
                    if (npc.FindBuffIndex(BuffID.Frostburn) == -1)
                    {
                        npc.AddBuff(BuffID.Frostburn, 2 * 60, false);
                    }
                }
            }
        }

        private static void DownedQueenBeeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.QueenBeeEffect = true;
        }

        private static void DownedRagnarEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.lavaRose = true;
            if(laugicalityPlayer.player.onFire)
            {
                laugicalityPlayer.DamageBoost(.15f);
                laugicalityPlayer.player.statDefense += 10;
            }
        }

        private static void DownedSkeletronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.SkeletronEffect = true;
        }

        private static void DownedAnDioEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.AnDioCapacityEffect = true;
            if(Laugicality.zaWarudo > 0)
            {
                laugicalityPlayer.player.immune = true;
                laugicalityPlayer.player.immuneTime = 2;
            }
        }

        private static void DownedWallOfFleshEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.WallOfFleshEffect = true;
        }

        private static void DownedTwinsEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.TwinsEffect = true;
        }

        private static void DownedDestroyerEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.noKnockback = true;
            laugicalityPlayer.DestroyerCapacityEffect = true;
        }

        private static void DownedSkeletronPrimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.SkeletronPrimeEffect = true;
        }

        private static void DownedAnnihilatorEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Laugicality.soulStoneAbility.JustPressed || laugicalityPlayer.player.HasBuff(Laugicality.instance.BuffType<SoulStoneAbilityCooldownBuff>())) return;

            laugicalityPlayer.player.Hurt(PlayerDeathReason.ByOther(2), 1, 0);

            laugicalityPlayer.player.AddBuff(Laugicality.instance.BuffType<SoulStoneAbilityCooldownBuff>(), 5 * 60);
        }

        private static void DownedSlybertronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if(laugicalityPlayer.player.potionDelay > 0)
            {
                if (laugicalityPlayer.SlybertronCounter <= 0)
                {
                    laugicalityPlayer.SlybertronCounter = 15;
                    if (Main.netMode != 1)
                    {
                        Projectile.NewProjectile(laugicalityPlayer.player.Center, new Vector2(0, 0), Laugicality.instance.ProjectileType<ElectroAura>(), (int)(48 * laugicalityPlayer.GetGlobalDamage()), 0, laugicalityPlayer.player.whoAmI);
                    }
                }
                else
                    laugicalityPlayer.SlybertronCounter--;
            }
        }

        private static void DownedSteamTrainEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.SteamTrainEffect = true;
            if (laugicalityPlayer.player.immuneTime > 0 && laugicalityPlayer.player.immune)
                laugicalityPlayer.DamageBoost(.1f);
        }

        private static void DownedPlanteraEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.player.SporeSac();
            laugicalityPlayer.player.sporeSac = true;
        }

        private static void DownedGolemEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.GolemEffect = true;
        }

        private static void DownedDukeFishronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.FishronEffect = true;
        }

        private static void DownedEtheriaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.EtheriaEffect = true;
        }

        private static void DownedMoonLordEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.MoonLordEffect = true;
            laugicalityPlayer.player.endurance += .2f;
        }


        //Curses
        private static void CurseEffect1(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.CapacityCurse1 = true;
        }

        private static void CurseEffect2(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.CapacityCurse2 = true;
        }

        private static void CurseEffect3(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.CapacityCurse3 = true;
        }

        private static void CurseEffect4(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.CapacityCurse4 = true;
        }
    }
}
