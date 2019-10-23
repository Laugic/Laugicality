using Laugicality.Projectiles.Mystic.Conjuration;
using Laugicality.Projectiles.Mystic.Destruction;
using Laugicality.Projectiles.Mystic.Illusion;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Projectiles.Special;

namespace Laugicality.Items.Weapons.Mystic
{
    public class FreyasFley : MysticItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Freya's Fley");
            Tooltip.SetDefault("Spores of the gods\nIllusion inflicts 'Shroomed', which slowly drains enemy life\nFires different projectiles based on Mysticism");
            Item.staff[item.type] = true;
        }

        public override void SetMysticDefaults()
        {
            item.damage = 11;
            item.width = 52;
            item.height = 50;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Nothing>();
            item.shootSpeed = 6f;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 10;
            item.useTime = 9;
            item.useAnimation = item.useTime;
            item.knockBack = 1;
            item.shootSpeed = 10f;
            item.shoot = ModContent.ProjectileType<FreyaDestruction>();
            LuxCost = 3;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 10;
            item.damage = (int)(item.damage * modPlayer.IllusionDamage);
            item.useTime = 35;
            item.useAnimation = 35;
            item.knockBack = 1;
            item.shootSpeed = 12f;
            item.shoot = ModContent.ProjectileType<FreyaIllusion>();
            VisCost = 10;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 12;
            item.useTime = 50;
            item.useAnimation = 50;
            item.knockBack = 5;
            item.shootSpeed = 2f;
            item.shoot = ModContent.ProjectileType<FreyaConjuration1>();
            MundusCost = 14;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(183, 12);
            recipe.AddIngredient(176, 10);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}