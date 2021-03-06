using Terraria;

namespace Laugicality.Buffs
{
	public class Aquos : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Aquos");
			Description.SetDefault("+10% Critical Strike Chance");
			Main.buffNoSave[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;
        }
        
	}
}
