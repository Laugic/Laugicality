using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class ToyTrain : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Toy Train");
			Description.SetDefault("Choo Choo!");
			Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<LaugicalityPlayer>(mod).ToyTrain = true;

            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("ToyTrain")] <= 0;

            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("ToyTrain"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
	}
}
