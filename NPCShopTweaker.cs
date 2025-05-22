using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia;

public class NPCShopTweaker : GlobalNPC
{
    public override void ModifyShop(NPCShop shop)
    {
        if (shop.NpcType == NPCID.BestiaryGirl)
        {
            if (!Main.hardMode)
            {
                RemoveItem(shop, ItemID.SquirrelHook);
            }
        } else if (shop.NpcType == NPCID.GoblinTinkerer)
        {
            RemoveItem(shop, ItemID.RocketBoots);
            RemoveItem(shop, ItemID.GrapplingHook);
        } else if (shop.NpcType == NPCID.Wizard)
        {
            RemoveItem(shop, ItemID.IceRod);
        }
        
        if (shop.NpcType == NPCID.Merchant)
        {
            AddItem(shop, ItemID.DynastyWood);
            AddItem(shop, ItemID.BlueDynastyShingles);
            AddItem(shop, ItemID.RedDynastyShingles);
        }

        if (shop.NpcType == NPCID.Steampunker)
        {
            RemoveItem(shop, ItemID.Clentaminator);
        }

        if (shop.NpcType == NPCID.SkeletonMerchant)
        {
            if (Main.moonPhase == 1 || Main.moonPhase == 2 || Main.moonPhase == 3 || Main.moonPhase == 4)
            {
                if (NPC.downedQueenSlime && shop.GetEntry(ItemID.Gradient) == null)
                {
                    shop.Add(ItemID.Gradient);
                }
            }
            else
            {
                if (Main.hardMode && shop.GetEntry(ItemID.FormatC) == null)
                {
                    shop.Add(ItemID.FormatC);
                }
            }
        }
    }
    
    private void RemoveItem(NPCShop shop, int itemToRemove)
    {
        shop.GetEntry(itemToRemove).Disable();
    }
    
    private void AddItem(NPCShop shop, int itemToAdd)
    {
        shop.Add(itemToAdd);
    }
}