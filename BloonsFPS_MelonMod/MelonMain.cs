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
            //MelonLogger.Msg("");

            MelonLogger.Msg("------------------");
            MelonLogger.Msg("Loading 92%");
            MelonLogger.Msg("Mod has finished loading.");
            MelonLogger.Msg("Please feel free to contribute to my github I take pull requests!");
            MelonLogger.Msg("Keybinds:");
            MelonLogger.Msg("T = Show Current Info");
            MelonLogger.Msg("Numlock = Toggle Invincibility");
            MelonLogger.Msg("Y = Add 100 Health");
            MelonLogger.Msg("More Coming Soon!");
            MelonLogger.Msg("-----------------");


            gameManagerScript = UnityEngine.Object.FindObjectOfType<GameManagerScript>();
            currentscene = gameManagerScript.levelSelected;
        }


       

        //--------------------------------------Declarations
        public static PlayerHealth playerHealth;
        public static Currency currency;
        public static Weapon weapon;
        public static GameManagerScript gameManagerScript;
        //--------------------------------------Assignable Values
        public static int health;
        public static int money;
        public static bool isinv = false;
        public static string currentweapon;
        public static string currentscene;
        //--------------------------------------
        

        public override void OnUpdate()
        {
            
            


            if (currentscene == "Tropical Island") //if on island
            {

               //----------------looking for existing instances
               playerHealth = UnityEngine.Object.FindObjectOfType<PlayerHealth>();
               currency = UnityEngine.Object.FindObjectOfType<Currency>();
               weapon = UnityEngine.Object.FindObjectOfType<Weapon>();

               //--------------- Asigning values---------------
               health = playerHealth.health;
               money = currency.currency;
               currentweapon = weapon.ToString();


                if (Input.GetKeyDown(KeyCode.Y))
                {
                    playerHealth.UpdateHealth(+100);
                }

                    //if press T
                if (Input.GetKeyDown(KeyCode.T))
                {
                
                MelonLogger.Msg(currentscene);
                MelonLogger.Msg("Health = " + health);
                MelonLogger.Msg("Money = " + money);
                MelonLogger.Msg("Current Weapon = " + currentweapon);
                }
               
                //-------------------------------------------Invincible
                if (Input.GetKeyDown(KeyCode.Numlock))
                {
                    if (isinv == false)
                    {
                        isinv = true;
                        playerHealth.invincible = true;
                    }
                    else
                    {
                        isinv = false;
                        playerHealth.invincible = false;
                    }

                }
                //----------------------------------------------------


            }

            else //if not on island
            {
              
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
