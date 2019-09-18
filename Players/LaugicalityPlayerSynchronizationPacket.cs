using System.IO;
using Laugicality.Focuses;
using Terraria;
using Terraria.ID;
using WebmilioCommons.Networking.Packets;

namespace Laugicality
{
    public class LaugicalityPlayerSynchronizationPacket : ModPlayerNetworkPacket<LaugicalityPlayer>
    {
        public override bool PostReceive(BinaryReader reader, int fromWho)
        {
            if (!IsResponse && Main.netMode == NetmodeID.MultiplayerClient)
            {
                IsResponse = true;
                Send(Main.myPlayer, Player.whoAmI);
            }

            return base.PostReceive(reader, fromWho);
        }


        public string Focus
        {
            get => ModPlayer.Focus == null ? "" : ModPlayer.Focus.UnlocalizedName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    return;

                ModPlayer.Focus = FocusManager.Instance[value];
            }
        }

        public bool IsResponse { get; set; }
    }
}