using System;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace WindblownDpsPlugin;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin {
    private new static ManualLogSource Log;
    
    private readonly Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);

    public override void Load() {
        // Plugin startup logic
        Log = base.Log;
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        Console.WriteLine("Test log");
        harmony.PatchAll(typeof(WeaponBehaviourPatch));
    }
}

[HarmonyPatch(typeof(WeaponBehaviour))]
[HarmonyPatch("OnStartWeaponAttack")]
class WeaponBehaviourPatch {
    static bool Prefix(WeaponBehaviour __instance) {
        return true;
    }
}
