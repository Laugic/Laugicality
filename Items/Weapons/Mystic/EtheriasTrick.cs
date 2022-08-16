using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Laugicality.Projectiles.Mystic.Conjuration;
using Laugicality.Projectiles.Mystic.Destruction;
using Laugicality.Projectiles.Mystic.Illusion;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Mystic
{
	public class EtheriasTrick : MysticItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Etheria's Trick");
            Tooltip.SetDefault("'A dimension in your hands'");
        }

		public override void SetMysticDefaults()
		{
			item.damage = 90;
            item.width = 44;
			item.height = 60;
			item.useTime = 18;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 2;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 6f;
        }

        public override string GetExtraTooltip()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
            {
                case 1:
                    return "Shoot a homing rocket bolt";
                case 2:
                    return "Shoots a giant lazer that inflicts 'Eeriness', which\ncauses enemies to take more damage the longer they go without taking damage";
                case 3:
                    return "Spawns energy orbs that create stalagmites and stalactites.";
                default:
                    return "";
            }
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            if(LaugicalityPlayer.Get(player).MysticMode == 2)
            {
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Etherlaser"));
            }

            return base.MysticShoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 250;
            item.useAnimation = item.useTime = 60;
            item.knockBack = 8;
            item.shootSpeed = 14f;
            item.shoot = ModContent.ProjectileType<EtherialRocket>();
            item.UseSound = SoundID.Item20;
            item.scale = 1f;
            LuxCost = 20;
            item.channel = false;
            item.autoReuse = true;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 26;
            item.useAnimation = item.useTime = 2 * 60;
            item.knockBack = 5;
            item.shootSpeed = 12f;
            item.shoot = ModContent.ProjectileType<EtheriaIllusion>();
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item20;
            item.scale = 1f;
            VisCost = 50;
            item.channel = true;
            item.autoReuse = false;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 38;
            item.useAnimation = item.useTime = 15;
            item.knockBack = 2;
            item.shootSpeed = 18f;
            item.shoot = ModContent.ProjectileType<AnDioConjuration1>();
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item20;
            item.scale = 1f;
            MundusCost = 15;
            item.channel = false;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BysmalBar>(), 16);
            recipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}