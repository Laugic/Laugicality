using Laugicality.Items.Consumables.Potions;
using Laugicality.Items.Loot;
using Laugicality.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class SpyritInABottle : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spyrit in a Bottle");
            Tooltip.SetDefault("Automatically switch Mysticism when you run out of the current Potentia,\nor one of your Potentias is at Max Overflow");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 1000;
            item.rare = ItemRarityID.Orange;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);

            switch (modPlayer.MysticMode)
            {
                case 1:
                    if (modPlayer.Lux <= modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost && (modPlayer.CurrentLuxCost > modPlayer.Lux || (modPlayer.Vis >= (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow) || (modPlayer.Mundus >= (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow)))
                        modPlayer.MysticSwitch();
                    break;
                case 2:
                    if (modPlayer.Vis <= modPlayer.VisMax + modPlayer.VisMaxPermaBoost && (modPlayer.CurrentVisCost > modPlayer.Vis || (modPlayer.Lux >= (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow) || (modPlayer.Mundus >= (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow)))
                        modPlayer.MysticSwitch();
                    break;
                default:
                    if (modPlayer.Mundus <= modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost && (modPlayer.CurrentMundusCost > modPlayer.Mundus || (modPlayer.Vis >= (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow) || (modPlayer.Lux >= (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow)))
                        modPlayer.MysticSwitch();
                    break;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FaeryInABottle>(), 1);
            recipe.AddIngredient(ModContent.ItemType<GreaterMysticaPotion>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SoulOfSought>(), 5);
            recipe.AddTile(ModContent.TileType<MineralEnchanterTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}