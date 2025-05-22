using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia.Content.Items;

public class BloodyNote : ModItem
{
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }
    
    public override void SetDefaults()
    {
        Item.width = 26;
        Item.height = 28;
        Item.value = Item.buyPrice(0, 2, 0);
        Item.rare = ItemRarityID.LightRed;
    }
    
}