using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Tools
{
	public class DrillOTron10000 : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Drillinator");
            Tooltip.SetDefault("'To the moon.'");
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
            item.shoot = mod.ProjectileType("DrillOTron10000");
            item.shootSpeed = 40f;
        }

        public override bool UseItem(Player player)
        {
            float mag = 18f;
            player.velocity = mag * player.DirectionTo(Main.MouseWorld);
            //player.pickSpeed = 0.00001f;
            for(int i = -2; i < 3; i++)
            {
                for(int j = -2; j < 3; j++)
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
            float mag = 18f;
            player.velocity = mag * player.DirectionTo(Main.MouseWorld);
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BysmalDrill", 1);
            recipe.AddIngredient(1006, 12);
            recipe.AddIngredient(3456, 8);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}