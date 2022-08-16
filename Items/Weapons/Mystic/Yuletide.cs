using Laugicality.Projectiles.Mystic.Conjuration;
using Laugicality.Projectiles.Mystic.Destruction;
using Laugicality.Projectiles.Mystic.Illusion;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;
using Laugicality.Items.Loot;
using Laugicality.Items.Materials;

namespace Laugicality.Items.Weapons.Mystic
{
	public class Yuletide : MysticItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yuletide");
            Tooltip.SetDefault("'Holiday Cheer'\nIllusion inflicts 'Frostburn'\nFires different projectiles based on Mysticism");
			Item.staff[item.type] = true;
		}

		public override void SetMysticDefaults()
		{
			item.damage = 36;
            item.width = 48;
			item.height = 48;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Nothing>();
			item.shootSpeed = 6f;
        }

        public override string GetExtraTooltip()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
            {
                case 1:
                    return "Shoots a stream of icicles that follow your cursor";
                case 2:
                    return "Shoots a bouncing snowflake that inflicts 'Brittle', \nwhich makes enemies take more damage based on the speed of what hits them";
                case 3:
                    return "Spawns a snowflake that shoots out icicles";
                default:
                    return "";
            }
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 30;
            item.useAnimation = item.useTime = 12;
            item.knockBack = 2;
            item.shootSpeed = 10;
            item.shoot = ModContent.ProjectileType<YuleDestruction>();
            LuxCost = 4;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 40;
            item.useTime = 25;
            item.useAnimation = 25;
            item.knockBack = 1;
            item.shootSpeed = 8f;
            item.shoot = ModContent.ProjectileType<YuleIllusion>();
            VisCost = 8;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 36;
            item.useAnimation = item.useTime = 30;
            item.knockBack = 5;
            item.shootSpeed = 2f;
            item.shoot = ModContent.ProjectileType<YuleConjuration1>();
            MundusCost = 12;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ChilledBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Vitasilk>(), 4);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}