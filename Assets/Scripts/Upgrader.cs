using UnityEngine;
using TMPro;

public abstract class Upgrader : MonoBehaviour
{
    [SerializeField] private float TimeUpgrade = 1;
    [SerializeField] protected int Gain = 1;
    [Space]
    [SerializeField] private TMP_Text txt_RedCoin;
    [SerializeField] private TMP_Text txt_YellowCoin;
    private float timer = 0;
    private void Start()
    {
        RefreshCost();
    }
    private void RefreshCost() // очень костыльно
    {
        txt_RedCoin.text = GetCostRed(Player.local).ToString();
        txt_YellowCoin.text = GetCostYellow(Player.local).ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        timer = TimeUpgrade;
        //if (!other.TryGetComponent<Player>(out var player)) return;
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.TryGetComponent<Player>(out var player)) return;
        if (!IsCurrency(player)) return;
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Upgrade(player);
            timer = TimeUpgrade;

            RefreshCost();
            player.character.LevelUp();
        }
    }
    protected abstract bool IsCurrency(Player player);
    protected abstract void Upgrade(Player player);
    protected abstract int GetCostRed(Player player);
    protected abstract int GetCostYellow(Player player);
}