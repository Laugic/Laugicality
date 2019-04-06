using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Weapons.Mystic
{
	public class MarsFury : MysticItem
    {
        int _counter = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mars' Fury");
            Tooltip.SetDefault("A Furious War\nIllusion inflicts 'Furious', which deals damage over time and makes enemies explode into Magma Shards upon death\nFires different projectiles based on Mysticism");
        }

		public override void SetMysticDefaults()
		{
            _counter = 0;
            item.damage = 40;
            item.width = 66;
			item.height = 74;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.noMelee = false;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shootSpeed = 6f;
            item.scale = 1.5f;
		}
        
        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if(_counter > 0)
                _counter--;
            if (modPlayer.mysticMode == 2 && _counter <= 0)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 8f, mod.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -8f, mod.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 8f, 0f, mod.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -8f, 0f, mod.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6f, 6f, mod.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -6f, -6f, mod.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6f, -6f, mod.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -6f, 6f, mod.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                _counter = 6;
            }
            return true;
        }      

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.scale = 1.5f;
            item.damage = 44;
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.knockBack = 8;
            item.shootSpeed = 4f;
            item.shoot = mod.ProjectileType("Nothing");
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.scale = 1f;
            item.damage = 32;
            item.useTime = 10;
            item.useAnimation = 10;
            item.knockBack = 4;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("Nothing");
            visCost = 4;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.scale = 1f;
            item.damage = 32;
            item.useTime = 38;
            item.useAnimation = 38;
            item.knockBack = 2;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("MarsConjuration");
            mundusCost = 20;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            luxCost = 8;
            if (modPlayer.mysticMode == 1 && modPlayer.lux >= luxCost * modPlayer.luxUseRate * modPlayer.globalPotentiaUseRate)
            {
                Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("MarsDestruction"), damage, knockback, Main.myPlayer);

                modPlayer.lux -= luxCost * modPlayer.luxUseRate * modPlayer.globalPotentiaUseRate;
                if (modPlayer.lux < 0)
                    modPlayer.lux = 0;
                if (modPlayer.lux > (modPlayer.luxMax + modPlayer.luxMaxPermaBoost) * modPlayer.luxOverflow * modPlayer.globalOverflow)
                    modPlayer.lux = (modPlayer.luxMax + modPlayer.luxMaxPermaBoost) * modPlayer.luxOverflow * modPlayer.globalOverflow;
                modPlayer.vis += luxCost * modPlayer.globalAbsorbRate * modPlayer.visAbsorbRate * modPlayer.luxDischargeRate * modPlayer.luxUseRate * modPlayer.globalPotentiaUseRate;
                if (modPlayer.vis > (modPlayer.visMax + modPlayer.visMaxPermaBoost) * modPlayer.visOverflow * modPlayer.globalOverflow)
                    modPlayer.vis = (modPlayer.visMax + modPlayer.visMaxPermaBoost) * modPlayer.visOverflow * modPlayer.globalOverflow;
                modPlayer.mundus += luxCost * modPlayer.globalAbsorbRate * modPlayer.mundusAbsorbRate * modPlayer.luxDischargeRate * modPlayer.luxUseRate * modPlayer.globalPotentiaUseRate;
                if (modPlayer.mundus > (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost) * modPlayer.mundusOverflow * modPlayer.globalOverflow)
                    modPlayer.mundus = (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost) * modPlayer.mundusOverflow * modPlayer.globalOverflow;

            }
            luxCost = 0;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HadesJudgement", 1);
            recipe.AddIngredient(null, "MagmaticCluster");
            recipe.AddIngredient(null, "MagmaticCrystal", 4);
            recipe.AddIngredient(null, "SoulOfHaught", 8);
            recipe.AddRecipeGroup("TitaniumBars", 6);
            recipe.AddIngredient(null, "RubrumDust", 4);
            recipe.AddIngredient(null, "AlbusDust", 2);
            recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
            
        }
    }
}