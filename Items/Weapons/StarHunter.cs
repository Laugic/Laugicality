using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons
{
	public class StarHunter : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bow of The Star Hunter");
            Tooltip.SetDefault("Shoot a supernova\n50% chance to not consume ammo");
		}

        private int reload = 0;
        private int reloadMax = 8;
        private int reload2 = 0;
        private int reloadMax2 = 32;
        private float theta = 0f;
        private float rotSp = 3.14f / 30;

		public override void SetDefaults()
        {
            item.scale *= 1.2f;
            item.damage = 550;
			item.ranged = true;
			item.width = 44;
			item.height = 86;
			item.useTime = 1;
			item.useAnimation = 32;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 10000;
			item.rare = 9;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
            item.channel = true;
            item.shoot = 10; 
			item.shootSpeed = 22f;
			item.useAmmo = 40;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3467, 16);
            recipe.AddIngredient(3456, 8);
            recipe.AddTile(412);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
            
        public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .50f;
		}

        public override void HoldItem(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if(reload > 0)
                reload--;
            if (reload2 > 0)
                reload2--;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
            //Super shot
            if(reload2 <= 0)
            {
                reload2 = reloadMax2;

                Projectile.NewProjectile(player.Center.X, player.Center.Y, 14, 0, mod.ProjectileType("Luminarrow"), (int)(item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -14, 0, mod.ProjectileType("Luminarrow"), (int)(item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 14, mod.ProjectileType("Luminarrow"), (int)(item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, -14, mod.ProjectileType("Luminarrow"), (int)(item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 10, 10, mod.ProjectileType("Luminarrow"), (int)(item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 10, -10, mod.ProjectileType("Luminarrow"), (int)(item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -10, -10, mod.ProjectileType("Luminarrow"), (int)(item.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -10, 10, mod.ProjectileType("Luminarrow"), (int)(item.damage / 1.2f), 3, Main.myPlayer);
            }
            //Normal shot
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            float mag = 12f;
            theta += rotSp;
            if (theta >= 3.14158265f * 2)
                theta -= 3.14158265f * 2;
            Projectile.NewProjectile(player.Center.X, player.Center.Y, (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, mod.ProjectileType("LuminarrowHead"), (int)(item.damage) / 2, 3, Main.myPlayer);

            //Normal shot
            if (reload <= 0)
            {
                reload = reloadMax;
                int numberProjectiles = Main.rand.Next(2, 4);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); 
                                                                                                                
                    float scale = 1f - (Main.rand.NextFloat() * .2f);
                    perturbedSpeed = perturbedSpeed * scale;
                    if(Main.player[Main.myPlayer] == player)
                        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 638, damage, knockBack, player.whoAmI);
                }
            }


            return false; 
        }
    }
}
