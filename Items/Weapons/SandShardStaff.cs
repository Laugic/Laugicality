using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.IO;
using Terraria.ObjectData;
using Terraria.Utilities;
using Terraria.ModLoader;
using Laugicality.Items;

namespace Laugicality.Items.Weapons {
public class SandShardStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons a Sandy Shark to fight for you.");
        }

        public override void SetDefaults()
    {
        item.damage = 8;
        item.mana = 10;
        item.width = 42;
        item.height = 42;
        item.useTime = 27;
        item.useAnimation = 27;
        item.useStyle = 1;
        item.noMelee = true; //so the item's animation doesn't do damage
        item.knockBack = 2f;
        item.value = 25000;
        item.rare = 1;
        item.UseSound = SoundID.Item44;
        item.autoReuse = true;
        item.shoot = mod.ProjectileType("SandyShark");
        item.shootSpeed = 10f;
        item.summon = true;
            item.buffType = mod.BuffType("SandyShark"); //The buff added to player after used the item
            item.buffTime = 3600;
        }
    
    public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
    	int i = Main.myPlayer;
		float num72 = item.shootSpeed;
		int num73 = damage;
		float num74 = knockBack;
    	num74 = player.GetWeaponKnockback(item, num74);
    	player.itemTime = item.useTime;
    	Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
		Vector2 value = Vector2.UnitX.RotatedBy((double)player.fullRotation, default(Vector2));
		Vector2 vector3 = Main.MouseWorld - vector2;
    	float num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
		float num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
		if (player.gravDir == -1f)
		{
			num79 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector2.Y;
		}
		float num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
		float num81 = num80;
		if ((float.IsNaN(num78) && float.IsNaN(num79)) || (num78 == 0f && num79 == 0f))
		{
			num78 = (float)player.direction;
			num79 = 0f;
			num80 = num72;
		}
		else
		{
			num80 = num72 / num80;
		}
    	num78 = 0f;
		num79 = 0f;
		vector2.X = (float)Main.mouseX + Main.screenPosition.X;
		vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
		Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, mod.ProjectileType("SandyShark"), num73, num74, i, 0f, 0f);
		return false;
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 8);
            recipe.AddIngredient(169, 16);
            recipe.AddIngredient(319, 1);
            recipe.AddIngredient(null, "DarkShard", 1);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}