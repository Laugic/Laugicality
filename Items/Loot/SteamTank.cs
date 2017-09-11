using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class SteamTank : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Cog of Knowledge");
            Tooltip.SetDefault("Steam powered!\nIncreases damage by 8% \nIncreases jump height and movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 48;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
            //item.defense = 1000;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.jumpSpeedBoost += 2f;
            player.moveSpeed += 0.5f;
            player.maxRunSpeed += 1.0f;
            player.magicDamage += 0.08f;
            player.meleeDamage += 0.08f;
            player.rangedDamage += 0.08f;
            player.thrownDamage += 0.08f;
            player.minionDamage += 0.08f;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2328, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}