using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

namespace BloonsFPS_MelonMod
{
    class ESP
    {
        public static void EnableBloonESP()
        {
            GameObject bloon = GameObject.Find("Enemy");
            Vector3 bloonW2S = Camera.main.WorldToScreenPoint(bloon.transform.position);

            if (bloonW2S.z < 0)
                return;

            Drawing.DrawString(new Vector2(bloonW2S.x, (Screen.height - bloonW2S.y + 1.0f)), "Bloon", Color.grey, 16);
        }
    }
}
