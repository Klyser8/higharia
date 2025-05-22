using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace higharia;

public class EffectsUtil
{
    public static void DrawAfterimagesCentered(Projectile proj, int mode, Color lightColor, int typeOneIncrement = 1, Texture2D texture = null, bool drawCentered = true)
        {
            if (texture is null)
                texture = TextureAssets.Projectile[proj.type].Value;

            int frameHeight = texture.Height / Main.projFrames[proj.type];
            int frameY = frameHeight * proj.frame;
            float scale = proj.scale;
            float rotation = proj.rotation;

            Rectangle rectangle = new Rectangle(0, frameY, texture.Width, frameHeight);
            Vector2 origin = rectangle.Size() / 2f;

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (proj.spriteDirection == -1)
                spriteEffects = SpriteEffects.FlipHorizontally;

            // If no afterimages are drawn due to an invalid mode being specified, ensure the projectile itself is drawn anyway.
            bool failedToDrawAfterimages = false;
            
            Vector2 centerOffset = drawCentered ? proj.Size / 2f : Vector2.Zero;
            Color alphaColor = proj.GetAlpha(lightColor);
            switch (mode)
            {
                // Standard afterimages. No customizable features other than total afterimage count.
                // Type 0 afterimages linearly scale down from 100% to 0% opacity. Their color and lighting is equal to the main projectile's.
                case 0:
                    for (int i = 0; i < proj.oldPos.Length; ++i)
                    {
                        Vector2 drawPos = proj.oldPos[i] + centerOffset - Main.screenPosition + new Vector2(0f, proj.gfxOffY);
                        // DO NOT REMOVE THESE "UNNECESSARY" FLOAT CASTS. THIS WILL BREAK THE AFTERIMAGES.
                        Color color = alphaColor * ((float)(proj.oldPos.Length - i) / (float)proj.oldPos.Length);
                        Main.spriteBatch.Draw(texture, drawPos, new Rectangle?(rectangle), color, rotation, origin, scale, spriteEffects, 0f);
                    }
                    break;

                // Paladin's Hammer style afterimages. Can be optionally spaced out further by using the typeOneDistanceMultiplier variable.
                // Type 1 afterimages linearly scale down from 66% to 0% opacity. They otherwise do not differ from type 0.
                case 1:
                    // Safety check: the loop must increment
                    int increment = Math.Max(1, typeOneIncrement);
                    Color drawColor = alphaColor;
                    int afterimageCount = ProjectileID.Sets.TrailCacheLength[proj.type];
                    float afterimageColorCount = (float)afterimageCount * 1.5f;
                    int k = 0;
                    while (k < afterimageCount)
                    {
                        Vector2 drawPos = proj.oldPos[k] + centerOffset - Main.screenPosition + new Vector2(0f, proj.gfxOffY);
                        // DO NOT REMOVE THESE "UNNECESSARY" FLOAT CASTS EITHER.
                        if (k > 0)
                        {
                            float colorMult = (float)(afterimageCount - k);
                            drawColor *= colorMult / afterimageColorCount;
                        }
                        Main.spriteBatch.Draw(texture, drawPos, new Rectangle?(rectangle), drawColor, rotation, origin, scale, spriteEffects, 0f);
                        k += increment;
                    }
                    break;

                // Standard afterimages with rotation. No customizable features other than total afterimage count.
                // Type 2 afterimages linearly scale down from 100% to 0% opacity. Their color and lighting is equal to the main projectile's.
                case 2:
                    for (int i = 0; i < proj.oldPos.Length; ++i)
                    {
                        float afterimageRot = proj.oldRot[i];
                        SpriteEffects sfxForThisAfterimage = proj.oldSpriteDirection[i] == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

                        Vector2 drawPos = proj.oldPos[i] + centerOffset - Main.screenPosition + new Vector2(0f, proj.gfxOffY);
                        // DO NOT REMOVE THESE "UNNECESSARY" FLOAT CASTS. THIS WILL BREAK THE AFTERIMAGES.
                        Color color = alphaColor * ((float)(proj.oldPos.Length - i) / (float)proj.oldPos.Length);
                        Main.spriteBatch.Draw(texture, drawPos, new Rectangle?(rectangle), color, afterimageRot, origin, scale, sfxForThisAfterimage, 0f);
                    }
                    break;

                default:
                    failedToDrawAfterimages = true;
                    break;
            }

            // Draw the projectile itself. Only do this if no afterimages are drawn because afterimage 0 is the projectile itself.
            if (ProjectileID.Sets.TrailCacheLength[proj.type] <= 0 || failedToDrawAfterimages)
            {
                Vector2 startPos = drawCentered ? proj.Center : proj.position;
                Main.spriteBatch.Draw(texture, startPos - Main.screenPosition + new Vector2(0f, proj.gfxOffY), rectangle, proj.GetAlpha(lightColor), rotation, origin, scale, spriteEffects, 0f);
            }
        }
}