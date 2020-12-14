using Terraria;

namespace Laugicality.Buffs
{
    public class CapacityCurseBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Capacity Curse");
            Description.SetDefault("You've been weakened!");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer.Get(player).WeakenedDefense += 10;
        }
    }
}
