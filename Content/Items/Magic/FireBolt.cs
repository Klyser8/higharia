using System.Collections.Generic;
using higharia.Content.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia.Content.Items.Magic;
public class FireBolt : ModItem, ILocalizedModType
{
    public new string LocalizationCategory => "Items.Magic";
    public override void SetDefaults()
    {
        Item.width = 34;
        Item.height = 38;
        Item.damage = 46;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 12;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true;
        Item.knockBack = 9f;
        Item.value = 50000; // 5 gold
        Item.rare = ItemRarityID.Pink;
        Item.UseSound = SoundID.Item20;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<FireBoltProjectile>();
        Item.shootSpeed = 5.0f;
    }

    public override void AddRecipes()
    {
        CreateRecipe().
            AddIngredient(ItemID.WaterBolt).
            AddIngredient(ItemID.LivingFireBlock, 100).
            AddIngredient(ItemID.HallowedBar, 3).
            AddTile(ModContent.TileType<Tiles.PrismaticBookcase>()).
            Register();
    }

    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
        TooltipLine line = new TooltipLine(Mod, "FireBolt", "Casts a slow moving bolt of fire");
        tooltips.Add(line);
    }
}