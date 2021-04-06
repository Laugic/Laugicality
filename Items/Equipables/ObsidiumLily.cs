using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    [AutoloadEquip(EquipType.Face)]
    public class ObsidiumLily : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obsidium Lily");
            Tooltip.SetDefault("You are immune to contact damage from enemies that\nare at max life and have less defense than you\n'A calming aura'");
        }

        public override void SetDefaults()
        {
            //item.CloneDefaults(ItemID.NaturesGift);
            item.width = 24;
            item.height = 24;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>();
            modPlayer.Lily = true;
        }
    }
}