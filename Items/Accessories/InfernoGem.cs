using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class InfernoGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Ignites nearby enemies\nUse to toggle this effect in higher tier gems.");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item9;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(116, 2);
        }


        public override bool UseItem(Player player)
        {
            player.GetModPlayer<LaugicalityPlayer>(mod).inf = !player.GetModPlayer<LaugicalityPlayer>(mod).inf;
            Main.NewText(player.GetModPlayer<LaugicalityPlayer>(mod).inf.ToString(), 250, 250, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2348, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe Hrecipe = new ModRecipe(mod);
            Hrecipe.AddIngredient(null, "ObsidiumBar", 8);
            Hrecipe.AddTile(77);
            Hrecipe.SetResult(2422);
            Hrecipe.AddRecipe();
        }
    }
}