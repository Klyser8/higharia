using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia.FlightUI;

public class PlayerFlightUITracker : ModPlayer
{
    
    public override void PostUpdateEquips()
    {
        /*// If the player has a flight item, then show flight UI
        if (Main.dedServ)
        {
            return;
        }
        if (HasFlightItem())
        {
            ModContent.GetInstance<FlightUISystem>().ShowFlightUI();
        } else
        {
            ModContent.GetInstance<FlightUISystem>().HideFlightUI();
        }*/
    }

    private bool HasFlightItem()
    {
        for (int i = 3; i < 3 + Player.extraAccessorySlots + 5; i++)
        {
            var item = Player.armor[i];
            if (item == null || item.IsAir)
            {
                continue;
            }
            
            if (Higharia.FlightItems.Contains(item.type))
            {
                return true;
            }
        }

        return false;
    }
}