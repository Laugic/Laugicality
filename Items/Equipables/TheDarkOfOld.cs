using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class TheDarkOfOld : LaugicalityItem
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
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDamage += .08f;
            switch(modPlayer.MysticMode)
            {
                case 1:
                    if(modPlayer.Lux < (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) / 2)
                        modPlayer.MysticDamage += .08f;
                    break;
                case 2:
                    if (modPlayer.Vis < (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) / 2)
                        modPlayer.MysticDamage += .08f;
                    break;
                default:
                    if (modPlayer.Mundus < (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) / 2)
                        modPlayer.MysticDamage += .08f;
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