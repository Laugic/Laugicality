using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class EssenceOfEtheria : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of Etheria");
            Tooltip.SetDefault("Allows you to enter and leave the Etherial at will");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 1;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            //item.defense = 1000;
            item.lifeRegen = 1;
        }
        
        public override bool UseItem(Player player)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            LaugicalityWorld.downedEtheria = !LaugicalityWorld.downedEtheria;
            Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
            Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
            Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
            Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
            Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
            Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
            Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
            Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
            Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
            modPlayer.etherialTrail = 45;
            Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
            return true;
        }
    }
}