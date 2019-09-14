using Terraria.ModLoader;

namespace Laugicality.Backgrounds
{
	public class ObsidiumBkgOld : ModUgBgStyle
    {
        public const string
            BACKGROUNDS_PATH = "Backgrounds";


		public override bool ChooseBgStyle() => LaugicalityPlayer.Get().zoneObsidium;

        public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = mod.GetBackgroundSlot($"{BACKGROUNDS_PATH}/ExampleBiomeUG0");
			textureSlots[1] = mod.GetBackgroundSlot($"{BACKGROUNDS_PATH}/ExampleBiomeUG1");
			textureSlots[2] = mod.GetBackgroundSlot($"{BACKGROUNDS_PATH}/ExampleBiomeUG2");
			textureSlots[3] = mod.GetBackgroundSlot($"{BACKGROUNDS_PATH}/ExampleBiomeUG3");
		}
	}
}