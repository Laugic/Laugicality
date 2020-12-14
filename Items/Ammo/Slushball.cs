using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Ammo
{
    public class Slushball : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slushball");
            Tooltip.SetDefault("Inflicts 'Slushie', which makes enemies take more damage from snowballs that aren't Slushballs");
        }

        public override void SetDefaults()
        {
            item.damage = 6;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 7f;
            item.value = 0;
            item.rare = ItemRarityID.White;
            item.shoot = ModContent.ProjectileType<Projectiles.Ranged.SlushballProjectile>();
            item.shootSpeed = 14f;
            item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SlushBlock, 1);
            recipe.SetResult(this, 15);
            recipe.AddRecipe();
        }
    }
}
