using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
    public class EtherialEffectCooldownBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Etherial Rage");
            Description.SetDefault("+20 Defense & +20% Damage");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            //canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage += 0.2f;

            player.statDefense += 20;
        }
    }
}
