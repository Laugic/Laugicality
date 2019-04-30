using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables.Potions
{
    public class SupremeMysticaPotion : LaugicalityItem
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
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 2;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.GetModPlayer<LaugicalityPlayer>().Mysticality == 0;
        }

        public override bool UseItem(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>();
            if (modPlayer.Lux < (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * (1 + (modPlayer.LuxOverflow * modPlayer.GlobalOverflow - 1) / 2))
                modPlayer.Lux = (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * (1 + (modPlayer.LuxOverflow * modPlayer.GlobalOverflow - 1) / 2);
            if (modPlayer.Vis < (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * (1 + (modPlayer.VisOverflow * modPlayer.GlobalOverflow - 1) / 2))
                modPlayer.Vis = (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * (1 + (modPlayer.VisOverflow * modPlayer.GlobalOverflow - 1) / 2);
            if (modPlayer.Mundus < (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * (1 + (modPlayer.MundusOverflow * modPlayer.GlobalOverflow - 1) / 2))
                modPlayer.Mundus = (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * (1 + (modPlayer.MundusOverflow * modPlayer.GlobalOverflow - 1) / 2);
            player.AddBuff(mod.BuffType<Mysticality3>(), 60 * 60, true);
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