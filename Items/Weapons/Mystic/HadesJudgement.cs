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
    public class HadesJudgement : MysticItem
    {
        public int damage = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hades' Judgement");
            Tooltip.SetDefault("Cleanse your sins\nIllusion inflicts 'Shadowflame'\nFires different projectiles based on Mysticism");
            //Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 34;
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
            if (modPlayer.mysticMode != 1)
                return true;
            else return false;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 32 + 12 * modPlayer.destructionPower;
            item.damage = (int)(item.damage * modPlayer.destructionDamage);
            item.useTime = 46 - (6 * modPlayer.destructionPower);
            if (item.useTime <= 0)
                item.useTime = 1;
            item.useAnimation = item.useTime;
            item.knockBack = 5 + 3 * modPlayer.destructionPower;
            item.shootSpeed = 4f;
            item.shoot = mod.ProjectileType("GaiaIllusion");
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 32;
            item.damage = (int)(item.damage * modPlayer.illusionDamage);
            item.useTime = 20;
            item.useAnimation = 20;
            item.knockBack = 4;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("HadesIllusion");
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 20;
            item.damage = (int)(item.damage * modPlayer.conjurationDamage);
            item.useTime = 65;
            item.useAnimation = 65;
            item.knockBack = 2;
            item.shootSpeed = 8f;
            item.shoot = mod.ProjectileType("HadesConjuration");
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            damage = item.damage;
            if (modPlayer.mysticMode == 1)
                Projectile.NewProjectile(target.Center.X + 32, target.Center.Y + 32, 0f, 0f, mod.ProjectileType("HadesExplosion"), damage, knockback, Main.myPlayer);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ObsidiumBar", 16);
            recipe.AddIngredient(null, "DarkShard", 2);
            recipe.AddIngredient(ItemID.FallenStar, 4);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe Hrecipe = new ModRecipe(mod);
            Hrecipe.AddIngredient(ItemID.HellstoneBar, 16);
            Hrecipe.AddIngredient(null, "DarkShard", 2);
            Hrecipe.AddIngredient(ItemID.FallenStar, 4);
            Hrecipe.AddTile(16);
            Hrecipe.SetResult(this);
            Hrecipe.AddRecipe();
        }
    }
}