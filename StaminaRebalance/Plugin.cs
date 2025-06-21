using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Runtime.CompilerServices;

namespace StaminaRebalance
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;

        private void Awake()
        {
            // Plugin startup logic
            Logger = base.Logger;
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
            Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
        }
    }
    [HarmonyPatch(typeof(CharacterMovement), "Start")]
    class Patch
    {
        static void Postfix(CharacterMovement __instance)
        {
            __instance.jumpStaminaUsageSprinting = 0.05f;
            __instance.sprintStaminaUsage = 0f;
        }
    }
}
