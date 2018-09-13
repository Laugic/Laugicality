using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons
{
    public class Aurora : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aurora");
            Tooltip.SetDefault("'Chill them into submission'");
        }
        public override void SetDefaults()
        {
            item.damage = 55;           
            item.melee = true;             
            item.noMelee = false;
            item.width = 54;
            item.height = 58;
            item.useTime = 46;       
            item.useAnimation = 23;   
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 100000;
            item.rare = 3;
            //item.reuseDelay = 20;    
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;       
            item.shoot = mod.ProjectileType("Aurora");  
            item.shootSpeed = 16f;     
            item.useTurn = true;
            item.maxStack = 1;      
            item.consumable = false;  
            //item.noUseGraphic = true;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            int numberProjectiles = Main.rand.Next(2, 4);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5)); // 30 degree spread.
                                                                                                               // If you want to randomize the speed to stagger the projectiles
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Aurora"), damage, knockBack, player.whoAmI);
            }


            return false; // return false because we don't want tmodloader to shoot projectile
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FrostBlade", 1);
            recipe.AddIngredient(null, "SoulOfSought", 6);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddRecipeGroup("TitaniumBars", 8);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}