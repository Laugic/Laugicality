using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
    public class Pyramind : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases your minion capacity\n+40 Mana\nIncreased Potentia Regen");
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
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.maxMinions += 1;
            player.statManaMax2 += 40;
            modPlayer.LuxRegen += .02f;
            modPlayer.VisRegen += .02f;
            modPlayer.MundusRegen += .02f;
        }
    }
}