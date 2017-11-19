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
	public class PlutosFrost : MysticItem
    {
        public int damage = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pluto's Frost");
            Tooltip.SetDefault("'Make them fall for you' \nIllusion inflicts 'Frigid', which stops enemies in their tracks\nFires different projectiles based on Mysticism");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

		public override void SetDefaults()
		{
			item.damage = 10;
            //item.magic = true;
            item.width = 48;
			item.height = 48;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
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
            if (modPlayer.mysticMode == 2) {
                int numberProjectiles = Main.rand.Next(1, 3);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.
                                                                                                                    // If you want to randomize the speed to stagger the projectiles
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("PlutoIllusion"), damage, knockBack, player.whoAmI);
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
                item.damage = 68 + 16 * modPlayer.destructionPower;
                item.damage = (int)(item.damage * modPlayer.mysticDamage * modPlayer.destructionDamage);
                item.useTime = 22 - (2 * modPlayer.destructionPower);
                if (item.useTime <= 0)
                    item.useTime = 4;
                item.useAnimation = item.useTime;
                item.knockBack = 4 + 2 * modPlayer.destructionPower;
                item.shootSpeed = 14f;
                item.shoot = mod.ProjectileType("PlutoDestruction");
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
                item.shoot = mod.ProjectileType("PlutoIllusion");
                item.noUseGraphic = false;
            }
            else if (modPlayer.mysticMode == 3)
            {
                player.AddBuff(mod.BuffType("Conjuration"), 1, true);
                item.damage = 54;
                item.damage = (int)(item.damage * modPlayer.mysticDamage * modPlayer.conjurationDamage);
                item.useTime = 24;
                item.useAnimation = item.useTime;
                item.knockBack = 2;
                item.shootSpeed = 24f;
                item.shoot = mod.ProjectileType("PlutoConjuration");
                item.noUseGraphic = false;
            }
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 12); //Crystal Shard
            recipe.AddIngredient(null, "FrigidEssence", 12);
            recipe.AddIngredient(null, "SoulOfSought", 8);
            recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}