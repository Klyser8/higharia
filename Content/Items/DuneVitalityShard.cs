using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace higharia.Content.Items;

public class DuneVitalityShard : ModItem
{
    public static readonly int LifePerShard = 20;
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 3;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.LifeCrystal);
        Item.width = 30;
        Item.height = 30;
        Item.value = Item.buyPrice(0, 3, 50);
        Item.rare = ItemRarityID.Orange;
        Item.consumable = true;
    }

    public override bool CanUseItem(Player player)
    {
        return true;
    }

    public override bool? UseItem(Player player)
    {
        if (player.ConsumedLifeCrystals >= 15)
        {
            return null;
        }
        player.UseHealthMaxIncreasingItem(LifePerShard);
        player.ConsumedLifeCrystals++;
        return true;
    }
}