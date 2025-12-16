using UnityEngine;

public abstract class Upgrader : MonoBehaviour
{
    [SerializeField] private float TimeUpgrade = 1;
    [SerializeField] protected int Gain = 1;
    private float timer = 0;
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
        }
    }
    protected abstract bool IsCurrency(Player player);
    protected abstract void Upgrade(Player player);
}