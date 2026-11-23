namespace Scp330PinkCandy;

using System.ComponentModel;
using Exiled.API.Interfaces;

/// <summary>Plugin configuration generated in EXILED's server config.</summary>
public sealed class Config : IConfig
{
    [Description("Whether the plugin is enabled.")]
    public bool IsEnabled { get; set; } = true;

    [Description("Whether verbose plugin logs are enabled.")]
    public bool Debug { get; set; } = false;

    [Description("Chance (0-100) that an SCP-330 interaction gives Pink Candy.")]
    public float PinkCandyChance { get; set; } = 15f;
}
