using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Thrown
{
    public class EnginatorT : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enginator");
            Tooltip.SetDefault("CHOO CHOO");
        }
        public override void SetDefaults()
        {
            item.damage = 110;
            item.thrown = true;
            item.noMelee = true;
            item.width = 106;
            item.height = 74;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10;
            item.rare = ItemRarityID.Orange;
            item.reuseDelay = 20;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("EnginatorTProj");
            item.shootSpeed = 16f;
            item.useTurn = true;
            item.maxStack = 1;
            item.consumable = false;
            item.noUseGraphic = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(SteamBar), 16);
            recipe.AddIngredient(null, "SoulOfFraught", 8);
            recipe.AddIngredient(mod, nameof(Gear), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}