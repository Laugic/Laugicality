using System.IO;
using Terraria;
using WebmilioCommons.Networking.Packets;

namespace Laugicality.Focuses
{
    public class FocusChangedPacket : ModPlayerNetworkPacket<LaugicalityPlayer>
    {
        protected override bool PostReceive(BinaryReader reader, int fromWho)
        {
            Main.NewText($"Player {Player.name} now has focus {ModPlayer.Focus.DisplayName}");

            return true;
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
    }
}