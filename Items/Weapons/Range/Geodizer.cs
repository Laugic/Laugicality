using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Range
{
	public class Geodizer : ModItem
	{
		public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'For Fury'");
		}
        public int numShots = 1;
		public override void SetDefaults()
		{
            numShots = 2;
			item.damage = 10;
            item.ranged = true;
			item.width = 80;
			item.height = 44;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shootSpeed = 14f;
            item.shoot = 10;
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            numShots++;
            if (numShots > 8)
                numShots = 2;
            int numberProjectiles = numShots;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5+2*numShots)); 
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; 
        }
        
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-26, 4);
        }
        

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AndesiaCore", 1);
            recipe.AddIngredient(null, "DioritusCore", 1);
            recipe.AddIngredient(3081, 10);
            recipe.AddIngredient(3086, 25);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}