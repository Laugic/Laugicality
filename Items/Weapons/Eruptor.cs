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
	public class Eruptor : ModItem
	{
		public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'For Fury'");
		}
        public int numShots = 1;
		public override void SetDefaults()
		{
            numShots = 3;
			item.damage = 32;
            item.thrown = true;
			item.width = 80;
			item.height = 44;
			item.useTime = 15;
			item.useAnimation = 15;
            item.useStyle = 1;
            item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 4;
			item.UseSound = SoundID.Item19;
			item.autoReuse = true;
			item.shootSpeed = 20f;
            item.shoot = mod.ProjectileType("Eruptor");
            item.noUseGraphic = true;
            //item.useAmmo = AmmoID.Bullet;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            numShots++;
            if (numShots > 6)
                numShots = 3;
            int numberProjectiles = numShots;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5+2*numShots)); 
                //float scale = 1f - (Main.rand.NextFloat() * .3f);
                //perturbedSpeed = perturbedSpeed * scale; 
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
            recipe.AddIngredient(null, "ObsidiumBar", 12);
            recipe.AddRecipeGroup("TitaniumBars", 6);
            recipe.AddIngredient(null, "MagmaticCluster");
            recipe.AddIngredient(null, "MagmaticCrystal", 4);
            recipe.AddIngredient(null, "SoulOfHaught", 8);
            recipe.AddIngredient(null, "VerdiDust", 4);
            recipe.AddIngredient(null, "AlbusDust", 2);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}