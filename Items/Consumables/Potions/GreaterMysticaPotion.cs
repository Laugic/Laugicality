using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables.Potions
{
    public class GreaterMysticaPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Greater Potentia Potion");
            Tooltip.SetDefault("Restores all Potentias to full capacity\nDoes not remove Overflow\nOverflow is increased by 10% while the Mysticality debuff is active");
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
            if (modPlayer.lux < modPlayer.luxMax + modPlayer.luxMaxPermaBoost)
                modPlayer.lux = modPlayer.luxMax + modPlayer.luxMaxPermaBoost;
            if (modPlayer.vis < modPlayer.visMax + modPlayer.visMaxPermaBoost)
                modPlayer.vis = modPlayer.visMax + modPlayer.visMaxPermaBoost;
            if (modPlayer.mundus < modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost)
                modPlayer.mundus = modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost;
            player.AddBuff(mod.BuffType("Mysticality2"), 60 * 60, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MysticaPotion", 1);
            recipe.AddIngredient(null, "LiquidVerdi", 1);
            recipe.AddIngredient(null, "MagmaSnapper", 1);
            recipe.AddIngredient(null, "Crystilla", 2);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}