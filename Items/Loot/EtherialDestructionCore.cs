using Terraria;
using Terraria.ID;


namespace Laugicality.Items.Loot
{
    public class EtherialDestructionCore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Destruction");
            Tooltip.SetDefault("Your global damage modifier is applied to your defense while in the Etherial");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0)
            {
                modPlayer.EtherialDestroyer = true;
            }
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DestructionCore", 1);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 6);
            recipe.AddTile(null, "AncientEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}