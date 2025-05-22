using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia;

public class ItemPickupHandler : GlobalItem
{
    /*public override bool OnPickup(Item item, Player player)
    {
        var deathInventoryList = player.GetModPlayer<PlayerDeathInventoryTracker>().GetInventoryPreDeath();
        for (int i = 0; i < deathInventoryList.Count; i++)
        {
            var data = deathInventoryList[i];
            if (data.ItemId == item.type)
            {
                bool placed = InsertItemIntoSlot(player, item, data);
                if (placed)
                {
                    deathInventoryList.RemoveAt(i);
                    return false; // Item has been placed; prevent normal pickup behavior
                }
            }
        }
        return true; // Allow normal pickup behavior
    }

    
    private bool InsertItemIntoSlot(Player player, Item item, PlayerDeathInventoryTracker.DeathDataItemValue data)
    {
        Item[] targetArray = null;

        if (data.LoadoutIndex == -1)
        {
            // Main equipment or inventory
            switch (data.SlotType)
            {
                case "inventory":
                    targetArray = player.inventory;
                    break;
                case "armor":
                    targetArray = player.armor;
                    break;
                case "dye":
                    targetArray = player.dye;
                    break;
                case "miscEquips":
                    targetArray = player.miscEquips;
                    break;
                case "miscDyes":
                    targetArray = player.miscDyes;
                    break;
                default:
                    return false; // Invalid slot type
            }
        }
        else
        {
            // Equipment in loadouts
            if (data.LoadoutIndex >= 0 && data.LoadoutIndex < player.Loadouts.Length)
            {
                var loadout = player.Loadouts[data.LoadoutIndex];
                switch (data.SlotType)
                {
                    case "armor":
                        targetArray = loadout.Armor;
                        break;
                    case "dye":
                        targetArray = loadout.Dye;
                        break;
                    default:
                        return false; // Invalid slot type for loadouts
                }
            }
            else
            {
                return false; // Invalid loadout index
            }
        }

        if (targetArray != null && data.SlotIndex >= 0 && data.SlotIndex < targetArray.Length)
        {
            if (targetArray[data.SlotIndex].IsAir)
            {
                targetArray[data.SlotIndex] = item.Clone();
                item.TurnToAir(); // Remove the item from the world
                return true;
            }
        }

        return false;
    }*/


}