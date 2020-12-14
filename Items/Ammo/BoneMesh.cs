using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Ammo
{
    public class BoneMesh : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Mesh");
            Tooltip.SetDefault("Extractinated bones!\nFragment on impact");
        }

        public override void SetDefaults()
        {
            item.damage = 12;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 7f;
            item.value = 0;
            item.rare = ItemRarityID.Green;
            item.shoot = ModContent.ProjectileType<Projectiles.Ranged.BoneMeshProjectile>();
            item.shootSpeed = 14f;
            item.ammo = AmmoID.Snowball;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 1);
            recipe.AddTile(TileID.Extractinator);
            recipe.SetResult(this, 30);
            recipe.AddRecipe();
        }
    }
}
