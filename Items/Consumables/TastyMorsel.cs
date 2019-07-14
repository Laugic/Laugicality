using Laugicality.NPCs.PreTrio;
using Laugicality.Projectiles;
using Laugicality.Projectiles.BossSummons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;

namespace Laugicality.Items.Consumables
{
	public class TastyMorsel : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons Dune Sharkron in the desert \n\'Mmm... Looks delicious.\'");
        }

        public override void SetDefaults()
		{
			item.width = 16;
			item.height = 20;
			item.maxStack = 20;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
			item.shoot = mod.ProjectileType<Nothing>();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType<GeneralBossSpawn>(), mod.NPCType<DuneSharkron>(), knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player) => player.ZoneDesert && NPC.CountNPCS(mod.NPCType<DuneSharkron>()) < 1;

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.Lens, 2);
			recipe.AddIngredient(ItemID.Vertebrae, 3);
            recipe.AddIngredient(ItemID.SharkFin, 2);
            recipe.AddTile(TileID.DemonAltar);

			recipe.SetResult(this);
			recipe.AddRecipe();


            recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.Lens, 2);
            recipe.AddIngredient(ItemID.RottenChunk, 3);
            recipe.AddIngredient(ItemID.SharkFin, 2);
            recipe.AddTile(TileID.DemonAltar);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}