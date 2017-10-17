using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class IllusionCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Illusion Damage \n+1 Illusion Power");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            //item.defense = 1000;
            item.lifeRegen = 1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.illusionDamage += .1f;
            modPlayer.illusionPower += 1;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Diamond, 1);
            recipe.AddIngredient(ItemID.Amethyst, 1);
            recipe.AddIngredient(null, "DarkShard", 2);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}