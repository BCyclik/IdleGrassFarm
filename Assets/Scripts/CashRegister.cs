using System.Collections.Generic;
using UnityEngine;

public class CashRegister : MonoBehaviour
{
    [SerializeField] private Transform Point;
    [SerializeField] private float MinDistanceClient = 1;
    [Space]
    [SerializeField] private TriggerRelay trigger;
    private void Awake()
    {
        trigger.EventOnTriggerStay.AddListener(PlaceOrder);
    }
    public void PlaceOrder(Collider other) // замудрил функцию...
    {
        if (!other.TryGetComponent<Player>(out var player)) return;
        var character = player.character;

        if (character.inventory.IsEmpty) return;

        var client = QueueCustomers[0];
        float dist = Vector3.Distance(client.transform.position, Point.position);
        if (dist > MinDistanceClient) return;

        var item = character.inventory.GetLastItem();
        client.ReceiveOrder(item);

        player.YellowCoins += item.PriceYellowCoins;
        player.RedCoins += item.PriceRedCoins;
        character.Wave(); // для красоты

        QueueCustomers.RemoveAt(0);
        RefreshQueue();
    }
    private void RefreshQueue()
    {
        for(int i = 1; i < QueueCustomers.Count; i++)
        {
            var target = QueueCustomers[i - 1].transform;

            QueueCustomers[i].SetTarget(target);
        }

        QueueCustomers[0].SetTarget(Point);
    }
    [Space]
    [SerializeField] private List<Client> QueueCustomers = new();
    public int CountCustomersQueue => QueueCustomers.Count;
    public void GetInLine(Client client)
    {
        QueueCustomers.Add(client);

        var target = Point;
        if (QueueCustomers.Count > 1) target = QueueCustomers[^2].transform;
        
        client.SetTarget(target);
    }
}