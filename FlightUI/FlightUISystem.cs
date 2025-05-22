using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace higharia.FlightUI;

public class FlightUISystem : ModSystem
{
    internal UserInterface FlightUI;
    internal FlightUI FlightUIState;
    
    private GameTime _lastUpdateUiGameTime;

    public override void Load()
    {
        if (Main.dedServ)
        {
            return;
        }

        FlightUI = new UserInterface();

        FlightUIState = new FlightUI();
        FlightUIState.Activate();
    }
    
    

    public override void UpdateUI(GameTime gameTime)
    {
        _lastUpdateUiGameTime = gameTime;
        if (FlightUI?.CurrentState != null)
        {
            FlightUI.Update(gameTime);
        }
    }
    
    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
        int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
        if (mouseTextIndex != -1) {
            layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                "Higharia: FlightUI",
                delegate
                {
                    if ( _lastUpdateUiGameTime != null && FlightUI?.CurrentState != null) {
                        FlightUI.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
                    }
                    return true;
                },
                InterfaceScaleType.UI));
        }
    }
    
    internal void ShowFlightUI() {
        FlightUI?.SetState(FlightUIState);
    }

    internal void HideFlightUI() {
        FlightUI?.SetState(null);
    }
}