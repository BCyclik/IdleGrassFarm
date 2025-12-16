using UnityEngine;

[CreateAssetMenu(fileName = "DataBase", menuName = "DataBase")]
public class DataBase : ScriptableObject
{
    private static DataBase instance = null;
    public static DataBase Instance
    {
        get
        {
            if (instance == null) instance = Resources.Load<DataBase>("DataBase");

            return instance;
        }
    }
    [SerializeField] private int additionalCapacityPerLevel = 2;
    public static int AdditionalCapacityPerLevel => Instance.additionalCapacityPerLevel;
    [SerializeField] private int yellowCoinInventoryLevelUpCost = 5;
    public static int YellowCoinInventoryLevelUpCost => Instance.yellowCoinInventoryLevelUpCost;
    [SerializeField] private int redCoinInventoryLevelUpCost = 5;
    public static int RedCoinInventoryLevelUpCost => Instance.redCoinInventoryLevelUpCost;
    [Space]
    [SerializeField] private float additionalDistancePerLevel = 0.5f;
    public static float AdditionalDistancePerLevel => Instance.additionalDistancePerLevel;
    [SerializeField] private int yellowCoinSickleLevelUpCost = 5;
    public static int YellowCoinSickleLevelUpCost => Instance.yellowCoinSickleLevelUpCost;
    [SerializeField] private int redCoinSickleLevelUpCost = 5;
    public static int RedCoinSickleLevelUpCost => Instance.redCoinSickleLevelUpCost;
}