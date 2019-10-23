using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
    public class EtherialScarf : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("While in the etherial, prevent a hit of lethal damage once every minute. \n20% Damage Reduction");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.2f;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0)
                modPlayer.EtherialScarf = true;
        }
    }
}