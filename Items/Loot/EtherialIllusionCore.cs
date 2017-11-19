using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Loot
{
    public class EtherialIllusionCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+20% Illusion Damage and +2 Illusion Power while in the Etherial");
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
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.etherial || modPlayer.etherable)
            {
                modPlayer.illusionDamage += .2f;
                modPlayer.illusionPower += 2;
            }
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IllusionCore", 1);
            recipe.AddIngredient(null, "EtherialEssence", 6);
            recipe.AddTile(null, "AncientEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}