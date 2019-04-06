using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Tools
{
	public class Drillinator : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Chariot");
            Tooltip.SetDefault("'To the sun.'");
		}

        public override void SetDefaults()
        {
            item.damage = 90;
            item.melee = true;
            item.width = 82;
            item.height = 34;
            item.useTime = 1;
            item.useAnimation = 11;
            item.channel = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.pick = 2500;
            item.tileBoost += 8;
            item.useStyle = 5;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 12, 0, 0);
            item.rare = 11;
            item.UseSound = SoundID.Item23;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Drillinator");
            item.shootSpeed = 40f;
        }

        public override bool UseItem(Player player)
        {
            float mag = 28f;
            player.velocity = mag * player.DirectionTo(Main.MouseWorld);
            //player.pickSpeed = 0.00001f;
            for(int i = -8; i < 9; i++)
            {
                for(int j = -8; j < 9; j++)
                {
                    int k = Main.SmartCursorX + i;
                    int l = Main.SmartCursorY + j;
                    Terraria.WorldGen.KillTile(k, l);
                }
            }
            return true;
        }

        public override void HoldItem(Player player)
        {
            player.pickSpeed -= 0.25f;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            float mag = 28f;
            player.velocity = mag * player.DirectionTo(Main.MouseWorld);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DrillOTron10000", 1);
            recipe.AddIngredient(3467, 12);
            recipe.AddIngredient(null, "GalacticFragment", 8);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}