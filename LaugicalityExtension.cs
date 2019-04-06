using Terraria.ModLoader;

namespace Laugicality
{
    internal static class LaugicalityExtension
    {
        public static void AddLine(this ModTranslation modTranslation, string line)
        {
            modTranslation.SetDefault(modTranslation.GetDefault() + "\n" + line);
        }
    }
}
