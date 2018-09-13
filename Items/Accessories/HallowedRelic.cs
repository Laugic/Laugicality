using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class HallowedRelic : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("You feel Blessed");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 48;
            item.value = 10000;
            item.rare = 8;
            item.accessory = true;
            item.lifeRegen = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.SoulStoneV)
            {
                if (modPlayer.spelunker)
                    player.findTreasure = true;
                Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
                if (modPlayer.owl)
                    player.nightVision = true;
                if (modPlayer.hunter)
                    player.detectCreature = true;
                if (modPlayer.danger)
                    player.dangerSense = true;
            }
            player.maxMinions++;
            if (modPlayer.calm)
                player.calmed = true;
            player.resistCold = true;
            player.lifeMagnet = true;
            player.statLifeMax2 += (player.statLifeMax + player.statLifeMax2) / 5 / 20 * 20 - (player.statLifeMax / 5 / 20 * 20);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HolyStone", 1);
            recipe.AddIngredient(null, "SightStone", 1);
            recipe.AddTile(null, "AncientEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}