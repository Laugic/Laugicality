using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Mystic
{
    public class GaiasWorld : MysticItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gaia's World");
            Tooltip.SetDefault("The World is in your hands\nIllusion inflicts a random elemental debuff\nFires different projectiles based on Mysticism");
            Item.staff[item.type] = true;
        }

        public override void SetMysticDefaults()
        {
            item.damage = 25;
            item.width = 40;
            item.height = 40;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType("GaiaDestruction");
            item.shootSpeed = 6f;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 25;
            item.useTime = 28;
            item.useAnimation = item.useTime;
            item.knockBack = 6;
            item.shootSpeed = 10;
            item.shoot = ModContent.ProjectileType("GaiaDestruction");
            LuxCost = 7;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 25;
            item.useTime = 20;
            item.useAnimation = item.useTime;
            item.knockBack = 4;
            item.shootSpeed = 12f;
            item.shoot = ModContent.ProjectileType("GaiaIllusion");
            VisCost = 10;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 25;
            item.useTime = 32;
            item.useAnimation = 32;
            item.knockBack = 3;
            item.shootSpeed = 8f;
            item.shoot = ModContent.ProjectileType("GaiaConjuration");
            MundusCost = 12;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 8);
            recipe.AddIngredient(null, "Crystilla", 4);
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddIngredient(ItemID.Sapphire);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}