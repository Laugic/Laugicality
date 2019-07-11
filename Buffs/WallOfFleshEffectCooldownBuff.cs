using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
    
    public class WallOfFleshEffectCooldownBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Wall of Flesh Effect Cooldown");
            Description.SetDefault("Your Steam Train effect is on Cooldown.");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            canBeCleared = false;
        }
    }
}
