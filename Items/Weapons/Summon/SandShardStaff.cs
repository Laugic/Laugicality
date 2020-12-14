using System;
using Laugicality.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Projectiles.Special;
using Laugicality.Projectiles.Summon;

namespace Laugicality.Items.Weapons.Summon
{
    public class SandShardStaff : LaugicalityItem
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
            item.noMelee = true; 
            item.knockBack = 2f;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item44;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Nothing>();
            item.shootSpeed = 10f;
            item.summon = true;
            item.buffType = ModContent.BuffType<SandySharkBuff>();
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
		    Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, ModContent.ProjectileType<SandySharkProjectile>(), num73, num74, i, 0f, 0f);
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
            recipe.AddIngredient(ItemID.DemoniteBar, 8);
            recipe.AddIngredient(169, 16);
            recipe.AddIngredient(319, 1);
            recipe.AddIngredient(null, "AncientShard", 1);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe Arecipe = new ModRecipe(mod);
            Arecipe.AddIngredient(ItemID.CrimtaneBar, 8);
            Arecipe.AddIngredient(169, 16);
            Arecipe.AddIngredient(319, 1);
            Arecipe.AddIngredient(null, "AncientShard", 1);
            Arecipe.AddTile(16);
            Arecipe.SetResult(this);
            Arecipe.AddRecipe();
        }
    }
}