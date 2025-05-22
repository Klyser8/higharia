using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using higharia.Content;               // for LootUtils
using higharia.Content.Items;
using higharia.Content.Items.Melee;
using higharia.Content.Items.Ranged; // for ForgottenIceBlade

namespace higharia
{
    public class MobLootTweaker : GlobalNPC
    {

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            // 1) Remove Hellfire from every single NPC
            LootUtils.ModifyItemInLoot(npcLoot, ItemID.HelFire);
            LootUtils.ModifyItemInLoot(npcLoot, ItemID.Amarok);

            // 2) Mimic variants: just remove the one or two IDs via the generic helper
            switch (npc.type)
            {
                case NPCID.Mimic:                   // normal
                    LootUtils.ModifyItemInLoot(npcLoot, ItemID.DualHook);
                    break;
                case NPCID.BigMimicCorruption:
                    LootUtils.ModifyItemInLoot(npcLoot, ItemID.WormHook);
                    break;
                case NPCID.BigMimicCrimson:
                    LootUtils.ModifyItemInLoot(npcLoot, ItemID.TendonHook);
                    LootUtils.ModifyItemInLoot(npcLoot, ItemID.SoulDrain);
                    break;
                case NPCID.BigMimicHallow:
                    LootUtils.ModifyItemInLoot(npcLoot, ItemID.IlluminantHook);
                    LootUtils.ModifyItemInLoot(npcLoot, ItemID.FlyingKnife, ModContent.ItemType<CrystallineKnife>());
                    break;

                // 3) Ice Mimic: replace Frostbrand with your ForgottenIceBlade
                case NPCID.IceMimic:
                    LootUtils.ModifyItemInLoot(npcLoot, ItemID.Frostbrand, ModContent.ItemType<ForgottenIceBlade>());
                    break;

                // 4) Medusa: needs custom remove + re-add behind a Mech condition
                case NPCID.Medusa:
                    // remove her vanilla head drop
                    npcLoot.RemoveWhere(rule =>
                        rule is CommonDrop cd && cd.itemId == ItemID.MedusaHead);

                    // re-add it only if at least one mech boss is downed
                    var mechCondition = new LeadingConditionRule(new Conditions.BeatAnyMechBoss());
                    mechCondition.OnSuccess(ItemDropRule.Common(ItemID.MedusaHead, 10));
                    npcLoot.Add(mechCondition);
                    break;
            }
        }
    }
}
