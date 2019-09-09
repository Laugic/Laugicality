using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class CursedRelic : LaugicalityItem
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
            item.rare = ItemRarityID.Yellow;
            item.accessory = true;
            item.defense = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.10f;
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.SoulStoneVisuals && modPlayer.inf)
                player.AddBuff(116, 2);
            player.allDamage += 0.10f;
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;
            player.manaRegenBonus += 25;
            player.magicDamage += 0.20f;
            player.kbBuff = true;
            if (modPlayer.battle)
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