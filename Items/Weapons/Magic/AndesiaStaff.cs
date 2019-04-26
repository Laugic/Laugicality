using System;
using Laugicality.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Magic
{
    public class AndesiaStaff : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staff of Honor");
            Tooltip.SetDefault("Right click to place \n'Onto War!'");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 50;           
            item.magic = true;             
            item.noMelee = true;
            item.mana = 4;
            item.width = 88;
            item.height = 88;
            item.useTime = 10;       
            item.useAnimation = 10;   
            item.useStyle = 5;
            item.knockBack = 6;
            item.value = 100000;
            item.rare = ItemRarityID.Green;
            //item.reuseDelay = 20;    
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;       
            //item.shoot = mod.ProjectileType("EnginatorP");  
            item.shootSpeed = 0f;     
            item.useTurn = true;
            item.maxStack = 1;      
            item.consumable = false;  
            //item.noUseGraphic = true;

        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.shoot = mod.ProjectileType("AndesiaStaff");
                item.noUseGraphic = true;
            }
            else
            {
                item.shoot = mod.ProjectileType<Nothing>();
                item.noUseGraphic = false;
            }
            return player.ownedProjectileCounts[mod.ProjectileType("AndesiaStaff")] < 1;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(Main.player[Main.myPlayer] == player)
            {
                Projectile.NewProjectile((int)(Main.MouseWorld.X) - 3 + Main.rand.Next(0, 6), (int)(Main.MouseWorld.Y) - 360 - 3 + Main.rand.Next(0, 6), 0, 0, mod.ProjectileType("Dioritite"), (int)(item.damage), 3, Main.myPlayer);
                Projectile.NewProjectile((int)(Main.MouseWorld.X) - 3 + Main.rand.Next(0, 6), (int)(Main.MouseWorld.Y) + 360 - 3 + Main.rand.Next(0, 6), 0, 0, mod.ProjectileType("Andesimite"), (int)(item.damage), 3, Main.myPlayer);
            }
            return true;
        }

        //(int)(Main.mouseX + Main.screenPosition.X), (int)(Main.mouseY + Main.screenPosition.Y)
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AndesiaCore", 1);
            recipe.AddIngredient(3086, 32);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}