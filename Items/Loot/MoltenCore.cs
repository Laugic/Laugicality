using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class MoltenCore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Attacks inflict 'On Fire!'. +4 Defense \n+30% Throwing Velocity and Mystic Duration\nRelease a burst of rocks when hit");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 44;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.Obsidium = true;
            modPlayer.Rocks = true;
            modPlayer.MysticDuration += 0.3f;
            player.statDefense += 4;
            player.thrownVelocity += 0.3f;
        }
    }
}