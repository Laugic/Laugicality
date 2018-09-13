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
            Tooltip.SetDefault("'Make them fall for you' \nArrows inflict 'Lovestruck', which makes enemies drop Hearts on death\nFires different projectiles based on Mysticism\nThe amount of angels that can be conjured is your Conjuration Power * your Max Minions + 1");
            //Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        

        public override void SetDefaults()
		{
			item.damage = 40;
            item.width = 44;
			item.height = 74;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 6f;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;

            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.mysticMode == 3)
            {
                for (int p = 0; p < 1000; p++)
                {
                    if (Main.projectile[p].type == mod.ProjectileType("CupidConjurationAngel"))
                    {
                        if (player.ownedProjectileCounts[mod.ProjectileType("CupidConjurationAngel")] >= modPlayer.conjurationPower * player.maxMinions + 1)
                        {
                            Main.projectile[p].Kill();
                            break;
                        }
                    }

                }
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.useStyle = 1;
            item.damage = 34 + 14 * modPlayer.destructionPower;
            item.damage = (int)(item.damage * modPlayer.destructionDamage);
            item.useTime = 22 - (4 * modPlayer.destructionPower);
            if (item.useTime <= 0)
                item.useTime = 1;
            item.useAnimation = item.useTime;
            item.knockBack = 2 + 2 * modPlayer.destructionPower;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("CupidDestruction");
            item.noUseGraphic = true;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.useStyle = 5;
            item.damage = 42;
            item.damage = (int)(item.damage * modPlayer.illusionDamage);
            item.useTime = 16;
            item.useAnimation = item.useTime;
            item.knockBack = 1;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("CupidIllusion");
            item.noUseGraphic = false;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.useStyle = 5;
            item.damage = 35;
            item.damage = (int)(item.damage * modPlayer.conjurationDamage);
            item.useTime = 20;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 0f;
            item.shoot = mod.ProjectileType("CupidConjurationAngel");
            item.noUseGraphic = false;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pearlwood, 24);
            recipe.AddRecipeGroup("SilverBars", 8);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddIngredient(null, "SoulOfSought", 4);
            recipe.AddIngredient(ItemID.CrystalShard, 4);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}