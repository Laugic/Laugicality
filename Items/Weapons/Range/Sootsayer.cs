using Laugicality.Items.Ammo;
using Laugicality.Items.Materials;
using Laugicality.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Range
{
	public class Sootsayer : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Converts snowballs into sootballs\nShoots more snowballs as you consume Obsidium Hearts");
		}

		public override void SetDefaults()
		{
			item.damage = 10;
            item.ranged = true;
			item.width = 46;
			item.height = 26;
			item.useTime = 38;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 8;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shootSpeed = 14f;
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

            int numberProjectiles = 3 + LaugicalityPlayer.Get(player).ObsidiumHeart / 2;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type==ProjectileID.SnowBallFriendly?ModContent.ProjectileType<SootballProjectile>():type, damage, knockBack, player.whoAmI);
            }

            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 16);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}