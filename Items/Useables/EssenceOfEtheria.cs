using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Useables
{
    public class EssenceOfEtheria : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The High Priestess");
            Tooltip.SetDefault("Allows you to enter and leave the Etherial at will, as long as no powerful creatures are present to stop you. \nCan place shadows of itself, which can be wired to enter the Etherial. \nAn odd number of wires need to be connected, or it will immediately switch back.");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.expert = true;
            item.createTile = mod.TileType("HighPriestess");
        }

        public override bool CanUseItem(Player player)
        {
            bool boss = false;
            for(int i = 0;  i < 200; i++)
            {
                if (Main.npc[i].boss && Main.npc[i].active)
                    boss = true;
            }
            return !boss;
        }

        public override bool UseItem(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
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
            modPlayer.etherialTrail = 80;
            Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
            return true;
        }
    }
}