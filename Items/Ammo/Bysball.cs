using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Ammo
{
    public class Bysball : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bysball");
            Tooltip.SetDefault("Dimension warping snowballs");
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
            item.rare = ItemRarityID.Cyan;
            item.shoot = ModContent.ProjectileType<Projectiles.Ranged.BysballProjectile>();
            item.shootSpeed = 14f;
            item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BysmalBar>(), 3);
            recipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 6);
            recipe.SetResult(this, 333);
            recipe.AddRecipe();
        }
    }
}
