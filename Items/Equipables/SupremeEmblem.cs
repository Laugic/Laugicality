using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class SupremeEmblem : LaugicalityItem
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
            item.rare = ItemRarityID.Green;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.allDamage += 0.2f;
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
            recipe.AddIngredient(mod, nameof(EtherialEssence), 5);
            recipe.AddTile(null, "AncientEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}