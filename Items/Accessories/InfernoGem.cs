using Laugicality.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class InfernoGem : LaugicalityItem
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
            item.rare = ItemRarityID.Green;
            item.accessory = true;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item9;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(116, 2);
        }


        public override bool UseItem(Player player)
        {
            LaugicalityPlayer.Get(player).inf = !LaugicalityPlayer.Get(player).inf;
            Main.NewText(LaugicalityPlayer.Get(player).inf.ToString(), 250, 250, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2348, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe hrecipe = new ModRecipe(mod);
            hrecipe.AddIngredient(mod, nameof(ObsidiumBar), 8);
            hrecipe.AddTile(77);
            hrecipe.SetResult(2422);
            hrecipe.AddRecipe();
        }
    }
}