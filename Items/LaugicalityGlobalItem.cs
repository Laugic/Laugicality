using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace Laugicality.Items
{
	public class LaugicalityGlobalItem : GlobalItem
	{
		public bool mystic = false;
        public int meleeDmg = -1;
        public int yeet = 0;
        public LaugicalityGlobalItem()
		{
            yeet = 0;
            mystic = false;
            meleeDmg = -1;
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
            myClone.yeet = yeet;
            return myClone;
		}

        /*public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            if (item.accessory && item.stack == 1 && rand.NextBool(40))
            {
                string pref = "Yeeting";
                switch(rand.Next(4))
                {
                    case 0:
                        pref = "Swift";
                        break;
                    case 1:
                        pref = "Speedy";
                        break;
                    case 2:
                        pref = "Zippy";
                        break;
                    default:
                        pref = "Yeeting";
                        break;
                }
                return mod.PrefixType(pref);
            }
            return -1;
        }*/

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            player.moveSpeed += .05f * item.GetGlobalItem<LaugicalityGlobalItem>().yeet;
            player.maxRunSpeed += .05f * item.GetGlobalItem<LaugicalityGlobalItem>().yeet;
        }

        public override void HoldItem(Item item, Player player)
        {
            if(meleeDmg == -1)
            {
                if (item.noMelee)
                    meleeDmg = 0;
                else
                    meleeDmg = 1;
            }
            
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (NPC.CountNPCS(mod.NPCType("ZaWarudo")) >= 1 && modPlayer.zImmune)
            {
                if (!modPlayer.zProjImmune && meleeDmg == 1)
                {
                    item.noMelee = true;
                }
                else
                {
                    if (meleeDmg == 0)
                        item.noMelee = true;

                    if (meleeDmg == 1)
                        item.noMelee = false;
                }
            }
            else
            {
                if (meleeDmg == 0)
                    item.noMelee = true;

                if (meleeDmg == 1)
                    item.noMelee = false;
            }
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
        /*public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            
            if (!item.social && item.prefix > 0 && item.GetGlobalItem<LaugicalityGlobalItem>().yeet > 0)
            {
                TooltipLine line = new TooltipLine(mod, "Yeeting", "+" + item.GetGlobalItem<LaugicalityGlobalItem>().yeet * 5 + "% Max Run speed and Movement speed");
                line.isModifier = true;
                tooltips.Add(line);
            }
            else
            {
                foreach (TooltipLine line in tooltips)
                {
                    if (line.Name == "Yeeting")
                        tooltips.Remove(line);
                }
            }
        }*/

        public override void NetSend(Item item, BinaryWriter writer)
        {
            writer.Write(yeet);
        }

        public override void NetReceive(Item item, BinaryReader reader)
        {
            yeet = reader.ReadByte();
        }
    }
}
