using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class ConjurationBoost : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Conjuration Power");
			Description.SetDefault("'Otherworldly energy strengthens you.'\n+1 to all Mystic Powers");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<LaugicalityPlayer>(mod).destructionPower += 1;
            player.GetModPlayer<LaugicalityPlayer>(mod).illusionPower += 1;
            player.GetModPlayer<LaugicalityPlayer>(mod).conjurationPower += 1;
        }
        
	}
}
