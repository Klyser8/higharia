using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia.Content.Projectiles;

public class CrystallineKnifeProjectile : ModProjectile
{
    
    public override void SetDefaults()
    {
        Projectile.arrow = false;
        Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
        Projectile.width = 16;
        Projectile.height = 16;
        Projectile.friendly = true;
        Projectile.penetrate = 3;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.light = 0.25f;
        AIType = ProjectileID.ThrowingKnife;
    }

    public override void OnKill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
        
        Vector2 usePos = Projectile.position; // Position to use for dusts

        // Offset the rotation by 90 degrees because the sprite is oriented vertically.
        Vector2 rotationVector = (Projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
        usePos += rotationVector * 16f;
        for (int i = 0; i < 20; i++)
        {
            Dust dust = Dust.NewDustDirect(usePos, Projectile.width, Projectile.height,
                DustID.PurpleCrystalShard);
            dust.position = (dust.position + Projectile.Center) / 2f;
            dust.velocity += rotationVector * 2f;
            dust.velocity *= 0.5f;
            dust.noGravity = true;
            dust.scale = 2.0f;
        }
        base.OnKill(timeLeft);
    }

    public override void PostAI()
    {
        base.PostAI();
        // Spawn a trail of dust behind the projectile
        Vector2 usePos = Projectile.position; // Position to use for dusts
        // Offset the rotation by 90 degrees because the sprite is oriented vertically.
        Vector2 rotationVector = (Projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
        usePos += rotationVector * 16f;
        Dust dust = Dust.NewDustDirect(usePos, Projectile.width, Projectile.height,
            DustID.PurpleCrystalShard);
        dust.position = (dust.position + Projectile.Center) / 2f;
        dust.velocity += rotationVector * 2f;
        dust.velocity *= 0.5f;
        dust.noGravity = true;
        dust.scale = 1.5f; // Scale the dust to make it larger
        dust.fadeIn = 1.5f; // Fade in the dust over time
    }
}