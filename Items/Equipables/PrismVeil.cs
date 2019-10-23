using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class PrismVeil : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+20% Mystic Burst Damage\nDecreased Mystic Burst Cooldown\nIncreased Movement Speed while Mystic Burst is on Cooldown\nBecome immune for a time after Mystic Bursts");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 100;
            item.rare = ItemRarityID.Cyan;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticBurstDamage += .2f;
            modPlayer.MysticSwitchCoolRate += 1;
            if(modPlayer.MysticSwitchCool > 0)
            {
                player.moveSpeed += 1f;
                player.maxRunSpeed += 2f;
            }
            modPlayer.PrismVeil = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalShard, 12);
            recipe.AddIngredient(ItemID.SoulofNight, 6);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}