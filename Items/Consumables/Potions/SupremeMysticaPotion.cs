using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables.Potions
{
    public class SupremeMysticaPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Supreme Potentia Potion");
            Tooltip.SetDefault("Restores all Potentias to full capacity\nRestores Overflow to half capacity\nOverflow is increased by 20% while the Mysticality debuff is active");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 30;
            item.rare = 1;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 2;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.GetModPlayer<LaugicalityPlayer>().mysticality == 0;
        }

        public override bool UseItem(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>();
            if (modPlayer.lux < (modPlayer.luxMax + modPlayer.luxMaxPermaBoost) * (1 + (modPlayer.luxOverflow * modPlayer.globalOverflow - 1) / 2))
                modPlayer.lux = (modPlayer.luxMax + modPlayer.luxMaxPermaBoost) * (1 + (modPlayer.luxOverflow * modPlayer.globalOverflow - 1) / 2);
            if (modPlayer.vis < (modPlayer.visMax + modPlayer.visMaxPermaBoost) * (1 + (modPlayer.visOverflow * modPlayer.globalOverflow - 1) / 2))
                modPlayer.vis = (modPlayer.visMax + modPlayer.visMaxPermaBoost) * (1 + (modPlayer.visOverflow * modPlayer.globalOverflow - 1) / 2);
            if (modPlayer.mundus < (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost) * (1 + (modPlayer.mundusOverflow * modPlayer.globalOverflow - 1) / 2))
                modPlayer.mundus = (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost) * (1 + (modPlayer.mundusOverflow * modPlayer.globalOverflow - 1) / 2);
            player.AddBuff(mod.BuffType("Mysticality3"), 60 * 60, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GreaterMysticaPotion", 2);
            recipe.AddIngredient(null, "LiquidAlbus", 1);
            recipe.AddIngredient(null, "MagmaticCrystal", 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}