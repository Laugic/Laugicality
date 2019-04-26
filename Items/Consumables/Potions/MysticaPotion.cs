using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables.Potions
{
    public class MysticaPotion : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Potentia Potion");
            Tooltip.SetDefault("Restores all Potentias to full capacity, but removes Overflow");
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
            modPlayer.Lux = modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost;
            modPlayer.Vis = modPlayer.VisMax + modPlayer.VisMaxPermaBoost;
            modPlayer.Mundus = modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost;
            player.AddBuff(mod.BuffType("Mysticality"), 60 * 60, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(null, "ArcaneShard", 1);
            recipe.AddIngredient(null, "VerdiDust", 1);
            recipe.AddIngredient(null, "LavaGem", 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}