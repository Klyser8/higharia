using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace higharia;

public class PlayerDeathInventoryTracker : ModPlayer
{
    
    /*private List<DeathDataItemValue> _inventoryPreDeath = new();
    
    public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genDust,
        ref PlayerDeathReason damageSource)
    {
        // Clear previous death data
        _inventoryPreDeath.Clear();

        // Store main inventory items
        for (int i = 0; i < Player.inventory.Length; i++)
        {
            Item item = Player.inventory[i];
            if (!item.IsAir)
            {
                _inventoryPreDeath.Add(new DeathDataItemValue("inventory", i, item.type, item.stack));
            }
        }

        // Store items from all loadouts
        for (int loadoutIndex = -1; loadoutIndex < Player.Loadouts.Length; loadoutIndex++)
        {
            StoreEquipmentItems(Player, loadoutIndex);
        }

        // Store misc equipment (not part of loadouts)
        for (int i = 0; i < Player.miscEquips.Length; i++)
        {
            Item item = Player.miscEquips[i];
            if (!item.IsAir)
            {
                _inventoryPreDeath.Add(new DeathDataItemValue("miscEquips", i, item.type, item.stack));
            }
        }

        // Store misc dyes (not part of loadouts)
        for (int i = 0; i < Player.miscDyes.Length; i++)
        {
            Item item = Player.miscDyes[i];
            if (!item.IsAir)
            {
                _inventoryPreDeath.Add(new DeathDataItemValue("miscDyes", i, item.type, item.stack));
            }
        }

        return true;
    }

    private void StoreEquipmentItems(Player player, int loadoutIndex)
    {
        Item[] armorArray;
        Item[] dyeArray;

        if (loadoutIndex == -1)
        {
            // Main equipment (currently equipped)
            armorArray = player.armor;
            dyeArray = player.dye;
        }
        else
        {
            // Equipment in loadouts
            armorArray = player.Loadouts[loadoutIndex].Armor;
            dyeArray = player.Loadouts[loadoutIndex].Dye;
        }

        // Store armor items
        for (int i = 0; i < armorArray.Length; i++)
        {
            Item item = armorArray[i];
            if (!item.IsAir)
            {
                _inventoryPreDeath.Add(new DeathDataItemValue("armor", i, item.type, item.stack, loadoutIndex));
            }
        }

        // Store dye items
        for (int i = 0; i < dyeArray.Length; i++)
        {
            Item item = dyeArray[i];
            if (!item.IsAir)
            {
                _inventoryPreDeath.Add(new DeathDataItemValue("dye", i, item.type, item.stack, loadoutIndex));
            }
        }
    }


    
    public List<DeathDataItemValue> GetInventoryPreDeath()
    {
        return _inventoryPreDeath;
    }
    
    public class DeathDataItemValue
    {
        public DeathDataItemValue(string slotType, int slotIndex, int itemId, int stack, int loadoutIndex = -1)
        {
            SlotType = slotType; // e.g., "inventory", "armor", etc.
            SlotIndex = slotIndex;
            ItemId = itemId;
            Stack = stack;
            LoadoutIndex = loadoutIndex; // -1 for main equipment, 0-2 for loadouts
        }

        public string SlotType { get; set; }
        public int SlotIndex { get; set; }
        public int ItemId { get; set; }
        public int Stack { get; set; }
        public int LoadoutIndex { get; set; }
    }*/

    
    
}