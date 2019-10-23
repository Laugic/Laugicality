using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class WaterWalkingGem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Allows the ability to walk on water\nUse to toggle this effect in higher tier gems.");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.accessory = true;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item9;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.waterWalk = true;
        }
        
        public override bool UseItem(Player player)
        {
            LaugicalityPlayer.Get(player).ww = !LaugicalityPlayer.Get(player).ww;
            Main.NewText(LaugicalityPlayer.Get(player).ww.ToString(), 250, 250, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(302, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe wWrecipe = new ModRecipe(mod);
            wWrecipe.AddIngredient(54);
            wWrecipe.AddIngredient(this);
            wWrecipe.AddTile(114);
            wWrecipe.SetResult(863);
            wWrecipe.AddRecipe();
        }
    }
}