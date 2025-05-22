using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace higharia;

public class ItemTweaker : GlobalItem
{
    
    public override void SetDefaults(Item item)
    {
        ModifyItemNames(item);
        ModifyItemRarities(item);

        if (item.type == ItemID.IceRod)
        {
            item.damage = 11;
            item.mana = 8;
            item.useTime = 18;
            item.useAnimation = 18;
            item.value = Item.sellPrice(0, 3);
        }

        if (item.type == ItemID.PrincessWeapon)
        {
            item.damage = 51;
            item.mana = 16;
            item.useTime = 30;
            item.useAnimation = 30;
            item.value = Item.sellPrice(0, 7);
        }

        if (item.type == ItemID.CrystalSerpent)
        {
            item.damage = 36;
            item.mana = 10;
            item.useTime = 26;
            item.useAnimation = 26;
            item.value = Item.sellPrice(0, 5);
        }

        if (item.type == ItemID.CandyCaneSword)
        {
            item.damage = 26;
        }
        
        if (item.type == ItemID.RedRyder)
        {
            item.damage = 29;
        }

        if (item.type == ItemID.SquirrelHook)
        {
            item.value = 12;
        }

        if (item.type == ItemID.FishHook)
        {
            item.shootSpeed = 10;
        }

        if (item.type == ItemID.Clentaminator)
        {
            item.value = Item.sellPrice(0, 25);
        }
        
        if (ModContent.TryFind("FishGunsPlus", "DoubleBarrelCod", out ModItem doubleBarrelCod) && doubleBarrelCod.Item.type == item.type)
        {
            item.damage = 20;
        }

        if (item.type == ItemID.SoulDrain)
        {
            item.damage = 50;
        }

        if (item.type == ItemID.BreakerBlade)
        {
            item.useTime = 42;
            item.useAnimation = 42;
        }

        if (item.type == ItemID.CursedFlames)
        {
            item.useTime = 24;
            item.useAnimation = 22;
            item.damage = 73;
            item.mana = 13;
        }

        if (item.type == ItemID.SkyFracture)
        {
            item.damage = 54;
        }

        if (item.type == ItemID.RainbowRod)
        {
            item.damage = 68;
        }

        if (item.type == ItemID.MedusaHead)
        {
            item.damage = 52;
        }

        if (item.type == ItemID.Frostbrand)
        {
            item.useTime = 20;
            item.useAnimation = 20;
            item.damage = 45;
        }

        if (item.type == ItemID.IceSickle)
        {
            item.useTime = 28;
            item.useAnimation = 28;
            item.damage = 70;
        }

        if (item.type == ItemID.HelFire)
        {
            item.damage = 45;
        }

        if (item.type == ItemID.Chik)
        {
            item.damage = 54;
        }

        if (item.type == ItemID.Gradient)
        {
            item.value = Item.sellPrice(0, 30);
        }

        if (item.type == ItemID.Code2)
        {
            item.damage = 59;
        }

        if (item.type == ItemID.Amarok)
        {
            item.damage = 66;
        }
    }

    public override void SetStaticDefaults()
    {
        // Disable sailfish boots
        ItemID.Sets.Deprecated[ItemID.SailfishBoots] = true;
        ItemID.Sets.Deprecated[ItemID.TsunamiInABottle] = true;
        ItemID.Sets.Deprecated[ItemID.SlimeHook] = true;
        ItemID.Sets.Deprecated[ItemID.CandyCaneHook] = true;
        ItemID.Sets.Deprecated[ItemID.OrichalcumAnvil] = true;
        // ModContent.TryFind("FishGunsPlus", "MutantNightfish", out ModItem mutantNightfish);
        // ItemID.Sets.Deprecated[mutantNightfish.Type] = true;
    }

    private void ModifyItemNames(Item item)
    {
        if (item.type == ItemID.GrapplingHook)
        {
            item.SetNameOverride("Molten Hook");
        }
    }

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        if (item.type == ItemID.LuckyHorseshoe || item.type == ItemID.ObsidianHorseshoe)
        {
            tooltips[3] = new TooltipLine(Higharia.Instance(), "Horseshoe", "Reduces fall damage by 50%");
        } else if (item.type == ItemID.BlueHorseshoeBalloon || item.type == ItemID.YellowHorseshoeBalloon ||
                   item.type == ItemID.WhiteHorseshoeBalloon)
        {
            tooltips[4] = new TooltipLine(Higharia.Instance(), "HorseshoeBalloon", "Increases jump height and reduces fall damage by 50%");
        } else if (item.type == ItemID.BalloonHorseshoeFart ||
                   item.type == ItemID.BalloonHorseshoeHoney || item.type == ItemID.HorseshoeBundle)
        {
            tooltips[3] = new TooltipLine(Higharia.Instance(), "HorseshoeBalloon", "Increases jump height and reduces fall damage by 50%");
        }
        
