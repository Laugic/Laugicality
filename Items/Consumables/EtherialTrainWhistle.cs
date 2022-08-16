﻿using Laugicality.Items.Loot;
using Laugicality.Projectiles.BossSummons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;

namespace Laugicality.Items.Consumables
{
	public class EtherialTrainWhistle : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons Steam Train");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 40;
            item.maxStack = 20;
            item.rare = ItemRarityID.Pink;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
            item.shoot = ModContent.ProjectileType<Nothing>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<GeneralBossSpawn>(), ModContent.NPCType<NPCs.SteamTrain.SteamTrainOld>(), knockBack, player.whoAmI);
            return false;
        }
        public override bool CanUseItem(Player player)
        {
            return ( LaugicalityWorld.downedEtheria & NPC.CountNPCS(ModContent.NPCType<NPCs.SteamTrain.SteamTrainOld>()) < 1);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod, nameof(EtherialEssence), 4);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);

			recipe.AddRecipe();
        }
	}
}