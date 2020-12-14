using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Laugicality.Items.Placeable;
using Laugicality.Projectiles.Thrown;
using Laugicality.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace Laugicality.Items.Weapons.Thrown
{
    public class Antarctica : LaugicalityItem
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
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<AntarcticaProjectile>();
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
            recipe.AddIngredient(null, nameof(BysmalBar), 15);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 6);
            recipe.AddTile(null, nameof(AlchemicalInfuser));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}