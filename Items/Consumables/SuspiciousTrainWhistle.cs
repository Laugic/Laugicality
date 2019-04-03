using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Consumables
{
	public class SuspiciousTrainWhistle : ModItem
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
			item.rare = 5;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
			item.shoot = mod.ProjectileType("Nothing");
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("GeneralBossSpawn"), mod.NPCType("SteamTrain"), knockBack, player.whoAmI);
            return false;
        }
        public override bool CanUseItem(Player player)
        {
            return (NPC.CountNPCS(mod.NPCType("SteamTrain")) < 1);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1225, 5);
            recipe.AddIngredient(ItemID.Cog, 60);
            recipe.AddIngredient(null, "SoulOfSought", 6);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}