using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class AncientCarapace : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Carapace");
            Tooltip.SetDefault("Your Defense is added to your Potentia\nIncreased endurance as Potentia drops\nIncreased Mystic Damage for a time after taking damage");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
            item.defense = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);

            modPlayer.LuxMax += player.statDefense;
            modPlayer.VisMax += player.statDefense;
            modPlayer.MundusMax += player.statDefense;

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

            player.endurance += (1 - (currPotentia / currMaxPotentia)) * .15f;

            modPlayer.Carapace = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShadowScale, 16);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}