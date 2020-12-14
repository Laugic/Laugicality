using System;
using Laugicality.NPCs.RockTwins;
using Laugicality.Projectiles.BossSummons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Buffs;
using Laugicality.Projectiles.Mystic.Conjuration;

namespace Laugicality.Items.Consumables.Buffs
{
    public class Soul : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Restores Potentia and gives the Reaper buff.");
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
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.AddBuff(ModContent.BuffType<ReaperBuff>(), (int)(10 * 60 * modPlayer.MysticDuration));
            item.stack = 0;
            modPlayer.AddLux(50);
            modPlayer.AddVis(50);
            modPlayer.AddMundus(50);

            BurstConjuration(player);

            return base.OnPickup(player);
        }

        private void BurstConjuration(Player player)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<DeathConjuration>()] > 0)
            {
                for (int i = 0; i < 1000; i++)
                {
                    if (Main.projectile[i].type == ModContent.ProjectileType<DeathConjuration>())
                    {
                        DeathConjuration dc = (DeathConjuration)(Main.projectile[i].modProjectile);
                        dc.Burst();
                    }
                }
            }
        }
    }
}
