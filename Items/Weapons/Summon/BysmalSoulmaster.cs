using Microsoft.Xna.Framework;
using System;
using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Summon
{
    public class BysmalSoulmaster : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bysmal Soulmaster");
            Tooltip.SetDefault("'Unleash them'\nWhen in the Etherial after defeating Etheria, attack twice as fast.");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 250;
            item.summon = true;
            item.mana = 9;
            item.width = 28;
            item.height = 30;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = 10000;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item122;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType("SoulmasterOrb");
            item.shootSpeed = 14f;
        }

        public override void HoldItem(Player player)
        {
            if ((LaugicalityWorld.downedEtheria || LaugicalityPlayer.Get(player).Etherable > 0) && LaugicalityWorld.downedTrueEtheria)
            {
                item.useTime = 30;
                item.useAnimation = 30;
            }
            else
            {
                item.useTime = 60;
                item.useAnimation = 60;
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float theta = 0;
            float mag = 8;
            for(int i = 0; i < 8; i++)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, ModContent.ProjectileType("SoulmasterOrb"), damage, 3f, player.whoAmI);
                theta += (float)Math.PI / 4;
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BysmalBar", 15);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 8);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}