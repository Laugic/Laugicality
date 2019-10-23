using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items
{
    public abstract class SteamItem : LaugicalityItem
    {

        public static int steamTier = 1;
        public static bool steam = false;
        public static int steamCost = 1;
        public override void SetDefaults()
        {
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
            item.crit = 4;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                // take reverse for 'damage',  grab translation
                string[] split = tt.text.Split(' ');
                // todo: translation alchemical
                tt.text = split.First() + " steam " + split.Last();
            }
        }

        public override void GetWeaponDamage(Player player, ref int damage)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            damage = (int)(damage * modPlayer.steamDamage);
        }

        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get(player);
        }

        /*
        //Steam item
        //VV
        public override bool CanUseItem(Player player)
        {

            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (steam)
            {
                if (modPlayer.connected >= steamTier && LaugicalityWorld.power >= steamCost)
                    return true;
                else
                    return false;
            }
            return true;
        }

        public override bool UseItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (steam)
            {
                LaugicalityWorld.power -= steamCost;
                if (LaugicalityWorld.power < 0)
                    LaugicalityWorld.power = 0;
            }
            return true;
        }
        //^^
        //Steam Item end*/
    }
}