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
    public class FreyasFley : MysticItem
    {
        public string tt = "";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Freya's Fley");
            Tooltip.SetDefault("Spores of the gods\nIllusion inflicts 'Shroomed', which slowly drains enemy life\nFires different projectiles based on Mysticism");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }



        public override void SetDefaults()
        {
            item.damage = 8;

            item.mana = 4;
            item.width = 52;
            item.height = 50;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2;
            item.value = 10000;
            item.rare = 1;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("HermesDestruction");
            item.shootSpeed = 6f;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 6 + 2 * modPlayer.destructionPower;
            item.damage = (int)(item.damage * modPlayer.destructionDamage);
            item.mana = 2;
            item.useTime = 10 - modPlayer.destructionPower;
            if (item.useTime <= 0)
                item.useTime = 2;
            item.useAnimation = item.useTime;
            item.knockBack = modPlayer.destructionPower;
            item.shootSpeed = 8f + (float)(2 * modPlayer.destructionPower);
            item.shoot = mod.ProjectileType("FreyaDestruction");
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 8;
            item.damage = (int)(item.damage * modPlayer.illusionDamage);
            item.mana = 8;
            item.useTime = 35;
            item.useAnimation = 35;
            item.knockBack = 1;
            item.shootSpeed = 8f;
            item.shoot = mod.ProjectileType("FreyaIllusion");
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 8;
            item.damage = (int)(item.damage * modPlayer.conjurationDamage);
            item.mana = 6;
            item.useTime = 50;
            item.useAnimation = 50;
            item.knockBack = 5;
            item.shootSpeed = 2f;
            item.shoot = mod.ProjectileType("FreyaConjuration1");
        }



        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(183, 12);
            recipe.AddIngredient(176, 10);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}