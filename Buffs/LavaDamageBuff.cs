using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
    public class LavaDamageBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lava Damage");
            Description.SetDefault("+15% Damage");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage += .15f;
        }
    }
}
