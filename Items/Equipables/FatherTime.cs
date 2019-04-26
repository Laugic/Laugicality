using Laugicality.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class FatherTime : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Father Time");
            Tooltip.SetDefault("+15% Increased Damage while time is stopped\nReduces cooldown between Time Stops\nIncreases Duration of Time Stop\n'Mastery of Time'");
        }

        public override void SetDefaults()
        {
            item.width = 58;
            item.height = 64;
            item.value = 100;
            item.rare = ItemRarityID.LightPurple;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if(Laugicality.zaWarudo > 0)
            {
                player.magicDamage += 0.15f;
                player.meleeDamage += 0.15f;
                player.rangedDamage += 0.15f;
                player.thrownDamage += 0.15f;
                player.minionDamage += 0.15f;
            }
            modPlayer.zaWarudoDuration += (int)(1.75 * 60);
            modPlayer.zCoolDown -= 10 * 60;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TimeWinder", 1);
            recipe.AddIngredient(null, "Clockface", 1);
            recipe.AddIngredient(null, "HandsOfTime", 1);
            recipe.AddIngredient(ItemID.Ectoplasm, 8);
            recipe.AddIngredient(mod, nameof(Gear), 20);
            recipe.AddIngredient(ItemID.Cog, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}