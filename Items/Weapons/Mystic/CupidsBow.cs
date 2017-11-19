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
	public class CupidsBow : MysticItem
    {
        public int damage = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cupid's Bow");
            Tooltip.SetDefault("'Make them fall for you' \nArrows inflict 'Lovestruck', which makes enemies friendly towards you\nFires different projectiles based on Mysticism");
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
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			//item.shoot = mod.ProjectileType("GaiaDestruction");
			item.shootSpeed = 6f;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
            return true;
        }
        public override void HoldItem(Player player)
        {
            
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            //Main.NewText(modPlayer.mysticMode.ToString(), 200, 200, 0);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color

            if (modPlayer.mysticMode  == 1)
            {
                player.AddBuff(mod.BuffType("Destruction"), 1, true);
                item.useStyle = 1;
                item.damage = 30 + 10 * modPlayer.destructionPower;
                item.damage = (int)(item.damage * modPlayer.mysticDamage * modPlayer.destructionDamage);
                item.useTime = 23 - (3 * modPlayer.destructionPower);
                if (item.useTime <= 0)
                    item.useTime = 1;
                item.useAnimation = item.useTime;
                item.knockBack = 2 + 2 * modPlayer.destructionPower;
                item.shootSpeed = 12f;
                item.shoot = mod.ProjectileType("CupidDestruction");
                item.noUseGraphic = true;
            }
            else if(modPlayer.mysticMode == 2)
            {
                player.AddBuff(mod.BuffType("Illusion"), 1, true);
                item.useStyle = 5;
                item.damage = 77;
                item.damage = (int)(item.damage * modPlayer.mysticDamage * modPlayer.illusionDamage);
                item.useTime = 48;
                item.useAnimation = item.useTime;
                item.knockBack = 1;
                item.shootSpeed = 12f;
                item.shoot = mod.ProjectileType("CupidIllusion");
                item.noUseGraphic = false;
            }
            else if (modPlayer.mysticMode == 3)
            {
                player.AddBuff(mod.BuffType("Conjuration"), 1, true);
                item.useStyle = 5;
                item.damage = 20;
                item.damage = (int)(item.damage * modPlayer.mysticDamage * modPlayer.conjurationDamage);
                item.useTime = 20;
                item.useAnimation = item.useTime;
                item.knockBack = 2;
                item.shootSpeed = 24f;
                item.shoot = mod.ProjectileType("CupidConjuration");
                item.noUseGraphic = false;
            }
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(621, 24); //Pearlwood
            recipe.AddRecipeGroup("SilverBars", 8);
            recipe.AddIngredient(520, 6); //Soul of Light
            recipe.AddIngredient(null, "SoulOfSought", 4);
            recipe.AddIngredient(502, 4); //Crystal Shard
            recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}