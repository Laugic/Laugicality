using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class EtherialGlobe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+30% Damage while in the Etherial");
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
                player.thrownDamage += 0.3f;
                player.rangedDamage += 0.3f;
                player.magicDamage += 0.3f;
                player.minionDamage += 0.3f;
                player.meleeDamage += 0.3f;
                modPlayer.mysticDamage += 0.3f;
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