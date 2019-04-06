using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Backgrounds
{
	public class ObsidiumBkgOld : ModUgBgStyle
	{
		public override bool ChooseBgStyle()
		{
			return Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod).zoneObsidium;
		}

		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/ExampleBiomeUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/ExampleBiomeUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/ExampleBiomeUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/ExampleBiomeUG3");
		}
	}
}