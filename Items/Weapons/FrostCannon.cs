using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons
{
	public class FrostCannon : ModItem
	{
		public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Fires a blast of frost");
		}

		public override void SetDefaults()
		{
			item.damage = 9;
            item.ranged = true;
			item.width = 46;
			item.height = 26;
			item.useTime = 38;
			item.useAnimation = 38;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shootSpeed = 14f;
            item.useAmmo = AmmoID.Snowball;
            item.shoot = mod.ProjectileType("Frostball");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = Main.rand.Next(3,6);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); // 30 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                 float scale = 1f - (Main.rand.NextFloat() * .3f);
                 perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Frostball"), damage, knockBack, player.whoAmI);
            }


            return false; // return false because we don't want tmodloader to shoot projectile
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(10, 0);
        }
        

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SnowballCannon, 1);
            recipe.AddIngredient(null, "ChilledBar", 12);
            recipe.AddIngredient(null, "FrostShard", 1);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}