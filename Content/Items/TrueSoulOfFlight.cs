﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia.Content.Items;

public class TrueSoulOfFlight : ModItem
{
    public override void SetStaticDefaults() {
        // Registers a vertical animation with 4 frames and each one will last 5 ticks (1/12 second)
        Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
        ItemID.Sets.AnimatesAsSoul[Item.type] = true; // Makes the item have an animation while in world (not held.). Use in combination with RegisterItemAnimation

        ItemID.Sets.ItemIconPulse[Item.type] = true; // The item pulses while in the player's inventory
        ItemID.Sets.ItemNoGravity[Item.type] = true; // Makes the item have no gravity

        Item.ResearchUnlockCount = 25; // Configure the amount of this item that's needed to research it in Journey mode.
    }

    public override void SetDefaults() {
        Item.width = 18;
        Item.height = 18;
        Item.maxStack = Item.CommonMaxStack;
        Item.value = 2000;
        Item.rare = ItemRarityID.Lime;
    }

    public override void PostUpdate() {
        Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale); // Makes this item glow when thrown out of inventory.
    }
}