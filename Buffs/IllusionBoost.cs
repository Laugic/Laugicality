using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class IllusionBoost : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Illusion Power");
			Description.SetDefault("'The mind's energy strengthens you.'\n+10% Illusion Damage, +1 Illusion Power");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<LaugicalityPlayer>(mod).illusionDamage += 0.1f;
            player.GetModPlayer<LaugicalityPlayer>(mod).illusionPower += 1;
        }
        
	}
}
