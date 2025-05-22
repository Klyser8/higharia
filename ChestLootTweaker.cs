using higharia.Content.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace higharia;

public class ChestLootTweaker : ModSystem
{
    public override void PostWorldGen()
    {
        ConvertChests();
    }

    public static void ConvertChests()
    {
        chests: foreach (var chest in Main.chest)
        {
            Higharia.Instance().Logger.Debug("Looking at chest");
            if (chest == null)
            {
                continue;
            }

            slots: for (var slot = 0; slot < 20; slot++)
            {
                // print(chest.item[i]) through C#
                Higharia.Instance().Logger.Debug($"Item in slot {slot}: {chest.item[slot]}");
                if (chest.item[slot] == null)
                {
                    continue;
                }

                if (ReplaceItem(chest, slot, new Item(ItemID.GoldCoin, Main.rand.Next(1, 3)),
                        ItemID.MagicMirror, ItemID.IceMirror))
                {
                    continue;
                }
                if (ReplaceItem(chest, slot, new Item(ItemID.ObsidianSkull), 
                    ItemID.HermesBoots))
                {
                    continue;
                }
                if (ReplaceItem(chest, slot, new Item(ItemID.LesserManaPotion, Main.rand.Next(8, 15)),
                        ItemID.RecallPotion, ItemID.RestorationPotion, ItemID.LesserRestorationPotion))
                {
                    continue;
                }
                if (ReplaceItem(chest, slot, new Item(ItemID.HandWarmer), ItemID.FlurryBoots))
                {
                    continue;
                }
                if (ReplaceItem(chest, slot, new Item(ModContent.ItemType<DuneVitalityShard>()), ItemID.SandBoots))
                {
                    continue;
                }
                if (ReplaceItem(chest, slot, new Item(ItemID.ObsidianRose), ItemID.LuckyHorseshoe))
                {
                    continue;
                }
                if (ReplaceItem(chest, slot, new Item(ItemID.CloudinaBottle), ItemID.ShinyRedBalloon))
                {
                    continue;
                }
                if (ReplaceItem(chest, slot, new Item(ItemID.ShinyRedBalloon), ItemID.CloudinaBottle,
                        ItemID.SandstorminaBottle, ItemID.BlizzardinaBottle))
                {
                    continue;
                }
                
                if (ReplaceItem(chest, slot, new Item(ModContent.ItemType<SilkenClump>()), ItemID.WebSlinger))
                {
                    continue;
                }

                bool isShadowChest = false;
                var shadowTile = Framing.GetTileSafely(chest.x, chest.y);
                var shadowChestFrameXMin = 108;
                var shadowChestFrameXMax = 177;
                if (shadowTile.TileType == TileID.Containers)
                {
                    if (shadowTile.TileFrameX >= shadowChestFrameXMin && shadowTile.TileFrameX <= shadowChestFrameXMax)
                    {
                        isShadowChest = true;
                        Higharia.Instance().Logger.Debug("Found shadow chest!");
                    }
                }
                if (!isShadowChest && ReplaceItem(chest, slot, new Item(ItemID.FeatherfallPotion),
                        ItemID.GravitationPotion))
                {
                    continue;
                }
                
                if (isShadowChest)
                {
                    // Get first empty slot
                    if (chest.item[slot].type == ItemID.None)
                    {
                        if (SetItemWithChance(chest, slot, new Item(ItemID.LuckyHorseshoe), 0.5f))
                        {
                            // Send in chat
                            Higharia.Instance().Logger.Debug("Added lucky horseshoe to shadow chest");
                             break;
                        }
                        
                        SetItemWithChance(chest, slot, new Item(ItemID.HermesBoots), 1.00f);
                        Higharia.Instance().Logger.Debug("Added hermes boots to shadow chest");
                        break;
                    }
                }
            }
            bool isFrozenChest = false;
            var frozenTile = Framing.GetTileSafely(chest.x, chest.y);
            var frozenChestFrameXMin = 396;
            var frozenChestFrameXMax = 429;
            if (frozenTile.TileType == TileID.Containers)
            {
                if (frozenTile.TileFrameX >= frozenChestFrameXMin && frozenTile.TileFrameX <= frozenChestFrameXMax)
                {
                    isFrozenChest = true;
                    Higharia.Instance().Logger.Debug("Found frozen chest!");
                }
            }

            if (isFrozenChest)
            {
                for (var slot = 0; slot < 20; slot++)
                {
                    // Check that the slot is empty
                    if (chest.item[slot].type != ItemID.None)
                    {
                        continue;
                    }

                    if (chest.item[slot].type == ItemID.IceRod)
                    {
                        Higharia.Instance().Logger.Debug($"Ice rod already in slot {slot}, skipping chest");
                        break;
                    }

                    SetItemWithChance(chest, slot, new Item(ItemID.IceRod), 0.111f);
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Replaces an item in a chest with a new item if the item to replace is found.
    /// </summary>
    /// <param name="chest"></param> The chest to modify.
    /// <param name="slot"></param> The slot to modify.
    /// <param name="newItem"></param> The new item to replace with.
    /// <param name="toReplace"></param> The item(s) to replace.
    /// <returns></returns> True if an item was replaced, false otherwise.
    private static bool ReplaceItem(Chest chest, int slot, Item newItem, params int[] toReplace)
    {
        foreach (var itemId in toReplace)
        {
            if (chest.item[slot].type == itemId)
            {
                Higharia.Instance().Logger.Debug($"Item at slot {slot} is {chest.item[slot]}");
                chest.item[slot].SetDefaults(newItem.type);
                chest.item[slot].stack = newItem.stack;
                return true;
            }
        }

        return false;
    }
    
    private static bool SetItemWithChance(Chest chest, int slot, Item item, float chance)
    {
        if (Main.rand.NextFloat() < chance)
        {
            if (chest == null)
            {
                return false;
            }
            chest.item[slot].SetDefaults(item.type);
            chest.item[slot].stack = item.stack;
            return true;
        }

        return false;
    }
}