﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia.Content.Projectiles;

public class LeechDaggerProjectile : ModProjectile
{

    public const int FadeInDuration = 13;
    public const int FadeOutDuration = 8;

    public const int TotalDuration = 30;

    public float CollisionWidth => 10f * Projectile.scale;
    
    public int FadeInTimer
    {
        get => (int)Projectile.ai[0];
        set => Projectile.ai[0] = value;
    }

    public override void SetDefaults()
    {
        Projectile.Size = new Vector2(18); // This sets width and height to the same value (important when projectiles can rotate)
        Projectile.aiStyle = ProjAIStyleID.ShortSword; // This is the projectile's AI
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.tileCollide = false;
        Projectile.scale = 1.25f;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.ownerHitCheck = true; // Prevents hits through tiles. Most melee weapons that use projectiles have this
        Projectile.extraUpdates = 1; // Update 1+extraUpdates times per tick
        Projectile.timeLeft = 360; // This value does not matter since we manually kill it earlier, it just has to be higher than the duration we use in AI
        Projectile.hide = true; // Important when used alongside player.heldProj. "Hidden" projectiles have special draw conditions
    }

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
	    // Get the player who shot the projectile
		Player player = Main.player[Projectile.owner];
		int healAmount = damageDone / 5;
		player.Heal(healAmount);
    }

    public override void AI() {
		Player player = Main.player[Projectile.owner];

		FadeInTimer += 1;
		if (FadeInTimer >= TotalDuration) {
			// Kill the projectile if it reaches it's intended lifetime
			Projectile.Kill();
			return;
		}

		// Important so that the sprite draws "in" the player's hand and not fully in front or behind the player
		player.heldProj = Projectile.whoAmI;

		// Fade in and out
		// GetLerpValue returns a value between 0f and 1f - if clamped is true - representing how far Timer got along the "distance" defined by the first two parameters
		// The first call handles the fade in, the second one the fade out.
		// Notice the second call's parameters are swapped, this means the result will be reverted
		Projectile.Opacity = Utils.GetLerpValue(0f, FadeInDuration, FadeInTimer, clamped: true) * Utils.GetLerpValue(TotalDuration, TotalDuration - FadeOutDuration, FadeInTimer, clamped: true);

		// Keep locked onto the player, but extend further based on the given velocity (Requires ShouldUpdatePosition returning false to work)
		Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter, reverseRotation: false, addGfxOffY: false);
		Projectile.Center = playerCenter + Projectile.velocity * (FadeInTimer - 1f);

		// Set spriteDirection based on moving left or right. Left -1, right 1
		Projectile.spriteDirection = (Vector2.Dot(Projectile.velocity, Vector2.UnitX) >= 0f).ToDirectionInt();

		// Point towards where it is moving, applied offset for top right of the sprite respecting spriteDirection
		Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

		// The code in this method is important to align the sprite with the hitbox how we want it to
		SetVisualOffsets();
	}

	private void SetVisualOffsets() {
		// 32 is the sprite size (here both width and height equal)
		const int halfSpriteWidth = 42 / 2;
		const int halfSpriteHeight = 42 / 2;

		int halfProjWidth = Projectile.width / 2;
		int halfProjHeight = Projectile.height / 2;

		// Vanilla configuration for "hitbox in middle of sprite"
		DrawOriginOffsetX = 0;
		DrawOffsetX = -(halfSpriteWidth - halfProjWidth);
		DrawOriginOffsetY = -(halfSpriteHeight - halfProjHeight);

		// Vanilla configuration for "hitbox towards the end"
		//if (Projectile.spriteDirection == 1) {
		//	DrawOriginOffsetX = -(HalfProjWidth - HalfSpriteWidth);
		//	DrawOffsetX = (int)-DrawOriginOffsetX * 2;
		//	DrawOriginOffsetY = 0;
		//}
		//else {
		//	DrawOriginOffsetX = (HalfProjWidth - HalfSpriteWidth);
		//	DrawOffsetX = 0;
		//	DrawOriginOffsetY = 0;
		//}
	}
	
	public override bool ShouldUpdatePosition() {
		// Update Projectile.Center manually
		return false;
	}

	public override void CutTiles() {
		// "cutting tiles" refers to breaking pots, grass, queen bee larva, etc.
		DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
		Vector2 start = Projectile.Center;
		Vector2 end = start + Projectile.velocity.SafeNormalize(-Vector2.UnitY) * 10f;
		Utils.PlotTileLine(start, end, CollisionWidth, DelegateMethods.CutTiles);
	}

	public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox) {
		// "Hit anything between the player and the tip of the sword"
		// shootSpeed is 2.1f for reference, so this is basically plotting 12 pixels ahead from the center
		Vector2 start = Projectile.Center;
		Vector2 end = start + Projectile.velocity * 22f;
		float collisionPoint = 0f; // Don't need that variable, but required as parameter
		return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), start, end, CollisionWidth, ref collisionPoint);
	}

}