﻿using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Objects;

namespace Arphox.Stardew.ShowDailyLuck;

internal sealed class ModEntry : Mod
{
    public override void Entry(IModHelper helper)
    {
        helper.Events.GameLoop.DayStarted += DayStarted;
    }

    private void DayStarted(object? sender, DayStartedEventArgs e)
    {
        Game1.addMorningFluffFunction(TellLuckToPlayer);
    }

    private static void TellLuckToPlayer()
    {
        TV? tv = TryGetTvOnCurrentLocation(Game1.player);
        if (tv is null)
        {
            return;
        }

        string fortuneForecast = tv.getFortuneForecast(Game1.player);
        Game1.chatBox.addInfoMessage(fortuneForecast);
    }

    private static TV? TryGetTvOnCurrentLocation(Farmer farmer)
    {
        return farmer.currentLocation.furniture
            .OfType<TV>()
            .FirstOrDefault();
    }
}
