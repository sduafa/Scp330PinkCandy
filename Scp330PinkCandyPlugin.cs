namespace Scp330PinkCandy;

using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Scp330;
using CandyKindID = InventorySystem.Items.Usables.Scp330.CandyKindID;

/// <summary>Gives Pink Candy from SCP-330 according to the configured chance.</summary>
public sealed class Scp330PinkCandyPlugin : Plugin<Config>
{
    private readonly Random random = new();

    public override string Name => "Scp330PinkCandy";

    public override string Author => "Server Administrator";

    public override Version Version => new(1, 0, 0);

    public override Version RequiredExiledVersion => new(9, 15, 2);

    public override void OnEnabled()
    {
        Exiled.Events.Handlers.Scp330.InteractingScp330 += OnInteractingScp330;
        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        Exiled.Events.Handlers.Scp330.InteractingScp330 -= OnInteractingScp330;
        base.OnDisabled();
    }

    private void OnInteractingScp330(InteractingScp330EventArgs ev)
    {
        double chance = Config.PinkCandyChance;
        chance = Math.Max(0d, Math.Min(100d, chance));

        if (!ev.IsAllowed || double.IsNaN(chance) || random.NextDouble() * 100d >= chance)
            return;

        ev.Candy = CandyKindID.Pink;

        if (Config.Debug)
            Log.Debug($"Gave Pink Candy to {ev.Player.Nickname} from SCP-330.");
    }
}
