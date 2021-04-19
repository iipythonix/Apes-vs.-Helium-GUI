using UnityEngine;
using System;
using MelonLoader;

namespace BloonsFPS_MelonMod
{
    public class GUI : MelonMod
    {
        public override void OnGUI()
        {
            Button(new Rect(0, 0, 250, 100), "Button", GUIStyle.none);
        }

        private static void Button(Rect rect, string v, GUIStyle none)
        {
            throw new NotImplementedException();
        }
    }
}