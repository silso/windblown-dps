using System.Collections.Generic;
using BepInEx.Preloader.Core.Patching;
using Mono.Cecil;

namespace WindblownDpsPlugin;

[PatcherPluginInfo("io.bepis.mytestplugin", "My Test Plugin", "1.0")]
public class Patcher : BasePatcher
{
    // List of assemblies to patch
    // public static IEnumerable<string> TargetDLLs { get; } = new[] {"DpsPatches.dll"};
    public override void Initialize()
    {
        base.Initialize();
        Log.LogInfo($"Initialized Patcher");
    }

    // Patches the assemblies
    [TargetAssembly("bosco.dll")]
    public void PatchAssembly(AssemblyDefinition assembly)
    {
        var module = assembly.MainModule;
        Log.LogInfo($"Module count: {assembly.Modules.Count}");
    }
}