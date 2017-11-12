using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables
{
	public class EtherialEnergy : ModItem
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
			item.rare = 1;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item4;
			item.consumable = true;
		}
        
        public override bool CanUseItem(Player player)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            return !modPlayer.etherialSlot;
        }

        public override bool UseItem(Player player)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.etherialSlot = true;
            return true;
        }
    }
}