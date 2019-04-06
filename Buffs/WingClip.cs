using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class WingClip : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Wing Clip");
            Description.SetDefault("Flight time drastically reduced.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.wingTimeMax = 45;
            player.wingTime = 0;
            player.jumpSpeedBoost = 0;
        }

    }
}
