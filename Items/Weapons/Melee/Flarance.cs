using Laugicality.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
    class Flarance : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Eruptions fly forth'\nProjectiles become stronger as you consume Obsidium Hearts");
        }

        public override void SetDefaults()
        {
            item.damage = 24;
            item.melee = true;
            item.width = 42;
            item.height = 48;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 1;
            item.knockBack = 5;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;    
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.Melee.FlaranceProjectile>();
            item.shootSpeed = 14f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            int id = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, item.shoot, damage, knockBack, player.whoAmI);
            Main.projectile[id].ai[0] = modPlayer.ObsidiumHeart;
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(ObsidiumBar), 16);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
