using UnityEngine;
using System;
using MelonLoader;

namespace BloonsFPS_MelonMod
{
    public class GUI : MelonMod
    {
        void Button()
        {

        }
        Texture tex;
        public override void OnGUI()
        {
            if (!tex)
            {
                MelonLogger.Msg("Texture???");
            }

            if (GUILayout.Button(tex))
            {
                MelonLogger.Msg("Clicked the thing");
            }

            if (GUILayout.Button("Button"))
            {
                MelonLogger.Msg("Button pressed");
            }
        }
    }
}