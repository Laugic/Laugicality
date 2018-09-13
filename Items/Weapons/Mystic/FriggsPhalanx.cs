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
	public class FriggsPhalanx : MysticItem
    {
        public string tt = "";
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frigg's Phalanx");
            Tooltip.SetDefault("'The swarm cometh'\nIllusion inflicts 'Poison'\nFires different projectiles based on Mysticism");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 25;
            //item.magic = true;
            item.width = 48;
			item.height = 48;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Nothing");
			item.shootSpeed = 6f;
		}


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.mysticMode == 1)
            {
                int numberProjectiles = Main.rand.Next(1, 3);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // degree spread.
                                                                                                                    // If you want to randomize the speed to stagger the projectiles
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    if(Main.rand.Next(2) == 0)
                    {
                        if(!player.strongBees)
                            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 181, damage, knockBack, player.whoAmI);
                        else
                            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 566, (int)(damage * 1.5), knockBack, player.whoAmI);
                    }
                    else
                        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("FriggDestruction"), damage, knockBack, player.whoAmI);
                }
            }
            if(modPlayer.mysticMode == 2)
            {
                float theta = (float)Main.rand.NextDouble() * 3.14f * 2;
                float mag = 360;
                Projectile.NewProjectile((int)(Main.MouseWorld.X) + (int)(mag * Math.Cos(theta)), (int)(Main.MouseWorld.Y) + (int)(mag * Math.Sin(theta)), -4 * (float)Math.Cos(theta), -4 * (float)Math.Sin(theta), mod.ProjectileType("FriggIllusion"), damage, 3, Main.myPlayer);
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
                item.damage = 22 + 6 * modPlayer.destructionPower;
                item.damage = (int)(item.damage * modPlayer.destructionDamage);
                item.useTime = 15 - 2 * modPlayer.destructionPower;
                if (item.useTime <= 0)
                    item.useTime = 2;
                item.useAnimation = item.useTime;
                item.knockBack = modPlayer.destructionPower;
                item.shootSpeed = 8f + (float)(2 * modPlayer.destructionPower);
                item.shoot = mod.ProjectileType("Nothing");
            }
            else if(modPlayer.mysticMode == 2)
            {
                player.AddBuff(mod.BuffType("Illusion"), 1, true);
                item.damage = 25;
                item.damage = (int)(item.damage * modPlayer.illusionDamage);
                item.useTime = 15;
                item.useAnimation = 15;
                item.knockBack = 1;
                item.shootSpeed = 8f;
                item.shoot = mod.ProjectileType("Nothing");
            }
            else if (modPlayer.mysticMode == 3)
            {
                player.AddBuff(mod.BuffType("Conjuration"), 1, true);
                item.damage = 25;
                item.damage = (int)(item.damage * modPlayer.conjurationDamage);
                item.useTime = 50;
                item.useAnimation = 50;
                item.knockBack = 5;
                item.shootSpeed = 2f;
                item.shoot = mod.ProjectileType("FriggConjuration");
            }
        }


        /*
        public override bool CanRightClick()
        {
                return true;
        }
        
        public override void RightClick(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.mysticMode += 1;
            if (modPlayer.mysticMode > 3) modPlayer.mysticMode = 1;
        }
        */

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(331, 10);
            recipe.AddIngredient(2431, 8);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}