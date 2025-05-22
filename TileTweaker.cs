using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia;

public class TileTweaker : GlobalTile
{
    public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
    {
        if (type == TileID.Mythril || type == TileID.Orichalcum)
        {
            int mechBossesDefeated = 0;
            if (NPC.downedMechBoss1) mechBossesDefeated++;
            if (NPC.downedMechBoss2) mechBossesDefeated++;
            if (NPC.downedMechBoss3) mechBossesDefeated++;
            if (mechBossesDefeated < 1)
            {
                return false;
            }
        } else if (type == TileID.Adamantite || type == TileID.Titanium)
        {
            int mechBossesDefeated = 0;
            if (NPC.downedMechBoss1) mechBossesDefeated++;
            if (NPC.downedMechBoss2) mechBossesDefeated++;
            if (NPC.downedMechBoss3) mechBossesDefeated++;
            if (mechBossesDefeated < 2)
            {
                return false;
            }
        }
        return base.CanKillTile(i, j, type, ref blockDamaged);
    }

    public override bool CanExplode(int i, int j, int type)
    {
        if (type == TileID.Mythril || type == TileID.Orichalcum)
        {
            int mechBossesDefeated = 0;
            if (NPC.downedMechBoss1) mechBossesDefeated++;
            if (NPC.downedMechBoss2) mechBossesDefeated++;
            if (NPC.downedMechBoss3) mechBossesDefeated++;
            if (mechBossesDefeated < 1)
            {
                return false;
            }
        } else if (type == TileID.Adamantite || type == TileID.Titanium)
        {
            int mechBossesDefeated = 0;
            if (NPC.downedMechBoss1) mechBossesDefeated++;
            if (NPC.downedMechBoss2) mechBossesDefeated++;
            if (NPC.downedMechBoss3) mechBossesDefeated++;
            if (mechBossesDefeated < 2)
            {
                return false;
            }
        }
        return base.CanExplode(i, j, type);
    }
}