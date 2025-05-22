using Terraria.ModLoader;

namespace higharia;

public class RocketBootTweaker : ModPlayer
{
    public override void ResetEffects()
    {
        // You can either let vanilla set it to 7 internally
        // or explicitly do it yourself. This ensures each frame,
        // we start with the default rocketTimeMax = 7.
        Player.rocketTimeMax = 7;
    }

    public override void PostUpdateEquips()
    {
        // We'll check the player's accessory slots to see
        // which boots the player has. We want the *best* one
        // equipped, presumably. So we’ll look for Terraspark first,
        // then Frostspark, etc.
        
        // Accessory slots: armor indices [3..8] and also [10..15] in 1.4.4 if using more accessory slots.
        // We'll do a simple loop checking each accessory slot. 
        // If we find Terraspark, we set rocketTimeMax = 15, and break out. 
        // Otherwise we keep searching.

        for (int i = 3; i < 3 + Player.extraAccessorySlots + 5; i++)
        {
            var item = Player.armor[i];
            if (item == null || item.IsAir) 
                continue;

            switch (item.type)
            {
                case 5000: // Terraspark
                    Player.rocketTimeMax = 15;
                    // We found the best boots, no need to check for others
                    return;

                case 1862: // Frostspark
                    // If we haven't found Terraspark, this is next best
                    Player.rocketTimeMax = 13;
                    // Don't return here, because maybe the next slot has Terraspark
                    break;

                case 898: // Lightning
                    // If we haven't found better yet, set 11
                    // but keep scanning, in case Frostspark or Terraspark is next
                    if (Player.rocketTimeMax < 11) {
                        Player.rocketTimeMax = 11;
                    }
                    break;

                case 405: // Spectre
                    if (Player.rocketTimeMax < 9) {
                        Player.rocketTimeMax = 9;
                    }
                    break;

                // If it’s just Rocket Boots, do nothing
                // because vanilla already sets rocketTimeMax = 7 
                // (the default).
            }
        }
    }
}