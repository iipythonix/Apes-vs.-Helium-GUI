using UnityEngine;
using MelonLoader;
using BloonsFPS_MelonMod;
using BloonsFPSMelonMod;

namespace BloonsFPS_MelonMod
{
    public class Menu : MelonMod
    {
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
        public static int x; // Lives
        public static int y; // Currency
        public static int health;
        public static int money;
        public static string currentweapon;
        public static string currentscene;
        public static string currencyString;
        public static string livesString;
        public static float movementSpeed;
        public static bool noknockback;
        public static bool resetSmovementSpeed;
        public static string speedString;
        //--------------------------------------Define update currency and lives

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

            //----------------Assigning Values
            health = playerHealth.health;
            money = currency.currency;
            currentweapon = weapon.ToString();

        }

        public static void OnMenu()
        {
            if (CheatToggles.GUIEnabled)
            {
                if (CheatToggles.isAlreadyLogged == false)
                {
                    MelonLogger.Msg("GUI = enabled");
                    CheatToggles.isAlreadyLogged = true;
                }
                else if (CheatToggles.isAlreadyLogged == true)
                {
                    ;
                }

                GUI.Box(new Rect(0f, 0f, 400f, 200f), "BloonsFPSGUI");

                // God Mode
                if (GUI.Toggle(new Rect(0f, 20f, 200f, 20f), CheatToggles.noblooncollision, "God Mode") != CheatToggles.noblooncollision)
                {
                    CheatToggles.noblooncollision = !CheatToggles.noblooncollision;
                }

                // Currency
                if (GUI.Button(new Rect(0f, 36f, 200f, 20f), "Add Money"))
                {
                    CustomUpdate();
                    currency.UpdateCurrency(+y);
                    MelonLogger.Msg("Added currency");
                }
                y.ToString(currencyString);
                currencyString = GUI.TextField(new Rect(0f, 60f, 200f, 20f), "Moners");

                // Health
                if (GUI.Button(new Rect(0f, 96f, 200f, 20f), "Add health"))
                {
                    CustomUpdate();
                    playerHealth.UpdateHealth(+x);
                    MelonLogger.Msg("Added health");
                }
                x.ToString(livesString);
                livesString = GUI.TextField(new Rect(0f, 120f, 200f, 20f), "Hearts");

                // Dead function for now
                if (GUI.Toggle(new Rect(200f, 20f, 200f, 20f), CheatToggles.GUIWeapon, "Bloon ESP") != CheatToggles.GUIWeapon)
                {
                    CheatToggles.GUIWeapon = !CheatToggles.GUIWeapon;
                }

                // Weapon GUI
                if (CheatToggles.GUIWeapon == true)
                {
                    GUI.Box(new Rect(0f, 200f, 400f, 200f), "Weapon GUI");
                    {
                        if (GUI.Toggle(new Rect(0f, 210f, 200f, 20f), CheatToggles.enableWeaponBuff, "Hypersonic Toggle"))
                        {
                            CheatToggles.enableWeaponBuff = !CheatToggles.enableWeaponBuff;
                        }
                    }
                }
                
            }
            else if (CheatToggles.GUIEnabled == false)
            {
                if (CheatToggles.isAlreadyLogged == false)
                {
                    MelonLogger.Msg("GUI = disabled");
                    CheatToggles.isAlreadyLogged = true;
                }
                else if (CheatToggles.isAlreadyLogged == true)
                {
                    ;
                }
            }
        }
    }
}
    
