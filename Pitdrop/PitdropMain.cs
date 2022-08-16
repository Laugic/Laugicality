using SubworldLibrary;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Laugicality.Pitdrop
{
    public class PitdropMain
    {
        public static void PickRoom(float difficulty)
        {
            Subworld.Enter<PitdropWorld>();
        }
    }
}
