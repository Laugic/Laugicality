using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class RuneOfEruption : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune of Eruption");
            Tooltip.SetDefault("+20% Overflow damage and velocity\nIncreased movement and jump speed when on Overflow");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 36;
            item.value = Item.sellPrice(gold: 4);
            item.rare = ItemRarityID.LightRed;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.IsOnOverflow())
            {
                modPlayer.OverflowDamage += .2f;
                modPlayer.OverflowVelocity += .2f;
                player.moveSpeed += .25f;
                player.jumpSpeedBoost += 3;
                player.maxRunSpeed += 3;
                player.accRunSpeed += 3;
            }
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RuneOfTheAncients", 1);
            recipe.AddIngredient(null, "Eruption", 1);
            recipe.AddIngredient(mod, nameof(SoulOfHaught), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}