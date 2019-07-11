using Terraria;

namespace Laugicality.Buffs
{
    public class MobilityCurseBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mobility Curse");
            Description.SetDefault("Slow down there, punk.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed *= .7f;
            player.maxRunSpeed *= .7f;
        }
    }
}
