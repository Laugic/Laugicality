using System.Collections.Generic;
using Laugicality.Focuses;
using Laugicality.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.SoulStones
{
    public class SoulStone : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Tooltip.SetDefault("Absorbs the souls of powerful fallen creatures\nAn otherwordly entity seems to have sealed some of its power...");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            item.width = 30;
            item.height = 28;
            item.value = Item.buyPrice(silver: 20);
            item.rare = ItemRarityID.Expert;

            item.accessory = true;
        }

        public override bool CanEquipAccessory(Player player, int slot) => base.CanEquipAccessory(player, slot) && player.GetModPlayer<LaugicalityPlayer>().Focus != null;

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
            LaugicalityPlayer laugicalityPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>();

            if (laugicalityPlayer.Focus == null)
            {
                tooltips.Add(new TooltipLine(mod, "SoulStoneNoPlayerFocus", "You must have a selected focus to use the Soul Stone!")
                {
                    overrideColor = Color.Red
                });
                return;
            }

            tooltips.Add(new TooltipLine(Laugicality.instance, "SoulStoneDisplayFocusName", "Your focus is " + laugicalityPlayer.Focus.DisplayName + '.')
            {
                overrideColor = laugicalityPlayer.Focus.AssociatedColor
            });

            foreach (FocusEffect effect in laugicalityPlayer.Focus)
                if (effect.Condition(laugicalityPlayer))
                    tooltips.Add(effect.Tooltip);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);
            LaugicalityPlayer laugicalityPlayer = player.GetModPlayer<LaugicalityPlayer>();

            foreach (FocusEffect effect in laugicalityPlayer.Focus)
                if (effect.Condition(laugicalityPlayer))
                    effect.Effect(laugicalityPlayer, hideVisual);
        }
    }
}