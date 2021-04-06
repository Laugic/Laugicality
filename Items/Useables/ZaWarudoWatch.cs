using Laugicality.Buffs;
using Laugicality.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Time;

namespace Laugicality.Items.Useables
{
    public class ZaWarudoWatch : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The World");
            Tooltip.SetDefault("'ZA WARUDO!'");
        }

        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 42;
            item.value = 100;
            item.rare = ItemRarityID.Pink;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.expert = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !player.HasBuff(ModContent.BuffType<TimeExhausted>());
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/zawarudo"));
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            TimeManagement.TryAlterTime(new TimeAlterationRequest(player, modPlayer.zaWarudoDuration, 0));
            /*if(Laugicality.zaWarudo < modPlayer.zaWarudoDuration)
            {
                Laugicality.zaWarudo = modPlayer.zaWarudoDuration;
                LaugicalGlobalNPCs.zTime = modPlayer.zaWarudoDuration;
            }*/
            foreach ( Player player2 in Main.player)
               player.AddBuff(ModContent.BuffType<TimeExhausted>(), modPlayer.zCoolDown, true);
            return true;
        }
    }
}