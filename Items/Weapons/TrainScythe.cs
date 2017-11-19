using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons
{
	public class TrainScythe : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("CHOO CHOO \n Inflicts 'Steamy'");	//The (English) text shown below your weapon's name
		}

		public override void SetDefaults()
		{
            item.scale *= 1.25f;
			item.damage = 777;			//The damage of your weapon
			item.melee = true;			//Is your weapon a melee weapon?
			item.width = 144;			//Weapon's texture's width
			item.height = 144;			//Weapon's texture's height
			item.useTime = 60;			//The time span of using the weapon. Remember in terraria, 60 frames is a second.
			item.useAnimation = 60;			//The time span of the using animation of the weapon, suggest set it the same as useTime.
			item.useStyle = 1;			//The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			item.knockBack = 6;			//The force of knockback of the weapon. Maxium is 20
			item.value = 10000;			//The value of the weapon
			item.rare = 7;				//The rarity of the weapon, from -1 to 13
			item.UseSound = SoundID.Item71;		//The sound when the weapon is using
			item.autoReuse = true;          //Whether the weapon can use automaticly by pressing mousebutton
            //item.shoot = mod.ProjectileType("TrainScythe");
            //item.shootSpeed = 10f;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SteamBar", 16);
            recipe.AddIngredient(null, "SoulOfWrought", 8);
            recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Steam"));
				//Emit dusts when swing the sword
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Electrified"), 120);		//Add Onfire buff to the NPC for 1 second
		}
	}
}
