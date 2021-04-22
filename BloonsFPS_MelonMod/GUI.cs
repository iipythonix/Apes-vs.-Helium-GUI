using UnityEngine;
using MelonLoader;

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

        public override void OnGUI()
        {
            if (CheatToggles.GUIEnabled)
            {

                MelonLogger.Msg("GUI = enabled");

                GUI.Label(new Rect(25, 25, 100, 30), "Python GUI");

                if (GUI.Toggle(new Rect(500f, 2f, 15f, 20f), CheatToggles.nobalooncollision, "No Balloon Collision") != CheatToggles.nobalooncollision)
                {
                    CheatToggles.nobalooncollision = !CheatToggles.nobalooncollision;
                }
            }
            else
            {
                CheatToggles.GUIEnabled = false;
                MelonLogger.Msg("GUI = disabled");
            }
        }
    }
}