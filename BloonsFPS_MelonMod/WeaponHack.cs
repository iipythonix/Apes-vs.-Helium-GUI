using System.Collections.Generic;
using System.Linq;
using MelonLoader;
using UnityEngine;
using BloonsFPSMelonMod;
using BloonsFPS_MelonMod;

namespace BloonsFPSMelonMod
{
    public class WeaponHack
    {
        //List float
        public static void CustomUpdate()
        {
            _weapon = UnityEngine.Object.FindObjectsOfType<Weapon>().ToList<Weapon>();
        }
        public static List<Weapon> _weapon;
        public int damage;
        public float attackspeed;

        public static int Value { get; set; }

        //Make the stupid dumb text read
        public void OnUpdate()
        {
            if (CheatToggles.enableWeaponBuff == true)
            {
                CheatToggles.GUIWeapon = true;

            }
        }
    }
}
