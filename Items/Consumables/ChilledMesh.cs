using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Consumables
{
	public class ChilledMesh : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons Hypothema\n'It's almost freezing your fingers off.'");
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
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("GeneralBossSpawn"), mod.NPCType("Hypothema"), knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            return (player.ZoneSnow && NPC.CountNPCS(mod.NPCType("Hypothema")) < 1);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SnowBlock, 25);
            recipe.AddIngredient(ItemID.IceBlock, 25);
            recipe.AddIngredient(ItemID.DemoniteBar, 12);
            recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();

            ModRecipe arecipe = new ModRecipe(mod);
            arecipe.AddIngredient(ItemID.SnowBlock, 25);
            arecipe.AddIngredient(ItemID.IceBlock, 25);
            arecipe.AddIngredient(ItemID.CrimtaneBar, 12);
            arecipe.AddTile(26);
            arecipe.SetResult(this);
            arecipe.AddRecipe();
        }
	}
}