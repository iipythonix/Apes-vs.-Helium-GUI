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
        public static void changeLives(int number)
        {
            PlayerHealth.instance.UpdateHealth(number);
        }
        public static void changeMoney(int number)
        {
            Currency.instance.UpdateCurrency(number);
        }

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

                GUI.Box(new Rect(0, 0, 400, 200), "BloonsFPSGUI");

                if (GUI.Toggle(new Rect(0f, 20f, 200f, 20f), CheatToggles.nobalooncollision, "No Balloon Collision") != CheatToggles.nobalooncollision)
                {
                    CheatToggles.nobalooncollision = !CheatToggles.nobalooncollision;
                }
                if (GUI.Button(new Rect(0f, 36f, 200f, 20f), "Add $100"))
                {
                    CustomUpdate();
                    currency.UpdateCurrency(+100);
                    MelonLogger.Msg("Added 100 currency");
                }
                if (GUI.Button(new Rect(0f, 56f, 200f, 20f), "Add $1000"))
                {
                    CustomUpdate();
                    currency.UpdateCurrency(+1000);
                    MelonLogger.Msg("Added $1000");
                }
                if (GUI.Button(new Rect(0f, 76f, 200f, 20f), "Add $10000"))
                {
                    CustomUpdate();
                    currency.UpdateCurrency(+10000);
                    MelonLogger.Msg("Added $10000");
                }
                if (GUI.Button(new Rect(0f, 96f, 200f, 20f), "Add 100 health"))
                {
                    CustomUpdate();
                    playerHealth.UpdateHealth(+100);
                    MelonLogger.Msg("Added 100 health");
                }
                if (GUI.Button(new Rect(0f, 116f, 200f, 20f), "Add 1000 health"))
                {
                    CustomUpdate();
                    playerHealth.UpdateHealth(+1000);
                    MelonLogger.Msg("Added 1000 health");
                }
                GUI.Label(new Rect(300f, 10f, 200f, 20f), "AttackSpeed Value: " + WeaponHack::attackspeed.ToString());
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
    
