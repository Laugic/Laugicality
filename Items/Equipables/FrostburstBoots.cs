using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class FrostburstBoots : BootItem
    {
        public override void SetStaticDefaults()
        {
            LaugicalityVars.RocketBoots.Add(item.type);
            Tooltip.SetDefault("Allows flight, super fast running, and extra mobility on ice\nGrants the ability to double jump\nIncreases jump height and negates fall damage\n15% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = Item.sellPrice(gold: 8);
            item.rare = ItemRarityID.Lime;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += .15f;
            player.accRunSpeed += 4.5f;
            player.rocketBoots = 3;
            player.iceSkate = true;
            player.doubleJumpBlizzard = true;
            player.noFallDmg = true;
            player.jumpSpeedBoost += 3;
        }


        public override bool CanEquipAccessory(Player player, int slot)
        {
            for (int j = 0; j < player.armor.Length; j++)
            {
                if (j != slot && LaugicalityVars.RocketBoots.Contains(player.armor[j].type))
                    return false;
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostsparkBoots);
            recipe.AddRecipeGroup(Laugicality.COLORED_BALLOON_GROUP);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}