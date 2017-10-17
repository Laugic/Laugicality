using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Items;
using Laugicality.Items.Weapons.Mystic;


namespace Laugicality
{
    public abstract class MysticItem : ModItem
    {
        // make-safe
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
            var tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                // take reverse for 'damage',  grab translation
                string[] split = tt.text.Split(' ');
                // todo: translation alchemical
                tt.text = split.First() + " mystic " + split.Last();
            }
        }

        public override void GetWeaponDamage(Player player, ref int damage)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            damage = (int)(damage * modPlayer.mysticDamage);
        }
    }
}