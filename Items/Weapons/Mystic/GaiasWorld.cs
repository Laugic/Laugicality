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
	public class GaiasWorld : MysticItem
    {
        public string tt = "";
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gaia's World");
            Tooltip.SetDefault("The World is in your hands \nRight click while holding to change Mysticism");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 10;
            //item.magic = true;
            item.mana = 6;
            item.width = 40;
			item.height = 40;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("GaiaDestruction");
			item.shootSpeed = 6f;
		}

        public override void HoldItem(Player player)
        {
            
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            //Main.NewText(modPlayer.mysticMode.ToString(), 200, 200, 0);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color

            if (modPlayer.mysticMode  == 1)
            {
                player.AddBuff(mod.BuffType("Destruction"), 1, true);
                item.damage = 30 + 5 * modPlayer.destructionPower;
                item.damage = (int)(item.damage * modPlayer.mysticDamage * modPlayer.destructionDamage);
                item.mana = 6;
                item.useTime = 26 - (2 * modPlayer.destructionPower);
                if (item.useTime <= 0)
                    item.useTime = 1;
                item.useAnimation = item.useTime;
                item.knockBack = 4 + (2 * modPlayer.destructionPower);
                item.shootSpeed = 8f + (float)(2 * modPlayer.destructionPower);
                item.shoot = mod.ProjectileType("GaiaDestruction");
            }
            else if(modPlayer.mysticMode == 2)
            {
                player.AddBuff(mod.BuffType("Illusion"), 1, true);
                item.damage = 30;
                item.damage = (int)(item.damage * modPlayer.mysticDamage * modPlayer.illusionDamage);
                item.mana = 6;
                item.useTime = 16;
                item.useAnimation = item.useTime;
                item.knockBack = 4;
                item.shootSpeed = 12f;
                item.shoot = mod.ProjectileType("GaiaIllusion");
            }
            else if (modPlayer.mysticMode == 3)
            {
                player.AddBuff(mod.BuffType("Conjuration"), 1, true);
                item.damage = 22;
                item.damage = (int)(item.damage * modPlayer.mysticDamage * modPlayer.conjurationDamage);
                item.mana = 6;
                item.useTime = 24;
                item.useAnimation = 24;
                item.knockBack = 3;
                item.shootSpeed = 8f;
                item.shoot = mod.ProjectileType("GaiaConjuration");
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
        }*/
        
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 8);
            recipe.AddIngredient(null, "DarkShard", 8);
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddIngredient(ItemID.Sapphire);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}