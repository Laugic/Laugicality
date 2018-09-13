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
	public class StaffOfAnDio : MysticItem
    {
        public int damage = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Loki's Staff");
            Tooltip.SetDefault("'Many tricks up his sleeve'\nIllusion locks the player in place\nFires different projectiles based on Mysticism");
            Item.staff[item.type] = true; 
        }

		public override void SetDefaults()
		{
			item.damage = 40;
            //item.magic = true;
            item.width = 48;
			item.height = 48;
			item.useTime = 18;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			//item.shoot = mod.ProjectileType("GaiaDestruction");
			item.shootSpeed = 6f;
		}

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 36 + 16 * modPlayer.destructionPower;
            item.damage = (int)(item.damage * modPlayer.destructionDamage);
            item.useTime = 34 - (4 * modPlayer.destructionPower);
            if (item.useTime <= 1)
                item.useTime = 2;
            item.useAnimation = item.useTime;
            item.knockBack = 4 + 2 * modPlayer.destructionPower;
            item.shootSpeed = 14f;
            item.shoot = mod.ProjectileType("AnDioDestruction1");
            item.UseSound = SoundID.Item20;
            item.scale = 1f;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            modPlayer.player.AddBuff(mod.BuffType("Frigid"), 1, true);
            item.damage = 26;
            item.damage = (int)(item.damage * modPlayer.illusionDamage);
            item.useTime = 2;
            item.useAnimation = item.useTime;
            item.knockBack = 5;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("AnDioIllusion");
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item20;
            item.scale = 1f;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 38;
            item.damage = (int)(item.damage * modPlayer.conjurationDamage);
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 18f;
            item.shoot = mod.ProjectileType("AnDioConjuration1");
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item20;
            item.scale = 1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DioritusCore", 1);
            recipe.AddIngredient(null, "AndesiaCore", 1);
            recipe.AddIngredient(3081, 25);
            recipe.AddIngredient(3086, 25);
            recipe.AddRecipeGroup("TitaniumBars", 8);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}