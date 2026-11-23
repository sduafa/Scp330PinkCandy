# Scp330PinkCandy

一个 [EXILED](https://github.com/Exiled-Team/EXILED) 插件：按配置的概率把 SCP-330 取出的糖果替换为 **Pink Candy（粉色糖果）**。

An EXILED plugin that replaces candy taken from SCP-330 with **Pink Candy** according to a configurable chance.

## 功能 / Features

- 监听 `Scp330.InteractingScp330` 事件。
- 按 `PinkCandyChance`（0–100）概率把本次取出的糖果设为 `CandyKindID.Pink`。
- 概率值会被限制在 0–100 之间，非法值（NaN）直接忽略。
- 仅在事件允许（`IsAllowed`）时生效，不会破坏其他插件对糖果的修改逻辑。
- 可选的调试日志。

## 配置 / Configuration

服务器配置文件中（`~/.config/EXILED/Configs/<port>-config.yml`）的 `scp330_pink_candy` 段：

| 键 | 类型 | 默认值 | 说明 |
| --- | --- | --- | --- |
| `is_enabled` | bool | `true` | 是否启用插件 |
| `debug` | bool | `false` | 是否输出详细日志 |
| `pink_candy_chance` | float | `15` | 每次交互获得 Pink Candy 的概率（0–100） |

## 构建 / Build

需要 .NET Framework 4.8 目标包与 .NET SDK：

```powershell
dotnet build Scp330PinkCandy.csproj -c Release
```

输出：`bin/Release/net48/Scp330PinkCandy.dll`。

依赖的 `ExMod.Exiled` 9.15.2 通过 NuGet 还原，`PrivateAssets="all"` 表示不会传递到下游项目。

## 安装 / Installation

1. 将 `Scp330PinkCandy.dll` 放入 EXILED 的 `Plugins` 目录。
2. 重启服务器，插件会自动生成配置。
3. 按需修改 `pink_candy_chance`。

## 仓库内容 / Repository contents

仓库按“原样上传整个文件夹”的要求提交，包含：

- 源码：`Config.cs`、`Scp330PinkCandyPlugin.cs`、`Scp330PinkCandy.csproj`
- 构建产物：`bin/`、`obj/`（其中含 EXILED / 游戏程序集，仅用于本地构建，不属于本插件）

> 注意：`bin/Release/net48` 中的 `Assembly-CSharp-Publicized.dll`、`Exiled.*.dll` 等为第三方程序集，版权归其各自作者所有，请勿单独再分发。
