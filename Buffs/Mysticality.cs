﻿using Terraria;

namespace Laugicality.Buffs
{
    public class Mysticality : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mysticality");
            Description.SetDefault("You can't drink Potentia Potions for a while");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
            canBeCleared = false;
        }


        public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer.Get(player).Mysticality = 2;
        }
    }
}
