using higharia.Content.Items;
using higharia.Content.Items.Melee;
using higharia.Content.Items.Ranged;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PrismaticBookcase = higharia.Content.Tiles.PrismaticBookcase;

namespace higharia;

public class RecipeChanger : ModSystem
{
    
    
    public override void PostAddRecipes()
    {
        for (int i = 0; i < Recipe.numRecipes; i++)
        {
            Recipe recipe = Main.recipe[i];
            ReplaceHookRecipes(recipe);
            ReplacePickaxeRecipes(recipe);
            ReplaceAxeRecipes(recipe);
            ReplaceHammerRecipes(recipe);
            ReplaceHamaxeRecipes(recipe);
            ReplaceSwordRecipes(recipe);
            ReplaceSpearRecipes(recipe);
            ReplaceShortswordRecipes(recipe);
            ReplaceYoyoRecipes(recipe);
            ReplaceBowRecipes(recipe);
            ReplaceStaffRecipes(recipe);
            ReplaceRobeRecipes(recipe);
            ReplaceHelmetRecipes(recipe);
            ReplaceChainmailRecipes(recipe);
            ReplaceGreavesRecipes(recipe);
            ReplaceBootsRecipes(recipe);
            ReplaceMiscRecipes(recipe);
            ReplaceModdedRecipes(recipe);

            if (recipe.TryGetResult(ItemID.MagicMirror, out _))
            {
                recipe.DisableRecipe();
            }
            if (recipe.TryGetResult(ItemID.RecallPotion, out _))
            {
                recipe.DisableRecipe();
            }
            
            ReplaceWingRecipes(recipe);
        }
    }

    public override void SetStaticDefaults()
    {
        AddShimmerRecipes();
    }

