# Scp330PinkCandy

An [SCP: Secret Laboratory](https://store.steampowered.com/app/700330/) [LabAPI](https://github.com/northwood-studios/LabAPI) plugin that replaces candy taken from SCP-330 with **Pink Candy** based on a configurable probability.

> Migrated from EXILED to LabAPI (`Northwood.LabAPI` 1.1.7). The plugin no longer depends on `ExMod.Exiled`.

## Features

- Listens to the `PlayerEvents.InteractingScp330` event.
- Sets the retrieved candy to `CandyKindID.Pink` based on `PinkCandyChance` (0–100).
- The probability is clamped between 0 and 100; invalid values (such as `NaN`) are ignored.
- Only takes effect when the event is allowed (`IsAllowed`), so it does not override another plugin's decision to deny candy.
- Includes optional debug logging.

## Requirements

- SCP: Secret Laboratory dedicated server with LabAPI 1.1.7+ (bundled with every official server build).
- No separate LabAPI installation is required.

## Installation

1. Place `Scp330PinkCandy.dll` into the LabAPI plugins directory:
   - Default: `%APPDATA%\SCP Secret Laboratory\LabAPI\plugins\`
   - With hoster policy (`gamedir_for_configs: true` in `hoster_policy.txt`): `AppData\SCP Secret Laboratory\LabAPI\plugins\` inside the server directory.
2. Restart the server.

## Configuration

The plugin configuration is generated at:

```
%APPDATA%\SCP Secret Laboratory\LabAPI\configs\<port>\Scp330PinkCandy\config.yml
```

| Key | Type | Default | Description |
| --- | --- | --- | --- |
| `debug` | bool | `false` | Whether to output detailed logs |
| `pink_candy_chance` | float | `15` | Probability (0–100) of obtaining Pink Candy per interaction |

Enabling/disabling the plugin is controlled by `properties.yml` in the same directory:

```yaml
is_enabled: true
unsupported_loading: Default
```

## Build

Requires the .NET SDK and the .NET Framework 4.8 targeting pack:

```powershell
dotnet build Scp330PinkCandy.csproj -c Release
```

Output: `bin/Release/net48/Scp330PinkCandy.dll`.

Project references:

- NuGet `Northwood.LabAPI` 1.1.7 (`PrivateAssets="all"` and `ExcludeAssets="runtime"`; it is not copied to the output).
- `refs/Assembly-CSharp-Publicized.dll`: game assembly used only to compile against `CandyKindID` (`Private=false`, not packaged).

## Repository contents

- Source: `Config.cs`, `Scp330PinkCandyPlugin.cs`, `Scp330PinkCandy.csproj`
- Build reference: `refs/Assembly-CSharp-Publicized.dll`
- `bin/` and `obj/` are ignored and not tracked; build the plugin locally to produce the DLL.

> Note: the game assembly in `refs/` is © Northwood Studios and is included only as a compile-time reference. Do not redistribute it separately.
