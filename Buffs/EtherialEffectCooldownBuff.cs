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
            player.thrownDamage += 0.2f;
            player.rangedDamage += 0.2f;
            player.magicDamage += 0.2f;
            player.minionDamage += 0.2f;
            player.meleeDamage += 0.2f;

            player.statDefense += 20;
        }
    }
}
