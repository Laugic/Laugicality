using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Range
{
    public class Avalanche : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Unleash frigid hell.'\nWhile in the Etherial after defeating Etheria, shoot an Avalanche twice as often");
        }
        int counter = 0;
        public override void SetDefaults()
        {
            counter = 0;
            item.damage = 60;
            item.ranged = true;
            item.width = 106;
            item.height = 58;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 8;
            item.value = 10000;
            item.rare = 4;
            item.UseSound = SoundID.Item34;
            item.autoReuse = true;
            item.shootSpeed = 18f;
            item.useAmmo = AmmoID.Snowball;
            item.shoot = ProjectileID.SnowBallFriendly;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = 3;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8));
                                                                                                              
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                if (i == 0)
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Frostball"), damage, knockBack, player.whoAmI);
                else
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            counter++;
            if (((LaugicalityWorld.downedEtheria || player.GetModPlayer<LaugicalityPlayer>(mod).etherable > 0) && LaugicalityWorld.downedTrueEtheria) || counter >= 2)
            {
                counter = 0;
                Projectile.NewProjectile(position.X, position.Y, speedX * 1.5f, speedY * 1.5f, mod.ProjectileType("Avalanche"), damage * 3, knockBack, player.whoAmI);
            }

            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(10, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FrostThrower", 1);
            recipe.AddIngredient(null, "BysmalBar", 12);
            recipe.AddIngredient(null, "EtherialEssence", 5);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}