using Terraria;

namespace Laugicality.Buffs
{
    public class CarapaceDamageBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Broken Shroud");
            Description.SetDefault("Increased Damage!");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer.Get(player).DamageBoost(.15f);
        }
    }
}
