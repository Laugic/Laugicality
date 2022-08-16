using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class AncientHelmet : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increased Max Run Speed and Jump Height");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 22;
            item.value = Item.sellPrice(silver: 50);
            item.rare = ItemRarityID.Blue;
            item.defense = 3;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<AncientArmor>() && legs.type == ModContent.ItemType<AncientGreaves>();
        }


        public override void UpdateEquip(Player player)
        {
            player.maxRunSpeed += 6f;
            player.accRunSpeed += 6f;
            player.jumpSpeedBoost += 4;
        }
        
        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.setBonus = "Increased Max Minions, Mana, and Potentia";
            modPlayer.LuxMax += 40;
            modPlayer.VisMax += 40;
            modPlayer.MundusMax += 40;
            player.statManaMax2 += 40;
            player.maxMinions += 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Crystilla", 6);
            recipe.AddIngredient(ItemID.DesertFossil, 12);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}