using System;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace higharia;

public class AltarPatchSystem : ModSystem
{
	public override void Load()
	{
		// Type worldGenClass = Type.GetType("Terraria.WorldGen");
		// MethodInfo detourMethod = worldGenClass.GetMethod("SmashAltar", BindingFlags.Static | BindingFlags.Public);
		On_WorldGen.SmashAltar += On_WorldGenOnSmashAltar;
	}

	private void On_WorldGenOnSmashAltar(On_WorldGen.orig_SmashAltar orig, int altarX, int altarY)
	{
		// --- Early exits / conditions ---------------------------------------------------
		
		if (Main.netMode == 1 // client mode => server is the authority
		    || !Main.hardMode
		    || WorldGen.noTileActions
		    || WorldGen.gen)
		{
			return;
		}

		// waveIndex cycles 0->1->2 for each 3 altars smashed
		int waveIndex = WorldGen.altarCount % 3;
		// waveCount increments every 3 altars: (altarCount / 3) + 1
		int waveCount = (WorldGen.altarCount / 3) + 1;

		// Base spawn multiplier depends on world size & wave
		double spawnMultiplier = (double)Main.maxTilesX / 4200.0;
		spawnMultiplier = spawnMultiplier * 310.0 - 85 * waveIndex;
		spawnMultiplier *= 0.85;
		spawnMultiplier /= waveCount;

		int waveIndexInverse = 1 - waveIndex; // affects vein sizes slightly
		bool discoveredNewTier = false;

		// Check if any mechanical bosses are defeated
		int mechBossesDefeated = 0;
		if (NPC.downedMechBoss1) mechBossesDefeated++;
		if (NPC.downedMechBoss2) mechBossesDefeated++;
		if (NPC.downedMechBoss3) mechBossesDefeated++;

		// DrunkWorld minor toggles
		if (Main.drunkWorld)
		{
			// Flip Adamantite <-> Titanium chance
			if (WorldGen.SavedOreTiers.Adamantite == TileID.Adamantite) // 111 => Adamantite
				WorldGen.SavedOreTiers.Adamantite = TileID.Titanium; // 223 => Titanium
			else if (WorldGen.SavedOreTiers.Adamantite == TileID.Titanium)
				WorldGen.SavedOreTiers.Adamantite = TileID.Adamantite;
		}

		// --- Figure out which ore "type" (Cobalt vs. Palladium, etc.) this wave spawns --
		int chosenOreType;
		int messageIndex = 0;
		if (waveIndex == 0)
		{
			// waveIndex=0 => Cobalt/Palladium
			if (WorldGen.SavedOreTiers.Cobalt == -1)
			{
				discoveredNewTier = true;
				WorldGen.SavedOreTiers.Cobalt = TileID.Cobalt; // 107 => Cobalt
				if (WorldGen.genRand.Next(2) == 0)
				{
					WorldGen.SavedOreTiers.Cobalt = TileID.Palladium; // 221 => Palladium
				}
			}

            messageIndex = 12; // default text for "Cobalt"
			if (WorldGen.SavedOreTiers.Cobalt == TileID.Palladium)
			{
				messageIndex += 9; // shift message for Palladium
				spawnMultiplier *= 0.90;
			}

			chosenOreType = WorldGen.SavedOreTiers.Cobalt;
			spawnMultiplier *= 1.05;
		}
		else if (waveIndex == 1)
		{

			// DrunkWorld toggles for Mythril <-> Orich
			if (Main.drunkWorld)
			{
				if (WorldGen.SavedOreTiers.Mythril == TileID.Mythril) // 108 => Mythril
					WorldGen.SavedOreTiers.Mythril = TileID.Orichalcum; // 222 => Orichalcum
				else if (WorldGen.SavedOreTiers.Mythril == TileID.Orichalcum)
					WorldGen.SavedOreTiers.Mythril = TileID.Mythril;
			}

			if (WorldGen.SavedOreTiers.Mythril == -1)
			{
				discoveredNewTier = true;
				WorldGen.SavedOreTiers.Mythril = TileID.Mythril;
				if (WorldGen.genRand.NextBool(2))
				{
					WorldGen.SavedOreTiers.Mythril = TileID.Orichalcum;
				}
			}

            messageIndex = 13; // default text for "Mythril"
			if (WorldGen.SavedOreTiers.Mythril == TileID.Orichalcum)
			{
				messageIndex += 9; // shift message for Orich
				spawnMultiplier *= 0.90;
			}

			chosenOreType = WorldGen.SavedOreTiers.Mythril;
		}
		else
		{
			if (Main.drunkWorld)
			{
				// Flip Cobalt <-> Palladium occasionally (this is just leftover from original code)
				if (WorldGen.SavedOreTiers.Cobalt == TileID.Cobalt)
					WorldGen.SavedOreTiers.Cobalt = TileID.Palladium;
				else if (WorldGen.SavedOreTiers.Cobalt == TileID.Palladium)
					WorldGen.SavedOreTiers.Cobalt = TileID.Cobalt;
			}

			if (WorldGen.SavedOreTiers.Adamantite == -1)
			{
				discoveredNewTier = true;
				WorldGen.SavedOreTiers.Adamantite = TileID.Adamantite; // Adamantite
				if (WorldGen.genRand.Next(2) == 0)
				{
					WorldGen.SavedOreTiers.Adamantite = TileID.Titanium; // Titanium
				}
			}

            messageIndex = 14; // default "Adamantite"
			if (WorldGen.SavedOreTiers.Adamantite == TileID.Titanium)
			{
				messageIndex += 9; // shift message => "Titanium"
				spawnMultiplier *= 0.90;
			}

			chosenOreType = WorldGen.SavedOreTiers.Adamantite;
		}

		if (discoveredNewTier)
		{
			// Sync newly discovered ore tier
			NetMessage.SendData(MessageID.WorldData);
		}
		
		if ((chosenOreType == TileID.Mythril || chosenOreType == TileID.Orichalcum) && mechBossesDefeated < 1)
		{
			String chosenOreTypeString = chosenOreType == TileID.Mythril ? "Mythril" : "Orichalcum";
			DisplayNewCursedOreMessage($"You world has been blessed with {chosenOreTypeString} -yet its power remains bound until one mechanical guardian is laid to rest.");
		} else if ((chosenOreType == TileID.Adamantite || chosenOreType == TileID.Titanium) && mechBossesDefeated < 2)
		{
			String chosenOreTypeString = chosenOreType == TileID.Adamantite ? "Adamantite" : "Titanium";
			DisplayNewCursedOreMessage($"You world has been blessed with {chosenOreTypeString} -yet its power remains bound until two mechanical guardian are laid to rest.");
		}
		else
		{
            DisplayNewOreMessage(messageIndex);
		}

		// --- Now spawn the ore only in the desired biome(s) -----------------------
		int tries = (int)spawnMultiplier;
		// Adamantite has lower odds to generate, hence more tries
		switch (chosenOreType) // 107, 108, 111, 221, 222, 223
		{
			case TileID.Cobalt:
				tries = (int)(spawnMultiplier);
				break;
			case TileID.Palladium:
				tries = (int)(spawnMultiplier * 6.0);
				break;
			case TileID.Mythril:
				tries = (int)(spawnMultiplier * 3.0);
				break;
			case TileID.Orichalcum:
				tries = (int)(spawnMultiplier * 4.0);
				break;
			case TileID.Adamantite:
				tries = (int)(spawnMultiplier * 7.0);
				break;
			case TileID.Titanium:
				tries = (int)(spawnMultiplier * 4.0);
				break;
		}
		for (int t = 0; t < tries; t++)
		{
			// We attempt to pick a random location multiple times
			// You can adjust the # of tries vs. # of successes as you wish
			int spawnX = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
			int spawnY = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 150);

			// For remix or other special worlds, you can do different Y ranges if needed
			if (Main.remixWorld)
			{
				spawnY = WorldGen.genRand.Next((int)(Main.worldSurface + 15), Main.maxTilesY - 200);
			}

			// We only place ore if it’s the correct biome
			bool correctBiome = CheckBiomeForOre(chosenOreType, spawnX, spawnY);
			if (!correctBiome)
				continue;

			// Place the ore vein
			if (Main.tenthAnniversaryWorld)
			{
				WorldGen.OreRunner(
					spawnX,
					spawnY,
					WorldGen.genRand.Next(5, 11 + waveIndexInverse),
					WorldGen.genRand.Next(5, 11 + waveIndexInverse),
					(ushort)chosenOreType
				);
			}
			else
			{
				// Send msg in console
				Main.NewText($"Spawning {chosenOreType} at {spawnX}, {spawnY}");
				WorldGen.OreRunner(
					spawnX,
					spawnY,
					WorldGen.genRand.Next(5, 9 + waveIndexInverse),
					WorldGen.genRand.Next(5, 9 + waveIndexInverse),
					(ushort)chosenOreType
				);
			}
		}

