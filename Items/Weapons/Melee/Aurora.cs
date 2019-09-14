using Laugicality.Items.Loot;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
    public class Aurora : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aurora");
            Tooltip.SetDefault("'Chill them into submission'");
        }

        public override void SetDefaults()
        {
            item.damage = 65;
            item.melee = true;
            item.noMelee = false;
            item.width = 54;
            item.height = 58;
            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 100000;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Aurora");
            item.shootSpeed = 16f;
            item.useTurn = true;
            item.maxStack = 1;
            item.consumable = false;
        }

        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FrostBlade", 1);
            recipe.AddIngredient(mod, nameof(SoulOfSought), 6);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddRecipeGroup("TitaniumBars", 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}