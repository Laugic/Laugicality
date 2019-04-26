using Laugicality.SoulStones;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Focuses
{
    public sealed class VitalityFocus : Focus
    {
        public VitalityFocus() : base("VitalityFocus", "Vitality", Color.Red, new FocusEffect[]
        {
            new FocusEffect(p => NPC.downedSlimeKing, DownedKingSlimeEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedKingSlime", "+2 life regen while jumping") { overrideColor = new Color(0x2B, 0x9D, 0xE9) }), 
            new FocusEffect(p => NPC.downedBoss1, DownedEyeOfCthulhuEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedEyeOfCthulhu", "+25 max life during the night") { overrideColor = new Color(0xB0, 0x3A, 0x2E) }),
            new FocusEffect(p => NPC.downedBoss2, DownedWorldEvilBossEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedWorldEvilBoss", "If you are losing life, lose 2 less life (to a minimum of 1)") { overrideColor = new Color(0x88, 0x4E, 0xA0)}), 
            new FocusEffect(p => NPC.downedQueenBee, DownedQueenBeeEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedQueenBee", "Honey provides quadruple the normal regeneration") { overrideColor = new Color(0xF3, 0x9C, 0x12)}), 
            new FocusEffect(p => NPC.downedBoss3, (p, h) => p.player.statLifeMax2 += p.player.statDefense, new TooltipLine(Laugicality.instance, "VitalityFocusDownedSkeletronEffect", "Your defense is added to your max life") { overrideColor = new Color(0x83, 0x91, 0x92) }),
            new FocusEffect(p => Main.hardMode, DownedWallOfFleshEffect, new TooltipLine(Laugicality.instance, "VitalityFocusDownedWallOfFleshEffect", "Pressing the Ability Key will heal you for 15% of your max life. 30 second cooldown.") { overrideColor = new Color(0xAC, 0x39, 0x5A) }), 
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

        private static void DownedWorldEvilBossEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.lifeRegen < 0)
                laugicalityPlayer.player.lifeRegen = laugicalityPlayer.player.lifeRegen >= - 3 ? (laugicalityPlayer.player.lifeRegen + 2) : -1;
        }

        private static void DownedQueenBeeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.player.honey)
                laugicalityPlayer.HoneyRegenMultiplier += 4; // Base honey regen is 1hp/s.
        }

        private static void DownedWallOfFleshEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Laugicality.soulStoneAbility.JustPressed || laugicalityPlayer.player.HasBuff(Laugicality.instance.BuffType<SoulStoneAbilityCooldownBuff>())) return;

            laugicalityPlayer.player.statLife += (int)(laugicalityPlayer.player.statLifeMax2 * 0.15f);
            laugicalityPlayer.player.AddBuff(Laugicality.instance.BuffType<SoulStoneAbilityCooldownBuff>(), 30 * 60);
        }
    }
}