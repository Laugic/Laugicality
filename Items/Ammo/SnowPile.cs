using Laugicality.Items.Placeable;
using Laugicality.Projectiles.Ranged;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Ammo
{
    public class SnowPile : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Snow Pile");
        }

        public override void SetDefaults()
        {
            item.damage = 8;
            item.ranged = true;
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.consumable = false;
            item.knockBack = 4f;
            item.value = 0;
            item.rare = ItemRarityID.Green;
            item.shoot = ProjectileID.SnowBallFriendly;
            item.shootSpeed = 10f;
            item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Snowball, 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
