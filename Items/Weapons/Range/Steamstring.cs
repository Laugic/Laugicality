using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Range
{
	public class Steamstring : LaugicalityItem
	{
        //public bool steam = true;
        //public int steamTier = 1;
        //public int steamCost = 60;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Steaming Frenzy' \nTurns wooden arrows into Brass Arrows & fires an additional Brass Arrow\n33% chance to not consume ammo");
		}

		public override void SetDefaults()
        {
            //steam = true;
            //steamTier = 1;
            //steamCost = 60;
            item.scale *= 1.2f;
            item.damage = 48;
			item.ranged = true;
			item.width = 40;
			item.height = 62;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item10;
			item.autoReuse = true;
			item.shoot = 10; 
			item.shootSpeed = 16f;
			item.useAmmo = 40;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(SteamBar), 16);
            recipe.AddIngredient(mod, nameof(SoulOfSought), 8);
            recipe.AddIngredient(null, "SoulOfThought", 8);
            recipe.AddIngredient(mod, nameof(Gear), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
        /*
        //Steam item
        //VV
        public override bool CanUseItem(Player player)
        {

            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (steam)
            {
                if (modPlayer.connected >= steamTier && LaugicalityWorld.power >= steamCost)
                    return true;
                else
                    return false;
            }
            return true;
        }

        public override bool UseItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            LaugicalityWorld.power -= steamCost;
            if (LaugicalityWorld.power < 0)
                LaugicalityWorld.power = 0;
            return true;
        }
        //^^
        //Steam Item end
        */
            
        public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .33f;
		}

        public override void HoldItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);

            //Main.NewText("Steam Tier: " + steamTier.ToString(), 0, 250, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));

            float scale = 1f - (Main.rand.NextFloat() * .2f);
            perturbedSpeed = perturbedSpeed * scale;
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType("BrassArrow"), damage, knockBack, player.whoAmI);
            
            if(type == ProjectileID.WoodenArrowFriendly)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType("BrassArrow"), damage, knockBack, player.whoAmI);
                return false;
            }
            return true;
        }
    }
}
