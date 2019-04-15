using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Laugicality.Items
{
	public class LaugicalityGlobalItem : GlobalItem
	{
        public LaugicalityGlobalItem()
		{
            Yeet = 0;
            Mystic = false;
            MeleeDmg = -1;
        }

		public override bool InstancePerEntity => true;

        public override GlobalItem Clone(Item item, Item itemClone)
		{
			LaugicalityGlobalItem myClone = (LaugicalityGlobalItem)base.Clone(item, itemClone);

            myClone.Yeet = Yeet;
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
            int yet = item.GetGlobalItem<LaugicalityGlobalItem>().Yeet;

            player.moveSpeed += .1f * yet;
            player.maxRunSpeed += player.maxRunSpeed * (.015f * yet);
        }
        
        public override bool NewPreReforge(Item item)
	    {
	        Yeet = 0;
            return true;
	    }

	    public override void HoldItem(Item item, Player player)
        {
            if(MeleeDmg == -1)
            {
                if (item.noMelee)
                    MeleeDmg = 0;
                else
                    MeleeDmg = 1;
            }
            
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (NPC.CountNPCS(mod.NPCType("ZaWarudo")) >= 1 && modPlayer.zImmune)
            {
                if (!modPlayer.zProjImmune && MeleeDmg == 1)
                {
                    item.noMelee = true;
                }
                else
                {
                    if (MeleeDmg == 0)
                        item.noMelee = true;

                    if (MeleeDmg == 1)
                        item.noMelee = false;
                }
            }
            else
            {
                if (MeleeDmg == 0)
                    item.noMelee = true;

                if (MeleeDmg == 1)
                    item.noMelee = false;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            
            if (!item.social && item.prefix > 0 && item.GetGlobalItem<LaugicalityGlobalItem>().Yeet > 0)
            {
                TooltipLine line = new TooltipLine(mod, "Yeeting", "+" + item.GetGlobalItem<LaugicalityGlobalItem>().Yeet * 1.5 + "% Max Run speed and Movement speed");
                line.isModifier = true;
                tooltips.Add(line);
            }
        }

        public override void NetSend(Item item, BinaryWriter writer)
        {
            writer.Write((byte)Yeet);
        }

        public override void NetReceive(Item item, BinaryReader reader)
        {
            Yeet = (int)(reader.ReadByte());
        }

        public bool Mystic { get; }

        public int MeleeDmg { get; set; } = -1;

        public int Yeet { get; set; }
    }
}
