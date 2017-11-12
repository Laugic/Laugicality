using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class EtherialSkull : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+20% Damage while in the Etherial");
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
                player.thrownDamage += 0.2f;
                player.rangedDamage += 0.2f;
                player.magicDamage += 0.2f;
                player.minionDamage += 0.2f;
                player.meleeDamage += 0.2f;
                modPlayer.mysticDamage += 0.2f;
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