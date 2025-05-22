using Terraria.ID;
using Terraria.ModLoader;

namespace higharia.Content.Items;

public class PrismaticBookcase : ModItem
{
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.PrismaticBookcase>());
        Item.value = 5000;
        Item.width = 48;
        Item.height = 64;
        Item.rare = ItemRarityID.Pink;
    }
}