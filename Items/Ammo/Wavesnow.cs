using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Ammo
{
    public class Wavesnow : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wavesnowball");
            Tooltip.SetDefault("'Wiggle'");
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
            item.shoot = ModContent.ProjectileType<Projectiles.Ranged.WavesnowProjectile>();
            item.shootSpeed = 4f;
            item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentVortex, 1);
            recipe.SetResult(this, 60);
            recipe.AddRecipe();
        }
    }
}
