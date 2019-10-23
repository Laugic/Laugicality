using Terraria;

namespace Laugicality.Buffs
{
    public class Mysticality3 : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Volatile Mysticality");
            Description.SetDefault("You can't drink Potentia Potions for a while.\n+20% Overflow");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
            canBeCleared = false;
        }


        public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer.Get(player).Mysticality = 2;
            LaugicalityPlayer.Get(player).GlobalOverflow += .2f;
        }
    }
}
