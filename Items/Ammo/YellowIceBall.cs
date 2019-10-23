using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Ammo
{
    public class YellowIceBall : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yellow Iceball");
            Tooltip.SetDefault("The yellow ice just wants to be eaten.\n'Looks tasty'");
        }

        public override void SetDefaults()
        {
            item.damage = 14;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 7f;
            item.value = 0;
            item.rare = ItemRarityID.White;
            item.shoot = ModContent.ProjectileType("YellowIceBall");
            item.shootSpeed = 10f;
            item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlock, 1);
            recipe.AddIngredient(ItemID.ChlorophyteOre, 1);
            recipe.SetResult(this, 8);
            recipe.AddRecipe();
        }
    }
}
