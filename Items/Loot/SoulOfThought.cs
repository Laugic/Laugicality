using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
	public class SoulOfThought : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of Thought");
			Tooltip.SetDefault("'The essence of intelligence'");
			// ticksperframe, frameCount
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 5));
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		// TODO -- Velocity Y smaller, post NewItem?
		public override void SetDefaults()
		{
			Item refItem = new Item();
			refItem.SetDefaults(ItemID.SoulofSight);
			item.width = refItem.width;
			item.height = refItem.height;
			item.maxStack = 999;
			item.value = 40000;
			item.rare = ItemRarityID.Orange;
            item.scale *= 1.5f;
        }

		// The following 2 methods are purely to show off these 2 hooks. Don't use them in your own code.
		public override void GrabRange(Player player, ref int grabRange)
		{
			grabRange *= 3;
		}
        /*
		public override bool GrabStyle(Player player)
		{
			Vector2 vectorItemToPlayer = player.Center - item.Center;
			Vector2 movement = -vectorItemToPlayer.SafeNormalize(default(Vector2)) * 0.1f;
			item.velocity = item.velocity + movement;
			item.velocity = Collision.TileCollision(item.position, item.velocity, item.width, item.height);
			return true;
		}
        */
		public override void PostUpdate()
		{
			Lighting.AddLight(item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
		}
	}
    
}