using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
    public class EtherialTank : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("CHOO CHOO! While in the etherial, the faster you move, the higher your damage.\nColliding with an enemy deals your movement speed * 500 in damage.\nGreatly increases Movement Speed.");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = ItemRarityID.LightRed;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0)
            {
                modPlayer.EtherialTank = true;
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