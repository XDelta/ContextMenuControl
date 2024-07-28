using FrooxEngine;
using HarmonyLib;
using ResoniteModLoader;

namespace ContextMenuControl;

public class ContextMenuControl : ResoniteMod {
	internal const string VERSION_CONSTANT = "1.0.0";
	public override string Name => "ContextMenuControl";
	public override string Author => "Delta";
	public override string Version => VERSION_CONSTANT;
	public override string Link => "https://github.com/XDelta/ContextMenuControl";

	[AutoRegisterConfigKey]
	private static readonly ModConfigurationKey<bool> hideScaleButtonEntirely = new ModConfigurationKey<bool>("hideScaleButtonEntirely", "Hide the scaling options entirely", () => false);

	[AutoRegisterConfigKey]
	private static readonly ModConfigurationKey<bool> hideLocomotionButtonEntirely = new ModConfigurationKey<bool>("hideLocomotionButtonEntirely", "Hide the locomotion options entirely", () => false);

	[AutoRegisterConfigKey]
	private static readonly ModConfigurationKey<bool> disableScaleReset = new ModConfigurationKey<bool>("disableScaleReset", "Disable reset scale option, instead just enable/disable will be shown", () => false);

	[AutoRegisterConfigKey]
	private static readonly ModConfigurationKey<bool> hiddenContextMenu = new ModConfigurationKey<bool>("hiddenContextMenu", "Hide the context menu from others, overrides visibility settings on submenus", () => false);

	internal static ModConfiguration Config;

	public override void OnEngineInit() {
		Config = GetConfiguration();
		Config.Save(true);
		Harmony harmony = new Harmony("net.deltawolf.ContextMenuControl");
		harmony.PatchAll();
	}
	//IsAtScale is only used for the Reset Scale check.
	[HarmonyPatch(typeof(UserRoot), "IsAtScale")]
	private class UserRootIsAtScalePatch {
		public static bool Prefix(UserRoot __instance, ref bool __result) {
			if (Config.GetValue(disableScaleReset)) {
				__result = true;
				return false;
			}
			return true;
		}
	}

	//Disable the scale button
	[HarmonyPatch(typeof(InteractionHandler), "CanScale", MethodType.Getter)]
	private class InteractionHandlerCanScalePatch {
		public static bool Prefix(InteractionHandler __instance, ref bool __result) {
			if (Config.GetValue(hideScaleButtonEntirely)) {
				__result = false;
				return false;
			}
			return true;
		}
	}

	//Disable the locomotion button
	[HarmonyPatch(typeof(LocomotionController), "CanUseAnyLocomotion")]
	private class LocomotionControllerCanUseAnyLocomotionPatch {
		public static bool Prefix(LocomotionController __instance, ref bool __result) {
			if (Config.GetValue(hideLocomotionButtonEntirely)) {
				__result = false;
				return false;
			}
			return true;
		}
	}

	//Set ContextMenuOptions to be hidden for all context menus
	[HarmonyPatch(typeof(ContextMenu), "OpenMenu", new[] { typeof(IWorldElement), typeof(Slot), typeof(ContextMenuOptions) })]
	private class ContextMenuOpenMenuPatch {
		public static void Prefix(ref ContextMenuOptions options) {
			if (Config.GetValue(hiddenContextMenu)) {
				options.hidden = true; //force the hidden option to be true.
			}
		}
	}
}
