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
	public class DionysusBloom : MysticItem
    {
        public int damage = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dionysus' Bloom");
            Tooltip.SetDefault("'Grow his strength' \nIllusion inflicts 'Venom'\nFires different projectiles based on Mysticism");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        

        public override void SetMysticDefaults()
		{
			item.damage = 44;
            item.width = 64;
			item.height = 64;
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
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 64f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.mysticMode == 2)
            {

                int numberProjectiles = Main.rand.Next(1, 4);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); 
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("DionysusIllusion"), damage, knockBack, player.whoAmI);
                }
                return false;
            }
            if (modPlayer.mysticMode == 3)
            {
                for (int p = 999; p >= 0; p--)
                {
                    if (Main.projectile[p].type == mod.ProjectileType("DionysusConjuration"))
                    {
                        if (player.ownedProjectileCounts[mod.ProjectileType("DionysusConjuration")] >= modPlayer.conjurationPower + 1)
                        {
                            Main.projectile[p].Kill();
                            break;
                        }
                    }

                }
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 60 + 12 * modPlayer.destructionPower;
            item.damage = (int)(item.damage * modPlayer.destructionDamage);
            item.useTime = 30 - (4 * modPlayer.destructionPower);
            if (item.useTime <= 0)
                item.useTime = 2;
            item.useAnimation = (int)(item.useTime);
            item.knockBack = 0;
            item.shootSpeed = 14f;
            item.shoot = mod.ProjectileType("DionysusDestruction");
            item.UseSound = SoundID.Item1;
            item.scale = 1.5f;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 42;
            item.damage = (int)(item.damage * modPlayer.illusionDamage);
            item.useTime = 10;
            item.useAnimation = item.useTime;
            item.knockBack = 5;
            item.shootSpeed = 18f;
            item.shoot = mod.ProjectileType("Nothing");
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            item.scale = 1f;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 44;
            item.damage = (int)(item.damage * modPlayer.conjurationDamage);
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 20f;
            item.shoot = mod.ProjectileType("DionysusConjuration");
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            item.scale = 1f;
        }

       


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1006, 16); //Chlorophyte
            recipe.AddIngredient(null, "SoulOfSought", 8);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}