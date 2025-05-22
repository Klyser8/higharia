using System.Collections.Generic;
using higharia.Content.Projectiles;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia.Content.Items.Magic;

public class FrigidflameBolt : ModItem, ILocalizedModType
{

    public new string LocalizationCategory => "Items.Magic";
    public override void SetDefaults()
    {
        Item.width = 38;
        Item.height = 42;
        Item.damage = 111;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 20;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true;
        Item.knockBack = 5.5f;
        Item.value = 80000; // 8 gold
        Item.rare = ItemRarityID.LightRed;
        Item.UseSound = SoundID.Item8;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<FrigidflameBoltProjectile>();
        Item.shootSpeed = 11f;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<FireBolt>())
            .AddIngredient(ItemID.FlowerofFrost)
            .AddIngredient(ItemID.SoulofSight)
            .AddIngredient(ItemID.SoulofMight)
            .AddIngredient(ItemID.SoulofFright)
            .AddTile(TileID.CrystalBall)
            .Register();
    }
    
    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
        TooltipLine line = new TooltipLine(Mod, "FrigidflameBolt", "Casts massive explosive bolts of fire & ice");
        tooltips.Add(line);
    }
}