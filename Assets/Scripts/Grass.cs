using UnityEngine;

public class Grass : MonoBehaviour
{
    public FarmerField controller {get; set;}
    //private Item item {get; set;}

    [SerializeField] private bool growing = false;
    public bool Growing => growing;
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
        growing = true;
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
        growing = false;
    }
}