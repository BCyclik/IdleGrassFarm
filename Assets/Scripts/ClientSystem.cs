using UnityEngine;

public class ClientSystem : MonoBehaviour
{
    private static ClientSystem instance = null;
    public static ClientSystem Instance
    {
        get
        {
            if (instance == null) instance = FindAnyObjectByType<ClientSystem>();
            return instance;
        }
    }
    public static Transform EndPoint => Instance.endPoint;
    [SerializeField] private Client prefabClient;
    [SerializeField] private Transform pointSpawn;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float delayNewClient = 1;
    [SerializeField] private int maxClients = 8;
    [Space]
    [SerializeField] private CashRegister cashRegister;
    private float timer = 0;
    private void Update()
    {
        if (cashRegister.CountCustomersQueue >= maxClients) return;
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = delayNewClient;
            SpawnNewClient();
        }
    }
    private void SpawnNewClient()
    {
        var client = Instantiate(prefabClient, pointSpawn.position, pointSpawn.rotation);
        cashRegister.GetInLine(client);
    }
}