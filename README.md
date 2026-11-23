# Scp330PinkCandy

An [EXILED](https://github.com/Exiled-Team/EXILED) plugin that replaces candy taken from SCP-330 with **Pink Candy** based on a configurable probability.

## Features

- Listens to the `Scp330.InteractingScp330` event.
- Sets the retrieved candy to `CandyKindID.Pink` based on the `PinkCandyChance` (0–100).
- The probability value is clamped between 0 and 100; invalid values ​​(such as NaN) are ignored.
- Only takes effect when the event is permitted (`IsAllowed`), ensuring it does not interfere with candy-modification logic implemented by other plugins.
- Includes optional debug logging.

## Configuration

Located under the `scp330_pink_candy` section in your server configuration file (`~/.config/EXILED/Configs/<port>-config.yml`):

| Key | Type | Default | Description |
| --- | --- | --- | --- |
| `is_enabled` | bool | `true` | Whether the plugin is enabled |
| `debug` | bool | `false` | Whether to output detailed logs |
| `pink_candy_chance` | float | `15` | The probability (0–100) of obtaining Pink Candy per interaction |

## Build

Requires the .NET Framework 4.8 targeting pack and the .NET SDK:

```powershell
dotnet build Scp330PinkCandy.csproj -c Release
```

Output: `bin/Release/net48/Scp330PinkCandy.dll`.

The dependency `ExMod.Exiled` 9.15.2 is restored via NuGet; `PrivateAssets="all"` is used to ensure it is not propagated to downstream projects. ## Installation

1. Place `Scp330PinkCandy.dll` into the `Plugins` directory of EXILED.
2. Restart the server; the plugin will automatically generate its configuration.
3. Modify `pink_candy_chance` as desired.

