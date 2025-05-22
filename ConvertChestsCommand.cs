using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace higharia;

public class ConvertChestsCommand : ModCommand
{
    public override void Action(CommandCaller caller, string input, string[] args)
    {
        ChestLootTweaker.ConvertChests();
        caller.Reply("Chests converted!", Color.Green);
        caller.Reply("Invalid Command.", Color.Red);
    }

    public override string Command { get; } = "convertchests";
    public override CommandType Type { get; } = CommandType.Chat;
}