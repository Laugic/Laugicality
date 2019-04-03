using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class MachtCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Attack Crystal");
            Tooltip.SetDefault("+10% Damage and critical strike chance \nSet your enemies ablaze");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 3;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.SoulStoneV)
            {
                if (modPlayer.inf)
                    player.AddBuff(116, 2);
            }
            player.magicDamage += 0.10f;
            player.meleeDamage += 0.10f;
            player.rangedDamage += 0.10f;
            player.thrownDamage += 0.10f;
            player.minionDamage += 0.10f;
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RageGem", 1);
            recipe.AddIngredient(null, "WrathGem", 1);
            recipe.AddIngredient(null, "InfernoGem", 1);
            recipe.AddTile(null, "CrystalineInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}