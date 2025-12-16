using UnityEngine;

public class Grass : MonoBehaviour
{
    public FarmerField controller { get; set; }
    //private Item item {get; set;}

    [SerializeField] private GameObject obj_Full;
    [SerializeField] private GameObject obj_Low;
    [SerializeField] private bool growing = false;
    public bool Growing
    {
        get => growing;
        set
        {
            growing = value;
            obj_Low.SetActive(value);
            obj_Full.SetActive(!value);
            GetComponent<Collider>().enabled = !value;
        }
    }
    private float timer = 0;
    // public void Init(FarmerField controller)
    // {

    // }
    public void Cut(Character character)
    {
        if (Growing) return;

        bool result = character.inventory.AddItem(controller.item);
        if (!result) return;

        timer = controller.GetDelay();
        Growing = true;
    }
    private void Update()
    {
        if (!Growing) return;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            GrewUp();
        }
    }
    private void GrewUp()
    {
        Growing = false;
    }
}