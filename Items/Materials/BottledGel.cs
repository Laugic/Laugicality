using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
    public class BottledGel : LaugicalityItem
    {
        int _time = 0;
        int _sec = 15;
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The gels will mesh together over time");
        }
        public override void SetDefaults()
        {
            _time = 0;
            item.width = 28;
            item.height = 28;
            item.maxStack = 1;
            item.rare = ItemRarityID.Orange;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            //item.UseSound = SoundID.Item9;
            item.consumable = true;
        }
        
        public override void UpdateInventory(Player player)
        {
            if(_time < 60 * _sec)
                _time++;
            else
            {
                player.QuickSpawnItem(ModContent.ItemType<BottledPinkGel>(), 1);
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