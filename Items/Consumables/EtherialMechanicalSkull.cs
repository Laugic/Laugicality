using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Laugicality.Items.Consumables
{
	public class EtherialMechanicalSkull : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Etherial Skull");
            Tooltip.SetDefault("Summons Skeletron Prime");
        }
        public override void SetDefaults()
		{
			item.width = 16;
			item.height = 20;
			item.maxStack = 20;
			item.rare = 1;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
			item.shoot = mod.ProjectileType("Nothing");
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            if (NPC.CountNPCS(NPCID.SkeletronPrime) < 1)
                NPC.NewNPC((int)player.position.X, (int)player.position.Y - 480, NPCID.SkeletronPrime);
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            return (!Main.dayTime && modPlayer.etherial);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EtherialEssence", 4);
            recipe.AddTile(26);
            recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}