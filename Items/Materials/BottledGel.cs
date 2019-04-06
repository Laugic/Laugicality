using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
    public class BottledGel : ModItem
    {
        int time = 0;
        int sec = 15;
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The gels will mesh together over time");
        }
        public override void SetDefaults()
        {
            time = 0;
            item.width = 28;
            item.height = 28;
            item.maxStack = 1;
            item.rare = 3;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            //item.UseSound = SoundID.Item9;
            item.consumable = true;
        }
        
        public override void UpdateInventory(Player player)
        {
            if(time < 60 * sec)
                time++;
            else
            {
                player.QuickSpawnItem(mod.ItemType("BottledPinkGel"), 1);
                item.stack -= 1;
            }
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(126); //Water Bottle
            recipe.AddIngredient(ItemID.PinkGel);
            recipe.AddIngredient(ItemID.Gel, 5);
            //recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}