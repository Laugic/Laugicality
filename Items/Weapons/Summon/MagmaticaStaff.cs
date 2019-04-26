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
using Laugicality.Items.Materials;
using Laugicality.Projectiles;

namespace Laugicality.Items.Weapons.Summon
{
    public class MagmaticaStaff : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons a Magmatic Core to fight for you.");
        }

        public override void SetDefaults()
        {
            item.damage = 18;
            item.mana = 10;
            item.width = 40;
            item.height = 40;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 2f;
            item.value = 25000;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item44;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<Nothing>();
            item.shootSpeed = 10f;
            item.summon = true;
            item.buffType = mod.BuffType("MagmaticCore");
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
		    Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, mod.ProjectileType("MagmaticCore"), num73, num74, i, 0f, 0f);
		    return player.altFunctionUse != 2;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(ObsidiumBar), 14);
            recipe.AddIngredient(null, "DarkShard", 1);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}