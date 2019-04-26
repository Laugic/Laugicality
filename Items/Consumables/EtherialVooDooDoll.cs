using Laugicality.Items.Loot;
using Laugicality.Projectiles;
using Laugicality.Projectiles.BossSummons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Consumables
{
	public class EtherialVooDooDoll : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Etherial VooDoo Doll");
            Tooltip.SetDefault("Summons the Wall of Flesh in the Etherial");
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
			item.consumable = true;
			item.shoot = mod.ProjectileType<Nothing>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType<GeneralBossSpawn>(), NPCID.WallofFlesh, knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player) => player.ZoneUnderworldHeight && LaugicalityWorld.downedEtheria && NPC.CountNPCS(NPCID.WallofFlesh) < 1;

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod, nameof(EtherialEssence), 8);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);

			recipe.AddRecipe();
        }
	}
}