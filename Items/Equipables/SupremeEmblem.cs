using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class SupremeEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Cog of Knowledge");
            Tooltip.SetDefault("'The power of all'\nIncreases damage by 20%");
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
            player.magicDamage += 0.2f;
            player.meleeDamage += 0.2f;
            player.rangedDamage += 0.2f;
            player.thrownDamage += 0.2f;
            player.minionDamage += 0.2f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SupremeWarriorEmblem", 1);
            recipe.AddIngredient(null, "SupremeRangerEmblem", 1);
            recipe.AddIngredient(null, "SupremeSorcererEmblem", 1);
            recipe.AddIngredient(null, "SupremeSummonerEmblem", 1);
            recipe.AddIngredient(null, "SupremeNinjaEmblem", 1);
            recipe.AddIngredient(null, "SupremeMysticEmblem", 1);
            recipe.AddIngredient(null, "SoulOfThought", 5);
            recipe.AddIngredient(null, "SoulOfFraught", 5);
            recipe.AddIngredient(null, "SoulOfWrought", 5);
            recipe.AddTile(null, "AncientEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}