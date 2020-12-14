using System;
using Terraria;

namespace Laugicality.Buffs
{
    public class TenacityCurseBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Tenacity Curse");
            Description.SetDefault("You've been weakened!\n-12 Defense");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer.Get(player).WeakenedDefense += 12;
        }
    }
}
