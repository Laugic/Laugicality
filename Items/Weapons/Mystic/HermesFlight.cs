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
	public class HermesFlight : MysticItem
    {
        public string tt = "";
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hermes' Flight");
            Tooltip.SetDefault("Weild the power of Hermes\nIllusion inflicts 'Hermes' Smite', which drains enemy life\nFires different projectiles based on Mysticism");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetMysticDefaults()
		{
			item.damage = 20;
            //item.magic = true;
            item.mana = 4;
            item.width = 28;
			item.height = 28;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("HermesDestruction");
			item.shootSpeed = 6f;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.mysticMode == 1)
            {
                int numberProjectiles = Main.rand.Next(2, 4);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.
                                                                                                                    // If you want to randomize the speed to stagger the projectiles
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("HermesDestruction"), damage, knockBack, player.whoAmI);
                }

            }
            return true; // return false because we don't want tmodloader to shoot projectile
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 16 + 4 * modPlayer.destructionPower;
            item.damage = (int)(item.damage * modPlayer.destructionDamage);
            item.mana = 4;
            item.useTime = 20 - modPlayer.destructionPower;
            if (item.useTime <= 2)
                item.useTime = 2;
            item.useAnimation = item.useTime;
            item.knockBack = 2 + 2 * modPlayer.destructionPower;
            item.shootSpeed = 10f + (float)(2 * modPlayer.destructionPower);
            item.shoot = mod.ProjectileType("HermesDestruction");
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 25;
            item.damage = (int)(item.damage * modPlayer.illusionDamage);
            item.mana = 4;
            item.useTime = 16;
            item.useAnimation = 16;
            item.knockBack = 2;
            item.shootSpeed = 8f;
            item.shoot = mod.ProjectileType("HermesIllusion");
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 18;
            item.damage = (int)(item.damage * modPlayer.conjurationDamage);
            item.mana = 6;
            item.useTime = 22;
            item.useAnimation = 22;
            item.knockBack = 5;
            item.shootSpeed = 8f;
            item.shoot = mod.ProjectileType("HermesConjuration1");
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 12);
            recipe.anyWood = true;
            recipe.AddIngredient(ItemID.Feather, 4);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}