using Laugicality.Items.Loot;
using Laugicality.NPCs.PreTrio;
using Laugicality.Projectiles.Mystic.Illusion;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Tools
{
    public class Debugger : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Debugger");
            Tooltip.SetDefault("'A debug tool'");
        }

		public override void SetDefaults()
		{
			item.damage = 40;
			item.noMelee = true;
			item.magic = true;
			item.channel = true;
			item.mana = 5;
			item.rare = ItemRarityID.Pink;
			item.width = 28;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 14f;
			item.useAnimation = 20;
			item.shoot = ModContent.ProjectileType<TestLaser>();
			item.value = 0;
		}
	}
}