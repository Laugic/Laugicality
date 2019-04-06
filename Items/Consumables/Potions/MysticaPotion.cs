using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables.Potions
{
    public class MysticaPotion : ModItem
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
            modPlayer.lux = modPlayer.luxMax + modPlayer.luxMaxPermaBoost;
            modPlayer.vis = modPlayer.visMax + modPlayer.visMaxPermaBoost;
            modPlayer.mundus = modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost;
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