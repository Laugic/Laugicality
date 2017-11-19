using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class CursedRelic : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Cursed? \nMastery of violence");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 48;
            item.value = 10000;
            item.rare = 8;
            item.accessory = true;
            item.defense = 8;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.10f;
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.SoulStoneV)
                player.AddBuff(116, 2);
            player.magicDamage += 0.10f;
            player.meleeDamage += 0.10f;
            player.rangedDamage += 0.10f;
            player.thrownDamage += 0.10f;
            player.minionDamage += 0.10f;
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;
            player.manaRegenBonus += 25;
            player.magicDamage += 0.20f;
            player.kbBuff = true;
            player.enemySpawns = true;
            if (player.thorns < 1f)
            {
                player.thorns = 0.333333343f;
            }
            player.ammoCost80 = true;
            player.rangedDamage += 0.10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TitanStone", 1);
            recipe.AddIngredient(null, "AggressionStone", 1);
            recipe.AddTile(null, "AncientEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}