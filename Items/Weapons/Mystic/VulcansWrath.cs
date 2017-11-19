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
	public class VulcansWrath : MysticItem
    {
        public int damage = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vulcan's Wrath");
            Tooltip.SetDefault("'Unleash his fury' \nIllusion inflicts 'Steamy'\nFires different projectiles based on Mysticism");
            //Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

		public override void SetDefaults()
		{
			item.damage = 10;
            //item.magic = true;
            item.width = 48;
			item.height = 48;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.noMelee = false; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			//item.shoot = mod.ProjectileType("GaiaDestruction");
			item.shootSpeed = 6f;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.mysticMode == 1) {
                int numberProjectiles = Main.rand.Next(2, 5);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.
                                                                                                                    // If you want to randomize the speed to stagger the projectiles
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 242, damage, knockBack, player.whoAmI);
                }

            }
            return true; // return false because we don't want tmodloader to shoot projectile
        }
        public override void HoldItem(Player player)
        {
            
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            //Main.NewText(modPlayer.mysticMode.ToString(), 200, 200, 0);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color

            if (modPlayer.mysticMode  == 1)
            {
                player.AddBuff(mod.BuffType("Destruction"), 1, true);
                item.damage = 46 + 8 * modPlayer.destructionPower;
                item.damage = (int)(item.damage * modPlayer.mysticDamage * modPlayer.destructionDamage);
                item.useTime = 36 - (3 * modPlayer.destructionPower);
                if (item.useTime <= 0)
                    item.useTime = 2;
                item.useAnimation = (int)(item.useTime/2);
                item.knockBack = 4 + 2 * modPlayer.destructionPower;
                item.shootSpeed = 14f;
                item.shoot = 242;
                item.UseSound = SoundID.Item1;
                item.scale = 1.5f;
            }
            else if(modPlayer.mysticMode == 2)
            {
                player.AddBuff(mod.BuffType("Illusion"), 1, true);
                item.damage = 48;
                item.damage = (int)(item.damage * modPlayer.mysticDamage * modPlayer.illusionDamage);
                item.useTime = 10;
                item.useAnimation = item.useTime;
                item.knockBack = 5;
                item.shootSpeed = 18f;
                item.shoot = mod.ProjectileType("VulcanIllusion");
                item.noUseGraphic = false;
                item.UseSound = SoundID.Item1;
                item.scale = 1f;
            }
            else if (modPlayer.mysticMode == 3)
            {
                player.AddBuff(mod.BuffType("Conjuration"), 1, true);
                item.damage = 48;
                item.damage = (int)(item.damage * modPlayer.mysticDamage * modPlayer.conjurationDamage);
                item.useTime = 24;
                item.useAnimation = item.useTime;
                item.knockBack = 2;
                item.shootSpeed = 32f;
                item.shoot = mod.ProjectileType("VulcanConjuration");
                item.noUseGraphic = false;
                item.UseSound = SoundID.Item33;
                item.scale = 1f;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SteamBar", 16);
            recipe.AddIngredient(null, "SoulOfWrought", 8);
            recipe.AddIngredient(null, "SoulOfFraught", 8);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}