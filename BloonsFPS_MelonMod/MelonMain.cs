using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;

namespace BloonsFPSMelonMod
{
    /// <summary>
    /// If you need help with your mods, join the Bloons FPS discord server: https://discord.gg/6dMwHkzCyj
    /// Thanks to Sayan for creating such an Awesome fan game!
    /// </summary>
    public class MelonMain : MelonMod
    {
        // "modFolder" is the location of where your mods data will be. Ex: BloonsFPS/Mods/MyModsFolder
        // Assembly.GetExecutingAssembly()  will automatically get your mod's filename. Don't modify this line.
        internal static string modFolder = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";

        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Mod has finished loading.");
            MelonLogger.Msg("Please feel free to contribute to my github I take pull requests! https://github.com/iipythonix/Apes-vs.-Helium-GUI");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                MelonLogger.Msg("You just pressed T");
            }
        }

        

        public override void OnSceneWasLoaded(int buildIndex, string levelName)
        {
            if (levelName is null)
            {
                throw new ArgumentNullException(nameof(levelName));
            }
        }
    }
}