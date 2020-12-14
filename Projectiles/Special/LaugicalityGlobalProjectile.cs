using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.NPCs;
using Microsoft.Xna.Framework.Graphics;
using Laugicality.Buffs;
using Laugicality.Projectiles.Plague;

namespace Laugicality.Projectiles.Special
{
    public class LaugicalityGlobalProjectile : GlobalProjectile
    {
        public bool etherial = false;
        public bool bitherial = false;
        public bool friend = false;
        private int _dmg = 0;
        public int eDmg = 0;
        public float oldVx = 0f;
        public float oldVy = 0f;
        public int ai = 0;
        public float xTemp = 0;
        public float yTemp = 0;
        public bool zImmune = false;
        public bool frozen = false;
        bool _justSpawned = false;

        public override void SetDefaults(Projectile projectile)
        {
            _justSpawned = false;
            frozen = false;
            zImmune = false;
            ai = projectile.aiStyle;
            oldVx = 0f;
            oldVy = 0f;
            eDmg = 0;
            _dmg = 0;
            etherial = false;
            bitherial = false;
            if (LaugicalityVars.eProjectiles.Contains(projectile.type))
            {
                bitherial = true;
            }
            if (LaugicalityVars.zProjectiles.Contains(projectile.type))
            {
                zImmune = true;
            }
        }

        public override bool PreDraw(Projectile projectile, SpriteBatch spriteBatch, Color lightColor)
        {
            if (eDmg == 0)
                eDmg = projectile.damage;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(Main.player[projectile.owner]);

            if (bitherial)
            {
                if (modPlayer.etherial)
                    projectile.damage = eDmg  + 25;
                else
                    projectile.damage = eDmg;
                return true;
            }
            else
            {
                if (_dmg == 0)
                {
                    _dmg = projectile.damage;
                    friend = !projectile.hostile;
                }
                if (!friend)
                {
                    if (etherial)
                    {
                        if (LaugicalityWorld.downedEtheria)
                        {
                            projectile.damage = _dmg;
                            return true;
                        }
                        else
                        {
                            projectile.damage = 0;
                            return false;
                        }
                    }
                    else
                    {

                        if (LaugicalityWorld.downedEtheria)
                        {
                            projectile.damage = 0;
                            return false;
                        }
                        else
                        {
                            projectile.damage = _dmg;
                            return true;
                        }
                    }
                }
                else return true;
            }

        }

        public override bool PreAI(Projectile projectile)
        {
            if (eDmg == 0)
                eDmg = projectile.damage;
            
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);

            if (bitherial)
            {
                if (modPlayer.etherial)
                    projectile.damage = eDmg + 25;
                else
                    projectile.damage = eDmg;
            }
            else
            {
                if (_dmg == 0)
                {
                    _dmg = projectile.damage;
                    friend = !projectile.hostile;
                }
                if (!friend)
                {
                    if (etherial)
                    {
                        if (LaugicalityWorld.downedEtheria)
                        {
                            projectile.damage = _dmg;
                        }
                        else
                        {
                            projectile.damage = 0;
                            projectile.Kill();
                        }
                    }
                    else
                    {

                        if (LaugicalityWorld.downedEtheria)
                        {
                            projectile.damage = 0;
                            projectile.Kill();
                        }
                        else
                        {
                            projectile.damage = _dmg;
                        }
                    }
                }
            }
            if (!_justSpawned)
            {
                EtherialSpawn(projectile);
                _justSpawned = true;
            }

            if (projectile.type == ProjectileID.StardustGuardian || projectile.type == ProjectileID.StardustGuardianExplosion)
                projectile.damage = (int)(2000 * Main.player[projectile.owner].minionDamage);

            int rand = Main.rand.Next(60);
            /*if (projectile.friendly && projectile.damage > 0)
            {
                if (modPlayer.Obsidium && rand == 0 && modPlayer.SoulStoneVisuals)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                if (modPlayer.Frost && rand == 0 && modPlayer.SoulStoneVisuals)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                if (modPlayer.SkeletonPrime && rand == 0 && modPlayer.SoulStoneVisuals)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 44, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                if (modPlayer.Doucheron && rand == 0 && modPlayer.SoulStoneVisuals)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 199, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                if (modPlayer.QueenBee && rand == 0 && modPlayer.SoulStoneVisuals)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 46, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                if (modPlayer.Steamified && rand == 0 && modPlayer.SoulStoneVisuals)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Steam>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                if (modPlayer.Slimey && rand == 0 && modPlayer.SoulStoneVisuals)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 116, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                if (modPlayer.EtherialFrost && rand == 0 && modPlayer.SoulStoneVisuals)
                {
                    Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<EtherialDust>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
            }*/

            bool zProjImmune = false;

            Player projOwner = Main.player[projectile.owner];
            zProjImmune = LaugicalityPlayer.Get(projOwner).zProjImmune;

