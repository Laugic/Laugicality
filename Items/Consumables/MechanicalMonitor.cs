using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Consumables
{
	public class MechanicalMonitor : ModItem
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
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("GeneralBossSpawn"), mod.NPCType("TheAnnihilator"), knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            return (!Main.dayTime && NPC.CountNPCS(mod.NPCType("TheAnnihilator")) < 1);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1225, 5);
            recipe.AddIngredient(ItemID.Lens, 3);
			recipe.AddIngredient(ItemID.Vertebrae, 3);
            recipe.AddIngredient(null, "SoulOfHaught", 3);
            recipe.AddIngredient(null, "SoulOfSought", 3);
            recipe.AddIngredient(ItemID.Cog, 20);
            recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
            
            ModRecipe Arecipe = new ModRecipe(mod);
            Arecipe.AddIngredient(1225, 5);
            Arecipe.AddIngredient(ItemID.Lens, 3);
            Arecipe.AddIngredient(ItemID.RottenChunk, 3);
            Arecipe.AddIngredient(null, "SoulOfHaught", 3);
            Arecipe.AddIngredient(null, "SoulOfSought", 3);
            Arecipe.AddIngredient(ItemID.Cog, 20);
            Arecipe.AddTile(134);
            Arecipe.SetResult(this);
            Arecipe.AddRecipe();
        }
	}
}