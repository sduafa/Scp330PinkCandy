namespace Scp330PinkCandy;

using System.ComponentModel;

/// <summary>Plugin configuration stored in <c>configs/&lt;port&gt;/Scp330PinkCandy/config.yml</c>.</summary>
public sealed class Config
{
    [Description("Whether verbose plugin logs are enabled.")]
    public bool Debug { get; set; } = false;

    [Description("Chance (0-100) that an SCP-330 interaction gives Pink Candy.")]
    public float PinkCandyChance { get; set; } = 15f;
}
