using Laugicality.Items.Materials;
using Laugicality.Projectiles.Thrown;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Thrown
{
    public class Obshardian : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoots faster and pierces more as you consume Obsidium Hearts");
        }
        public override void SetDefaults()
        {
            item.damage = 34;           
            item.thrown = true;             
            item.noMelee = true;
            item.width = 14;
            item.height = 26;
            item.useAnimation = item.useTime = 20;   
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;       
            item.shoot = ModContent.ProjectileType<ObshardianP>();  
            item.shootSpeed = 16f;     
            item.useTurn = true;
            item.maxStack = 999;       
            item.consumable = true;  
            item.noUseGraphic = true;

        }

        public override void HoldItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            item.useAnimation = item.useTime = 24 - modPlayer.ObsidiumHeart * 2;
            base.HoldItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            int id = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
            Main.projectile[id].ai[1] = modPlayer.ObsidiumHeart;
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(ObsidiumBar), 4);
            recipe.AddTile(16);
            recipe.SetResult(this, 111);
            recipe.AddRecipe();
        }
    }
}