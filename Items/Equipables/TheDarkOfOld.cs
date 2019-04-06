using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class TheDarkOfOld : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Dark of Old");
            Tooltip.SetDefault("+8% Mystic Damage.\nAn Additional +8% Mystic Damage when below 50% of your current Potentia");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 1;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.mysticDamage += .08f;
            switch(modPlayer.mysticMode)
            {
                case 1:
                    if(modPlayer.lux < (modPlayer.luxMax + modPlayer.luxMaxPermaBoost) / 2)
                        modPlayer.mysticDamage += .08f;
                    break;
                case 2:
                    if (modPlayer.vis < (modPlayer.visMax + modPlayer.visMaxPermaBoost) / 2)
                        modPlayer.mysticDamage += .08f;
                    break;
                default:
                    if (modPlayer.mundus < (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost) / 2)
                        modPlayer.mysticDamage += .08f;
                    break;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 8);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}