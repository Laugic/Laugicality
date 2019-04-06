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
            int minPotentia = (int)(modPlayer.luxMax + modPlayer.luxMaxPermaBoost);
            if(modPlayer.visMax + modPlayer.visMaxPermaBoost < minPotentia)
                minPotentia = (int)(modPlayer.visMax + modPlayer.visMaxPermaBoost);
            if (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost < minPotentia)
                minPotentia = (int)(modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost);
            player.statLifeMax2 += minPotentia;
            float currPotentia = 1;
            float currMaxPotentia = 1;
            switch (modPlayer.mysticMode)
            {
                case 1:
                    currPotentia = modPlayer.lux;
                    currMaxPotentia = modPlayer.luxMax + modPlayer.luxMaxPermaBoost;
                    break;
                case 2:
                    currPotentia = modPlayer.vis;
                    currMaxPotentia = modPlayer.visMax + modPlayer.visMaxPermaBoost;
                    break;
                default:
                    currPotentia = modPlayer.mundus;
                    currMaxPotentia = modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost;
                    break;
            }
            if (currMaxPotentia == 0)
                currMaxPotentia = 1;
            player.lifeRegen += (int)(6 * (1 - (currPotentia / currMaxPotentia)));
            modPlayer.mysticDamage += .2f * (1-(player.statLife / player.statLifeMax2));
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