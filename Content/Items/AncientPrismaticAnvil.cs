using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia.Content.Items;

public class AncientPrismaticAnvil : ModItem
{
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.AncientPrismaticAnvil>());
        Item.value = Item.buyPrice(0, 2);
        Item.width = 30;
        Item.height = 18;
        Item.rare = ItemRarityID.Pink;
    }
}