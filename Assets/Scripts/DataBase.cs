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
    [Header("Базовая вместимость инвентаря")]
    [SerializeField] private int baseCapacityInventory = 5;
    public static int BaseCapacityInventory => Instance.baseCapacityInventory;
    [Header("Увелечение вместимости в инвентаре за уровень")]
    [SerializeField] private int additionalCapacityPerLevel = 2;
    public static int AdditionalCapacityPerLevel => Instance.additionalCapacityPerLevel;
    [Header("Стоймость улучшения инвентаря - желтые монеты (стоймость = уровень * cost)")]
    [SerializeField] private int yellowCoinInventoryLevelUpCost = 5;
    public static int YellowCoinInventoryLevelUpCost => Instance.yellowCoinInventoryLevelUpCost;
    [Header("Стоймость улучшения инвентаря - красные монеты (стоймость = уровень * cost)")]
    [SerializeField] private int redCoinInventoryLevelUpCost = 5;
    public static int RedCoinInventoryLevelUpCost => Instance.redCoinInventoryLevelUpCost;
    [Space]
    [Header("Базовая длительность скашивания (чем больше тем дольше)")]
    [SerializeField] private int baseDurationSickle = 2;
    public static int BaseDurationSickle => Instance.baseDurationSickle;
    [Header("Увелечение скорости серпа за уровень")]
    [SerializeField] private float additionalSpeedSicklePerLevel = 0.2f;
    public static float AdditionalSpeedSicklePerLevel => Instance.additionalSpeedSicklePerLevel;
    [Header("Базовая дальность серпа")]
    [SerializeField] private int baseDistanceSickle = 5;
    public static int BaseDistanceSickle => Instance.baseDistanceSickle;
    [Header("Увелечение дальности в серпа за уровень")]
    [SerializeField] private float additionalDistancePerLevel = 0.5f;
    public static float AdditionalDistancePerLevel => Instance.additionalDistancePerLevel;
    [Header("Стоймость улучшения серпа - желтые монеты (стоймость = уровень * cost)")]
    [SerializeField] private int yellowCoinSickleLevelUpCost = 5;
    public static int YellowCoinSickleLevelUpCost => Instance.yellowCoinSickleLevelUpCost;
    [Header("Стоймость улучшения серпа - красные монеты (стоймость = уровень * cost)")]
    [SerializeField] private int redCoinSickleLevelUpCost = 5;
    public static int RedCoinSickleLevelUpCost => Instance.redCoinSickleLevelUpCost;
}