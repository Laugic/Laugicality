using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class RuneOfTheAncients : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune of the Ancients");
            Tooltip.SetDefault("+15% Overflow damage and velocity\nIncreased movement speed when on Overflow");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 36;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if(modPlayer.IsOnOverflow())
            {
                modPlayer.OverflowDamage += .15f;
                modPlayer.OverflowVelocity += .15f;
                player.moveSpeed += .15f;
                player.jumpSpeedBoost += 3;
                player.maxRunSpeed += 2;
                player.accRunSpeed += 2;
            }
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(169, 24);
            recipe.AddIngredient(607, 16);
            recipe.AddIngredient(null, "AncientShard", 1);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}