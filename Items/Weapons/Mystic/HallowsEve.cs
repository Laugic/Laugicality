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
	public class HallowsEve : MysticItem
    {
        public int damage = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallow's Eve");
             Tooltip.SetDefault("'The spirits of the darkness are bent to your will'"
							+ "\nIllusion inflicts 'Spooked', which drains life rapidly."
							+ "\nFires different projectiles based on Mysticism");
            Item.staff[item.type] = true;
        }

        public override void SetMysticDefaults()
		{
			item.damage = 55;
            item.width = 116;
			item.height = 122;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 6f;
            item.scale = .75f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.mysticMode == 1)
            {
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 8f, mod.ProjectileType("HallowsEveDestruction1"), damage, 3f, player.whoAmI);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -8f, mod.ProjectileType("HallowsEveDestruction1"), damage, 3f, player.whoAmI);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 8f, 0f, mod.ProjectileType("HallowsEveDestruction1"), damage, 3f, player.whoAmI);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -8f, 0f, mod.ProjectileType("HallowsEveDestruction1"), damage, 3f, player.whoAmI);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 6f, 6f, mod.ProjectileType("HallowsEveDestruction2"), damage, 3f, player.whoAmI);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -6f, -6f, mod.ProjectileType("HallowsEveDestruction2"), damage, 3f, player.whoAmI);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 6f, -6f, mod.ProjectileType("HallowsEveDestruction2"), damage, 3f, player.whoAmI);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -6f, 6f, mod.ProjectileType("HallowsEveDestruction2"), damage, 3f, player.whoAmI);
				
                return false;
            }
            if (modPlayer.mysticMode == 3)
            {
                
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 40 + 15 * modPlayer.destructionPower;
            item.damage = (int)(item.damage * modPlayer.destructionDamage);
            item.useTime = 33 - (5 * modPlayer.destructionPower);
            if (item.useTime <= 2)
                item.useTime = 3;
            item.useAnimation = (int)(item.useTime);
            item.knockBack = 0;
            item.shootSpeed = 14f;
            item.shoot = mod.ProjectileType("Nothing");
            item.UseSound = SoundID.Item1;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 55;
            item.damage = (int)(item.damage * modPlayer.illusionDamage);
            item.useTime = 14;
            item.useAnimation = item.useTime;
            item.knockBack = 5;
            item.shootSpeed = 10f;
            item.shoot = mod.ProjectileType("HallowsEveIllusion1");
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 55;
            item.damage = (int)(item.damage * modPlayer.conjurationDamage);
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 8f;
            item.shoot = mod.ProjectileType("HallowsEveConjuration1");
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
        }

       


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpookyWood, 40);
            recipe.AddIngredient(ItemID.Pumpkin, 12);
            recipe.AddIngredient(ItemID.Ectoplasm, 8);
            recipe.AddIngredient(null, "SoulOfHaught", 8);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}