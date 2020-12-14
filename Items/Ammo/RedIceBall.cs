using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Ammo
{
    public class RedIceBall : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimchunk");
            Tooltip.SetDefault("The crimson ice is much heavier, and more damaging.");
        }

        public override void SetDefaults()
        {
            item.damage = 16;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 7f;
            item.value = 0;
            item.rare = ItemRarityID.Blue;
            item.shoot = ModContent.ProjectileType<Projectiles.Ranged.RedIceBallProjectile>();
            item.shootSpeed = 8f;
            item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RedIceBlock, 1);
            recipe.SetResult(this, 15);
            recipe.AddRecipe();
        }
    }
}
