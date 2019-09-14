using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;

namespace Laugicality.Items.Weapons.Mystic
{
	public class FriggsPhalanx : MysticItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frigg's Phalanx");
            Tooltip.SetDefault("'The swarm cometh'\nIllusion inflicts 'Poison'\nFires different projectiles based on Mysticism");
			Item.staff[item.type] = true;
		}

        public override void SetMysticDefaults()
		{
			item.damage = 25;
            item.width = 48;
			item.height = 48;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType<Nothing>();
			item.shootSpeed = 6f;
		}

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.MysticMode == 1)
            {
                int numberProjectiles = Main.rand.Next(1, 3);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    if(Main.rand.Next(2) == 0)
                    {
                        if(!player.strongBees)
                            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 181, damage, knockBack, player.whoAmI);
                        else
                            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 566, (int)(damage * 1.5), knockBack, player.whoAmI);
                    }
                    else
                        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("FriggDestruction"), damage, knockBack, player.whoAmI);
                }
            }
            if(modPlayer.MysticMode == 2)
            {
                float theta = (float)Main.rand.NextDouble() * 3.14f * 2;
                float mag = 360;
                Projectile.NewProjectile((int)(Main.MouseWorld.X) + (int)(mag * Math.Cos(theta)), (int)(Main.MouseWorld.Y) + (int)(mag * Math.Sin(theta)), -4 * (float)Math.Cos(theta), -4 * (float)Math.Sin(theta), mod.ProjectileType("FriggIllusion"), damage, 3, Main.myPlayer);
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 28;
            item.useTime = 13;
            item.useAnimation = item.useTime;
            item.knockBack = 1f;
            item.shootSpeed = 10;
            item.shoot = mod.ProjectileType<Nothing>();
            LuxCost = 6;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 25;
            item.useTime = 15;
            item.useAnimation = 15;
            item.knockBack = 1;
            item.shootSpeed = 8f;
            item.shoot = mod.ProjectileType<Nothing>();
            VisCost = 5;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 25;
            item.useTime = 50;
            item.useAnimation = 50;
            item.knockBack = 5;
            item.shootSpeed = 2f;
            item.shoot = mod.ProjectileType("FriggConjuration");
            MundusCost = 16;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(331, 10);
            recipe.AddIngredient(2431, 8);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}