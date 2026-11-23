namespace Scp330PinkCandy;

using System;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Handlers;
using LabApi.Features.Console;
using LabApi.Loader.Features.Plugins;
using CandyKindID = InventorySystem.Items.Usables.Scp330.CandyKindID;

/// <summary>Gives Pink Candy from SCP-330 according to the configured chance.</summary>
public sealed class Scp330PinkCandyPlugin : Plugin<Config>
{
    private readonly Random random = new();

    public override string Name => "Scp330PinkCandy";

    public override string Description => "Gives Pink Candy from SCP-330 according to the configured chance.";

    public override string Author => "Server Administrator";

    public override Version Version => new(1, 0, 0);

    public override Version RequiredApiVersion => new(1, 1, 7);

    public override void Enable()
    {
        PlayerEvents.InteractingScp330 += OnInteractingScp330;
    }

    public override void Disable()
    {
        PlayerEvents.InteractingScp330 -= OnInteractingScp330;
    }

    private void OnInteractingScp330(PlayerInteractingScp330EventArgs ev)
    {
        float configured = Config.PinkCandyChance;
        if (float.IsNaN(configured))
            return;

        double chance = Math.Max(0d, Math.Min(100d, configured));

        if (!ev.IsAllowed || random.NextDouble() * 100d >= chance)
            return;

        ev.CandyType = CandyKindID.Pink;

        if (Config.Debug)
            Logger.Debug($"Gave Pink Candy to {ev.Player.DisplayName} from SCP-330.");
    }
}
