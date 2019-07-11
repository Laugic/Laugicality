using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
    public class SteamTrainSoulCooldownBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Steam Train Soul Cooldown");
            Description.SetDefault("Your Steam Train effect is on Cooldown.");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            canBeCleared = false;
        }
    }
}
