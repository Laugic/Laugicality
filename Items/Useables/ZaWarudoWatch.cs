using Laugicality.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Useables
{
    public class ZaWarudoWatch : ModItem
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
            item.rare = 5;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.expert = true;
        }

        public override bool CanUseItem(Player player)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            return !modPlayer.zCool;
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/zawarudo"));
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            Laugicality.zawarudo = modPlayer.zaWarudoDuration;
            LaugicalGlobalNPCs.zTime = modPlayer.zaWarudoDuration;
            foreach ( Player player2 in Main.player){
                
            if (modPlayer.andioChestguard == true)
                player.AddBuff(mod.BuffType("TimeExhausted"), modPlayer.zCoolDown, true);
            else
                player.AddBuff(mod.BuffType("TimeExhausted"), modPlayer.zCoolDown, true);
            }
            return true;
        }
    }
}