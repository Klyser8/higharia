using higharia.Content.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia;

public class ExtractinatorUseTweaker : GlobalItem
{
    public override void ExtractinatorUse(int extractType, int extractinatorBlockType, ref int resultType, ref int resultStack)
    {
        if (extractType != ItemID.DesertFossil)
        {
            return;
        }

        resultStack = 1;

        if (Main.rand.NextFloat() < 0.003)
        {
            resultType = ModContent.ItemType<DuneVitalityShard>();
        }
    }
}