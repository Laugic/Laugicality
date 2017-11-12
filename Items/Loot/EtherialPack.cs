using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class EtherialPack : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+30% Movement Speed and Max Run Speed while in the Etherial");
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
                player.maxRunSpeed += 3f;
                player.moveSpeed += .3f;
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