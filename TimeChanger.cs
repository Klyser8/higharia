using Terraria.ModLoader;

namespace higharia;

public class TimeChanger : ModSystem
{

    public override void ModifyTimeRate(ref double timeRate, ref double tileUpdateRate, ref double eventUpdateRate)
    {
        timeRate *= 0.33;
    }

    public override void PostAddRecipes()
    {
        
    }
}