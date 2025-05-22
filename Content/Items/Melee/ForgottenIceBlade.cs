using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia.Content.Items.Melee;

public class ForgottenIceBlade : ModItem, ILocalizedModType
{
    public new string LocalizationCategory => "Items.Melee";
    public override void SetDefaults() {
        Item.width = 28; // The item texture's width.
        Item.height = 38; // The item texture's height.

        Item.useStyle = ItemUseStyleID.Swing; // The useStyle of the Item.
        Item.useTime = 20; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
        Item.useAnimation = 20; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
        Item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button.

        Item.DamageType = DamageClass.Melee; // Whether your item is part of the melee class.
        Item.damage = 20; // The damage your item deals.
        Item.knockBack = 1; // The force of knockback of the weapon. Maximum is 20
        Item.crit = 0; // The critical strike chance the weapon has. The player, by default, has a 4% critical strike chance.

        Item.value = Item.buyPrice(0, 1); // The value of the weapon in copper coins.
        Item.rare = ItemRarityID.Orange; // Give this item our custom rarity.
        Item.UseSound = SoundID.Item1; // The sound when the weapon is being used.
    }

    public override void MeleeEffects(Player player, Rectangle hitbox) {
        if (Main.rand.NextBool(3)) {
            // Emit dusts when the sword is swung
            Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.IceRod);
        }
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
        // Inflict the OnFire debuff for 1 second onto any NPC/Monster that this hits.
        // 60 frames = 1 second
        target.AddBuff(BuffID.Frostburn2, 120);
    }
}