		// --- Spawn Wraith(s) if in singleplayer or on server ----------------------
		if (Main.netMode != 1)
		{
			int wraithCount = Main.rand.Next(2) + 1;
			for (int w = 0; w < wraithCount; w++)
			{
				int closestPlayerIndex = (int)Player.FindClosest(
					new Vector2(altarX * 16, altarY * 16),
					16, 16
				);
				NPC.SpawnOnPlayer(closestPlayerIndex, 82); // Wraith
			}
		}

		// Increment altarCount & unlock achievement
		WorldGen.altarCount++;
		AchievementsHelper.NotifyProgressionEvent(6);


		// --------------------------------------------------------------------------------
		// Helper function: Decide if (x, y) is the right biome for the chosen ore.
		// "chosenOreType" is 107 or 221 (Cobalt/Palladium), 108 or 222 (Mythril/Orich),
		// etc. Then we decide if we’re in Caverns, Desert, Snow, Hallow, Hell, or Corrupt/Crimson.
		bool CheckBiomeForOre(int oreType, int x, int y)
		{
			// NOTE: This is just *one* way to check. Real code often uses "SceneMetrics" 
			// or specific tile checks. For demonstration, we do approximate checks:

			if (oreType == TileID.Cobalt)
			{
				return IsUnderground(x, y);
			}

			if (oreType == TileID.Palladium)
			{
				return IsUndergroundDesert(x, y);
			}

			if (oreType == TileID.Mythril)
			{
				// 108 => Mythril => Underground Snow
				return IsUndergroundSnow(x, y);
			}

			if (oreType == TileID.Orichalcum)
			{
				// 222 => Orichalcum => Underground Hallow
				return IsUndergroundHallow(x, y);
			}

			if (oreType == TileID.Adamantite)
			{
				// 111 => Adamantite => Hell
				// Hell ~ last ~200 tiles or so
				return IsUnderworld(x, y);
			}

			if (oreType == TileID.Titanium)
			{
				// 223 => Titanium => Underground Crimson/Corruption
				return IsUndergroundEvil(x, y);
			}

			return false;
		}

