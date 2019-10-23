using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Useables
{
    public class BysmalKey : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bysmal Key");
            Tooltip.SetDefault("Prevent Bysmal Armor from cycling in new Bonuses until toggled on again.");
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
            Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
            LaugicalityPlayer.Get(player).BysmalAbsorbDisabled = !LaugicalityPlayer.Get(player).BysmalAbsorbDisabled;
            if (LaugicalityPlayer.Get(player).BysmalAbsorbDisabled)
                Main.NewText("Your Bysmal Armor has been locked, and won't absorb any more bonuses.", 0, 100, 150);
            else
                Main.NewText("Your Bysmal Armor has been unlocked, and will absorb bonuses again.", 0, 100, 150);
            for (int i = 0; i < 12; i++)
            {
                Dust.NewDust(player.position + player.velocity, player.width, player.height, ModContent.DustType<Etherial>(), 0f, 0f);
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
            recipe.AddIngredient(null, "BysmalBar", 4);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 2);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}