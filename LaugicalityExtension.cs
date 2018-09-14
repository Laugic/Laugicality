using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Laugicality
{
    internal static class LaugicalityExtension
    {
        public static void AddLine(this ModTranslation self, string line)
        {
            self.SetDefault(self.GetDefault() + "\n" + line);
        }
    }
}
