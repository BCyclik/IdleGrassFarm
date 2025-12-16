using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewGame : MonoBehaviour
{
    [SerializeField] private TMP_Text txt_RedCoins;
    [SerializeField] private TMP_Text txt_YellowCoins;
    [Space]
    [SerializeField] private TMP_Text txt_CountItemsInventory;
    //[SerializeField] private TMP_Text txt_CountItemsInventory;
    [SerializeField] private Button btn_Inventory;
    [SerializeField] private ScrollRect scrollRect_Inventory;
    [SerializeField] private ViewItem prefabViewItem;
    [Space]
    [SerializeField] private TMP_Text txt_LevelSickle;

    private void Awake()
    {
        btn_Inventory.onClick.AddListener(OpenOrCloseInventory);
    }
    private void Start()
    {
        Player.local.EventChangeRedCoins.AddListener(SetRedCoins);
        Player.local.EventChangeYellowCoins.AddListener(SetYellowCoins);

        Player.local.character.inventory.EventChangeLevel.AddListener(RefreshInventory);
        Player.local.character.inventory.EventRemoveItem.AddListener(RemoveItemFromInventory);
        Player.local.character.inventory.EventAddItem.AddListener(AddItemToInventory);

        Player.local.character.sickle.EventChangeLevel.AddListener(RefreshSickle);

        RefreshInventory();
        RefreshSickle();
    }
    private void OpenOrCloseInventory()
    {
        bool value = !scrollRect_Inventory.gameObject.activeSelf;
        scrollRect_Inventory.gameObject.SetActive(value);
    }
    private void SetRedCoins(int value)
    {
        txt_RedCoins.text = value.ToString();
    }
    private void SetYellowCoins(int value)
    {
        txt_YellowCoins.text = value.ToString();
    }
    private void RefreshSickle()
    {
        var sickle = Player.local.character.sickle;
        txt_LevelSickle.text = sickle.Level.ToString();
    }
    private void AddItemToInventory(Item item)
    {
        var view = Instantiate(prefabViewItem, scrollRect_Inventory.content, false);
        view.Init(item);

        RefreshInventory();
    }
    private void RemoveItemFromInventory(int index)
    {
        var view = scrollRect_Inventory.content.GetChild(index).gameObject;
        Destroy(view);

        RefreshInventory();
    }
    private void RefreshInventory()
    {
        var inventory = Player.local.character.inventory;
        string str = inventory.CountItems + "/" + inventory.MaxCapacity;
        txt_CountItemsInventory.text = str;
    }
}