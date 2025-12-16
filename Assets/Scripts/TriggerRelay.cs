using UnityEngine.Events;
using UnityEngine;

public class TriggerRelay : MonoBehaviour
{
    [SerializeField] private string Tag;
    [SerializeField] public UnityEvent<Collider> EventOnTriggerEnter;
    [SerializeField] public UnityEvent<Collider> EventOnTriggerStay;
    [SerializeField] public UnityEvent<Collider> EventOnTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(Tag) && !other.CompareTag(Tag)) return;

        EventOnTriggerEnter?.Invoke(other);
    }
    private void OnTriggerStay(Collider other)
    {
        if (!string.IsNullOrEmpty(Tag) && !other.CompareTag(Tag)) return;

        EventOnTriggerStay?.Invoke(other);
    }
    private void OnTriggerExit(Collider other)
    {
        if (!string.IsNullOrEmpty(Tag) && !other.CompareTag(Tag)) return;

        EventOnTriggerExit?.Invoke(other);
    }
}
