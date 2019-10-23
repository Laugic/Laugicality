using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
    public class BrainOfEtheria : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fragmented Mind");
            Tooltip.SetDefault("While in the etherial, if you would die from contact damage, heal 300 life instead. 3 minute cooldown.\nAfter colliding with an enemy, that enemy takes 50% more damage for 15 seconds.");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.EtherialBrain = true;
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