using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
    public class DestroyerSoulCooldownBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Destroyer Soul Cooldown");
            Description.SetDefault("Your Destroyer effect is on Cooldown.");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<LaugicalityPlayer>().DestroyerCooldown = true;
        }
    }
}
