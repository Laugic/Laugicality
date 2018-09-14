using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using Laugicality;

namespace Laugicality.Items.Weapons.Mystic
{
	public class MarsFury : MysticItem
    {
        public int damage = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mars' Fury");
            Tooltip.SetDefault("A Furious War\nIllusion inflicts 'Furious', which deals damage over time and makes enemies explode into Magma Shards upon death\nFires different projectiles based on Mysticism");
            //Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

		public override void SetDefaults()
		{
			item.damage = 40;
            //item.magic = true;
            item.width = 66;
			item.height = 74;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.noMelee = false; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			//item.shoot = mod.ProjectileType("GaiaDestruction");
			item.shootSpeed = 6f;
            item.scale = 1.5f;
		}
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.mysticMode == 2)
            {
                float theta =(float)( Main.rand.NextDouble() * Math.PI * 2);
                float shootMag = 12f;
                Projectile.NewProjectile(position.X, position.Y, (float)Math.Cos(theta) * shootMag, (float)Math.Sin(theta) * shootMag, mod.ProjectileType("MarsIllusion"), damage, knockBack, player.whoAmI);
            }
            return true;
        }
        

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.scale = 1.5f;
            item.damage = 32 + 12 * modPlayer.destructionPower;
            item.damage = (int)(item.damage * modPlayer.destructionDamage);
            item.useTime = 38 - (8 * modPlayer.destructionPower);
            if (item.useTime <= 2)
                item.useTime = 2;
            item.useAnimation = item.useTime;
            item.knockBack = 5 + 3 * modPlayer.destructionPower;
            item.shootSpeed = 4f;
            item.shoot = mod.ProjectileType("Nothing");
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.scale = 1f;
            item.damage = 32;
            item.damage = (int)(item.damage * modPlayer.illusionDamage);
            item.useTime = 10;
            item.useAnimation = 10;
            item.knockBack = 4;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("Nothing");
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.scale = 1f;
            item.damage = 32;
            item.damage = (int)(item.damage * modPlayer.conjurationDamage);
            item.useTime = 38;
            item.useAnimation = 38;
            item.knockBack = 2;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("MarsConjuration");
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            damage = item.damage;
            if (modPlayer.mysticMode == 1)
                Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("MarsDestruction"), damage, knockback, Main.myPlayer);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HadesJudgement", 1);
            recipe.AddIngredient(null, "MagmaticCluster");
            recipe.AddIngredient(null, "MagmaticCrystal", 4);
            recipe.AddIngredient(null, "SoulOfHaught", 8);
            recipe.AddRecipeGroup("TitaniumBars", 6);
            recipe.AddIngredient(null, "RubrumDust", 4);
            recipe.AddIngredient(null, "AlbusDust", 2);
            recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
            
        }
    }
}