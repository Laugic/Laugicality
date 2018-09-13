using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
	public class ObsidiumHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'A special kind of love.'\nHave a Heart from a Heart in a Heart in a Heart");
        }
        public override void SetDefaults()
        {
            //item.CloneDefaults(ItemID.ZephyrFish);
            item.width = 28;
			item.height = 28;
            item.shoot = mod.ProjectileType("ObsidiumHeart");
            item.buffType = mod.BuffType("ObsidiumHeart");
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.maxStack = 1;
			item.rare = 3;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item4;
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