		// -------------------------------------------------------------------
		// For brevity, these could be placeholders or more thorough checks:

		bool IsUnderground(int x, int y)
		{
			if (y > Main.rockLayer && y < Main.UnderworldLayer)
			{
				return ScanForTileType(x, y, 10, TileID.Dirt, TileID.Stone, TileID.ClayBlock);
			}

			return false;
		}

		bool IsUndergroundDesert(int x, int y)
		{
			// Real check might count sand tiles, or do: Main.tile[x, y].WallType == ...
			// Below is a simplistic example: 
			if (y > Main.worldSurface && y < Main.UnderworldLayer)
			{
				// Then check if there's a lot of sand in a small radius:
				// (Placeholder method)
				return ScanForTileType(x, y, 10,
					TileID.Sandstone, TileID.HardenedSand, TileID.CorruptHardenedSand, 
					TileID.CorruptSandstone,TileID.CrimsonHardenedSand, TileID.CrimsonSandstone,
					TileID.HallowHardenedSand, TileID.HallowSandstone, TileID.FossilOre);
			}

			return false;
		}

		bool IsUndergroundSnow(int x, int y)
		{
			// Similarly, check if y is underground, and we have lots of snow/ice
			if (y > Main.rockLayer && y < Main.UnderworldLayer)
			{
				return ScanForTileType(x, y, 20,
					TileID.IceBlock, TileID.SnowBlock, TileID.Slush, TileID.BreakableIce,
					TileID.CorruptIce, TileID.HallowedIce, TileID.FleshIce);
			}

			return false;
		}

