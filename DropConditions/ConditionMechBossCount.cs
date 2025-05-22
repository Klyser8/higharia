using Terraria;
using Terraria.GameContent.ItemDropRules;

namespace higharia.DropConditions;

public class ConditionMechBossCount : IItemDropRuleCondition
{

    private readonly int _requiredCount;
    
    public ConditionMechBossCount(int requiredCount) => _requiredCount = requiredCount;
    
    public string GetConditionDescription()
    {
        return $"After defeating {_requiredCount} mechanical boss" 
               + (_requiredCount > 1 ? "es" : "");
    }

    public bool CanDrop(DropAttemptInfo info)
    {
        int downed = (NPC.downedMechBoss1 ? 1 : 0)
                     + (NPC.downedMechBoss2 ? 1 : 0)
                     + (NPC.downedMechBoss3 ? 1 : 0);
        return downed >= _requiredCount;
    }

    public bool CanShowItemDropInUI()
    {
        return true;
    }
}