using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Consumables
{
	public class MoltenMess : ModItem
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
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("GeneralBossSpawn"), mod.NPCType("Ragnar"), knockBack, player.whoAmI);
            return false;
        }
        public override bool CanUseItem(Player player)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            return ( modPlayer.ZoneObsidium && NPC.CountNPCS(mod.NPCType("Ragnar")) < 1);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ObsidiumBar", 5);
            recipe.AddIngredient(173, 8);
            recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}