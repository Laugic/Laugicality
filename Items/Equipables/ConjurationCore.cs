using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class ConjurationCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Conjuration Damage \n+1 Conjuration Power");
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
            modPlayer.conjurationDamage += .1f;
            modPlayer.conjurationPower += 1;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Diamond, 1);
            recipe.AddIngredient(ItemID.Emerald, 1);
            recipe.AddIngredient(null, "DarkShard", 1);
            recipe.AddIngredient(null, "AncientShard", 1);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}