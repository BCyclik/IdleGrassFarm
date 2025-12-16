using UnityEngine.AI;
using UnityEngine;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class Client : MonoBehaviour
{
    public NavMeshAgent navMeshAgent => GetComponent<NavMeshAgent>();
    [SerializeField] private Transform Hand;
    [Space]
    [SerializeField] private Transform Target;
    public void SetTarget(Transform target)
    {
        Target = target;
    }
    private void Update()
    {
        if (Target == null) return;

        navMeshAgent.SetDestination(Target.position);
    }
    public void ReceiveOrder(Item item)
    {
        var obj = Instantiate(item.Obj, Hand, false);

        Target = ClientSystem.EndPoint;

        Destroy(gameObject, 3f);
    }
}