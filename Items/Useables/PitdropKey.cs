using Laugicality.Dusts;
using Laugicality.Items.Loot;
using Laugicality.Pitdrop;
using Microsoft.Xna.Framework;
using SubworldLibrary;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Useables
{
    public class PitdropKey : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pitdrop Key");
            Tooltip.SetDefault("Enter the Pitdrop");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 100;
            item.rare = ItemRarityID.Pink;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldingUp;
        }

        public override bool UseItem(Player player)
        {
            Subworld.Enter<PitdropWorld>();
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(20, 0);
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BysmalBar", 4);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 2);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}