            if (projectile.friendly == false)
                zProjImmune = false;
            if (LaugicalityVars.ezProjectiles.Contains(projectile.type) && LaugicalityWorld.downedEtheria)
                zImmune = true;
            if (Laugicality.zaWarudo > 0 && zProjImmune == false && zImmune == false)
            {
                projectile.timeLeft++;
                if (!frozen)
                {
                    oldVx = projectile.velocity.X;
                    oldVy = projectile.velocity.Y;
                    frozen = true;
                    xTemp = 0;
                    yTemp = 0;
                }
                if (frozen)
                {
                    projectile.velocity.X *= 0.01f;
                    projectile.velocity.Y *= 0.01f;
                    if (xTemp == 0 || yTemp == 0)
                    {
                        xTemp = projectile.position.X;
                        yTemp = projectile.position.Y;
                    }
                    else
                    {
                        projectile.position.X = xTemp;
                        projectile.position.Y = yTemp;
                    }
                }
                return false;
            }
            else
            {
                if (frozen)
                {
                    projectile.velocity.X = oldVx;
                    projectile.velocity.Y = oldVy;
                    frozen = false;
                }
                if (!frozen)
                {
                    oldVx = 0f;
                    oldVy = 0f;
                }
                return true;
            }
        }
        
        private void EtherialSpawn(Projectile projectile)
        {
            if(LaugicalityWorld.downedEtheria)
            {
                if (projectile.type == ProjectileID.Cthulunado)
                    projectile.timeLeft *= 2;
            }
        }


        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            InflictDebuffs(projectile, target, damage, knockback, crit);
        }

        private void InflictDebuffs(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(Main.player[projectile.owner]);
            int rand = Main.rand.Next(5);
            if (Main.myPlayer == projectile.owner)
            {
                if (modPlayer.Obsidium)
                {
                    target.AddBuff(24, (int)(3 * 60 + 60 * rand), false);
                }
                if (modPlayer.Frost)
                {
                    target.AddBuff(BuffID.Frostburn, (int)(3 * 60 + 60 * rand), false);
                }
                if (modPlayer.Poison)
                {
                    target.AddBuff(BuffID.Poisoned, (int)(3 * 60 + 60 * rand), false);
                }
                if (modPlayer.SkeletonPrime)
                {
                    target.AddBuff(39, (int)(4 * 60 + 60 * rand), false);
                }
                if (modPlayer.Doucheron)
                {
                    target.AddBuff(70, (int)(4 * 60 + 60 * rand), false);
                }
                if (modPlayer.QueenBee)
                {
                    target.AddBuff(20, (int)(4 * 60 + 60 * rand), false);
                }
                if (modPlayer.CursedFlame)
                {
                    target.AddBuff(BuffID.CursedInferno, (int)(4 * 60 + 60 * rand), false);
                }
                if (modPlayer.Steamified)
                {
                    target.AddBuff(ModContent.BuffType<Steamy>(), (int)(3 * 60 + 60 * rand), false);
                }
                if (modPlayer.Lovestruck)
                {
                    target.AddBuff(ModContent.BuffType<Lovestruck>(), (int)(4 * 60 + 60 * rand), false);
                }
                if (modPlayer.Slimey)
                {
                    target.AddBuff(ModContent.BuffType<Slimed>(), (int)(3 * 60 + 60 * rand), false);
                }
                if (modPlayer.JunglePlague && projectile.type != ModContent.ProjectileType<JunglePlagueSpore>())
                {
                    target.AddBuff(ModContent.BuffType<JunglePlagueBuff>(), (int)(3 * 60 + 60 * rand), false);
                    target.AddBuff(BuffID.Poisoned, (int)(3 * 60 + 60 * rand), false);
                }
                if (modPlayer.EtherialFrost && (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0))
                {
                    target.AddBuff(ModContent.BuffType<Frostbite>(), (int)(12 * 60 + 60 * rand), false);
                }
                if (modPlayer.EtherialPipes && (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0))
                {
                    target.AddBuff(ModContent.BuffType<Steamified>(), (int)((12 * 60 + 60 * rand)), false);
                }
                if (modPlayer.EtherCog && (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0))
                {
                    target.GetGlobalNPC<LaugicalGlobalNPCs>().attacker = projectile.owner;
                }
                /*
                if (modPlayer.critExplosion && projectile.type != ModContent.ProjectileType<ObsidiumArrowHead>())
                {
                    if (crit)
                    {
                        float mag = 6f;
                        float theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                        if (Main.myPlayer == projectile.owner)
                            Projectile.NewProjectile(target.Center.X, target.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, ModContent.ProjectileType<ObsidiumArrowHead>(), damage, 3f, Main.myPlayer);
                        theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                        if (Main.myPlayer == projectile.owner)
                            Projectile.NewProjectile(target.Center.X, target.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, ModContent.ProjectileType<ObsidiumArrowHead>(), damage, 3f, Main.myPlayer);
                        theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                        if (Main.myPlayer == projectile.owner)
                            Projectile.NewProjectile(target.Center.X, target.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, ModContent.ProjectileType<ObsidiumArrowHead>(), damage, 3f, Main.myPlayer);
                    }
                }*/

                if (target.GetGlobalNPC<LaugicalGlobalNPCs>().DebuffDamageMult < modPlayer.DebuffMult)
                    target.GetGlobalNPC<LaugicalGlobalNPCs>().DebuffDamageMult = modPlayer.DebuffMult;
            }
        }

        public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
        {
            if(projectile.type == ProjectileID.PhantasmalDeathray && LaugicalityWorld.downedEtheria)
            {
                target.AddBuff(ModContent.BuffType<TrueCurse>(), 5 * 60);
            }
            base.OnHitPlayer(projectile, target, damage, crit);
        }

        public void Explode(Vector2 center, float range, int damage)
        {
            foreach (NPC npc in Main.npc)
            {
                float dist = Vector2.Distance(center, npc.Center);
                if (dist <= range && npc.dontTakeDamage == false)
                {
                    npc.life -= damage;
                }
            }
        }
    }
}