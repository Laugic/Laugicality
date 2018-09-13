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
	public class Yuletide : MysticItem
    {
        public string tt = "";
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yuletide");
            Tooltip.SetDefault("'Holiday Cheer'\nIllusion inflicts 'Frostburn'\nFires different projectiles based on Mysticism");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 32;
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
            if (modPlayer.mysticMode == 3)
            {
                for(int i = 0; i < modPlayer.conjurationPower; i++)
                {
                    if(Main.netMode != 1)
                        Projectile.NewProjectile((int)(Main.MouseWorld.X) - 8 + Main.rand.Next(0, 16), (int)(Main.MouseWorld.Y) - 360 - 8 + Main.rand.Next(0, 16), 0, 0, mod.ProjectileType("YuleConjuration"), (int)(item.damage), 3, Main.myPlayer);
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
                item.damage = 22 + 8 * modPlayer.destructionPower;
                item.damage = (int)(item.damage * modPlayer.destructionDamage);
                item.useTime = 15 - 3 * modPlayer.destructionPower;
                if (item.useTime <= 0)
                    item.useTime = 2;
                item.useAnimation = item.useTime;
                item.knockBack = modPlayer.destructionPower;
                item.shootSpeed = 8f + (float)(2 * modPlayer.destructionPower);
                item.shoot = mod.ProjectileType("YuleDestruction");
            }
            else if(modPlayer.mysticMode == 2)
            {
                player.AddBuff(mod.BuffType("Illusion"), 1, true);
                item.damage = 40;
                item.damage = (int)(item.damage * modPlayer.illusionDamage);
                item.useTime = 25;
                item.useAnimation = 25;
                item.knockBack = 1;
                item.shootSpeed = 8f;
                item.shoot = mod.ProjectileType("YuleIllusion");
            }
            else if (modPlayer.mysticMode == 3)
            {
                player.AddBuff(mod.BuffType("Conjuration"), 1, true);
                item.damage = 36;
                item.damage = (int)(item.damage * modPlayer.conjurationDamage);
                item.useTime = 10;
                item.useAnimation = 10;
                item.knockBack = 5;
                item.shootSpeed = 2f;
                item.shoot = mod.ProjectileType("Nothing");
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
            recipe.AddIngredient(ItemID.SnowBlock, 25);
            recipe.AddIngredient(ItemID.IceBlock, 25);
            recipe.AddIngredient(null, "FrostShard", 1);
            recipe.AddIngredient(null, "ChilledBar", 6);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}