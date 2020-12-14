using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
    public class MoltenCore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Attacks inflict 'On Fire!'\n+30% Throwing Velocity and Mystic Duration\nRelease a burst of rocks when hit");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 44;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.accessory = true;
            item.expert = true;
            item.defense = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.Obsidium = true;
            modPlayer.Rocks = true;
            modPlayer.MysticDuration += 0.3f;
            player.thrownVelocity += 0.3f;
        }
    }
}