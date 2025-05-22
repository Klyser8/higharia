using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia;

public class MobStatTweaker : GlobalNPC
{
    
    public override void SetDefaults(NPC npc)
    {
        if (!NPC.downedGolemBoss)
        {
            return;
        }

        if (npc.type == NPCID.WyvernHead)
        {
            npc.lifeMax = 36000;
            npc.damage = 110;
            npc.defense = 15;
            npc.GivenName = "Arch Wyvern";
        } else if (npc.type is NPCID.WyvernBody or NPCID.WyvernBody2 or NPCID.WyvernBody3)
        {
            npc.lifeMax = 36000;
            npc.damage = 70;
            npc.defense = 30;
            npc.GivenName = "Arch Wyvern";
        } else if (npc.type == NPCID.WyvernLegs)
        {
            npc.lifeMax = 36000;
            npc.damage = 70;
            npc.defense = 40;
            npc.GivenName = "Arch Wyvern";
        }
    }

    public override void OnKill(NPC npc)
    {
        base.OnKill(npc);
        if (npc.type == NPCID.SkeletronPrime || npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism || 
            npc.type == NPCID.TheDestroyer || npc.type == NPCID.TheDestroyerBody || npc.type == NPCID.TheDestroyerTail)
        {
            int mechBossesDefeated = 0;
            if (NPC.downedMechBoss1) mechBossesDefeated++;
            if (NPC.downedMechBoss2) mechBossesDefeated++;
            if (NPC.downedMechBoss3) mechBossesDefeated++;
            
            if (mechBossesDefeated == 0)
            {
                Main.NewText("With a mechanical guardian vanquished, the curse upon Mythril and Orichalcum is shattered.", 194, 141, 203);
            }
            if (mechBossesDefeated == 1) // TODO test if message works
            {
                Main.NewText("With two mechanical guardians vanquished, the curse upon Adamantite and Titanium is shattered.", 194, 141, 203);
            }
        }
    }

    public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
    {
        // Check if golem was defeated once in this world
        if (!NPC.downedGolemBoss)
        {
            return true;
        } 
        if (npc.type == NPCID.WyvernHead)
        {
            var texture2D = ModContent.Request<Texture2D>("higharia/Content/NPC/ArchWyvernHead").Value;
            Main.EntitySpriteDraw(texture2D, npc.Center - Main.screenPosition, null, 
                drawColor, npc.rotation, texture2D.Size() / 2f, 1f, SpriteEffects.None);
            return false;
        }
        if (npc.type == NPCID.WyvernLegs)
        {
            var texture2D = ModContent.Request<Texture2D>("higharia/Content/NPC/ArchWyvernLegs").Value;
            Main.EntitySpriteDraw(texture2D, npc.Center - Main.screenPosition, null, 
                drawColor, npc.rotation, texture2D.Size() / 2f, 1f, SpriteEffects.None);
            return false;
        }
        if (npc.type == NPCID.WyvernTail)
        {
            var texture2D = ModContent.Request<Texture2D>("higharia/Content/NPC/ArchWyvernTail").Value;
            Main.EntitySpriteDraw(texture2D, npc.Center - Main.screenPosition, null, 
                drawColor, npc.rotation, texture2D.Size() / 2f, 1f, SpriteEffects.None);
            return false;
        }
        if (npc.type == NPCID.WyvernBody)
        {
            var texture2D = ModContent.Request<Texture2D>("higharia/Content/NPC/ArchWyvernBody1").Value;
            Main.EntitySpriteDraw(texture2D, npc.Center - Main.screenPosition, null, 
                drawColor, npc.rotation, texture2D.Size() / 2f, 1f, SpriteEffects.None);
            return false;
        }
        if (npc.type == NPCID.WyvernBody2)
        {
            var texture2D = ModContent.Request<Texture2D>("higharia/Content/NPC/ArchWyvernBody2").Value;
            Main.EntitySpriteDraw(texture2D, npc.Center - Main.screenPosition, null, 
                drawColor, npc.rotation, texture2D.Size() / 2f, 1f, SpriteEffects.None);
            return false;
        }
        if (npc.type == NPCID.WyvernBody3)
        {
            var texture2D = ModContent.Request<Texture2D>("higharia/Content/NPC/ArchWyvernBody3").Value;
            Main.EntitySpriteDraw(texture2D, npc.Center - Main.screenPosition, null, 
                drawColor, npc.rotation, texture2D.Size() / 2f, 1f, SpriteEffects.None);
            return false;
        }
        return true;
    }
}