using Terraria;

namespace Laugicality.Buffs
{
    public class TenacityCurseBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Tenacity Curse");
            Description.SetDefault("You've been weakened!");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 10;
            if (player.statDefense < 0)
                player.statDefense = 0;
        }
    }
}