    public override void AddRecipes()
    {
        Recipe moltenPickaxeRecipe = Recipe.Create(ItemID.MoltenPickaxe);
        moltenPickaxeRecipe.AddIngredient(ItemID.DeathbringerPickaxe);
        moltenPickaxeRecipe.AddIngredient(ItemID.HellstoneBar, 20);
        moltenPickaxeRecipe.Register();
        
        Recipe meteorHamaxeRecipe = Recipe.Create(ItemID.MeteorHamaxe);
        meteorHamaxeRecipe.AddIngredient(ItemID.BloodLustCluster);
        meteorHamaxeRecipe.AddIngredient(ItemID.FleshGrinder);
        meteorHamaxeRecipe.AddIngredient(ItemID.MeteoriteBar, 20);
        meteorHamaxeRecipe.Register();
        
        Recipe moltenFuryRecipe = Recipe.Create(ItemID.MoltenFury);
        moltenFuryRecipe.AddIngredient(ItemID.TendonBow);
        moltenFuryRecipe.AddIngredient(ItemID.HellstoneBar, 15);
        moltenFuryRecipe.Register();
        
        Recipe moltenHelmetRecipe = Recipe.Create(ItemID.MoltenHelmet);
        moltenHelmetRecipe.AddIngredient(ItemID.CrimsonHelmet);
        moltenHelmetRecipe.AddIngredient(ItemID.HellstoneBar, 10);
        moltenHelmetRecipe.Register();
        
        Recipe moltenBreastplateRecipe = Recipe.Create(ItemID.MoltenBreastplate);
        moltenBreastplateRecipe.AddIngredient(ItemID.CrimsonScalemail);
        moltenBreastplateRecipe.AddIngredient(ItemID.HellstoneBar, 20);
        moltenBreastplateRecipe.Register();
        
        Recipe moltenGreavesRecipe = Recipe.Create(ItemID.MoltenGreaves);
        moltenGreavesRecipe.AddIngredient(ItemID.CrimsonGreaves);
        moltenGreavesRecipe.AddIngredient(ItemID.HellstoneBar, 15);
        moltenGreavesRecipe.Register();

        Recipe wizardHatRecipe = Recipe.Create(ItemID.WizardHat);
        wizardHatRecipe.AddIngredient(ItemID.Silk, 10);
        wizardHatRecipe.AddIngredient(ItemID.FallenStar, 25);
        wizardHatRecipe.AddIngredient(ItemID.Leather, 3);
        wizardHatRecipe.AddTile(TileID.Loom);
        wizardHatRecipe.Register();

        Recipe crystalSerpentRecipeCorruption = Recipe.Create(ItemID.CrystalSerpent);
        crystalSerpentRecipeCorruption.AddIngredient(ItemID.DiamondStaff);
        crystalSerpentRecipeCorruption.AddIngredient(ItemID.AquaScepter);
        crystalSerpentRecipeCorruption.AddIngredient(ItemID.Vilethorn);
        crystalSerpentRecipeCorruption.AddIngredient(ItemID.IceRod);
        crystalSerpentRecipeCorruption.AddTile(TileID.DemonAltar);
        crystalSerpentRecipeCorruption.Register();

        Recipe crystalSerpentRecipeCrimson = Recipe.Create(ItemID.CrystalSerpent);
        crystalSerpentRecipeCrimson.AddIngredient(ItemID.DiamondStaff);
        crystalSerpentRecipeCrimson.AddIngredient(ItemID.AquaScepter);
        crystalSerpentRecipeCrimson.AddIngredient(ItemID.CrimsonRod);
        crystalSerpentRecipeCrimson.AddIngredient(ItemID.IceRod);
        crystalSerpentRecipeCrimson.AddTile(TileID.DemonAltar);
        crystalSerpentRecipeCrimson.Register();

        Recipe rocketBootsRecipe = Recipe.Create(ItemID.RocketBoots);
        rocketBootsRecipe.AddIngredient(ItemID.SoulofFlight, 10);
        rocketBootsRecipe.AddIngredient(ItemID.HellstoneBar, 20);
        rocketBootsRecipe.AddIngredient(ItemID.Leather, 5);
        rocketBootsRecipe.AddTile(TileID.Anvils);
        rocketBootsRecipe.Register();
        
        Recipe cloudInABottleRecipe = Recipe.Create(ItemID.CloudinaBottle);
        cloudInABottleRecipe.AddIngredient(ItemID.Cloud, 100);
        cloudInABottleRecipe.AddIngredient(ItemID.Bottle);
        cloudInABottleRecipe.AddIngredient(ItemID.FallenStar, 100);
        cloudInABottleRecipe.AddTile(TileID.SkyMill);
        cloudInABottleRecipe.Register();
        
        Recipe clentaminatorRecipe = Recipe.Create(ItemID.Clentaminator);
        clentaminatorRecipe.AddIngredient(ItemID.IronBar, 100);
        clentaminatorRecipe.AddIngredient(ItemID.LeadBar, 100);
        clentaminatorRecipe.AddIngredient(ItemID.TinBar, 150);
        clentaminatorRecipe.AddIngredient(ItemID.CopperBar, 150);
        clentaminatorRecipe.AddIngredient(ItemID.Wire, 25);
        clentaminatorRecipe.AddIngredient(ItemID.HellstoneBar, 25);
        clentaminatorRecipe.AddIngredient(ItemID.CrystalShard, 5);
        clentaminatorRecipe.AddTile(TileID.Anvils);
        clentaminatorRecipe.Register();
        
        Recipe tinGreenSolutionRecipe = Recipe.Create(ItemID.GreenSolution, 5);
        tinGreenSolutionRecipe.AddIngredient(ItemID.GrassSeeds, 25);
        tinGreenSolutionRecipe.AddIngredient(ItemID.Gel, 25);
        tinGreenSolutionRecipe.AddIngredient(ItemID.PixieDust);
        tinGreenSolutionRecipe.AddIngredient(ItemID.TinBar);
        tinGreenSolutionRecipe.AddTile(TileID.Bottles);
        tinGreenSolutionRecipe.Register();
        
        Recipe copperGreenSolutionRecipe = Recipe.Create(ItemID.GreenSolution, 5);
        copperGreenSolutionRecipe.AddIngredient(ItemID.GrassSeeds, 25);
        copperGreenSolutionRecipe.AddIngredient(ItemID.Gel, 25);
        copperGreenSolutionRecipe.AddIngredient(ItemID.PixieDust);
        copperGreenSolutionRecipe.AddIngredient(ItemID.CopperBar);
        copperGreenSolutionRecipe.AddTile(TileID.Bottles);
        copperGreenSolutionRecipe.Register();
        
        Recipe meteorHelmetToCobaltHatRecipe = Recipe.Create(ItemID.CobaltHat);
        meteorHelmetToCobaltHatRecipe.AddIngredient(ItemID.MeteorHelmet);
        meteorHelmetToCobaltHatRecipe.AddIngredient(ItemID.CobaltBar, 10);
        meteorHelmetToCobaltHatRecipe.AddTile(TileID.Anvils);
        meteorHelmetToCobaltHatRecipe.Register();
        
        Recipe cobaltDrillToPalladiumDrillRecipe = Recipe.Create(ItemID.PalladiumDrill);
        cobaltDrillToPalladiumDrillRecipe.AddIngredient(ItemID.CobaltDrill);
        cobaltDrillToPalladiumDrillRecipe.AddIngredient(ItemID.PalladiumBar, 18);
        cobaltDrillToPalladiumDrillRecipe.AddTile(TileID.Anvils);
        cobaltDrillToPalladiumDrillRecipe.Register();
        
        Recipe palladiumDrillToMythrilDrillRecipe = Recipe.Create(ItemID.MythrilDrill);
        palladiumDrillToMythrilDrillRecipe.AddIngredient(ItemID.PalladiumDrill);
        palladiumDrillToMythrilDrillRecipe.AddIngredient(ItemID.MythrilBar, 15);
        palladiumDrillToMythrilDrillRecipe.AddTile(TileID.MythrilAnvil);
        palladiumDrillToMythrilDrillRecipe.Register();
        
        Recipe mythrilDrillToOrichalcumDrillRecipe = Recipe.Create(ItemID.OrichalcumDrill);
        mythrilDrillToOrichalcumDrillRecipe.AddIngredient(ItemID.MythrilDrill);
        mythrilDrillToOrichalcumDrillRecipe.AddIngredient(ItemID.OrichalcumBar, 18);
        mythrilDrillToOrichalcumDrillRecipe.AddTile(TileID.MythrilAnvil);
        mythrilDrillToOrichalcumDrillRecipe.Register();
        
        Recipe orichalcumDrillToAdamantiteDrillRecipe = Recipe.Create(ItemID.AdamantiteDrill);
        orichalcumDrillToAdamantiteDrillRecipe.AddIngredient(ItemID.OrichalcumDrill);
        orichalcumDrillToAdamantiteDrillRecipe.AddIngredient(ItemID.AdamantiteBar, 18);
        orichalcumDrillToAdamantiteDrillRecipe.AddTile(TileID.MythrilAnvil);
        orichalcumDrillToAdamantiteDrillRecipe.Register();
        
        Recipe adamantiteDrillToTitaniumDrillRecipe = Recipe.Create(ItemID.TitaniumDrill);
        adamantiteDrillToTitaniumDrillRecipe.AddIngredient(ItemID.AdamantiteDrill);
        adamantiteDrillToTitaniumDrillRecipe.AddIngredient(ItemID.TitaniumBar, 20);
        adamantiteDrillToTitaniumDrillRecipe.AddTile(TileID.MythrilAnvil);
        adamantiteDrillToTitaniumDrillRecipe.Register();
        
        Recipe cobaltChainsawToPalladiumChainsawRecipe = Recipe.Create(ItemID.PalladiumChainsaw);
        cobaltChainsawToPalladiumChainsawRecipe.AddIngredient(ItemID.CobaltChainsaw);
        cobaltChainsawToPalladiumChainsawRecipe.AddIngredient(ItemID.PalladiumBar, 12);
        cobaltChainsawToPalladiumChainsawRecipe.AddTile(TileID.Anvils);
        cobaltChainsawToPalladiumChainsawRecipe.Register();
        
        Recipe palladiumChainsawToMythrilChainsawRecipe = Recipe.Create(ItemID.MythrilChainsaw);
        palladiumChainsawToMythrilChainsawRecipe.AddIngredient(ItemID.PalladiumChainsaw);
        palladiumChainsawToMythrilChainsawRecipe.AddIngredient(ItemID.MythrilBar, 10);
        palladiumChainsawToMythrilChainsawRecipe.AddTile(TileID.MythrilAnvil);
        palladiumChainsawToMythrilChainsawRecipe.Register();
        
        Recipe mythrilChainsawToOrichalcumChainsawRecipe = Recipe.Create(ItemID.OrichalcumChainsaw);
        mythrilChainsawToOrichalcumChainsawRecipe.AddIngredient(ItemID.MythrilChainsaw);
        mythrilChainsawToOrichalcumChainsawRecipe.AddIngredient(ItemID.OrichalcumBar, 12);
        mythrilChainsawToOrichalcumChainsawRecipe.AddTile(TileID.MythrilAnvil);
        mythrilChainsawToOrichalcumChainsawRecipe.Register();
        
        Recipe orichalcumChainsawToAdamantiteChainsawRecipe = Recipe.Create(ItemID.AdamantiteChainsaw);
        orichalcumChainsawToAdamantiteChainsawRecipe.AddIngredient(ItemID.OrichalcumChainsaw);
        orichalcumChainsawToAdamantiteChainsawRecipe.AddIngredient(ItemID.AdamantiteBar, 12);
        orichalcumChainsawToAdamantiteChainsawRecipe.AddTile(TileID.MythrilAnvil);
        orichalcumChainsawToAdamantiteChainsawRecipe.Register();
        
        Recipe adamantiteChainsawToTitaniumChainsawRecipe = Recipe.Create(ItemID.TitaniumChainsaw);
        adamantiteChainsawToTitaniumChainsawRecipe.AddIngredient(ItemID.AdamantiteChainsaw);
        adamantiteChainsawToTitaniumChainsawRecipe.AddIngredient(ItemID.TitaniumBar, 13);
        adamantiteChainsawToTitaniumChainsawRecipe.AddTile(TileID.MythrilAnvil);
        adamantiteChainsawToTitaniumChainsawRecipe.Register();
        
        Recipe meteorBreastplateToCobaltBreastplateRecipe = Recipe.Create(ItemID.CobaltBreastplate);
        meteorBreastplateToCobaltBreastplateRecipe.AddIngredient(ItemID.MeteorSuit);
        meteorBreastplateToCobaltBreastplateRecipe.AddIngredient(ItemID.CobaltBar, 20);
        meteorBreastplateToCobaltBreastplateRecipe.AddTile(TileID.Anvils);
        meteorBreastplateToCobaltBreastplateRecipe.Register();
        
        Recipe meteorGreavesToCobaltLeggingsRecipe = Recipe.Create(ItemID.CobaltLeggings);
        meteorGreavesToCobaltLeggingsRecipe.AddIngredient(ItemID.MeteorLeggings);
        meteorGreavesToCobaltLeggingsRecipe.AddIngredient(ItemID.CobaltBar, 15);
        meteorGreavesToCobaltLeggingsRecipe.AddTile(TileID.Anvils);
        meteorGreavesToCobaltLeggingsRecipe.Register();
        
        Recipe jungleShirtToCobaltBreastplateRecipe = Recipe.Create(ItemID.CobaltBreastplate);
        jungleShirtToCobaltBreastplateRecipe.AddIngredient(ItemID.JungleShirt);
        jungleShirtToCobaltBreastplateRecipe.AddIngredient(ItemID.CobaltBar, 20);
        jungleShirtToCobaltBreastplateRecipe.AddTile(TileID.Anvils);
        jungleShirtToCobaltBreastplateRecipe.Register();
        
        Recipe junglePantsToCobaltLeggingsRecipe = Recipe.Create(ItemID.CobaltLeggings);
        junglePantsToCobaltLeggingsRecipe.AddIngredient(ItemID.JunglePants);
        junglePantsToCobaltLeggingsRecipe.AddIngredient(ItemID.CobaltBar, 15);
        junglePantsToCobaltLeggingsRecipe.AddTile(TileID.Anvils);
        junglePantsToCobaltLeggingsRecipe.Register();
        
        Recipe necroChestplateToCobaltBreastplateRecipe = Recipe.Create(ItemID.CobaltBreastplate);
        necroChestplateToCobaltBreastplateRecipe.AddIngredient(ItemID.NecroBreastplate);
        necroChestplateToCobaltBreastplateRecipe.AddIngredient(ItemID.CobaltBar, 20);
        necroChestplateToCobaltBreastplateRecipe.AddTile(TileID.Anvils);
        necroChestplateToCobaltBreastplateRecipe.Register();
        
        Recipe necroGreavesToCobaltLeggingsRecipe = Recipe.Create(ItemID.CobaltLeggings);
        necroGreavesToCobaltLeggingsRecipe.AddIngredient(ItemID.NecroGreaves);
        necroGreavesToCobaltLeggingsRecipe.AddIngredient(ItemID.CobaltBar, 15);
        necroGreavesToCobaltLeggingsRecipe.AddTile(TileID.Anvils);
        necroGreavesToCobaltLeggingsRecipe.Register();

        Recipe frostBrandRecipe = Recipe.Create(ItemID.Frostbrand);
        frostBrandRecipe.AddIngredient(ModContent.ItemType<ForgottenIceBlade>());
        frostBrandRecipe.AddIngredient(ItemID.FrostCore);
        frostBrandRecipe.AddIngredient(ItemID.SnowBlock, 100);
        frostBrandRecipe.AddTile(ModContent.TileType<Content.Tiles.AncientPrismaticAnvil>());
        frostBrandRecipe.Register();

        Recipe iceSickleRecipe = Recipe.Create(ItemID.IceSickle);
        iceSickleRecipe.AddIngredient(ModContent.ItemType<ForgottenIceBlade>());
        iceSickleRecipe.AddIngredient(ItemID.FrostCore);
        iceSickleRecipe.AddIngredient(ItemID.IceBlock, 100);
        iceSickleRecipe.AddTile(ModContent.TileType<Content.Tiles.AncientPrismaticAnvil>());
        iceSickleRecipe.Register();

        Recipe helFireRecipe = Recipe.Create(ItemID.HelFire);
        helFireRecipe.AddIngredient(ItemID.FormatC);
        helFireRecipe.AddIngredient(ItemID.HellstoneBar, 30);
        helFireRecipe.AddIngredient(ItemID.LivingFireBlock, 25);
        helFireRecipe.AddTile(TileID.Anvils);
        helFireRecipe.Register();

        Recipe ancientPrismaticAnvilRecipe = Recipe.Create(ModContent.ItemType<AncientPrismaticAnvil>());
        ancientPrismaticAnvilRecipe.AddIngredient(ItemID.AncientCloth, 2);
        ancientPrismaticAnvilRecipe.AddIngredient(ItemID.IronAnvil, 1);
        ancientPrismaticAnvilRecipe.AddIngredient(ModContent.ItemType<AncientSlimeStone>());
        ancientPrismaticAnvilRecipe.AddIngredient(ItemID.CrystalShard, 20);
        ancientPrismaticAnvilRecipe.AddTile(TileID.Anvils);
        ancientPrismaticAnvilRecipe.Register();

        Recipe flyingKnifeRecipe = Recipe.Create(ItemID.FlyingKnife);
        flyingKnifeRecipe.AddIngredient(ItemID.SoulofFlight, 10);
        flyingKnifeRecipe.AddIngredient(ModContent.ItemType<CrystallineKnife>());
        flyingKnifeRecipe.AddIngredient(ItemID.CobaltBar, 5);
        flyingKnifeRecipe.AddTile(ModContent.TileType<Content.Tiles.AncientPrismaticAnvil>());
        flyingKnifeRecipe.Register();

        Recipe amarokRecipe = Recipe.Create(ItemID.Amarok);
        amarokRecipe.AddIngredient(ItemID.Code2);
        amarokRecipe.AddIngredient(ItemID.FrostCore);
        amarokRecipe.AddIngredient(ItemID.IceBlock, 250);
        amarokRecipe.AddTile(TileID.IceMachine);
        amarokRecipe.Register();
    }

