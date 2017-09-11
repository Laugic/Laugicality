using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Laugicality.Items
{
	public class LaugicalityGlobalItem : GlobalItem
	{
		public bool mystic = false;

		public LaugicalityGlobalItem()
		{
            mystic = false;
        }

		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
        
		public override GlobalItem Clone(Item item, Item itemClone)
		{
			LaugicalityGlobalItem myClone = (LaugicalityGlobalItem)base.Clone(item, itemClone);
			return myClone;
		}
        
        /*
        public override bool AltFunctionUse(Item item, Player player)
        {
            if (mystic)
                return true;
            else return false;
        }
        
        public override bool CanUseItem(Item item, Player player)
        {
            if (player.altFunctionUse == 2 && mystic)
            {
                LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
                modPlayer.mysticMode += 1;
                if (modPlayer.mysticMode > 3) modPlayer.mysticMode = 1;
            }
            return true;
        }


        public virtual void HoldItem(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.mysticMode == 1)
            {
                player.AddBuff(mod.BuffType("Destruction"), 1, true);
            }
            if (modPlayer.mysticMode == 2)
            {
                player.AddBuff(mod.BuffType("Illusion"), 1, true);
            }
            if (modPlayer.mysticMode == 3)
            {
                player.AddBuff(mod.BuffType("Conjuration"), 1, true);
            }
        }

        public override bool CanRightClick(Item item)
        {
            if (mystic)
                return true;
            else return false;
        }


        public virtual void RightClick(Item item, Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.mysticMode += 1;
            if (modPlayer.mysticMode > 3) modPlayer.mysticMode = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if (mystic)
            {
                TooltipLine line = new TooltipLine(mod, "Right click to change Mysticism", "Right click to change Mysticism");
                line.overrideColor = Color.LimeGreen;
				tooltips.Add(line);

				/*foreach (TooltipLine line2 in tooltips)
				{
					if (line2.mod == "Terraria" && line2.Name == "ItemName")
					{
						line2.text = originalOwner + "'s " + line2.text;
					}
				}
			}
		}*/
        
	}
}
