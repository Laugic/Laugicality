using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class TitanStone : ModItem
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
            item.rare = 4;
            item.accessory = true;
            item.defense = 8;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.10f;
            player.AddBuff(116, 2);
            if (player.thorns < 1f)
            {
                player.thorns = 0.333333343f;
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
            recipe.AddIngredient(null, "PanzerCrystal", 1);
            recipe.AddIngredient(null, "MachtCrystal", 1);
            recipe.AddTile(null, "MineralEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}