using System;
using Laugicality.NPCs.RockTwins;
using Laugicality.Projectiles.BossSummons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Consumables.Buffs
{
    public class TimeCapsule : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Reduces debuff duration & increases buff duration");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
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
            item.stack = 0;
            return base.OnPickup(player);
        }
    }
}
