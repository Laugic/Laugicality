﻿using Laugicality.Items.Materials;
using Laugicality.NPCs.PreTrio;
using Laugicality.Projectiles.BossSummons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;

namespace Laugicality.Items.Consumables
{
	public class MoltenMess : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons Ragnar\n\'Chilled Lava.\' \nGuardian of the Obsidium.");
        }


        public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 20;
            item.value = 0;
            item.rare = ItemRarityID.Orange;
            item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
			item.shoot = ModContent.ProjectileType<Nothing>();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<GeneralBossSpawn>(), ModContent.NPCType<Ragnar>(), knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player) => LaugicalityPlayer.Get(player).zoneObsidium && NPC.CountNPCS(ModContent.NPCType<Ragnar>()) < 1;

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod, nameof(ObsidiumBar), 5);
            recipe.AddIngredient(ItemID.Obsidian, 8);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);

			recipe.AddRecipe();
        }
	}
}