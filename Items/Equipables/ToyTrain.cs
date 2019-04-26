using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class ToyTrain : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Miniature Train Whistle");
			Tooltip.SetDefault("Summons a Toy Train that follows you");
		}

		public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.shoot = mod.ProjectileType("ToyTrain");
			item.buffType = mod.BuffType("ToyTrain");
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.UseSound = SoundID.Item79;
        }
        

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}