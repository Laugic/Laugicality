using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Laugicality.Projectiles.Thrown;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Thrown
{
    public class ForbiddenAxe : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forgotten Axe");
            Tooltip.SetDefault("'From the dunes'");
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.thrown = true;
            item.noMelee = true;
            item.width = 12;
            item.height = 12;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<ForbiddenAxeProj>();
            item.shootSpeed = 12f;
            item.useTurn = true;
            item.maxStack = 1;
            item.consumable = false;
            item.noUseGraphic = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(AncientShard), 1);
            recipe.AddIngredient(mod, nameof(Crystilla), 4);
            recipe.AddIngredient(ItemID.FossilOre, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}