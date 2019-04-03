using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Consumables
{
	public class EmblemOfEtheria : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emblem of Etheria");
            Tooltip.SetDefault("Calls Etheria\n\'This seems like a terrible idea.\'");
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
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("GeneralBossSpawn"), mod.NPCType("Etheria"), knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            if (Main.dayTime && !LaugicalityWorld.downedEtheria)
                return false;
            else if (NPC.CountNPCS(mod.NPCType("Etheria")) > 0)
                return false;
            return true;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpookyWood, 75);
            recipe.AddIngredient(ItemID.Ectoplasm, 15);
            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();

            ModRecipe Arecipe = new ModRecipe(mod);
            Arecipe.AddIngredient(null, "EtherialEssence", 15);
            Arecipe.AddTile(TileID.DemonAltar);
            Arecipe.SetResult(this);
            Arecipe.AddRecipe();
        }
	}
}