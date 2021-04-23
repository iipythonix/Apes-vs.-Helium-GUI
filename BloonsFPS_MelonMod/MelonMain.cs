using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;
using BloonsFPS_MelonMod;
using System.Collections.Generic;
using System.Linq;

namespace BloonsFPSMelonMod
{
    /// <summary>
    /// If you need help with your mods, join the Bloons FPS discord server: https://discord.gg/6dMwHkzCyj
    /// Thanks to Sayan for creating such an Awesome fan game!
    /// </summary>
    //////// 
    ///:D///
    ////////

    public class MelonMain : MelonMod
    {
        // "modFolder" is the location of where your mods data will be. Ex: BloonsFPS/Mods/MyModsFolder
        // Assembly.GetExecutingAssembly()  will automatically get your mod's filename. Don't modify this line.
        internal static string modFolder = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";

       
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("-------------------");
            MelonLogger.Msg("Loading 92%");
            MelonLogger.Msg("Mod has finished loading.");
            MelonLogger.Msg("Please feel free to contribute to my github I take pull requests!");
            MelonLogger.Msg("Keybinds:");
            MelonLogger.Msg("T = Show Current Info");
            MelonLogger.Msg("I = Toggle Invincibility");
            MelonLogger.Msg("Y = Add 100 Health");
            MelonLogger.Msg("O = Add 100 Coins");
            MelonLogger.Msg("Right SHift = Open GUI");
            MelonLogger.Msg("More Coming Soon!");
            MelonLogger.Msg("-------------------");
            MelonLogger.Warning("Don't Use Hacks Before In-Game, May Cause Crash!");
            MelonLogger.Warning("If something does not work correcty, comment on github page!");
        }

        //--------------------------------------Declarations
        public static PlayerHealth playerHealth;
        public static Currency currency;
        public static Weapon weapon;
        public static GameManagerScript gameManagerScript;
        public static WaveSpawner WaveSpawner;
        public static Enemy enemy;
        public static UpgradeScript upgradeScript;
        public static SpawnObjectScript spawnObjectscript;
        public static FollowerScript followerScript;
        //--------------------------------------Assignable Values
        public static int health;
        public static int money;
        public static string currentweapon;
        public static string currentscene;
        //--------------------------------------

        public static void CustomUpdate()
        {
            //----------------looking for existing instances
            playerHealth = UnityEngine.Object.FindObjectOfType<PlayerHealth>();
            upgradeScript = UnityEngine.Object.FindObjectOfType<UpgradeScript>();
            spawnObjectscript = UnityEngine.Object.FindObjectOfType<SpawnObjectScript>();
            currency = UnityEngine.Object.FindObjectOfType<Currency>();
            weapon = UnityEngine.Object.FindObjectOfType<Weapon>();
            WaveSpawner = UnityEngine.Object.FindObjectOfType<WaveSpawner>();
            enemy = UnityEngine.Object.FindObjectOfType<Enemy>();
            followerScript = UnityEngine.Object.FindObjectOfType<FollowerScript>();
            _weapon = UnityEngine.Object.FindObjectsOfType<Weapon>().ToList<Weapon>();


            //----------------Assigning Values
            health = playerHealth.health;
            money = currency.currency;
            currentweapon = weapon.ToString();

        }

        public static List<Weapon> _weapon;

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
             CustomUpdate();
             playerHealth.UpdateHealth(+100);
             MelonLogger.Msg("Added 100 Health");
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
             CustomUpdate();
             currency.UpdateCurrency(+100);
                MelonLogger.Msg("Added 100 currency");
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                CustomUpdate();
                weapon.Attack();
            }

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                if (CheatToggles.GUIEnabled == false)
                {
                    CheatToggles.GUIEnabled = true;
                    MelonLogger.Msg("GUI = enabled");
                }
                else
                {
                    CheatToggles.GUIEnabled = false;
                    MelonLogger.Msg("GUI = disabled");
                }
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                CheatToggles.enableWeaponBuff = true;
                MelonLogger.Msg("WeaponBuff = enabled");
            }


            //if press T
            if (Input.GetKeyDown(KeyCode.T))
            {
             CustomUpdate();
                MelonLogger.Msg("Printing Info...");
                MelonLogger.Msg("----------");
                MelonLogger.Msg("current scene = " + currentscene);
                MelonLogger.Msg("Health = " + health);
                MelonLogger.Msg("Money = " + money);
                MelonLogger.Msg("Current Weapon = " + currentweapon);
                MelonLogger.Msg("----------");
                MelonLogger.Msg("Done!");
            }

                //-------------------------------------------Invincible
                if (Input.GetKeyDown(KeyCode.I))
                {
                     CustomUpdate();

                    if (CheatToggles.nobalooncollision == false)
                    {
                        CheatToggles.nobalooncollision = true;
                        playerHealth.invincible = true;
                        MelonLogger.Msg("You will now collide with baloons!");
                    }
                    else
                    {
                        CheatToggles.nobalooncollision = false;
                        playerHealth.invincible = false;
                        MelonLogger.Msg("You will no longer collide with baloons!");
                    }

                }
                //----------------------------------------------------

        }

        public override void OnSceneWasLoaded(int buildIndex, string levelName)
        {
            if (levelName is null)
            {
                throw new ArgumentNullException(nameof(levelName));
            }
        }

        // If this stops working I'll smash my keyboard. I've been doing this for 3 days straight.
        public override void OnGUI()
        {
            Menu.OnMenu();
        }
    }
}
