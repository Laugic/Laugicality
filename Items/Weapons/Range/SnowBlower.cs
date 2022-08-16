using Laugicality.Items.Loot;
using Laugicality.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Range
{
	public class SnowBlower : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Blows a barrge of brrs\nConverts some snowballs into Frostballs");
		}

		public override void SetDefaults()
		{
			item.damage = 60;
            item.ranged = true;
			item.width = 60;
			item.height = 38;
			item.useTime = item.useAnimation = 15;
            item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 8;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Yellow;
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
            int numberProjectiles = Main.rand.Next(4, 8);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(2));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                if(type == ProjectileID.SnowBallFriendly && i % 2 == 0) 
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
            recipe.AddIngredient(ModContent.ItemType<FrostThrower>(), 1);
            recipe.AddIngredient(ItemID.SnowmanCannon);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}