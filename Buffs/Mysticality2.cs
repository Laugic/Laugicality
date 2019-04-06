using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class Mysticality2 : ModBuff
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
            player.GetModPlayer<LaugicalityPlayer>(mod).mysticality = 2;
            player.GetModPlayer<LaugicalityPlayer>(mod).globalOverflow += .1f;
        }
    }
}
