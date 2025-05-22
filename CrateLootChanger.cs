using System.Collections.Generic;
using System.Linq;
using higharia.DropConditions;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia;

public class CrateLootChanger : GlobalItem
{

    private static readonly int[] NormalCrates = {
        ItemID.WoodenCrate,
        ItemID.IronCrate,
        ItemID.GoldenCrate,
        ItemID.JungleFishingCrate,
        ItemID.CorruptFishingCrate,
        ItemID.CrimsonFishingCrate,
        ItemID.HallowedFishingCrate,
        ItemID.DungeonFishingCrate,
        ItemID.FloatingIslandFishingCrate,
        ItemID.FrozenCrate,
        ItemID.LavaCrate,
        ItemID.OasisCrate,
        ItemID.OceanCrate
    };
    
    private static readonly int[] HardCrates = {
        ItemID.WoodenCrateHard,
        ItemID.IronCrateHard,
        ItemID.GoldenCrateHard,
        ItemID.JungleFishingCrateHard,
        ItemID.CorruptFishingCrateHard,
        ItemID.CrimsonFishingCrateHard,
        ItemID.HallowedFishingCrateHard,
        ItemID.DungeonFishingCrateHard,
        ItemID.FloatingIslandFishingCrateHard,
        ItemID.FrozenCrateHard,
        ItemID.LavaCrateHard,
        ItemID.OasisCrateHard,
        ItemID.OceanCrateHard
    };
    
    private static readonly int[] HardmodeOres = {
        ItemID.CobaltOre,
        ItemID.CobaltBar,
        ItemID.PalladiumOre,
        ItemID.PalladiumBar,
        ItemID.MythrilOre,
        ItemID.MythrilBar,
        ItemID.OrichalcumOre,
        ItemID.OrichalcumBar,
        ItemID.AdamantiteOre,
        ItemID.AdamantiteBar,
        ItemID.TitaniumOre,
        ItemID.TitaniumBar
    };
    
    private static readonly int[] NormalmodeOres =
    {
        ItemID.CopperOre,
        ItemID.TinOre,
        ItemID.IronOre,
        ItemID.LeadOre,
        ItemID.SilverOre,
        ItemID.TungstenOre,
        ItemID.GoldOre,
        ItemID.PlatinumOre,
    };
    
