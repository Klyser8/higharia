using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia;

public class ItemDropTweaker : GlobalItem
{
    public override void OnSpawn(Item item, IEntitySource source)
    {
        if (item.type == ItemID.RecallPotion)
        {
            item.active = false;
        }
        base.OnSpawn(item, source);
    }
}