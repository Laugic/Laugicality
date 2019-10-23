using Laugicality.Items.Loot;
using Laugicality.NPCs.Bosses;
using Laugicality.Projectiles.BossSummons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;

namespace Laugicality.Items.Consumables
{
	public class MechanicalMonitor : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steam-O-Vision");
            Tooltip.SetDefault("Summons The Annihilator");
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
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<GeneralBossSpawn>(), ModContent.NPCType<TheAnnihilator>(), knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player) => !Main.dayTime && NPC.CountNPCS(ModContent.NPCType<TheAnnihilator>()) < 1;

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.HallowedBar, 5);
            recipe.AddIngredient(ItemID.Lens, 3);
			recipe.AddIngredient(ItemID.Vertebrae, 3);
            recipe.AddIngredient(mod, nameof(SoulOfHaught), 3);
            recipe.AddIngredient(mod, nameof(SoulOfSought), 3);
            recipe.AddIngredient(ItemID.Cog, 20);

            recipe.AddTile(TileID.MythrilAnvil);

			recipe.SetResult(this);
			recipe.AddRecipe();
            

            recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.HallowedBar, 5);
            recipe.AddIngredient(ItemID.Lens, 3);
            recipe.AddIngredient(ItemID.RottenChunk, 3);
            recipe.AddIngredient(mod, nameof(SoulOfHaught), 3);
            recipe.AddIngredient(mod, nameof(SoulOfSought), 3);
            recipe.AddIngredient(ItemID.Cog, 20);

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);

            recipe.AddRecipe();
        }
	}
}