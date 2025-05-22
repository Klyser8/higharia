using System.Linq;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace higharia.Content
{
    public static class LootUtils
    {
        /// <summary>
        /// Removes every direct‐drop of oldItemId (if newItemId is null),
        /// or replaces them with newItemId (if newItemId has a value),
        /// then recurses through all chained rules to scrub or remap nested occurrences.
        /// Works for both chest/crate (ItemLoot) and NPC (NPCLoot).
        /// </summary>
        public static void ModifyItemInLoot(ItemLoot loot, int oldItemId, int? newItemId = null)
        {
            // 1) Top‐level direct drops: common, no‐luck common, or conditional drops
            if (newItemId == null)
            {
                loot.RemoveWhere(rule => IsDirectDropRule(rule, oldItemId));
            }
            else
            {
                foreach (var rule in loot.Get(false))
                {
                    switch (rule)
                    {
                        case CommonDrop cd when cd.itemId == oldItemId:
                            cd.itemId = newItemId.Value;
                            break;
                        case CommonDropNotScalingWithLuck cd2 when cd2.itemId == oldItemId:
                            cd2.itemId = newItemId.Value;
                            break;
                        case ItemDropWithConditionRule ic when ic.itemId == oldItemId:
                            ic.itemId = newItemId.Value;
                            break;
                    }
                }
            }

            // 2) Recurse through everything else
            foreach (var rule in loot.Get(false))
                ModifyItemInRuleTree(rule, oldItemId, newItemId);
        }

        public static void ModifyItemInLoot(NPCLoot loot, int oldItemId, int? newItemId = null)
        {
            if (newItemId == null)
            {
                loot.RemoveWhere(rule => IsDirectDropRule(rule, oldItemId));
            }
            else
            {
                foreach (var rule in loot.Get())
                {
                    switch (rule)
                    {
                        case CommonDrop cd when cd.itemId == oldItemId:
                            cd.itemId = newItemId.Value;
                            break;
                        case CommonDropNotScalingWithLuck cd2 when cd2.itemId == oldItemId:
                            cd2.itemId = newItemId.Value;
                            break;
                        case ItemDropWithConditionRule ic when ic.itemId == oldItemId:
                            ic.itemId = newItemId.Value;
                            break;
                    }
                }
            }

            foreach (var rule in loot.Get())
                ModifyItemInRuleTree(rule, oldItemId, newItemId);
        }

        // Helper: any rule that directly drops exactly one item by ID
        private static bool IsDirectDropRule(IItemDropRule rule, int id)
            => (rule is CommonDrop cd        && cd.itemId == id)
            || (rule is CommonDropNotScalingWithLuck cd2 && cd2.itemId == id)
            || (rule is ItemDropWithConditionRule ic     && ic.itemId == id);

        // Recursively scrub or remap nested occurrences in chained rules
        private static void ModifyItemInRuleTree(IItemDropRule rule, int oldId, int? newId)
        {
            if (rule is OneFromOptionsDropRule ofo)
            {
                if (newId == null)
                {
                    ofo.dropIds = ofo.dropIds.Where(x => x != oldId).ToArray();
                }
                else
                {
                    ofo.dropIds = ofo.dropIds
                        .Select(x => x == oldId ? newId.Value : x)
                        .ToArray();
                }
            }

            // (If you use ManyFromOptionsDropRule or other option‐lists, handle them here.)

            foreach (var chain in rule.ChainedRules)
                ModifyItemInRuleTree(chain.RuleToChain, oldId, newId);
        }
    }
}
