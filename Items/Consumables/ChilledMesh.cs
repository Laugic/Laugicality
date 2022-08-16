﻿using Laugicality.NPCs.PreTrio;
using Laugicality.Projectiles.BossSummons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;
using Laugicality.Items.Materials;

namespace Laugicality.Items.Consumables
{
	public class ChilledMesh : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Innocent Child");
            Tooltip.SetDefault("Summons Hypothema\n'What are you doing to him?'");
        }

        public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 20;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
			item.shoot = ModContent.ProjectileType<Nothing>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<GeneralBossSpawn>(), ModContent.NPCType<Hypothema>(), knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            return (player.ZoneSnow && NPC.CountNPCS(ModContent.NPCType<Hypothema>()) < 1);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.Snowball, 20);
            recipe.AddIngredient(ModContent.ItemType<Vitasilk>());
            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);

			recipe.AddRecipe();
        }
	}
}