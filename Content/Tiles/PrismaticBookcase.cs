using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace higharia.Content.Tiles;

public class PrismaticBookcase : ModTile
{
    
    public override string Texture => "higharia/Content/Tiles/PrismaticBookcase";

    public override void SetStaticDefaults() {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoFail[Type] = true;
        Main.tileObsidianKill[Type] = true;
        Main.tileSolidTop[Type] = true;
        TileID.Sets.IgnoredByNpcStepUp[Type] = true;
        
        DustType = DustID.PurpleCrystalShard;
        AdjTiles = new int[] { TileID.Bookcases }; 
        
        
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
        TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 18 };
        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.addTile(Type);

        AddMapEntry(new Color(255, 192, 203), CreateMapEntryName());
    }
}