using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Useables
{
    public class SoulOfTheAncients : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of the Ancients");
            Tooltip.SetDefault("Seal away a part of your Soul.\nUsing this item prevents you from unleashing Mystic Bursts, but increases Mystic Damage by 5%.");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 100;
            item.rare = ItemRarityID.Pink;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldingUp;
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/SoulStore"));
            player.GetModPlayer<LaugicalityPlayer>(mod).MysticBurstDisabled = !player.GetModPlayer<LaugicalityPlayer>(mod).MysticBurstDisabled;
            if (player.GetModPlayer<LaugicalityPlayer>(mod).MysticBurstDisabled)
                Main.NewText("You stored part of your Soul in the Vase.", 150, 100, 0);
            else
                Main.NewText("Your soul has been released.", 150, 100, 0);
            for (int i = 0; i < 12; i++)
            {
                Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Sandy"), 0f, 0f);
            }
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(20, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AncientShard", 2);
            recipe.AddIngredient(null, "Crystilla", 8);
            recipe.AddIngredient(ItemID.SandBlock, 40);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}