# ContextMenuControl

A [ResoniteModLoader](https://github.com/resonite-modding-group/ResoniteModLoader) mod for [Resonite](https://resonite.com/) that allows for higher control over your context menu and the options in them.

Current Features (All configurable)
* Hide the scale button entirely
* Hide the locomotion button entirely
* Disable the reset scale option, instead only the toggle is shown
* Allows hiding the whole context menu, including the root menu

## Installation
1. Install [ResoniteModLoader](https://github.com/resonite-modding-group/ResoniteModLoader).
1. Place [ContextMenuControl.dll](https://github.com/XDelta/ContextMenuControl/releases/latest/download/ContextMenuControl.dll) into your `rml_mods` folder. This folder should be at `C:\Program Files (x86)\Steam\steamapps\common\Resonite\rml_mods` for a default install. You can create it if it's missing, or if you launch the game once with ResoniteModLoader installed it will create this folder for you.
1. Start the game. If you want to verify that the mod is working you can check your Resonite logs.

## Config Options

| Config Option     | Default | Description |
| ------------------ | ------- | ----------- |
| `hideScaleButtonEntirely` | `false` | Hide the scaling options entirely |
| `hideLocomotionButtonEntirely` | `false` | Hide the locomotion options entirely |
| `disableScaleReset` | `false` | Disable reset scale option, instead just enable/disable will be shown |
| `hiddenContextMenu` | `false` | Hide the context menu from others, overrides visibility settings on submenus |