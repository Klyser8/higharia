using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia.Content.Items;

public class SilkenClump : ModItem
{
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }
    
    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 34;
        Item.value = Item.buyPrice(0, 0, 50);
        Item.rare = ItemRarityID.Pink;
    }
    
}