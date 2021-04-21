using BloonsFPSMelonMod;
using MelonLoader;

namespace BloonsFPS_MelonMod
{
    public class KeyBinds : MelonMod
    {

        public class EnableKeybinds
        {
            public static bool enableKeybinds = true;
        }

        public class ToggleKeybinds
        {
            
        }

        private class EnableKeybindsGetSet
        {
            public bool enableKeybinds { get; set; }
        }
    }
}