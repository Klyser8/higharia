using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia.Content.Items;

public class AncientSlimeStone : ModItem
{
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }
    
    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 44;
        Item.value = Item.buyPrice(0, 1, 0);
        Item.rare = ItemRarityID.LightRed;
        Item.maxStack = 9999;
    }
    
}