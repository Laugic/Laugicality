using Laugicality.Items.Placeable;
using Laugicality.Projectiles.Ranged;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Ammo
{
    public class Bloodbolt : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodbolt");
            Tooltip.SetDefault("Heavy, but high damage");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 7f;
            item.value = 0;
            item.rare = ItemRarityID.Green;
            item.shoot = ModContent.ProjectileType<BloodboltProjectile>();
            item.shootSpeed = 14f;
            item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RedIceBall>(), 90);
            recipe.AddIngredient(ItemID.SoulofNight, 1);
            recipe.SetResult(this, 90);
            recipe.AddRecipe();
        }
    }
}
