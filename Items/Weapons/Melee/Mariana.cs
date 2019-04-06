using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
	public class Mariana : ModItem
	{
		public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'To the depths'\nStriking enemies makes them emit bubbles!\nEnemies explode into bubbles on death, spreading the bubbles.");
		}

		public override void SetDefaults()
		{
			item.damage = 28;
            item.melee = true;
			item.width = 48;
			item.height = 54;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 10f;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("Bubbly"), 4 * 60 + Main.rand.Next(2 * 60));        //Add Onfire buff to the NPC for 1 second
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("GldBars", 5);
            recipe.AddRecipeGroup("SilverBars", 10);
            recipe.AddIngredient(ItemID.Seashell, 5);
            recipe.AddIngredient(ItemID.Coral, 5);
            recipe.AddIngredient(ItemID.SharkFin, 2);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}