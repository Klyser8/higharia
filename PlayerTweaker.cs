using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia;

public class PlayerTweaker : ModPlayer
{
    public override void PostUpdateEquips()
    {
        if (HasHorseshoeAccessory())
        {
            Player.noFallDmg = false;
        }
        
    }

    /*public override void OnHurt(Player.HurtInfo info)
    {
        if (info.DamageSource.SourceOtherIndex == 0 && HasHorseshoeAccessory()) //Fall damage
        {
            // print
            Higharia.Instance().Logger.Debug("Reducing fall damage by 50%");
            info.SourceDamage *= (int) 0.5f;
        }
        base.OnHurt(info);
    }*/

    public override void ModifyHurt(ref Player.HurtModifiers modifiers)
    {
        var sourceOtherIndex = modifiers.DamageSource.SourceOtherIndex;
        if (sourceOtherIndex == 0 && HasHorseshoeAccessory()) //Fall damage
        {
            // print
            Higharia.Instance().Logger.Debug("Reducing fall damage by 50%");
            modifiers.SourceDamage *= 0.5f;
        }
        base.ModifyHurt(ref modifiers);
    }

    private bool HasHorseshoeAccessory()
    {
        for (int i = 3; i < 3 + Player.armor.Length; i++)
        {
            var item = Player.armor[i];
            if (item == null || item.IsAir)
            {
                continue;
            }

            if (item.type == ItemID.LuckyHorseshoe ||
                item.type == ItemID.BlueHorseshoeBalloon ||
                item.type == ItemID.WhiteHorseshoeBalloon ||
                item.type == ItemID.YellowHorseshoeBalloon ||
                item.type == ItemID.ObsidianHorseshoe ||
                item.type == ItemID.HorseshoeBundle ||
                item.type == ItemID.BalloonHorseshoeFart ||
                item.type == ItemID.BalloonHorseshoeHoney ||
                item.type == ItemID.BalloonHorseshoeSharkron)
            {
                return true;
            }
        }
        return false;
    }
    
    
}