using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia;

public class ItemUseChanger : GlobalItem
{
    public override bool CanUseItem(Item item, Player player)
    {
        // Allow player to use life crystal only if a high enough stack.
        if (item.type == ItemID.LifeCrystal && player.statLifeMax < 400)
        {
            int requiredLifeCrystals = (player.statLifeMax - 100) / 40 + 1;
            requiredLifeCrystals = Math.Min(requiredLifeCrystals, 7); 
            bool canUse = item.stack >= requiredLifeCrystals;
            if (!canUse)
            {
                return false;
            }
            item.stack -= requiredLifeCrystals - 1;
            return true;
        }
        return base.CanUseItem(item, player);
    }

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        if (item.type == ItemID.LifeCrystal)
        {
            int requiredLifeCrystals = (Main.LocalPlayer.statLifeMax - 100) / 40 + 1;
            requiredLifeCrystals = Math.Min(requiredLifeCrystals, 7);
            TooltipLine tooltip;
            if (Main.LocalPlayer.statLifeMax >= 400)
            {
                tooltip = new TooltipLine(Higharia.Instance(), "crystalAmount", $"[c/cc0066:Max HP reached. Great job!]");
            }
            else
            {
                tooltip = new TooltipLine(Higharia.Instance(), "crystalAmount", $"Requires [c/cc0066:{requiredLifeCrystals}] to further increase HP.");
            }
            tooltips.Add(tooltip);
        }
    }
}