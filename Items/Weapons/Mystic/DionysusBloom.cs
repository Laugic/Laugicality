using Laugicality.Items.Loot;
using Laugicality.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Weapons.Mystic
{
	public class DionysusBloom : MysticItem
    {
        public int damage = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dionysus' Bloom");
            Tooltip.SetDefault("'Grow his strength' \nIllusion inflicts 'Venom'\nFires different projectiles based on Mysticism");
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
		}

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 64f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.MysticMode == 2)
            {

                int numberProjectiles = Main.rand.Next(1, 4);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); 
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("DionysusIllusion"), damage, knockBack, player.whoAmI);
                }
                return false;
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 72;
            item.useTime = 25;
            item.useAnimation = item.useTime;
            item.knockBack = 0;
            item.shootSpeed = 14f;
            item.shoot = mod.ProjectileType("DionysusDestruction");
            item.UseSound = SoundID.Item1;
            item.scale = 1.25f;
            LuxCost = 6;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 42;
            item.useTime = 10;
            item.useAnimation = item.useTime;
            item.knockBack = 5;
            item.shootSpeed = 18f;
            item.shoot = mod.ProjectileType<Nothing>();
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            item.scale = 1f;
            VisCost = 4;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 44;
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 20f;
            item.shoot = mod.ProjectileType("DionysusConjuration");
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            item.scale = 1f;
            MundusCost = 20;
        }

       


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1006, 16); //Chlorophyte
            recipe.AddIngredient(mod, nameof(SoulOfSought), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}