﻿using System;
using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Range
{
    public class DuneSharkgun : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("33% chance to not consume ammo\nOccasionally shoots Crystal bullets");
        }

        public override void SetDefaults()
        {
            item.damage = 9;
            item.ranged = true;
            item.width = 44;
            item.height = 86;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item41;
            item.autoReuse = true;
            item.channel = true;
            item.shoot = 10;
            item.shootSpeed = 12f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Minishark, 1);
            recipe.AddIngredient(mod, nameof(AncientShard), 1);
            recipe.AddIngredient(ItemID.FossilOre, 4);
            recipe.AddIngredient(mod, nameof(Crystilla), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .33f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 14f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            Vector2 perturbedSpeed = new Vector2(speedX, speedY);

            perturbedSpeed = perturbedSpeed * 1.33f;
            if (Main.rand.Next(3) == 0)
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.CrystalBullet, (int)(damage * 1.25), knockBack, player.whoAmI);

            return true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, -4);
        }
    }
}
