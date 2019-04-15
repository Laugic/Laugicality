using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Thrown
{
    public class Antarctica : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antarctica");
            Tooltip.SetDefault("'A blizzard hails from above'\nWhen in the Etherial after defeating Etheria, rain down more Hail,\nand stay stuck in enemies for twice as long.");
        }
        public override void SetDefaults()
        {
            item.damage = 150;
            item.thrown = true;
            item.noMelee = true;
            item.width = 12;
            item.height = 12;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Antarctica");
            item.shootSpeed = 26f;
            item.useTurn = true;
            item.maxStack = 1;
            item.consumable = false;
            item.noUseGraphic = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NorthPole);
            recipe.AddIngredient(null, "BysmalBar", 15);
            recipe.AddIngredient(null, "EtherialEssence", 6);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}