using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Range
{
	public class BysmalBlaster : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bysmal Blaster");
            Tooltip.SetDefault("'Blast them to another dimension'\n50% chance to not consume ammo\nWhile in the Etherial after defeating Etheria, shoots shotgun blasts twice as often");
		}

        private int reload = 0;
        private int reloadMax = 2;
        private float theta = 0f;
        private float rotSp = (float)Math.PI / 4;

		public override void SetDefaults()
        {
            item.scale *= 1.2f;
            item.damage = 88;
			item.ranged = true;
			item.width = 44;
			item.height = 86;
			item.useTime = 7;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 10000;
			item.rare = 9;
			item.UseSound = SoundID.Item41;
			item.autoReuse = true;
            item.channel = true;
            item.shoot = 10;
			item.shootSpeed = 22f;
			item.useAmmo = AmmoID.Bullet;
		}
        
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BysmalBar", 12);
            recipe.AddIngredient(null, "EtherialEssence", 5);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
            
        public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .50f;
		}

        public override void HoldItem(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
            
            float mag = 12f;
            theta += rotSp;

            if (theta >= 3.14158265f * 2)
                theta -= 3.14158265f * 2;

            Projectile.NewProjectile(player.Center.X, player.Center.Y, (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, mod.ProjectileType("BysmalBlast"), (int)(item.damage), 3, Main.myPlayer);

            //Normal shot
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                position += muzzleOffset;


            reload -= 1;

            if (reload <= 0)
            {
                reload = reloadMax;
                if ((LaugicalityWorld.downedEtheria || player.GetModPlayer<LaugicalityPlayer>(mod).Etherable > 0) && LaugicalityWorld.downedTrueEtheria)
                    reload /= 2;

                int numberProjectiles = Main.rand.Next(3, 6);

                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7)); 
                                                                                                                
                    float scale = 1f - (Main.rand.NextFloat() * .2f);
                    perturbedSpeed = perturbedSpeed * scale;

                    if(Main.player[Main.myPlayer] == player)
                        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
            }

            return false; 
        }
    }
}
