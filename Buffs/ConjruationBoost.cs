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
			Description.SetDefault("'Otherworldly energy strengthens you.'\n+10% Conjuration Damage, +1 Conjuration Power");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<LaugicalityPlayer>(mod).conjurationDamage += 0.1f;
            player.GetModPlayer<LaugicalityPlayer>(mod).conjurationPower += 1;
        }
        
	}
}
