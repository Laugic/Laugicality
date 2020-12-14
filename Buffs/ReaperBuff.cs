using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
    public class ReaperBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Reaper");
            Description.SetDefault("Increased damage and movement speed");
            Main.buffNoSave[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage += .15f;
            player.moveSpeed += .15f;
        }
    }
}
