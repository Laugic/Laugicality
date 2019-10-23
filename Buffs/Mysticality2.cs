using Terraria;

namespace Laugicality.Buffs
{
    public class Mysticality2 : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Unstable Mysticality");
            Description.SetDefault("You can't drink Potentia Potions for a while, but Overflow is increased by 10%");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
            canBeCleared = false;
        }


        public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer.Get(player).Mysticality = 2;
            LaugicalityPlayer.Get(player).GlobalOverflow += .1f;
        }
    }
}
