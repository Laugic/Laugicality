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

        public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            if (item.accessory && item.stack == 1 && rand.NextBool(80))
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
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            int yet = item.GetGlobalItem<LaugicalityGlobalItem>().yeet;
            player.moveSpeed += .1f * yet;
            player.maxRunSpeed += player.maxRunSpeed * (.015f * yet);
        }

	    public override bool NewPreReforge(Item item)
	    {
	        yeet = 0;
            return true;
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

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            
            if (!item.social && item.prefix > 0 && item.GetGlobalItem<LaugicalityGlobalItem>().yeet > 0)
            {
                TooltipLine line = new TooltipLine(mod, "Yeeting", "+" + item.GetGlobalItem<LaugicalityGlobalItem>().yeet * 1.5 + "% Max Run speed and Movement speed");
                line.isModifier = true;
                tooltips.Add(line);
            }
        }

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
