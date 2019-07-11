using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
    public class CarapaceDamageBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Fractured Carapace");
            Description.SetDefault("Increased Damage!");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<LaugicalityPlayer>(mod).DamageBoost(.15f);
        }
    }
}
