using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
    public class LavaRegen : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lava Regen");
            Description.SetDefault("Greatly increased regeneration");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 8;
        }
    }
}
