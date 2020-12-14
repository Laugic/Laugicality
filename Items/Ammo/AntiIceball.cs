using Laugicality.Items.Placeable;
using Laugicality.Projectiles.Ranged;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Ammo
{
    public class AntiIceball : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Anti-Iceball");
            Tooltip.SetDefault("Reverse gravity");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 7f;
            item.value = 0;
            item.rare = ItemRarityID.Blue;
            item.shoot = ModContent.ProjectileType<AntiIceballProjectile>();
            item.shootSpeed = 14f;
            item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<IceBall>(), 333);
            recipe.AddIngredient(ItemID.GravitationPotion, 1);
            recipe.SetResult(this, 333);
            recipe.AddRecipe();
        }
    }
}
