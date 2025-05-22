using System.Linq;
using higharia.Content.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia;

public class FishingTweaker : ModPlayer
{
    public override void ModifyCaughtFish(Item fish)
    {
        if (fish.type == ItemID.CrystalSerpent)
        {
            base.ModifyCaughtFish(new Item(ItemID.PrincessWeapon));
        }

        if (fish.type == ItemID.Bladetongue && !NPC.downedQueenSlime)
        {
            base.ModifyCaughtFish(new Item(ItemID.CrimsonFishingCrateHard));
        }
    }

    public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar,
        ref Vector2 sonarPosition)
    {
        // Array of 620, 621, 586, 587.
        int[] hardmodeMobs = { 620, 621, 586, 587 };
        if (hardmodeMobs.Contains(npcSpawn))
        {
            // If the player has not defeated at least two mech bosses, cancel the spawn
            int mechsDefeated = (NPC.downedMechBoss1 ? 1 : 0)
                                + (NPC.downedMechBoss2 ? 1 : 0)
                                + (NPC.downedMechBoss3 ? 1 : 0);
            if (mechsDefeated < 2)
            {
                npcSpawn = 0;
                // Spawn BloodyNote modded item
                itemDrop = ModContent.ItemType<BloodyNote>();
            }
        }
        base.CatchFish(attempt, ref itemDrop, ref npcSpawn, ref sonar, ref sonarPosition);
    }
}