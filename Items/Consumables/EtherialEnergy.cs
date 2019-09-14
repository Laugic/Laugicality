using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Consumables
{
	public class EtherialEnergy : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Imbues your body with Etherial energy");
        }

        public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.maxStack = 1;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item4;
			item.consumable = true;
		}
        
        public override bool CanUseItem(Player player) => !player.GetModPlayer<LaugicalityPlayer>(mod).etherialSlot;

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<LaugicalityPlayer>(mod).etherialSlot = true;

            return true;
        }
    }
}