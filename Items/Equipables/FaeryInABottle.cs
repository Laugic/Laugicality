using Laugicality.Items.Consumables.Potions;
using Laugicality.Items.Materials;
using Laugicality.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class FaeryInABottle : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Faery in a Bottle");
            Tooltip.SetDefault("Automatically switch Mysticism when you run out of the current Potentia");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 1000;
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);

            switch (modPlayer.MysticMode)
            {
                case 1:
                    if (modPlayer.CurrentLuxCost > modPlayer.Lux)
                        modPlayer.MysticSwitch();
                    break;
                case 2:
                    if (modPlayer.CurrentVisCost > modPlayer.Vis)
                        modPlayer.MysticSwitch();
                    break;
                default:
                    if (modPlayer.CurrentMundusCost > modPlayer.Mundus)
                        modPlayer.MysticSwitch();
                    break;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FireflyinaBottle);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 5);
            recipe.AddIngredient(ModContent.ItemType<MysticaPotion>(), 1);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}