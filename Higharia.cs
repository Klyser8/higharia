using Terraria.ID;
using Terraria.ModLoader;

namespace higharia
{
	public class Higharia : Mod
	{
		
		public static readonly int[] FlightItems =
            {
                ItemID.RocketBoots,
                ItemID.SpectreBoots,
                ItemID.LightningBoots,
                ItemID.FrostsparkBoots,
                ItemID.TerrasparkBoots,
                ItemID.WingsNebula,
                ItemID.WingsSolar,
                ItemID.WingsStardust,
                ItemID.WingsVortex,
                ItemID.DemonWings,
                ItemID.AngelWings,
                ItemID.FairyWings,
                ItemID.BoneWings,
                ItemID.HarpyWings,
                ItemID.BeeWings,
                ItemID.ButterflyWings,
                ItemID.FinWings,
                ItemID.FrozenWings,
                ItemID.GhostWings,
                ItemID.BatWings,
                ItemID.SpookyWings,
                ItemID.TatteredFairyWings,
                ItemID.WingsofEvil,
                ItemID.ArkhalisWings,
                ItemID.LeafWings,
                ItemID.BetsyWings,
                ItemID.FlameWings,
                ItemID.Jetpack,
                ItemID.RedsWings,
                ItemID.DTownsWings,
                ItemID.WillsWings,
                ItemID.CrownosWings,
                ItemID.CenxsWings,
                ItemID.BejeweledValkyrieWing,
                ItemID.Yoraiz0rWings,
                ItemID.LokisWings,
                ItemID.FishronWings,
                ItemID.LeinforsWings,
                ItemID.GhostarsWings,
                ItemID.SafemanWings,
                ItemID.FoodBarbarianWings,
                ItemID.MothronWings,
                ItemID.FestiveWings,
                ItemID.SteampunkWings,
                ItemID.RainbowWings,
                ItemID.LongRainbowTrailWings
            };
		
		public static Higharia Instance()
		{
			return ModContent.GetInstance<Higharia>();
		}
	}
}