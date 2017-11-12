using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class EtherialTank : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+20 Defense and 15% Damage Reduction while in the Etherial");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
            //item.defense = 1000;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.etherial)
            {
                player.endurance += 0.15f;
                item.defense = 20;
            }
            else
                item.defense = 0;
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