    public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
    {
        if (!HardCrates.Contains(item.type))
            return;

        // 0) First, scrub out any unwanted existing ores
        var top = itemLoot.Get(false);
        foreach (var rule in top)
        {
            RemoveUnwantedItemsFromRule(rule, HardmodeOres);
            
        }

        // 1) Compute how many each crate should drop
        int cobaltMin, cobaltMax;
        int palladiumMin, palladiumMax;
        int mythrilMin, mythrilMax;
        int orichalcumMin, orichalcumMax;
        int adamantiteMin, adamantiteMax;
        int titaniumMin, titaniumMax;

        const float tier2Mul = 0.75f;

        switch (item.type)
        {
            case ItemID.WoodenCrateHard:
                cobaltMin       =  6; cobaltMax       = 12;
                palladiumMin    = (int)(   cobaltMin * tier2Mul);
                palladiumMax    = (int)(   cobaltMax * tier2Mul);
                mythrilMin      =  6; mythrilMax      = 12;
                orichalcumMin   = (int)(mythrilMin * tier2Mul);
                orichalcumMax   = (int)(mythrilMax * tier2Mul);
                adamantiteMin   =  4; adamantiteMax   =  8;
                titaniumMin     = (int)(adamantiteMin * tier2Mul);
                titaniumMax     = (int)(adamantiteMax * tier2Mul);
                break;

            case ItemID.GoldenCrateHard:
                cobaltMin     = 24; cobaltMax     = 48;
                palladiumMin  = (int)(   cobaltMin * tier2Mul);
                palladiumMax  = (int)(   cobaltMax * tier2Mul);
                mythrilMin    = 24; mythrilMax    = 48;
                orichalcumMin = (int)(mythrilMin * tier2Mul);
                orichalcumMax = (int)(mythrilMax * tier2Mul);
                adamantiteMin = 16; adamantiteMax = 32;
                titaniumMin   = (int)(adamantiteMin * tier2Mul);
                titaniumMax   = (int)(adamantiteMax * tier2Mul);
                break;

            default:
                // all the other “medium” hardmode crates
                cobaltMin     = 12; cobaltMax     = 24;
                palladiumMin  = (int)(   cobaltMin * tier2Mul);
                palladiumMax  = (int)(   cobaltMax * tier2Mul);
                mythrilMin    = 12; mythrilMax    = 24;
                orichalcumMin = (int)(mythrilMin * tier2Mul);
                orichalcumMax = (int)(mythrilMax * tier2Mul);
                adamantiteMin =  8; adamantiteMax = 16;
                titaniumMin   = (int)(adamantiteMin * tier2Mul);
                titaniumMax   = (int)(adamantiteMax * tier2Mul);
                break;
        }

        // Queen Slime beaten?
        var queenRule = new LeadingConditionRule(new ConditionDownedQueenSlime());
        queenRule.OnSuccess(ItemDropRule.Common(ItemID.CobaltOre,    4, cobaltMin,     cobaltMax));
        queenRule.OnSuccess(ItemDropRule.Common(ItemID.PalladiumOre, 8, palladiumMin, palladiumMax));
        itemLoot.Add(queenRule);

        // Two mech bosses beaten?
        var twoMechRule = new LeadingConditionRule(new ConditionMechBossCount(2));
        twoMechRule.OnSuccess(ItemDropRule.Common(ItemID.MythrilOre,    2, mythrilMin,    mythrilMax));
        twoMechRule.OnSuccess(ItemDropRule.Common(ItemID.OrichalcumOre, 4, orichalcumMin, orichalcumMax));
        itemLoot.Add(twoMechRule);

        // Three mech bosses beaten?
        var threeMechRule = new LeadingConditionRule(new ConditionMechBossCount(3));
        threeMechRule.OnSuccess(ItemDropRule.Common(ItemID.AdamantiteOre, 4, adamantiteMin, adamantiteMax));
        threeMechRule.OnSuccess(ItemDropRule.Common(ItemID.TitaniumOre,   8, titaniumMin,   titaniumMax));
        itemLoot.Add(threeMechRule);

        // Fallback: if none of the above ran, drop one normal‐mode ore
        var fallback = new LeadingConditionRule(new ConditionMechBossCount(0));
        var oreFallback = new OneFromOptionsDropRule(1, 1, NormalmodeOres);
        fallback.OnSuccess(oreFallback);
        itemLoot.Add(fallback);
    }


    /// <summary>
    /// Recursively visits each rule (and its children) and removes any occurrences
    /// of certain items (by ID). You can expand this to handle more rule types if needed.
    /// </summary>
    private void RemoveUnwantedItemsFromRule(IItemDropRule rule, int[] itemIdsToRemove)
    {
        // 1) Handle "OneFromRulesRule": This rule has an array of sub-rules in `options`.
        if (rule is OneFromRulesRule ofr)
        {
            // Filter out any sub-rule that is dropping an unwanted item
            var filteredList = new List<IItemDropRule>();
            foreach (var subRule in ofr.options)
            {
                // If it's a CommonDrop with an item we want to remove, skip it
                if (subRule is CommonDrop cd && itemIdsToRemove.Contains(cd.itemId))
                {
                    continue;
                }

                // Keep the sub-rule, but also recurse into it to remove deeper children
                filteredList.Add(subRule);
                RemoveUnwantedItemsFromRule(subRule, itemIdsToRemove);
            }
            ofr.options = filteredList.ToArray();
        }

        // 2) Handle "SequentialRulesNotScalingWithLuckRule" or "SequentialRulesRule"
        //    by recursing into each of its child rules
        else if (rule is SequentialRulesNotScalingWithLuckRule seq)
        {
            foreach (var childRule in seq.rules)
            {
                RemoveUnwantedItemsFromRule(childRule, itemIdsToRemove);
            }
        }
        else if (rule is SequentialRulesRule seq2)
        {
            foreach (var childRule in seq2.rules)
            {
                RemoveUnwantedItemsFromRule(childRule, itemIdsToRemove);
            }
        }

        // 3) Handle "AlwaysAtleastOneSuccessDropRule"
        else if (rule is AlwaysAtleastOneSuccessDropRule always)
        {
            foreach (var childRule in always.rules)
            {
                RemoveUnwantedItemsFromRule(childRule, itemIdsToRemove);
            }
        }

        // 4) Finally, check the "ChainedRules" of any rule type. 
        //    Some rules chain additional sub-rules.
        foreach (var chain in rule.ChainedRules)
        {
            RemoveUnwantedItemsFromRule(chain.RuleToChain, itemIdsToRemove);
        }
    }
}