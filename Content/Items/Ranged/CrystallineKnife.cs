using higharia.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia.Content.Items.Ranged;

public class CrystallineKnife : ModItem, ILocalizedModType
{
    public new string LocalizationCategory => "Items.Ranged";
    public override void SetDefaults() {
        // Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools

        // Common Properties
        Item.rare = ItemRarityID.LightRed;
        Item.value = Item.sellPrice(0, 4);
        Item.maxStack = 1;

        // Use Properties
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 20;
        Item.useTime = 20;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;

        // Weapon Properties			
        Item.damage = 47;
        Item.knockBack = 4f;
        Item.noUseGraphic = true; // The item should not be visible when used
        Item.noMelee = true; // The projectile will do the damage and not the item
        Item.DamageType = DamageClass.Melee;

        // Projectile Properties
        Item.shootSpeed = 16f;
        Item.shoot = ModContent.ProjectileType<CrystallineKnifeProjectile>(); // The projectile that will be thrown
    }
    
}