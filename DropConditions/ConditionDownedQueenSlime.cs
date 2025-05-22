using Terraria;
using Terraria.GameContent.ItemDropRules;

namespace higharia.DropConditions;

public class ConditionDownedQueenSlime : IItemDropRuleCondition
{
    
    public string GetConditionDescription()
    {
        return "After defeating Queen Slime";
    }

    public bool CanDrop(DropAttemptInfo info)
    {
        return NPC.downedQueenSlime;
    }

    public bool CanShowItemDropInUI()
    {
        return true;
    }
}