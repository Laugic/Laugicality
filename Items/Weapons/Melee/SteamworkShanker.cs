using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
    public class SteamworkShanker : LaugicalityItem
    {
        public override void SetDefaults()
        {
            item.scale = 1f;
            item.damage = 100;
            item.melee = true;
            item.width = 60;
            item.height = 60;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = 5;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
            item.noUseGraphic = true;
            item.shootSpeed = 8f;
            item.shoot = mod.ProjectileType("SteamworkShanker");
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(SteamBar), 12);
            recipe.AddIngredient(ItemID.Cog, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
