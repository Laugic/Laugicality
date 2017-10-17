using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class MoltenCore : ModItem
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
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
            //item.defense = 1000;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.obsidium = true;
            modPlayer.rocks = true;
            modPlayer.mysticDuration += 0.3f;
            player.statDefense += 4;
            player.thrownVelocity += 0.3f;
        }
    }
}