    private void AddShimmerRecipes()
    {
        ItemID.Sets.ShimmerTransformToItem[ItemID.PinkDungeonVase] = ItemID.BlueDungeonVase;
        ItemID.Sets.ShimmerTransformToItem[ItemID.BlueDungeonVase] = ItemID.GreenDungeonVase;
        ItemID.Sets.ShimmerTransformToItem[ItemID.GreenDungeonVase] = ItemID.PinkDungeonVase;
    }

    private void ReplaceHookRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.AmethystHook, out _))
        {
            recipe.AddIngredient(ItemID.GrapplingHook);
            recipe.RemoveIngredient(ItemID.Amethyst);
            recipe.AddIngredient(ItemID.Amethyst, 50);
            recipe.AddIngredient(ItemID.PixieDust, 15);
            recipe.AddIngredient(ItemID.CrystalShard, 6);
        }
        else if (recipe.TryGetResult(ItemID.TopazHook, out _))
        {
            recipe.AddIngredient(ItemID.AmethystHook);
            recipe.RemoveIngredient(ItemID.Topaz);
            recipe.AddIngredient(ItemID.Topaz, 50);
            recipe.AddIngredient(ItemID.PixieDust, 15);
            recipe.AddIngredient(ItemID.CrystalShard, 8);
        }
        else if (recipe.TryGetResult(ItemID.SapphireHook, out _))
        {
            recipe.AddIngredient(ItemID.TopazHook);
            recipe.RemoveIngredient(ItemID.Sapphire);
            recipe.AddIngredient(ItemID.Sapphire, 40);
            recipe.AddIngredient(ItemID.PixieDust, 20);
            recipe.AddIngredient(ItemID.CrystalShard, 10);
        }
        else if (recipe.TryGetResult(ItemID.EmeraldHook, out _))
        {
            recipe.AddIngredient(ItemID.SapphireHook);
            recipe.RemoveIngredient(ItemID.Emerald);
            recipe.AddIngredient(ItemID.Emerald, 40);
            recipe.AddIngredient(ItemID.PixieDust, 20);
            recipe.AddIngredient(ItemID.CrystalShard, 12);
        }
        else if (recipe.TryGetResult(ItemID.RubyHook, out _))
        {
            recipe.AddIngredient(ItemID.EmeraldHook);
            recipe.RemoveIngredient(ItemID.Ruby);
            recipe.AddIngredient(ItemID.Ruby, 30);
            recipe.AddIngredient(ItemID.PixieDust, 25);
            recipe.AddIngredient(ItemID.CrystalShard, 14);
        }
        else if (recipe.TryGetResult(ItemID.DiamondHook, out _))
        {
            recipe.AddIngredient(ItemID.RubyHook);
            recipe.RemoveIngredient(ItemID.Diamond);
            recipe.AddIngredient(ItemID.Diamond, 30);
            recipe.AddIngredient(ItemID.PixieDust, 25);
            recipe.AddIngredient(ItemID.CrystalShard, 16);
        }
        else if (recipe.TryGetResult(ItemID.AmberHook, out _))
        {
            recipe.AddIngredient(ItemID.GrapplingHook);
            recipe.RemoveIngredient(ItemID.Amber);
            recipe.AddIngredient(ItemID.Amber, 50);
            recipe.AddIngredient(ItemID.PixieDust, 50);
            recipe.AddIngredient(ItemID.CrystalShard, 25);
            recipe.AddIngredient(ItemID.AncientCloth, 10);
        }

        if (recipe.TryGetResult(ItemID.GrapplingHook, out _))
        {
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
        }
    }
    private void ReplacePickaxeRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.TinPickaxe, out _))
        {
            recipe.AddIngredient(ItemID.CopperPickaxe);
        } else if (recipe.TryGetResult(ItemID.IronPickaxe, out _))
        {
            recipe.AddIngredient(ItemID.TinPickaxe);
        } else if (recipe.TryGetResult(ItemID.LeadPickaxe, out _))
        {
            recipe.AddIngredient(ItemID.IronPickaxe);
        } else if (recipe.TryGetResult(ItemID.SilverPickaxe, out _))
        {
            recipe.AddIngredient(ItemID.LeadPickaxe);
        } else if (recipe.TryGetResult(ItemID.TungstenPickaxe, out _))
        {
            recipe.AddIngredient(ItemID.SilverPickaxe);
        } else if (recipe.TryGetResult(ItemID.GoldPickaxe, out _))
        {
            recipe.AddIngredient(ItemID.TungstenPickaxe);
        } else if (recipe.TryGetResult(ItemID.PlatinumPickaxe, out _))
        {
            recipe.AddIngredient(ItemID.GoldPickaxe);
        } else if (recipe.TryGetResult(ItemID.NightmarePickaxe, out _) || recipe.TryGetResult(ItemID.DeathbringerPickaxe, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumPickaxe);
        } else if (recipe.TryGetResult(ItemID.MoltenPickaxe, out _) && !recipe.TryGetIngredient(ItemID.DeathbringerPickaxe, out _))
        {
            recipe.AddIngredient(ItemID.NightmarePickaxe);
        }
        
        if (recipe.TryGetResult(ItemID.CobaltPickaxe, out _))
        {
            recipe.AddIngredient(ItemID.MoltenPickaxe);
        } else if (recipe.TryGetResult(ItemID.CobaltDrill, out _))
        {
            recipe.AddIngredient(ItemID.MoltenPickaxe);
            recipe.AddIngredient(ItemID.Wire, 25);
        } else if (recipe.TryGetResult(ItemID.PalladiumPickaxe, out _))
        {
            recipe.AddIngredient(ItemID.CobaltPickaxe);
        } else if (recipe.TryGetResult(ItemID.PalladiumDrill, out _))
        {
            recipe.AddIngredient(ItemID.CobaltPickaxe);
            recipe.AddIngredient(ItemID.Wire, 25);
        } else if (recipe.TryGetResult(ItemID.MythrilPickaxe, out _))
        {
            recipe.AddIngredient(ItemID.PalladiumPickaxe);
        } else if (recipe.TryGetResult(ItemID.MythrilDrill, out _))
        {
            recipe.AddIngredient(ItemID.PalladiumPickaxe);
            recipe.AddIngredient(ItemID.Wire, 25);
        } else if (recipe.TryGetResult(ItemID.OrichalcumPickaxe, out _))
        {
            recipe.AddIngredient(ItemID.MythrilPickaxe);
        } else if (recipe.TryGetResult(ItemID.OrichalcumDrill, out _))
        {
            recipe.AddIngredient(ItemID.MythrilPickaxe);
            recipe.AddIngredient(ItemID.Wire, 25);
        } else if (recipe.TryGetResult(ItemID.AdamantitePickaxe, out _))
        {
            recipe.AddIngredient(ItemID.OrichalcumPickaxe);
        } else if (recipe.TryGetResult(ItemID.AdamantiteDrill, out _))
        {
            recipe.AddIngredient(ItemID.OrichalcumPickaxe);
            recipe.AddIngredient(ItemID.Wire, 25);
        } else if (recipe.TryGetResult(ItemID.TitaniumPickaxe, out _))
        {
            recipe.AddIngredient(ItemID.AdamantitePickaxe);
        } else if (recipe.TryGetResult(ItemID.TitaniumDrill, out _))
        {
            recipe.AddIngredient(ItemID.AdamantitePickaxe);
            recipe.AddIngredient(ItemID.Wire, 25);
        }
    }
    private void ReplaceAxeRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.TinAxe, out _))
        {
            recipe.AddIngredient(ItemID.CopperAxe);
        } else if (recipe.TryGetResult(ItemID.IronAxe, out _))
        {
            recipe.AddIngredient(ItemID.TinAxe);
        } else if (recipe.TryGetResult(ItemID.LeadAxe, out _))
        {
            recipe.AddIngredient(ItemID.IronAxe);
        } else if (recipe.TryGetResult(ItemID.SilverAxe, out _))
        {
            recipe.AddIngredient(ItemID.LeadAxe);
        } else if (recipe.TryGetResult(ItemID.TungstenAxe, out _))
        {
            recipe.AddIngredient(ItemID.SilverAxe);
        } else if (recipe.TryGetResult(ItemID.GoldAxe, out _))
        {
            recipe.AddIngredient(ItemID.TungstenAxe);
        } else if (recipe.TryGetResult(ItemID.PlatinumAxe, out _))
        {
            recipe.AddIngredient(ItemID.GoldAxe);
        } else if (recipe.TryGetResult(ItemID.WarAxeoftheNight, out _) || recipe.TryGetResult(ItemID.BloodLustCluster, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumAxe);
        }
        
        if (recipe.TryGetResult(ItemID.CobaltWaraxe, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumAxe);
        } else if (recipe.TryGetResult(ItemID.CobaltChainsaw, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumAxe);
            recipe.AddIngredient(ItemID.Wire, 25);
        } else if (recipe.TryGetResult(ItemID.PalladiumWaraxe, out _))
        {
            recipe.AddIngredient(ItemID.CobaltWaraxe);
        } else if (recipe.TryGetResult(ItemID.PalladiumChainsaw, out _))
        {
            recipe.AddIngredient(ItemID.CobaltWaraxe);
            recipe.AddIngredient(ItemID.Wire, 25);
        } else if (recipe.TryGetResult(ItemID.MythrilWaraxe, out _))
        {
            recipe.AddIngredient(ItemID.PalladiumWaraxe);
        } else if (recipe.TryGetResult(ItemID.MythrilChainsaw, out _))
        {
            recipe.AddIngredient(ItemID.PalladiumWaraxe);
            recipe.AddIngredient(ItemID.Wire, 25);
        } else if (recipe.TryGetResult(ItemID.OrichalcumWaraxe, out _))
        {
            recipe.AddIngredient(ItemID.MythrilWaraxe);
        } else if (recipe.TryGetResult(ItemID.OrichalcumChainsaw, out _))
        {
            recipe.AddIngredient(ItemID.MythrilWaraxe);
            recipe.AddIngredient(ItemID.Wire, 25);
        } else if (recipe.TryGetResult(ItemID.AdamantiteWaraxe, out _))
        {
            recipe.AddIngredient(ItemID.OrichalcumWaraxe);
        } else if (recipe.TryGetResult(ItemID.AdamantiteChainsaw, out _))
        {
            recipe.AddIngredient(ItemID.OrichalcumWaraxe);
            recipe.AddIngredient(ItemID.Wire, 25);
        } else if (recipe.TryGetResult(ItemID.TitaniumWaraxe, out _))
        {
            recipe.AddIngredient(ItemID.AdamantiteWaraxe);
        } else if (recipe.TryGetResult(ItemID.TitaniumChainsaw, out _))
        {
            recipe.AddIngredient(ItemID.AdamantiteWaraxe);
            recipe.AddIngredient(ItemID.Wire, 25);
        }
    }
    
    private void ReplaceHammerRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.TinHammer, out _))
        {
            recipe.AddIngredient(ItemID.CopperHammer);
        } else if (recipe.TryGetResult(ItemID.IronHammer, out _))
        {
            recipe.AddIngredient(ItemID.TinHammer);
        } else if (recipe.TryGetResult(ItemID.LeadHammer, out _))
        {
            recipe.AddIngredient(ItemID.IronHammer);
        } else if (recipe.TryGetResult(ItemID.SilverHammer, out _))
        {
            recipe.AddIngredient(ItemID.LeadHammer);
        } else if (recipe.TryGetResult(ItemID.TungstenHammer, out _))
        {
            recipe.AddIngredient(ItemID.SilverHammer);
        } else if (recipe.TryGetResult(ItemID.GoldHammer, out _))
        {
            recipe.AddIngredient(ItemID.TungstenHammer);
        } else if (recipe.TryGetResult(ItemID.PlatinumHammer, out _))
        {
            recipe.AddIngredient(ItemID.GoldHammer);
        } else if (recipe.TryGetResult(ItemID.TheBreaker, out _) || recipe.TryGetResult(ItemID.FleshGrinder, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumHammer);
        }
    }
    private void ReplaceHamaxeRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.MeteorHamaxe, out _) && !recipe.TryGetIngredient(ItemID.BloodLustCluster, out _))
        {
            recipe.AddIngredient(ItemID.WarAxeoftheNight);
            recipe.AddIngredient(ItemID.TheBreaker);
        } else if (recipe.TryGetResult(ItemID.MoltenHamaxe, out _))
        {
            recipe.AddIngredient(ItemID.MeteorHamaxe);
        }
    }
    private void ReplaceSwordRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.TinBroadsword, out _))
        {
            recipe.AddIngredient(ItemID.CopperBroadsword);
        } else if (recipe.TryGetResult(ItemID.IronBroadsword, out _))
        {
            recipe.AddIngredient(ItemID.TinBroadsword);
        } else if (recipe.TryGetResult(ItemID.LeadBroadsword, out _))
        {
            recipe.AddIngredient(ItemID.IronBroadsword);
        } else if (recipe.TryGetResult(ItemID.SilverBroadsword, out _))
        {
            recipe.AddIngredient(ItemID.LeadBroadsword);
        } else if (recipe.TryGetResult(ItemID.TungstenBroadsword, out _))
        {
            recipe.AddIngredient(ItemID.SilverBroadsword);
        } else if (recipe.TryGetResult(ItemID.GoldBroadsword, out _))
        {
            recipe.AddIngredient(ItemID.TungstenBroadsword);
        } else if (recipe.TryGetResult(ItemID.PlatinumBroadsword, out _))
        {
            recipe.AddIngredient(ItemID.GoldBroadsword);
        } else if (recipe.TryGetResult(ItemID.LightsBane, out _) || recipe.TryGetResult(ItemID.BloodButcherer, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumBroadsword);
        } else if (recipe.TryGetResult(ItemID.PurplePhaseblade, out _) ||
                   recipe.TryGetResult(ItemID.YellowPhaseblade, out _) ||
                   recipe.TryGetResult(ItemID.GreenPhaseblade, out _) ||
                   recipe.TryGetResult(ItemID.BluePhaseblade, out _) ||
                   recipe.TryGetResult(ItemID.RedPhaseblade, out _) ||
                   recipe.TryGetResult(ItemID.WhitePhaseblade, out _) ||
                   recipe.TryGetResult(ItemID.OrangePhaseblade, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumBroadsword);
        } else if (recipe.TryGetResult(ItemID.BladeofGrass, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumBroadsword);
        } else if (recipe.TryGetResult(ItemID.FieryGreatsword, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumBroadsword);
        }

        if (recipe.TryGetResult(ItemID.CobaltSword, out _))
        {
            recipe.AddIngredient(ItemID.PearlwoodSword);
        } else if (recipe.TryGetResult(ItemID.PalladiumSword, out _))
        {
            recipe.AddIngredient(ItemID.CobaltSword);
        } else if (recipe.TryGetResult(ItemID.MythrilSword, out _))
        {
            recipe.AddIngredient(ItemID.PalladiumSword);
        } else if (recipe.TryGetResult(ItemID.OrichalcumSword, out _))
        {
            recipe.AddIngredient(ItemID.MythrilSword);
        } else if (recipe.TryGetResult(ItemID.AdamantiteSword, out _))
        {
            recipe.AddIngredient(ItemID.OrichalcumSword);
        } else if (recipe.TryGetResult(ItemID.TitaniumSword, out _))
        {
            recipe.AddIngredient(ItemID.AdamantiteSword);
        }

        if (recipe.TryGetResult(ItemID.BluePhasesaber, out _) || 
            recipe.TryGetResult(ItemID.GreenPhasesaber, out _) ||
            recipe.TryGetResult(ItemID.RedPhasesaber, out _) ||
            recipe.TryGetResult(ItemID.YellowPhasesaber, out _) ||
            recipe.TryGetResult(ItemID.OrangePhasesaber, out _) ||
            recipe.TryGetResult(ItemID.PurplePhasesaber, out _) ||
            recipe.TryGetResult(ItemID.WhitePhasesaber, out _))
        {
            recipe.AddIngredient(ModContent.ItemType<AncientSlimeStone>());
            recipe.RemoveTile(ItemID.OrichalcumAnvil);
            recipe.RemoveTile(ItemID.MythrilAnvil);
            recipe.AddTile<Content.Tiles.AncientPrismaticAnvil>();
        }
    }

    private void ReplaceSpearRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.CobaltNaginata, out _))
        {
            recipe.AddIngredient(ItemID.DarkLance);
        } else if (recipe.TryGetResult(ItemID.PalladiumPike, out _))
        {
            recipe.AddIngredient(ItemID.CobaltNaginata);
        } else if (recipe.TryGetResult(ItemID.MythrilHalberd, out _))
        {
            recipe.AddIngredient(ItemID.PalladiumPike);
        } else if (recipe.TryGetResult(ItemID.OrichalcumHalberd, out _))
        {
            recipe.AddIngredient(ItemID.MythrilHalberd);
        } else if (recipe.TryGetResult(ItemID.AdamantiteGlaive, out _))
        {
            recipe.AddIngredient(ItemID.OrichalcumHalberd);
        } else if (recipe.TryGetResult(ItemID.TitaniumTrident, out _))
        {
            recipe.AddIngredient(ItemID.AdamantiteGlaive);
        }
    }
    
    private void ReplaceShortswordRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.TinShortsword, out _))
        {
            recipe.AddIngredient(ItemID.CopperShortsword);
        } else if (recipe.TryGetResult(ItemID.IronShortsword, out _))
        {
            recipe.AddIngredient(ItemID.TinShortsword);
        } else if (recipe.TryGetResult(ItemID.LeadShortsword, out _))
        {
            recipe.AddIngredient(ItemID.IronShortsword);
        } else if (recipe.TryGetResult(ItemID.SilverShortsword, out _))
        {
            recipe.AddIngredient(ItemID.LeadShortsword);
        } else if (recipe.TryGetResult(ItemID.TungstenShortsword, out _))
        {
            recipe.AddIngredient(ItemID.SilverShortsword);
        } else if (recipe.TryGetResult(ItemID.GoldShortsword, out _))
        {
            recipe.AddIngredient(ItemID.TungstenShortsword);
        } else if (recipe.TryGetResult(ItemID.PlatinumShortsword, out _))
        {
            recipe.AddIngredient(ItemID.GoldShortsword);
        }
    }

    private void ReplaceYoyoRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.Chik, out _))
        {
            recipe.RemoveIngredient(ItemID.WoodYoyo);
            recipe.AddIngredient(ModContent.ItemType<AncientSlimeStone>());
            recipe.AddIngredient(ItemID.Gradient);
            recipe.RemoveTile(TileID.MythrilAnvil);
            recipe.AddTile<Content.Tiles.AncientPrismaticAnvil>();
        }
    }
    private void ReplaceBowRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.CopperBow, out _))
        {
            recipe.AddIngredient(ItemID.WoodenBow);
        } else if (recipe.TryGetResult(ItemID.TinBow, out _))
        {
            recipe.AddIngredient(ItemID.CopperBow);
        } else if (recipe.TryGetResult(ItemID.IronBow, out _))
        {
            recipe.AddIngredient(ItemID.TinBow);
        } else if (recipe.TryGetResult(ItemID.LeadBow, out _))
        {
            recipe.AddIngredient(ItemID.IronBow);
        } else if (recipe.TryGetResult(ItemID.SilverBow, out _))
        {
            recipe.AddIngredient(ItemID.LeadBow);
        } else if (recipe.TryGetResult(ItemID.TungstenBow, out _))
        {
            recipe.AddIngredient(ItemID.SilverBow);
        } else if (recipe.TryGetResult(ItemID.GoldBow, out _))
        {
            recipe.AddIngredient(ItemID.TungstenBow);
        } else if (recipe.TryGetResult(ItemID.PlatinumBow, out _))
        {
            recipe.AddIngredient(ItemID.GoldBow);
        } else if (recipe.TryGetResult(ItemID.DemonBow, out _) || recipe.TryGetResult(ItemID.TendonBow, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumBow);
        } else if (recipe.TryGetResult(ItemID.MoltenFury, out _) && !recipe.TryGetIngredient(ItemID.TendonBow, out _))
        {
            recipe.AddIngredient(ItemID.DemonBow);
        }
        
        if (recipe.TryGetResult(ItemID.CobaltRepeater, out _))
        {
            recipe.AddIngredient(ItemID.MoltenFury);
        } else if (recipe.TryGetResult(ItemID.PalladiumRepeater, out _))
        {
            recipe.AddIngredient(ItemID.CobaltRepeater);
        } else if (recipe.TryGetResult(ItemID.MythrilRepeater, out _))
        {
            recipe.AddIngredient(ItemID.PalladiumRepeater);
        } else if (recipe.TryGetResult(ItemID.OrichalcumRepeater, out _))
        {
            recipe.AddIngredient(ItemID.MythrilRepeater);
        } else if (recipe.TryGetResult(ItemID.AdamantiteRepeater, out _))
        {
            recipe.AddIngredient(ItemID.OrichalcumRepeater);
        } else if (recipe.TryGetResult(ItemID.TitaniumRepeater, out _))
        {
            recipe.AddIngredient(ItemID.AdamantiteRepeater);
        }
    }
    private void ReplaceStaffRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.AmethystStaff, out _))
        {
            recipe.AddIngredient(ItemID.FallenStar, 25);
        } else if (recipe.TryGetResult(ItemID.TopazStaff, out _))
        {
            recipe.AddIngredient(ItemID.AmethystStaff);
        } else if (recipe.TryGetResult(ItemID.SapphireStaff, out _))
        {
            recipe.AddIngredient(ItemID.TopazStaff);
        } else if (recipe.TryGetResult(ItemID.EmeraldStaff, out _))
        {
            recipe.AddIngredient(ItemID.SapphireStaff);
        } else if (recipe.TryGetResult(ItemID.RubyStaff, out _))
        {
            recipe.AddIngredient(ItemID.EmeraldStaff);
        } else if (recipe.TryGetResult(ItemID.DiamondStaff, out _))
        {
            recipe.AddIngredient(ItemID.RubyStaff);
        }

        if (recipe.TryGetResult(ItemID.SoulDrain, out _))
        {
            recipe.AddIngredient(ModContent.ItemType<SilkenClump>());
            recipe.AddIngredient(ItemID.Bone, 25);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.AdamantiteBar, 8);
            recipe.AddTile(ItemID.MythrilAnvil);
            recipe.Register();
        }

        if (recipe.TryGetResult(ItemID.FlowerofFrost, out _))
        {
            recipe.AddIngredient(ItemID.FrostCore);
            recipe.AddIngredient(ItemID.MythrilBar, 8);
            recipe.AddIngredient(ItemID.FlowerofFire);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
        
        if (recipe.TryGetResult(ItemID.SkyFracture, out _))
        {
            recipe.AddIngredient(ItemID.SoulofSight, 6);
            recipe.AddIngredient(ItemID.SoulofMight, 6);
            recipe.AddIngredient(ItemID.SoulofFright, 6);
        }
        
        if (recipe.TryGetResult(ItemID.RainbowRod, out _))
        {
            recipe.RemoveIngredient(ItemID.SoulofSight);
            recipe.RemoveIngredient(ItemID.UnicornHorn);
            recipe.RemoveIngredient(ItemID.CrystalShard);
            recipe.RemoveIngredient(ItemID.SoulofLight);
            recipe.AddIngredient(ItemID.SoulofSight, 6);
            recipe.AddIngredient(ItemID.SoulofMight, 6);
            recipe.AddIngredient(ItemID.SoulofFright, 6);
            recipe.AddIngredient(ItemID.SoulofLight, 20);
            recipe.AddIngredient(ItemID.UnicornHorn, 6);
            recipe.AddIngredient(ItemID.CrystalShard, 30);
        }

        if (recipe.TryGetResult(ItemID.SpiritFlame, out _))
        {
            recipe.AddIngredient(ItemID.TitaniumBar, 10);
        }

        if (recipe.TryGetResult(ItemID.MeteorStaff, out _))
        {
            recipe.AddIngredient(ItemID.AdamantiteBar, 8);
        }
    }
    private void ReplaceRobeRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.AmethystRobe, out _))
        {
            recipe.TryGetIngredient(ItemID.Amethyst, out Item gem);
            gem.stack = 25;

            recipe.AddIngredient(ItemID.FallenStar, 10);
        } else if (recipe.TryGetResult(ItemID.TopazRobe, out _))
        {
            recipe.TryGetIngredient(ItemID.Topaz, out Item gem);
            gem.stack = 25;
            
            recipe.RemoveIngredient(ItemID.Robe);
            
            recipe.AddIngredient(ItemID.AmethystRobe);
            recipe.AddIngredient(ItemID.FallenStar, 12);
        } else if (recipe.TryGetResult(ItemID.SapphireRobe, out _))
        {
            recipe.TryGetIngredient(ItemID.Sapphire, out Item gem);
            gem.stack = 25;
            
            recipe.RemoveIngredient(ItemID.Robe);
            
            recipe.AddIngredient(ItemID.TopazRobe);
            recipe.AddIngredient(ItemID.FallenStar, 14);
        } else if (recipe.TryGetResult(ItemID.EmeraldRobe, out _))
        {
            recipe.TryGetIngredient(ItemID.Emerald, out Item gem);
            gem.stack = 25;
            
            recipe.RemoveIngredient(ItemID.Robe);
            
            recipe.AddIngredient(ItemID.SapphireRobe);
            recipe.AddIngredient(ItemID.FallenStar, 16);
        } else if (recipe.TryGetResult(ItemID.RubyRobe, out _))
        {
            recipe.TryGetIngredient(ItemID.Ruby, out Item gem);
            gem.stack = 25;
            
            recipe.RemoveIngredient(ItemID.Robe);
            
            recipe.AddIngredient(ItemID.EmeraldRobe);
            recipe.AddIngredient(ItemID.FallenStar, 18);
        } else if (recipe.TryGetResult(ItemID.DiamondRobe, out _))
        {
            recipe.TryGetIngredient(ItemID.Diamond, out Item gem);
            gem.stack = 25;
            
            recipe.RemoveIngredient(ItemID.Robe);
            
            recipe.AddIngredient(ItemID.RubyRobe);
            recipe.AddIngredient(ItemID.FallenStar, 20);
        } else if (recipe.TryGetResult(ItemID.AmberRobe, out _))
        {
            recipe.TryGetIngredient(ItemID.Amber, out Item gem);
            gem.stack = 30;

            recipe.AddIngredient(ItemID.FossilOre, 10);
            recipe.AddIngredient(ItemID.FallenStar, 30);
        }
    }
    private void ReplaceHelmetRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.CopperHelmet, out _))
        {
            recipe.AddIngredient(ItemID.WoodHelmet);
        } else if (recipe.TryGetResult(ItemID.CactusHelmet, out _))
        {
            recipe.AddIngredient(ItemID.CopperHelmet);
        }
        else if (recipe.TryGetResult(ItemID.TinHelmet, out _))
        {
            recipe.AddIngredient(ItemID.CopperHelmet);
        } else if (recipe.TryGetResult(ItemID.IronHelmet, out _))
        {
            recipe.AddIngredient(ItemID.TinHelmet);
        } else if (recipe.TryGetResult(ItemID.LeadHelmet, out _))
        {
            recipe.AddIngredient(ItemID.IronHelmet);
        } else if (recipe.TryGetResult(ItemID.SilverHelmet, out _))
        {
            recipe.AddIngredient(ItemID.LeadHelmet);
        } else if (recipe.TryGetResult(ItemID.TungstenHelmet, out _))
        {
            recipe.AddIngredient(ItemID.SilverHelmet);
        } else if (recipe.TryGetResult(ItemID.GoldHelmet, out _))
        {
            recipe.AddIngredient(ItemID.TungstenHelmet);
        } else if (recipe.TryGetResult(ItemID.PlatinumHelmet, out _))
        {
            recipe.AddIngredient(ItemID.GoldHelmet);
        } else if (recipe.TryGetResult(ItemID.ShadowHelmet, out _) || recipe.TryGetResult(ItemID.CrimsonHelmet, out _) ||
                   recipe.TryGetResult(ItemID.FossilHelm, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumHelmet);
        } else if (recipe.TryGetResult(ItemID.MoltenHelmet, out _) && !recipe.TryGetIngredient(ItemID.CrimsonHelmet, out _))
        {
            recipe.AddIngredient(ItemID.ShadowHelmet);
        } else if (recipe.TryGetResult(ItemID.NecroHelmet, out _))
        {
            recipe.AddIngredient(ItemID.FossilHelm);
        } else if (recipe.TryGetResult(ItemID.JungleHat, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumHelmet);
        } else if (recipe.TryGetResult(ItemID.MeteorHelmet, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumHelmet);
        }
        // Melee
        if (recipe.TryGetResult(ItemID.CobaltHelmet, out _))
        {
            recipe.AddIngredient(ItemID.MoltenHelmet);
        } else if (recipe.TryGetResult(ItemID.PalladiumMask, out _))
        {
            recipe.AddIngredient(ItemID.CobaltHelmet);
        } else if (recipe.TryGetResult(ItemID.MythrilHelmet, out _))
        {
            recipe.AddIngredient(ItemID.PalladiumHelmet);
        } else if (recipe.TryGetResult(ItemID.OrichalcumMask, out _))
        {
            recipe.AddIngredient(ItemID.MythrilHelmet);
        } else if (recipe.TryGetResult(ItemID.AdamantiteHelmet, out _))
        {
            recipe.AddIngredient(ItemID.OrichalcumMask);
        } else if (recipe.TryGetResult(ItemID.TitaniumMask, out _))
        {
            recipe.AddIngredient(ItemID.AdamantiteHelmet);
        }
        // Mage
        if (recipe.TryGetResult(ItemID.CobaltMask, out _))
        {
            recipe.AddIngredient(ItemID.JungleHat);
        } else if (recipe.TryGetResult(ItemID.PalladiumHeadgear, out _))
        {
            recipe.AddIngredient(ItemID.CobaltMask);
        } else if (recipe.TryGetResult(ItemID.MythrilHood, out _))
        {
            recipe.AddIngredient(ItemID.PalladiumHeadgear);
        } else if (recipe.TryGetResult(ItemID.OrichalcumHeadgear, out _))
        {
            recipe.AddIngredient(ItemID.MythrilHood);
        } else if (recipe.TryGetResult(ItemID.AdamantiteHeadgear, out _))
        {
            recipe.AddIngredient(ItemID.OrichalcumHeadgear);
        } else if (recipe.TryGetResult(ItemID.TitaniumHeadgear, out _))
        {
            recipe.AddIngredient(ItemID.AdamantiteHeadgear);
        }
        // Ranger
        if (recipe.TryGetResult(ItemID.CobaltHat, out _))
        {
            recipe.AddIngredient(ItemID.NecroHelmet);
        } else if (recipe.TryGetResult(ItemID.PalladiumHelmet, out _))
        {
            recipe.AddIngredient(ItemID.CobaltHat);
        } else if (recipe.TryGetResult(ItemID.MythrilHat, out _))
        {
            recipe.AddIngredient(ItemID.PalladiumHeadgear);
        } else if (recipe.TryGetResult(ItemID.OrichalcumHelmet, out _))
        {
            recipe.AddIngredient(ItemID.MythrilHat);
        } else if (recipe.TryGetResult(ItemID.AdamantiteMask, out _))
        {
            recipe.AddIngredient(ItemID.OrichalcumHelmet);
        } else if (recipe.TryGetResult(ItemID.TitaniumHelmet, out _))
        {
            recipe.AddIngredient(ItemID.AdamantiteMask);
        }
    }
    private void ReplaceChainmailRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.CopperChainmail, out _))
        {
            recipe.AddIngredient(ItemID.WoodBreastplate);
        } else if (recipe.TryGetResult(ItemID.CactusBreastplate, out _))
        {
            recipe.AddIngredient(ItemID.CopperChainmail);
        } else if (recipe.TryGetResult(ItemID.TinChainmail, out _))
        {
            recipe.AddIngredient(ItemID.CopperChainmail);
        } else if (recipe.TryGetResult(ItemID.IronChainmail, out _))
        {
            recipe.AddIngredient(ItemID.TinChainmail);
        } else if (recipe.TryGetResult(ItemID.LeadChainmail, out _))
        {
            recipe.AddIngredient(ItemID.IronChainmail);
        } else if (recipe.TryGetResult(ItemID.SilverChainmail, out _))
        {
            recipe.AddIngredient(ItemID.LeadChainmail);
        } else if (recipe.TryGetResult(ItemID.TungstenChainmail, out _))
        {
            recipe.AddIngredient(ItemID.SilverChainmail);
        } else if (recipe.TryGetResult(ItemID.GoldChainmail, out _))
        {
            recipe.AddIngredient(ItemID.TungstenChainmail);
        } else if (recipe.TryGetResult(ItemID.PlatinumChainmail, out _))
        {
            recipe.AddIngredient(ItemID.GoldChainmail);
        } else if (recipe.TryGetResult(ItemID.ShadowScalemail, out _) || recipe.TryGetResult(ItemID.CrimsonScalemail, out _) ||
                   recipe.TryGetResult(ItemID.FossilShirt, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumChainmail);
        } else if (recipe.TryGetResult(ItemID.MoltenBreastplate, out _) && !recipe.TryGetIngredient(ItemID.CrimsonScalemail, out _))
        {
            recipe.AddIngredient(ItemID.ShadowScalemail);
        } else if (recipe.TryGetResult(ItemID.NecroBreastplate, out _))
        {
            recipe.AddIngredient(ItemID.FossilShirt);
        } else if (recipe.TryGetResult(ItemID.JungleShirt, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumChainmail);
        } else if (recipe.TryGetResult(ItemID.MeteorSuit, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumChainmail);
        }

        if (recipe.TryGetResult(ItemID.CobaltBreastplate, out _))
        {
            recipe.AddIngredient(ItemID.MoltenBreastplate);
        } else if (recipe.TryGetResult(ItemID.PalladiumBreastplate, out _))
        {
            recipe.AddIngredient(ItemID.CobaltBreastplate);
        } else if (recipe.TryGetResult(ItemID.MythrilChainmail, out _))
        {
            recipe.AddIngredient(ItemID.PalladiumBreastplate);
        } else if (recipe.TryGetResult(ItemID.OrichalcumBreastplate, out _))
        {
            recipe.AddIngredient(ItemID.MythrilChainmail);
        } else if (recipe.TryGetResult(ItemID.AdamantiteBreastplate, out _))
        {
            recipe.AddIngredient(ItemID.OrichalcumBreastplate);
        } else if (recipe.TryGetResult(ItemID.TitaniumBreastplate, out _))
        {
            recipe.AddIngredient(ItemID.AdamantiteBreastplate);
        }
    }
    private void ReplaceGreavesRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.CopperGreaves, out _))
        {
            recipe.AddIngredient(ItemID.WoodGreaves);
        } else if (recipe.TryGetResult(ItemID.CactusLeggings, out _))
        {
            recipe.AddIngredient(ItemID.CopperGreaves);
        } else if (recipe.TryGetResult(ItemID.TinGreaves, out _))
        {
            recipe.AddIngredient(ItemID.CopperGreaves);
        } else if (recipe.TryGetResult(ItemID.IronGreaves, out _))
        {
            recipe.AddIngredient(ItemID.TinGreaves);
        } else if (recipe.TryGetResult(ItemID.LeadGreaves, out _))
        {
            recipe.AddIngredient(ItemID.IronGreaves);
        } else if (recipe.TryGetResult(ItemID.SilverGreaves, out _))
        {
            recipe.AddIngredient(ItemID.LeadGreaves);
        } else if (recipe.TryGetResult(ItemID.TungstenGreaves, out _))
        {
            recipe.AddIngredient(ItemID.SilverGreaves);
        } else if (recipe.TryGetResult(ItemID.GoldGreaves, out _))
        {
            recipe.AddIngredient(ItemID.TungstenGreaves);
        } else if (recipe.TryGetResult(ItemID.PlatinumGreaves, out _))
        {
            recipe.AddIngredient(ItemID.GoldGreaves);
        } else if (recipe.TryGetResult(ItemID.ShadowGreaves, out _) || recipe.TryGetResult(ItemID.CrimsonGreaves, out _) ||
                   recipe.TryGetResult(ItemID.FossilPants, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumGreaves);
        } else if (recipe.TryGetResult(ItemID.MoltenGreaves, out _) && !recipe.TryGetIngredient(ItemID.CrimsonGreaves, out _))
        {
            recipe.AddIngredient(ItemID.ShadowGreaves);
        } else if (recipe.TryGetResult(ItemID.NecroGreaves, out _))
        {
            recipe.AddIngredient(ItemID.FossilPants);
        } else if (recipe.TryGetResult(ItemID.JunglePants, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumGreaves);
        } else if (recipe.TryGetResult(ItemID.MeteorLeggings, out _))
        {
            recipe.AddIngredient(ItemID.PlatinumGreaves);
        }
        
        if (recipe.TryGetResult(ItemID.CobaltLeggings, out _))
        {
            recipe.AddIngredient(ItemID.MoltenGreaves);
        } else if (recipe.TryGetResult(ItemID.PalladiumLeggings, out _))
        {
            recipe.AddIngredient(ItemID.CobaltLeggings);
        } else if (recipe.TryGetResult(ItemID.MythrilGreaves, out _))
        {
            recipe.AddIngredient(ItemID.PalladiumLeggings);
        } else if (recipe.TryGetResult(ItemID.OrichalcumLeggings, out _))
        {
            recipe.AddIngredient(ItemID.MythrilGreaves);
        } else if (recipe.TryGetResult(ItemID.AdamantiteLeggings, out _))
        {
            recipe.AddIngredient(ItemID.OrichalcumLeggings);
        } else if (recipe.TryGetResult(ItemID.TitaniumLeggings, out _))
        {
            recipe.AddIngredient(ItemID.AdamantiteLeggings);
        }
    }
    private void ReplaceMiscRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.ManaCrystal, out _))
        {
            recipe.TryGetIngredient(ItemID.FallenStar, out Item fallenStar);
            fallenStar.stack = 20;
            // recipe.RemoveIngredient(ItemID.FallenStar);
            // recipe.AddIngredient(ItemID.FallenStar, 25);
        }

        if (recipe.TryGetResult(ItemID.SpaceGun, out _))
        {
            recipe.AddIngredient(ItemID.Handgun);
            recipe.AddIngredient(ItemID.FallenStar, 25);
        }

        if (recipe.TryGetIngredient(ItemID.SpellTome, out _))
        {
            recipe.RemoveTile(TileID.Bookcases);
            // Using prismatic bookcase, custom mod tile
            recipe.AddTile(ModContent.TileType<PrismaticBookcase>());
        }

        if (recipe.TryGetResult(ItemID.DaoofPow, out _))
        {
            recipe.RemoveTile(TileID.MythrilAnvil);
            recipe.AddTile(ModContent.TileType<Content.Tiles.AncientPrismaticAnvil>());
        }
    }

    private void ReplaceBootsRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.SpectreBoots, out _))
        {
            recipe.AddIngredient(ModContent.ItemType<AncientSlimeStone>());
            recipe.AddIngredient(ItemID.HermesBoots);
        }

        if (recipe.TryGetResult(ItemID.LightningBoots, out _))
        {
            recipe.AddIngredient(ItemID.HallowedBar, 3);
        }

        if (recipe.TryGetResult(ItemID.FrostsparkBoots, out _))
        {
            recipe.AddIngredient(ItemID.SoulofFright);
            recipe.AddIngredient(ItemID.SoulofSight);
            recipe.AddIngredient(ItemID.SoulofMight);
        }

        if (recipe.TryGetResult(ItemID.TerrasparkBoots, out _))
        {
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(ItemID.Ectoplasm, 5);
        }
    }

    private void ReplaceWingRecipes(Recipe recipe)
    {
        if (recipe.HasIngredient(ItemID.SoulofFlight) && !recipe.TryGetResult(ItemID.RocketBoots, out _))
        {
            recipe.RemoveIngredient(ItemID.SoulofFlight);
            // Add 20 true soul of flight as ingredient (custom item)
            recipe.AddIngredient(ModContent.ItemType<TrueSoulOfFlight>(), 25);
        }
    }

    private void ReplaceWhipRecipes(Recipe recipe)
    {
        if (recipe.TryGetResult(ItemID.ThornWhip, out _))
        {
            recipe.AddIngredient(ItemID.BlandWhip);
        }
        else if (recipe.TryGetResult(ItemID.BoneWhip, out _))
        {
            recipe.AddIngredient(ItemID.ThornWhip);
        }
    }

    private void ReplaceModdedRecipes(Recipe recipe)
    {
        if (ModContent.TryFind("FishGunsPlus", "DoubleBarrelCod", out ModItem result))
        {
            if (result.Item.type == recipe.createItem.type)
            {
                recipe.RemoveIngredient(ItemID.JungleSpores);
                if (ModContent.TryFind("FishGunsPlus", "VileSpitter", out ModItem vileSpitter))
                {
                    recipe.AddIngredient(vileSpitter);
                }
                if (ModContent.TryFind("FishGunsPlus", "BoneRattler", out ModItem boneRattler))
                {
                    recipe.AddIngredient(boneRattler);
                }
                if (ModContent.TryFind("FishGunsPlus", "Doober", out ModItem doober))
                {
                    recipe.AddIngredient(doober);
                }
                if (ModContent.TryFind("FishGunsPlus", "FlarefinThrower", out ModItem flarefinThrower))
                {
                    recipe.AddIngredient(flarefinThrower);
                }
                
                // recipe.ReplaceResult(result);
                // recipe.Register();
            }
        }
    }
}