using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Mystic
{
	public class ZeusBolt : MysticItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zeus' Bolt");
            Tooltip.SetDefault("''"
							+ "\nIllusion inflicts ''"
							+ "\nFires different projectiles based on Mysticism");
            Item.staff[item.type] = true;
        }

        public override void SetMysticDefaults()
		{
			item.damage = 44;
            item.width = 64;
			item.height = 64;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 2;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 6f;
            LuxCost = 10;
            VisCost = 10;
            MundusCost = 10;
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
            {
                if(Main.rand.Next(2) == 0)
                {
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType("ZuesBoltDestruction2"), damage, 3f, player.whoAmI, 0f, 0f);
                }
                else
                {
                    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType("ZuesBoltDestruction1"), damage, 3f, player.whoAmI, 0f, 0f);
                }
            }
            if (modPlayer.MysticMode == 3)
            {
                
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 72;
            item.useTime = 15;
            item.useAnimation = (int)(item.useTime);
            item.knockBack = 0;
            item.shootSpeed = 14f;
            item.shoot = ModContent.ProjectileType<Nothing>();
            item.UseSound = SoundID.Item1;
            item.scale = 1.5f;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 42;
            item.useTime = 32;
            item.useAnimation = item.useTime;
            item.knockBack = 5;
            item.shootSpeed = 10f;
            item.shoot = ModContent.ProjectileType("ZuesBoltIllusion1");
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            item.scale = 1f;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 44;
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 8f;
            item.shoot = ModContent.ProjectileType("HallowsEveConjuration1");
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            item.scale = 1f;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1006, 16); //Chlorophyte
            recipe.AddIngredient(mod, nameof(SoulOfSought), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}