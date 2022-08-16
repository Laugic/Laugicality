using Laugicality.Projectiles.Mystic.Conjuration;
using Laugicality.Projectiles.Mystic.Destruction;
using Laugicality.Projectiles.Mystic.Illusion;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Mystic
{
	public class StaffOfAnDio : MysticItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Loki's Staff");
            Tooltip.SetDefault("'Many tricks up his sleeve'");
            Item.staff[item.type] = true; 
        }

		public override void SetMysticDefaults()
		{
			item.damage = 40;
            item.width = 48;
			item.height = 48;
			item.useTime = 18;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 2;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 6f;
        }

        public override string GetExtraTooltip()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
            {
                case 1:
                    return "Shoots a slightly homing orb";
                case 2:
                    return "Shoots a homing beam that inflicts 'Time Dilation', which\ncauses enemies to take a burst of damage when Time is Stopped.";
                case 3:
                    return "Spawns energy orbs that create stalagmites and stalactites.";
                default:
                    return "";
            }
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 65f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return base.MysticShoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 42;
            item.useTime = 20;
            item.useAnimation = item.useTime;
            item.knockBack = 8;
            item.shootSpeed = 14f;
            item.shoot = ModContent.ProjectileType<AnDioDestruction1>();
            item.UseSound = SoundID.Item20;
            item.scale = 1f;
            LuxCost = 8;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 26;
            item.useAnimation = item.useTime = 4;
            item.knockBack = 5;
            item.shootSpeed = 12f;
            item.shoot = ModContent.ProjectileType<AnDioIllusion>();
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item20;
            item.scale = 1f;
            VisCost = 4;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 38;
            item.useAnimation = item.useTime = 15;
            item.knockBack = 2;
            item.shootSpeed = 18f;
            item.shoot = ModContent.ProjectileType<AnDioConjuration1>();
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item20;
            item.scale = 1f;
            MundusCost = 15;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("TitaniumBars", 12);
            recipe.AddIngredient(null, "DioritusCore", 1);
            recipe.AddIngredient(null, "AndesiaCore", 1);
            recipe.AddIngredient(3081, 25);
            recipe.AddIngredient(3086, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}