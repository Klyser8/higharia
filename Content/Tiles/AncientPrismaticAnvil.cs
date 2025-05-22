using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace higharia.Content.Tiles;

public class AncientPrismaticAnvil : ModTile
{
    
    public override string Texture => "higharia/Content/Tiles/AncientPrismaticAnvil";

    public override void SetStaticDefaults() {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoFail[Type] = true;
        Main.tileObsidianKill[Type] = true;
        Main.tileSolidTop[Type] = true;
        TileID.Sets.IgnoredByNpcStepUp[Type] = true;
        
        DustType = DustID.PinkCrystalShard;
        AdjTiles = new int[] { TileID.Anvils }; 
        
        
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
        TileObjectData.newTile.DrawYOffset = 2;
        TileObjectData.addTile(Type);

        AddMapEntry(new Color(228, 77, 225), CreateMapEntryName());
    }
}