		bool IsUndergroundHallow(int x, int y)
		{
			// Check if y is underground, and also if Hallow is around
			if (y > Main.rockLayer && y < Main.UnderworldLayer)
			{
				// We can scan for Pearlstone or Hallow tiles, or see if
				// Main.tile[x, y].wall == something, etc.
				return ScanForTileType(x, y, 50,
					TileID.Pearlstone, TileID.HallowedIce, TileID.Pearlsand,
					TileID.HallowHardenedSand, TileID.HallowSandstone);
			}

			return false;
		}

		bool IsUndergroundEvil(int x, int y)
		{
			// Check if y is underground, and also if Corrupt/Crimson blocks/walls are near
			if (y > Main.worldSurface && y < Main.UnderworldLayer)
			{
				// e.g. Ebonstone (TileID=25), Crimstone (TileID=203), etc.
				return ScanForTileType(x, y, 50,
					TileID.Ebonstone, TileID.CorruptIce, TileID.Ebonsand,
					TileID.CorruptHardenedSand, TileID.CorruptSandstone, TileID.Crimstone,
					TileID.FleshIce, TileID.Crimsand, TileID.CrimsonHardenedSand, TileID.CrimsonSandstone);
			}

			return false;
		}

		bool IsUndergroundJungle(int x, int y)
		{
			if (y > Main.worldSurface && y < Main.UnderworldLayer)
			{
				// e.g. Jungle grass, vines, etc.
				return ScanForTileType(x, y, 20,
					TileID.JungleGrass, TileID.JungleVines, TileID.JungleThorns,
					TileID.JunglePlants, TileID.JungleThorns, TileID.JunglePlants2, TileID.Mud, TileID.Hive);
			}

			return false;
		}

		bool IsUnderworld(int x, int y)
		{
			// Check if y is in the Underworld
			if (y >= Main.UnderworldLayer)
			{
				return ScanForTileType(x, y, 40,
					TileID.Ash, TileID.AshGrass, TileID.Hellstone, TileID.AshPlants, TileID.AshVines);
			}

			return false;
		}

		bool ScanForTileType(int centerX, int centerY, int radius, params int[] tileTypes)
		{
			// Add some vanilla tile types to the list
			tileTypes = tileTypes.Concat(new int[]
			{
				TileID.MarbleBlock,
				TileID.GraniteBlock
			}).ToArray();

			// Very rough check for demonstration
			foreach (int tileType in tileTypes)
			{
				for (int xx = centerX - radius; xx <= centerX + radius; xx++)
				{
					for (int yy = centerY - radius; yy <= centerY + radius; yy++)
					{
						if (!WorldGen.InWorld(xx, yy, 10)) continue;
						Tile tile = Main.tile[xx, yy];
						if (tile != null && tile.HasTile && tile.TileType == tileType)
							return true;
					}
				}
			}

			return false;
		}

		// --------------------------------------------------------------------------------
		// Helper to unify message display (client vs. server).
		void DisplayNewOreMessage(int messageId)
		{
			if (Main.netMode == NetmodeID.SinglePlayer) // Single player
			{
				Main.NewText(Lang.misc[messageId].Value, 50, byte.MaxValue, 130);
			}
			else if (Main.netMode == NetmodeID.Server) // Server
			{
				ChatHelper.BroadcastChatMessage(
					NetworkText.FromKey(Lang.misc[messageId].Key, Array.Empty<object>()),
					new Color(50, 255, 130)
				);
			}
		}
		
		// --------------------------------------------------------------------------------
		// Helper to unify message display (client vs. server).
		void DisplayNewCursedOreMessage(String msg)
		{
			if (Main.netMode == NetmodeID.SinglePlayer) // Single player
			{
				Main.NewText(msg, 255, 153, 132);
			}
			else if (Main.netMode == NetmodeID.Server) // Server
			{
				ChatHelper.BroadcastChatMessage(
					NetworkText.FromKey(msg, Array.Empty<object>()),
					new Color(255, 153, 132)
				);
			}
		}
	}
}