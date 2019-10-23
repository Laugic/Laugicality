using Laugicality.NPCs.RockTwins;
using Laugicality.Projectiles.BossSummons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;

namespace Laugicality.Items.Consumables
{
	public class AncientAwakener : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons Dioritus\n\'The rulers of the caverns are fearsome foes\'");
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
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<GeneralBossSpawn>(), ModContent.NPCType<Dioritus>(), knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            return (player.ZoneRockLayerHeight && NPC.CountNPCS(ModContent.NPCType<Andesia>()) < 1 && NPC.CountNPCS(ModContent.NPCType<Dioritus>()) < 1 && NPC.CountNPCS(ModContent.NPCType<AnDio3>()) < 1);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.MarbleBlock, 40);
            recipe.AddIngredient(ItemID.GoldenKey);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);

			recipe.AddRecipe();


            // TODO Move this to proper class.
            recipe = new ModRecipe(mod);

		    recipe.AddRecipeGroup(Laugicality.GOLD_BARS_GROUP, 4);
		    recipe.AddIngredient(ItemID.Bone);

		    recipe.AddTile(TileID.Hellforge);
		    recipe.SetResult(ItemID.GoldenKey);

		    recipe.AddRecipe();
        }
	}
}