using System;
using Laugicality.NPCs.RockTwins;
using Laugicality.Projectiles.BossSummons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Consumables.Buffs
{
    public class DryadSpore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Gives Dryad's Blessing'");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 1;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return false;
        }

        public override bool CanPickup(Player player)
        {
            return true;
        }

        public override bool OnPickup(Player player)
        {
            player.AddBuff(BuffID.DryadsWard, 4 * 60);
            item.stack = 0;
            return base.OnPickup(player);
        }
    }
}
