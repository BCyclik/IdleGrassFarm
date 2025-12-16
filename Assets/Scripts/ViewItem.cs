using UnityEngine;
using UnityEngine.UI;

public class ViewItem : MonoBehaviour
{
    [SerializeField] private Image image;

    public void Init(Item item)
    {
        image.sprite = item.Icon;
    } 
}