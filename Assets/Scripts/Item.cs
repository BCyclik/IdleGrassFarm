using UnityEngine;
[CreateAssetMenu(fileName = "newItem", menuName = "Item")]
public class Item : ScriptableObject
{
    public string Id => name;

    [SerializeField] private Sprite icon;
    public Sprite Icon => icon;
    [SerializeField] private int priceRedCoins;
    public int PriceRedCoins => priceRedCoins;
    [SerializeField] private int priceYellowCoins;
    public int PriceYellowCoins => priceYellowCoins;
    [SerializeField] private GameObject obj;
    public GameObject Obj => obj;
}