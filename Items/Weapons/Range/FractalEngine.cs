using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Items.Materials;
using Laugicality.Projectiles.Ranged;

namespace Laugicality.Items.Weapons.Range
{
    public class FractalEngine : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fractal Engine");
            Tooltip.SetDefault("Shoots Snowballs that break into more snowballs\n'Compounding'");
        }

        public override void SetDefaults()
        {
            item.damage = 60;
            item.ranged = true;
            item.width = 50;
            item.height = 26;
            item.useAnimation = item.useTime = 12;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(gold: 15);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item92;
            item.autoReuse = true;
            item.shootSpeed = 12f;
            item.useAmmo = AmmoID.Snowball;
            item.shoot = ProjectileID.SnowBallFriendly;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
            muzzleOffset.Y -= 6;
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
            perturbedSpeed.Y -= 4;
            if (type == ProjectileID.SnowBallFriendly)
                type = ModContent.ProjectileType<ClusterballProjectile>();
            Projectile.NewProjectile(position + muzzleOffset, perturbedSpeed * 1.25f, ModContent.ProjectileType<BigSnowballProjectile>(), damage, knockBack, player.whoAmI, type);
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-24, -8);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShroomiteBar, 12);
            recipe.AddIngredient(ItemID.FragmentVortex, 12);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}