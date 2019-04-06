using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class AncientShroud : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Shroud");
            Tooltip.SetDefault("Your Potentia is added to your Max Life\nIncreased Life Regen as Potentia drops\nIncreased Mystic Damage as Life drops");
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

            int minPotentia = (int)(modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost);

            if(modPlayer.VisMax + modPlayer.VisMaxPermaBoost < minPotentia)
                minPotentia = (int)(modPlayer.VisMax + modPlayer.VisMaxPermaBoost);

            if (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost < minPotentia)
                minPotentia = (int)(modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost);

            player.statLifeMax2 += minPotentia;
            float currPotentia = 1;
            float currMaxPotentia = 1;

            switch (modPlayer.MysticMode)
            {
                case 1:
                    currPotentia = modPlayer.Lux;
                    currMaxPotentia = modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost;
                    break;
                case 2:
                    currPotentia = modPlayer.Vis;
                    currMaxPotentia = modPlayer.VisMax + modPlayer.VisMaxPermaBoost;
                    break;
                default:
                    currPotentia = modPlayer.Mundus;
                    currMaxPotentia = modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost;
                    break;
            }
            if (currMaxPotentia == 0)
                currMaxPotentia = 1;

            player.lifeRegen += (int)(6 * (1 - (currPotentia / currMaxPotentia)));
            modPlayer.MysticDamage += .2f * (1-(player.statLife / player.statLifeMax2));
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TissueSample, 16);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}