using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia.Content.Projectiles
{
    public class FrigidflameBoltProjectile : ModProjectile
    {
        // 1) Track slow-down time & bounces
        private int timeSinceLastBounce = 0;
        private const int timeToHalt = 240; // 4 * 60 ticks
        private int bounceCount = 0;
        private const int maxBounces = 7;

        // We'll store initial speed after each bounce, so we know what speed we're slowing from.
        private float startingSpeed = 0f;

        public new string LocalizationCategory => "Projectiles.Magic";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 2;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 28;
            Projectile.friendly = true;
            Projectile.alpha = 255;
            Projectile.penetrate = 7;
            Projectile.timeLeft = 480;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
        }

        public override void OnSpawn(IEntitySource source)
        {
            // Record the initial speed on spawn
            startingSpeed = Projectile.velocity.Length();
        }

        public override void AI()
        {
            // Fade-in logic
            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= 25;
                if (Projectile.alpha < 0)
                    Projectile.alpha = 0;
            }

            // Simple lighting
            Lighting.AddLight(
                Projectile.Center,
                (255 - Projectile.alpha) * 0.45f / 255f,
                (255 - Projectile.alpha) * 0.2f / 255f,
                (255 - Projectile.alpha) * 0.1f / 255f
            );

            // Increase "time since last bounce"
            timeSinceLastBounce++;

            // Slow down over 5 seconds
            if (timeSinceLastBounce < timeToHalt)
            {
                float progress = (float)timeSinceLastBounce / timeToHalt; // 0.0 -> 1.0
                float factor = 1f - progress;                              // 1.0 -> 0.0

                if (Projectile.velocity != Vector2.Zero)
                {
                    Vector2 dir = Projectile.velocity.SafeNormalize(Vector2.Zero);
                    float newSpeed = startingSpeed * factor;
                    Projectile.velocity = dir * newSpeed;
                }
            }
            else
            {
                // We’ve reached 5 seconds => set velocity to 0 and explode
                if (Projectile.velocity != Vector2.Zero)
                {
                    Projectile.velocity = Vector2.Zero;
                    // Explode using the projectile's damage
                    Explode(baseDamage: Projectile.damage, killSelf: true);
                }
            }

            // Triple the dust area? 
            // (Your code scaled it differently. Adjust if you want a truly bigger area.)
            int dustAreaWidth = (int)Math.Round((Projectile.width / 2.0) * 2);
            int dustAreaHeight = (int)Math.Round((Projectile.height / 2.0) * 2);

            float offsetX = -(dustAreaWidth - Projectile.width) / 2f;
            float offsetY = -(dustAreaHeight - Projectile.height) / 2f;

            for (int i = 0; i < 4; i++)
            {
                float shortXVel = Projectile.velocity.X / 3f * i;
                float shortYVel = Projectile.velocity.Y / 3f * i;

                int fireDustIndex = Dust.NewDust(
                    new Vector2(Projectile.position.X + offsetX, Projectile.position.Y + offsetY),
                    dustAreaWidth,
                    dustAreaHeight,
                    DustID.InfernoFork,
                    0f,
                    0f,
                    100,
                    default,
                    1.2f
                );
                int frostDustIndex = Dust.NewDust(
                    new Vector2(Projectile.position.X + offsetX, Projectile.position.Y + offsetY),
                    dustAreaWidth,
                    dustAreaHeight,
                    DustID.Frost,
                    0f,
                    0f,
                    100,
                    default,
                    1.2f
                );

                Dust finalFireDust = Main.dust[fireDustIndex];
                finalFireDust.noGravity = true;
                finalFireDust.velocity *= 0.1f;
                finalFireDust.velocity += Projectile.velocity * 0.1f;
                finalFireDust.position.X -= shortXVel;
                finalFireDust.position.Y -= shortYVel;

                Dust finalFrostDust = Main.dust[frostDustIndex];
                finalFrostDust.noGravity = true;
                finalFrostDust.velocity *= 0.1f;
                finalFrostDust.velocity += Projectile.velocity * 0.1f;
                finalFrostDust.position.X -= shortXVel;
                finalFrostDust.position.Y -= shortYVel;
            }

            // Low chance to spawn smaller dust
            if (Main.rand.NextBool(10))
            {
                int fireDustSmol = Dust.NewDust(
                    new Vector2(Projectile.position.X + offsetX, Projectile.position.Y + offsetY),
                    dustAreaWidth,
                    dustAreaHeight,
                    DustID.InfernoFork,
                    0f,
                    0f,
                    100,
                    default,
                    0.6f
                );
                Main.dust[fireDustSmol].velocity *= 0.25f;
                Main.dust[fireDustSmol].velocity += Projectile.velocity * 0.5f;
            }

            // Rotation
            Projectile.rotation += 0.3f * Projectile.direction;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            EffectsUtil.DrawAfterimagesCentered(Projectile, ProjectileID.Sets.TrailingMode[Projectile.type], lightColor, 1);
            return false;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            bounceCount++;
            if (bounceCount > maxBounces)
            {
                Explode(baseDamage: Projectile.damage, killSelf: true);
                return false;
            }

            // Standard tile reflection
            if (Projectile.velocity.X != oldVelocity.X)
                Projectile.velocity.X = -oldVelocity.X;
            if (Projectile.velocity.Y != oldVelocity.Y)
                Projectile.velocity.Y = -oldVelocity.Y;

            // Reset slowdown timer, set new "starting speed"
            timeSinceLastBounce = 0;
            startingSpeed = Projectile.velocity.Length();

            SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item45, Projectile.Center);
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(
                    Projectile.position + Projectile.velocity,
                    Projectile.width,
                    Projectile.height,
                    DustID.InfernoFork,
                    Projectile.oldVelocity.X * 0.5f,
                    Projectile.oldVelocity.Y * 0.5f
                );
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Apply OnFire to the directly hit NPC
            target.AddBuff(BuffID.Frostburn2, 300);
            target.AddBuff(BuffID.OnFire3, 300);

            // Explode immediately (using the actual hit damage)
            Explode(baseDamage: damageDone, killSelf: true, target.whoAmI);
        }

        // ----------------------------------------
        // HELPER METHOD FOR EXPLOSION ON DEMAND
        // ----------------------------------------
        private void Explode(int baseDamage, bool killSelf, int hitNPC = -1)
        {
            float explosionRadius = 3f * 16f;
            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC otherNpc = Main.npc[i];
                if (otherNpc.active && otherNpc.CanBeChasedBy() && otherNpc.WithinRange(Projectile.Center, explosionRadius) && i != hitNPC)
                {
                    NPC.HitInfo hitInfo = new NPC.HitInfo
                    {
                        Damage = baseDamage,
                        Knockback = 7f,
                        Crit = false,
                        HitDirection = (Projectile.Center.X < otherNpc.Center.X) ? 1 : -1
                    };
                    otherNpc.StrikeNPC(hitInfo);
                    otherNpc.AddBuff(BuffID.OnFire3, 300);
                    otherNpc.AddBuff(BuffID.Frostburn2, 300);
                }
            }

            // 2) Make a satisfying fire + frost particle burst
            //    Feel free to adjust dust count and scale
            int totalDust = 60;
            for (int d = 0; d < totalDust; d++)
            {
                // Randomly pick frost or fire dust
                int dustType = Main.rand.NextBool() ? DustID.Frost : DustID.InfernoFork;
                Vector2 dustVel = new Vector2(
                    Main.rand.NextFloat(-4f, 4f),
                    Main.rand.NextFloat(-4f, 4f)
                );

                int dustIndex = Dust.NewDust(
                    Projectile.Center,   // position
                    1, 1,                // width/height of dust area
                    dustType,
                    dustVel.X,
                    dustVel.Y,
                    100,
                    default,
                    1.5f
                );
                Dust dust = Main.dust[dustIndex];
                dust.noGravity = true;
            }

            // 3) Finally kill the projectile if requested
            if (killSelf && Projectile.active)
            {
                Projectile.Kill();
            }
        }
    }
}
