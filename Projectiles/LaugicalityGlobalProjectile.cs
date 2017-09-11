using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles
{
    public class LaugicalityGlobalProjectile : GlobalProjectile
    {

        /*
        public float mystDmg = 0;
        public float mystDur = 0;
        public virtual bool PreAI(Projectile projectile)
        {
            return true;
            if (projectile.friendly == true) { 
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            mystDmg = modPlayer.mysticDamage;
            mystDur = modPlayer.mysticDuration;
            }
        }

        public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mysticDamage < mystDmg)target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mysticDamage = mystDmg;
            Main.NewText(target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mysticDamage.ToString(), 150, 0, 0);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color

        }*/
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
    }
}