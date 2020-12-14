using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Ammo
{
    public class Shbl : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shbl");
            Tooltip.SetDefault("'Shbl'");
        }

        public override void SetDefaults()
        {
            item.damage = 18;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 7f;
            item.value = 0;
            item.rare = ItemRarityID.Orange;
            item.shoot = ModContent.ProjectileType<Projectiles.Ranged.ShblProjectile>();
            item.shootSpeed = 14f;
            item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Shadowshot>(), 90);
            recipe.AddIngredient(ModContent.ItemType<Bloodbolt>(), 90);
            recipe.SetResult(this, 90);
            recipe.AddRecipe();
        }
    }
}
