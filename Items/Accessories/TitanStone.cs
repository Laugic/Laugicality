using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class TitanStone : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Damage reduction \n+10% Damage and critical strike chance \n Attackers take damage \nSet your enemies ablaze");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 1000;
            item.rare = ItemRarityID.LightRed;
            item.accessory = true;
            item.defense = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.10f;
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.SoulStoneVisuals)
            {
                if (modPlayer.inf)
                    player.AddBuff(116, 2);
            }
            if (player.thorns < 1f)
            {
                player.thorns = 0.333333343f;
            }
            player.allDamage += 0.10f;
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PanzerCrystal", 1);
            recipe.AddIngredient(null, "MachtCrystal", 1);
            recipe.AddTile(null, "MineralEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}