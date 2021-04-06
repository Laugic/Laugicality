using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public abstract class BootItem : LaugicalityItem
    {
        int dashDelay = 0;
        int dashCooldown = 0;
        int trail = 0;
        int rocketBootTime = 0;
        int dashDir = 0;
        float rocketAccel = .25f;
        int jumpDashes = 0;
        bool usedJump = false;
        int justJumped = 0;
        int counter = 0;
        int jumpTrail = 0;

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            SetBootVars();
            OtherBonuses(player, hideVisual);
            if (RunBoots)
                Run(player);
            if(RocketBootTimeMax > 0)
                GetRocketBoots(player);
            if (DashSpeed > 0)
                Dashes(player, hideVisual);
            if(JumpSpeed > 0)
            {
                JumpCheck(player, hideVisual);
                JumpTrail(player);
                Reset(player);
            }
            Delays(player);
        }

        public virtual void SetBootVars()
        {

        }

        public virtual void OtherBonuses(Player player, bool hideVisual)
        {

        }

        public virtual void Run(Player player)
        {
            if (Main.tileSolid[Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16) + 2].type] && Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16) + 2].type != 0 && Math.Abs(player.velocity.X) > 4 && Main.rand.Next(2) == 0)
            {
                int newDust = Dust.NewDust(new Vector2(player.Center.X + player.velocity.X, player.position.Y + 4 + player.height - 10f + player.velocity.Y), 8, 8, DustType, 0f, 0f, 0, default(Color), 1.5f);
            }
        }

        private void GetRocketBoots(Player player)
        {
            if (player.controlJump && rocketBootTime < RocketBootTimeMax && !LaugicalityPlayer.Get(player).MobilityCurse4)
            {
                if (rocketAccel < RocketAccelMax)
                    rocketAccel += RocketAccel;
                if (player.velocity.Y > -RocketSpeedMax)
                    player.velocity.Y -= rocketAccel;
                if (player.velocity.Y > 0)
                    player.velocity.Y *= .8f;
                RocketDust(player);
                rocketBootTime++;
                player.fallStart = (int)player.position.Y / 16;
                if (player.rocketDelay2 <= 0 && RocketSoundID != null)
                {
                    Main.PlaySound(RocketSoundID, player.position);
                    player.rocketDelay2 = 15;
                }
            }
            else
                rocketAccel = RocketAccelMax;
        }

        private void RocketDust(Player player)
        {
            int alpha = 0;
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    int newDust = Dust.NewDust(new Vector2(player.position.X - 4f + player.velocity.X, player.position.Y + (float)player.height - 10f + player.velocity.Y), 8, 8, DustType, 0f, 0f, alpha, default(Color), 1.5f);
                    Main.dust[newDust].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                    Main.dust[newDust].velocity.X = Main.dust[newDust].velocity.X * 1f - 2f - player.velocity.X * 0.3f;
                    Main.dust[newDust].velocity.Y = Main.dust[newDust].velocity.Y * 1f + 2f * player.gravDir - player.velocity.Y * 0.3f;
                    Main.dust[newDust].noGravity = false;
                }
                else
                {
                    int newDust = Dust.NewDust(new Vector2(player.position.X + (float)player.width - 4f + player.velocity.X, player.position.Y + (float)player.height - 10f + player.velocity.Y), 8, 8, DustType, 0f, 0f, alpha, default(Color), 1.5f);
                    Main.dust[newDust].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                    Main.dust[newDust].velocity.X = Main.dust[newDust].velocity.X * 1f + 2f - player.velocity.X * 0.3f;
                    Main.dust[newDust].velocity.Y = Main.dust[newDust].velocity.Y * 1f + 2f * player.gravDir - player.velocity.Y * 0.3f;
                    Main.dust[newDust].noGravity = false;
                }
            }
        }

        private void Dashes(Player player, bool hideVisual)
        {
            if (!player.mount.Active && player.grappling[0] == -1 && dashCooldown <= 0)
            {
                if (player.controlRight && player.releaseRight)
                {
                    if (dashDelay > 0 && dashDir == 1)
                    {
                        dashCooldown = DashCooldownMax;
                        trail = TrailLength;
                        player.velocity.X = DashSpeed;
                        player.GetModPlayer<LaugicalityPlayer>().DustBurst(DustType, 30);
                        dashDir = 0;
                        if(!hideVisual)
                            DashBurst(player);

                        if (WarpDist > 0)
                            player.Teleport(new Vector2(player.position.X + WarpDist, player.position.Y), 1);
                        if(ImmuneTime > 0)
                        {
                            player.immune = true;
                            player.immuneTime = ImmuneTime;
                        }
                    }
                    else
                    {
                        dashDelay = 15;
                        dashDir = 1;
                    }
                }
                if (player.controlLeft && player.releaseLeft)
                {
                    if (dashDelay > 0 && dashDir == 2)
                    {
                        dashCooldown = DashCooldownMax;
                        trail = TrailLength;
                        player.velocity.X = -DashSpeed;
                        player.GetModPlayer<LaugicalityPlayer>().DustBurst(DustType, 30);
                        dashDir = 0;
                        if (!hideVisual)
                            DashBurst(player);

                        if (WarpDist > 0)
                            player.Teleport(new Vector2(player.position.X - WarpDist, player.position.Y), 1);
                        if (ImmuneTime > 0)
                        {
                            player.immune = true;
                            player.immuneTime = ImmuneTime;
                        }
                    }
                    else
                    {
                        dashDelay = 15;
                        dashDir = 2;
                    }
                }
                if (player.controlDown && player.releaseDown)
                {
                    if (dashDelay > 0 && dashDir == 3)
                    {
                        dashCooldown = VDashCooldownMax;
                        trail = TrailLength;
                        player.velocity.Y = 2 * DashSpeed;
                        player.GetModPlayer<LaugicalityPlayer>().DustBurst(DustType, 30);
                        dashDir = 0;
                        if (!hideVisual)
                            DashBurst(player);
                        player.fallStart = (int)player.position.Y / 16;


                        if (WarpDist > 0)
                            player.Teleport(new Vector2(player.position.X, player.position.Y + WarpDist), 1);
                        if (ImmuneTime > 0)
                        {
                            player.immune = true;
                            player.immuneTime = ImmuneTime;
                        }
                    }
                    else
                    {
                        dashDelay = 15;
                        dashDir = 3;
                    }
                }
                if (player.controlUp && player.releaseUp)
                {
                    if (dashDelay > 0 && (jumpDashes < MaxVDashes || MaxVDashes == -1) && dashDir == 4)
                    {
                        dashCooldown = VDashCooldownMax;
                        trail = TrailLength;
                        player.velocity.Y = -DashSpeed;
                        player.GetModPlayer<LaugicalityPlayer>().DustBurst(DustType, 30);
                        dashDir = 0;
                        if (!hideVisual)
                            DashBurst(player);
                        jumpDashes++;
                        player.fallStart = (int)player.position.Y / 16;

                        if (WarpDist > 0)
                            player.Teleport(new Vector2(player.position.X, player.position.Y - WarpDist), 1);
                        if (ImmuneTime > 0)
                        {
                            player.immune = true;
                            player.immuneTime = ImmuneTime;
                        }
                    }
                    else
                    {
                        dashDelay = 15;
                        dashDir = 4;
                    }
                }
            }
            if (Main.tileSolid[Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16) + 2].type] && Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16) + 2].type != 0)
                jumpDashes = 0;
            if (player.grappling[0] != -1)
                jumpDashes = 0;
        }

        private void DashBurst(Player player)
        {
            int numProj = Main.rand.Next(3) + 3;
            for (int i = 0; i < numProj; i++)
            {
                float mag = Main.rand.NextFloat() * 4 + 2;
                float theta = Main.rand.NextFloat() * 2 * (float)Math.PI;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, mag * (float)Math.Cos(theta), mag * (float)Math.Sin(theta), ProjectileType, (int)(ProjectileDamage * player.GetModPlayer<LaugicalityPlayer>().GetGlobalDamage()), 0, player.whoAmI);
            }
        }

        private void JumpTrail(Player player)
        {
            if (jumpTrail > 0)
            {
                jumpTrail++;
                Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, DustType);
                player.velocity.Y = -JumpSpeed;
            }
            if (jumpTrail > JumpDur || player.releaseJump)
                jumpTrail = 0;
        }

        private void JumpCheck(Player player, bool hideVisual)
        {
            if (justJumped == 1 && player.releaseJump)
                justJumped = 2;
            if (!player.mount.Active && player.grappling[0] == -1)
            {
                if (player.controlJump && !usedJump && player.velocity.Y != 0)
                {
                    if (justJumped == 0)
                    {
                        justJumped = 1;
                        return;
                    }
                    Jump(player, hideVisual);
                }
            }
        }

        private void Jump(Player player, bool hideVisual)
        {
            player.velocity.Y = -JumpSpeed;
            usedJump = true;
            jumpTrail++;
            player.fallStart = (int)player.position.Y / 16;
            for (int i = 0; i < 40; i++)
                Dust.NewDust(new Vector2(player.position.X, player.Center.Y + 24), player.width, 4, DustType);
            if (hideVisual || ProjectileType == 0)
                return;
            for (int i = 0; i < 4; i++)
            {
                double theta = Math.PI * Main.rand.NextDouble();
                var mag = 6 + Main.rand.NextFloat() * 4;
                Projectile.NewProjectile(new Vector2(player.position.X, player.Center.Y + 24), new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag), ProjectileType, (int)(ProjectileDamage * player.allDamage), 3, player.whoAmI);
            }
        }

        private void Reset(Player player)
        {
            if (player.velocity.Y != 0)
                counter = 0;
            counter++;
            if (counter > 2 || player.grappling[0] != -1)
            {
                justJumped = 0;
                usedJump = false;
            }
        }

        private void Delays(Player player)
        {
            if (dashDelay > 0)
                dashDelay--;
            if (dashCooldown > 0)
                dashCooldown--;
            if (trail > 0)
            {
                trail--;
                player.GetModPlayer<LaugicalityPlayer>().DustTrail(DustType, 1);
            }
            if (Main.tileSolid[Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16) + 2].type] && Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16) + 2].type != 0 && Math.Abs(player.velocity.Y) < .25f)
                rocketBootTime = 0;
            if (player.grappling[0] != -1)
                rocketBootTime = 0;
        }
        /*
        public override bool CanEquipAccessory(Player player, int slot)
        {
            if(LaugicalityVars.DashBoots.Contains(item.type))
            {
                for (int j = 0; j < player.armor.Length; j++)
                {
                    if (j != slot && LaugicalityVars.DashBoots.Contains(player.armor[j].type))
                        return false;
                }
            }
            if (LaugicalityVars.RocketBoots.Contains(item.type))
            {
                for (int j = 0; j < player.armor.Length; j++)
                {
                    if (j != slot && LaugicalityVars.RocketBoots.Contains(player.armor[j].type))
                        return false;
                }
            }
            return true;
        }*/

        public float DashSpeed { get; set; } = 0;
        public int DashCooldownMax { get; set; } = 60;
        public int VDashCooldownMax { get; set; } = 60;
        public int MaxVDashes { get; set; } = 0;

        public int RocketBootTimeMax { get; set; } = 0;
        public float RocketAccel { get; set; } = .05f;
        public float RocketAccelMax { get; set; } = .5f;
        public float RocketSpeedMax { get; set; } = 10;

        public int JumpSpeed { get; set; } = 0;
        public int JumpDur { get; set; } = 0;
        public int WarpDist { get; set; } = 0;
        public int ImmuneTime { get; set; } = 0;


        public int DustType { get; set; } = 0;
        public int TrailLength { get; set; } = 0;
        public int ProjectileType { get; set; } = 0;
        public int ProjectileDamage { get; set; } = 0;
        public Terraria.Audio.LegacySoundStyle RocketSoundID { get; set; } = null;
        public bool RunBoots { get; set; } = false;
    }
}
