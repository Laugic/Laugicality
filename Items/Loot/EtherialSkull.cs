using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
    public class EtherialSkull : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("After taking damage, your damage is boosted by the percentage of your health that was taken for 10 seconds.\nIf this buff is still active when damage is taken again, the boost is stacked.");
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
            if (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0)
            {
                modPlayer.EtherialBones = true;
            }
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