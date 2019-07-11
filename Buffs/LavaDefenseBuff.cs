using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
    public class LavaDefenseBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lava Defense");
            Description.SetDefault("+10 Defense");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 10;
        }
    }
}