        if (item.type == ItemID.RocketBoots) // Post WoF
        {
            TooltipLine tooltip = new TooltipLine(Higharia.Instance(), "flightTime", $"[c/aaaaaa:Flight time:] [c/44C87F: 1.17s]");
            tooltips.Add(tooltip);
        }
        if (item.type == ItemID.SpectreBoots) // Post Queen Slime
        {
            TooltipLine tooltip = new TooltipLine(Higharia.Instance(), "flightTime", $"[c/aaaaaa:Flight time:] [c/44C87F: 1.5s]"); // + 0.33s
            tooltips.Add(tooltip);
        }
        if (item.type == ItemID.LightningBoots) // Post Mechanical boss (any)
        {
            TooltipLine tooltip = new TooltipLine(Higharia.Instance(), "flightTime", $"[c/aaaaaa:Flight time:] [c/44C87F: 1.79s]"); // + 0.29s
            tooltips.Add(tooltip);
        }
        if (item.type == ItemID.FrostsparkBoots) // Post all mech bosses
        {
            TooltipLine tooltip = new TooltipLine(Higharia.Instance(), "flightTime", $"[c/aaaaaa:Flight time:] [c/44C87F: 2.22s]"); // + 0.43s
            tooltips.Add(tooltip);
        }
        if (item.type == ItemID.TerrasparkBoots) // Post Plantera
        {
            TooltipLine tooltip = new TooltipLine(Higharia.Instance(), "flightTime", $"[c/aaaaaa:Flight time:] [c/44C87F: 2.56s]"); // + 0.34s
            tooltips.Add(tooltip);
        }

        if (item.type == ItemID.SoulDrain)
        {
            TooltipLine tooltip = new TooltipLine(Higharia.Instance(), "SoulDrain", "Great against crowds!");
            tooltips.Add(tooltip);
        }
    }

    private void ModifyItemRarities(Item item)
    {
        if (item.type == ItemID.GrapplingHook)
        {
            item.rare = ItemRarityID.Orange;
        } else if (item.type == ItemID.ObsidianSkull)
        {
            item.rare = ItemRarityID.Blue;
        } else if (item.type == ItemID.HandWarmer)
        {
            item.rare = ItemRarityID.Blue;
        } else if (item.type == ItemID.ObsidianRose)
        {
            item.rare = ItemRarityID.Blue;
        } else if (item.type == ItemID.LuckyHorseshoe)
        {
            item.rare = ItemRarityID.Green;
        } else if (item.type == ItemID.HermesBoots)
        {
            item.rare = ItemRarityID.Green;
        } else if (item.type == ItemID.IceRod)
        {
            item.rare = ItemRarityID.Green;
        } else if (item.type == ItemID.CrystalSerpent)
        {
            item.rare = ItemRarityID.Orange;
        } else if (item.type == ItemID.PrincessWeapon)
        {
            item.rare = ItemRarityID.LightRed;
        } else if (item.type == ItemID.CloudinaBottle)
        {
            item.rare = ItemRarityID.Green;
        }
        
        if (item.type == ItemID.AmethystHook)
        {
            item.rare = ItemRarityID.LightRed;
        } else if (item.type == ItemID.TopazHook)
        {
            item.rare = ItemRarityID.LightRed;
        } else if (item.type == ItemID.SapphireHook)
        {
            item.rare = ItemRarityID.LightRed;
        } else if (item.type == ItemID.EmeraldHook)
        {
            item.rare = ItemRarityID.LightRed;
        } else if (item.type == ItemID.RubyHook)
        {
            item.rare = ItemRarityID.LightRed;
        } else if (item.type == ItemID.DiamondHook)
        {
            item.rare = ItemRarityID.Pink;
        }  else if (item.type == ItemID.AmberHook)
        {
            item.rare = ItemRarityID.Pink;
        }

        if (item.type == ItemID.RocketBoots)
        {
            item.rare = ItemRarityID.LightRed;
        } else if (item.type == ItemID.SpectreBoots)
        {
            item.rare = ItemRarityID.Pink;
        }

        if (item.type == ItemID.BlizzardinaBottle || item.type == ItemID.BlizzardinaBalloon)
        {
            item.rare = ItemRarityID.Pink;
        } else if (item.type == ItemID.SandstorminaBottle || item.type == ItemID.SandstorminaBalloon)
        {
            item.rare = ItemRarityID.Pink;
        } else if (item.type == ItemID.YellowHorseshoeBalloon || item.type == ItemID.WhiteHorseshoeBalloon)
        {
            item.rare = ItemRarityID.LightPurple;
        }
        
        if (item.type == ItemID.Clentaminator)
        {
            item.rare = ItemRarityID.LightRed;
        }

        if (item.type == ItemID.SoulDrain)
        {
            item.rare = ItemRarityID.LightPurple;
        }

        if (item.type == ItemID.SkyFracture)
        {
            item.rare = ItemRarityID.LightPurple;
        }
        
        if (item.type == ItemID.RainbowRod)
        {
            item.rare = ItemRarityID.LightPurple;
        }

        if (item.type == ItemID.MedusaHead)
        {
            item.rare = ItemRarityID.Pink;
        }

        if (item.type == ItemID.Gradient)
        {
            item.rare = ItemRarityID.LightRed;
        }

        if (item.type == ItemID.Chik)
        {
            item.rare = ItemRarityID.Pink;
        }

        if (item.type == ItemID.Amarok)
        {
            item.rare = ItemRarityID.LightPurple;
        }
    }
    
}