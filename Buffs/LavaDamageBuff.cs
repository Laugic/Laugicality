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
            player.meleeDamage += .15f;
            player.minionDamage += .15f;
            player.magicDamage += .15f;
            player.rangedDamage += .15f;
            player.thrownDamage += .15f;
        }
    }
}
