using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Projectiles.Mystic.Destruction;
using Laugicality.Projectiles.Mystic.Illusion;
using Laugicality.Projectiles.Mystic.Conjuration;

namespace Laugicality.Items.Weapons.Mystic
{
    public class ChlorysBlade : MysticItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chlorys's Blade");
            Tooltip.SetDefault("Illusion inflicts 'Poisoned'\nFires different projectiles based on Mysticism");
        }

        public override void SetMysticDefaults()
        {
            item.damage = 10;
            item.width = 48;
            item.height = 48;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.noMelee = false;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shootSpeed = 6f;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 10;
            item.useTime = 48;
            item.useAnimation = (int)(item.useTime / 2);
            item.knockBack = 3;
            item.shootSpeed = 10f;
            item.shoot = mod.ProjectileType<ChlorysDestruction>();
            item.UseSound = SoundID.Item1;
            LuxCost = 6;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 8;
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.knockBack = 5;
            item.shootSpeed = 8f;
            item.shoot = mod.ProjectileType<ChlorysIllusion>();
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            item.scale = 1f;
            VisCost = 6;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 10;
            item.useTime = 60;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 4f;
            item.shoot = mod.ProjectileType<ChlorysConjuration1>();
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            item.scale = 1f;
            MundusCost = 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 16);
            recipe.anyWood = true;
            recipe.AddIngredient(ItemID.Acorn, 6);
            recipe.AddIngredient(ItemID.Sunflower, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}