using Laugicality.Items.Loot;
using Laugicality.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Range
{
	public class FrostThrower : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Fires a stream of frost\nConverts Snowballs into Frostballs");
		}

		public override void SetDefaults()
		{
			item.damage = 20;
            item.ranged = true;
			item.width = 60;
			item.height = 38;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 8;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shootSpeed = 18f;
            item.useAmmo = AmmoID.Snowball;
            item.shoot = ProjectileID.SnowBallFriendly;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = 2;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(2));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                if(type == ProjectileID.SnowBallFriendly) 
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<FrostballProjectile>(), damage, knockBack, player.whoAmI);
                else
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(10, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SMG>(), 1);
            recipe.AddIngredient(mod, nameof(SoulOfSought), 8);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FrostCannon>(), 1);
            recipe.AddIngredient(mod, nameof(SoulOfSought), 8);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}