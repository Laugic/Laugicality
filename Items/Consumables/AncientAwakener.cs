using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Consumables
{
	public class AncientAwakener : ModItem
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
			item.rare = 1;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
			item.shoot = mod.ProjectileType("Nothing");
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("GeneralBossSpawn"), mod.NPCType("Dioritus"), knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            return (player.ZoneRockLayerHeight && NPC.CountNPCS(mod.NPCType("Andesia")) < 1 && NPC.CountNPCS(mod.NPCType("Dioritus")) < 1 && NPC.CountNPCS(mod.NPCType("AnDio3")) < 1);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3081, 40);
            recipe.AddIngredient(327, 1);
            recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();

            ModRecipe grecipe = new ModRecipe(mod);
            grecipe.AddRecipeGroup("GldBars", 4);
            grecipe.AddIngredient(154, 1);
            grecipe.AddTile(77);
            grecipe.SetResult(327);
            grecipe.AddRecipe();
        }
	}
}