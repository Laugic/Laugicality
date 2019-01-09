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
	public class GreatGladius : MysticItem
    {
        public int damage = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gladius of The Great Moldyrian");
            Tooltip.SetDefault("Praise the gods\nIlusion inflicts 'Daybroken'\nAttacks differently projectiles based on Mysticism");
            //Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

		public override void SetMysticDefaults()
		{
			item.damage = 1500;
            //item.magic = true;
            item.width = 70;
			item.height = 70;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.noMelee = false; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 9;
			item.UseSound = SoundID.Item1;
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
            item.damage = 1500 + 500 * modPlayer.destructionPower;
            item.damage = (int)(item.damage * modPlayer.destructionDamage);
            item.useTime = 34 - (8 * modPlayer.destructionPower);
            if (item.useTime <= 2)
                item.useTime = 3;
            item.useAnimation = item.useTime;
            item.knockBack = 5 + 3 * modPlayer.destructionPower;
            item.shootSpeed = 4f;
            item.shoot = mod.ProjectileType("Nothing");
            item.scale = 2f + .25f * modPlayer.destructionPower;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 1500;
            item.damage = (int)(item.damage * modPlayer.illusionDamage);
            item.useTime = 20;
            item.useAnimation = 20;
            item.knockBack = 4;
            item.shootSpeed = 12f;
            item.shoot = ProjectileID.Daybreak;
            item.scale = 1.5f;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 1000;
            item.damage = (int)(item.damage * modPlayer.conjurationDamage);
            item.useTime = 45;
            item.useAnimation = 45;
            item.knockBack = 2;
            item.shootSpeed = 8f;
            item.shoot = mod.ProjectileType("Nothing");
            item.scale = 2f;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if(modPlayer.mysticMode == 2)
                target.AddBuff(189, (int)(120 * modPlayer.mysticDuration * modPlayer.illusionPower)); //Daybroken
            if (modPlayer.mysticMode == 3)
            {
                if(Main.player[Main.myPlayer] == player && player.ownedProjectileCounts[mod.ProjectileType("GreatGladiusConjuration1")] < modPlayer.conjurationPower)
                    Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("GreatGladiusConjuration1"), damage, knockback, Main.myPlayer);
            }
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3467, 16);
            recipe.AddIngredient(null, "GalacticFragment", 8);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}